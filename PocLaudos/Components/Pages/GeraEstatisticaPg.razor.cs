using Microsoft.JSInterop;

using OfficeOpenXml;

namespace PocLaudos.Components.Pages;

public partial class GeraEstatisticaPg
{
    private DateRange DateRange { get; set; }=new DateRange(DateTime.UtcNow.AddYears(-2), DateTime.UtcNow);
    public List<Especie> Especies { get; set; } = new();
    [Inject] public Db Db { get; set; } = null!;
    [Inject] public INotifica Notifica { get; set; } = null!;
    [Inject] private IJSRuntime Js { get; set; } = null!;
    [Inject] private IWebHostEnvironment WebHostEnvironment { get; set; }=null!;
    public Especie? Especie { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        //Especies = await Db.Especie.AsNoTrackingWithIdentityResolution().ToListAsync();
    }

    async Task GeraEstatistica()
    {
        if (Especie == null)
        {
            Notifica.Alerta("Selecione a Especie");
            return;
        }

        var inicio = DateTime.MinValue;
        var fim = DateTime.MaxValue;
        if (DateRange.Start != null)
        {
            inicio = DateRange.Start.Value;
        }

        if (DateRange.End != null)
        {
            fim = DateRange.End.Value;
        }

        var laudos = await Db.LaudoPericial.Include(d => d.ModeloLaudo)
            .Include(d => d.ValorDecimal).ThenInclude(d => d.ClassificadorCampo)
            .Include(d => d.ValorLista).ThenInclude(d => d.ClassificadorCampo)
            .Include(d => d.ValorData).ThenInclude(d => d.ClassificadorCampo)
            .Where(d => d.ModeloLaudo!.EspecieId == Especie.Id && d.Emissao<=fim && d.Emissao>=inicio).AsNoTrackingWithIdentityResolution().ToListAsync();

        ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
        var endereco = Path.Combine(WebHostEnvironment.WebRootPath, "planilha.xlsx");
        var file = new FileInfo(endereco);
        if (file.Exists)
        {
            file.Delete();
        }
        using var package = new ExcelPackage();

        var modelos = laudos.DistinctBy(d => d.ModeloLaudoId).ToList();
        foreach (var modeloDistinct in modelos)
        {
            ModeloLaudo modelo = modeloDistinct.ModeloLaudo!;

            var laudosDoModelo = laudos.Where(d => d.ModeloLaudoId == modelo.Id).ToList();
            if (laudosDoModelo.Any())
            {
                var ws = package.Workbook.Worksheets.Add(modelo.Nome);
                var primeiro = laudosDoModelo[0];
                var dec = primeiro.ValorLista.OrderBy(d => d.ClassificadorCampo!.Nome).ToList();
                var val = primeiro.ValorDecimal.OrderBy(d => d.ClassificadorCampo!.Nome).ToList();
                var dat = primeiro.ValorData.OrderBy(d => d.ClassificadorCampo!.Nome).ToList();

                var nunDec = dec.Count;
                var numVal = val.Count;
                var numDat = dat.Count;
                int pontoPartida = 1;
                for (int i = 0; i < nunDec; i++)
                {
                    var c = dec[i];
                    ws.Cells[1, pontoPartida].Value = c.ClassificadorCampo!.Nome;
                    pontoPartida++;
                }
                for (int i = 0; i < numVal; i++)
                {
                    var c = val[i];
                    ws.Cells[1, pontoPartida].Value = c.ClassificadorCampo!.Nome;
                    pontoPartida++;
                }
                for (int i = 0; i < numDat; i++)
                {
                    var c = dat[i];
                    ws.Cells[1, pontoPartida].Value = c.ClassificadorCampo!.Nome;
                }
                for (var lps = 0; lps < laudosDoModelo.Count; lps++)
                {

                    var atual = laudosDoModelo[lps];
                    var decAtual = atual.ValorLista.OrderBy(d => d.ClassificadorCampo!.Nome).ToList();
                    var valAtual = atual.ValorDecimal.OrderBy(d => d.ClassificadorCampo!.Nome).ToList();
                    var datAtual = atual.ValorData.OrderBy(d => d.ClassificadorCampo!.Nome).ToList();

                    var nunDecdatAtual = decAtual.Count;
                    var numValdatAtual = valAtual.Count;
                    var numDatdatAtual = datAtual.Count;
                    int pontoPartidaAtual = 1;
                    for (int i = 0; i < nunDecdatAtual; i++)
                    {
                        var c = decAtual[i];
                        ws.Cells[2 + lps, pontoPartidaAtual].Value = c.Valor;
                        pontoPartidaAtual++;
                    }
                    for (int i = 0; i < numValdatAtual; i++)
                    {
                        var c = valAtual[i];
                        ws.Cells[2 + lps, pontoPartidaAtual].Value = c.Valor;
                        pontoPartidaAtual++;
                    }
                    for (int i = 0; i < numDatdatAtual; i++)
                    {
                        var c = datAtual[i];
                        var valorSt = "";
                        if (c.Valor != null)
                        {
                            valorSt = c.Valor.Value.ToString("dd/MM/yyyy HH:mm:ss");
                        }
                        ws.Cells[2 + lps, pontoPartidaAtual].Value = valorSt;
                    }
                }
            }

        }
        //await package.SaveAsync();

        var bb = await package.GetAsByteArrayAsync();

        var fileName = "Estatisticas.xlsx";
        await Js.InvokeVoidAsync("BlazorDownloadFile", fileName, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", bb);
    }
}