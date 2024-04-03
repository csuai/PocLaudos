using Microsoft.AspNetCore.Components.Web;

using PocLaudos.Dialogos;

namespace PocLaudos.Components.Pages;

public partial class EditaModeloLaudo
{
    private bool mostraFav = false;
    public string InvolucroInicial { get; set; } = "";
    public string InvolucroFinal { get; set; } = "";
    public int Fav { get; set; }
    private ModeloLaudoValidator Validator { get; set; } = new();
    public Especie? Especie
    {
        get
        {
            return Model.Especie;
        }
        set
        {
            Model.Especie = value;
            if (Model.Especie != null)
            {
                mostraFav = Model.Especie.Fav;
                Model.EspecieId = Model.Especie.Id;
                StateHasChanged();
            }

        }
    }
    public ModeloLaudo Model { get; set; } = new();
    private List<Especie> Especies { get; set; } = new();
    private List<ClassificadorCampo> ClassificadoresCampo { get; set; } = new();
    [Inject] private ClipboardService ClipboardService { get; set; } = null!;
    [Inject] private IDialogService DialogService { get; set; } = null!;
    [Inject] private Db Db { get; set; } = null!;
    [Inject] private INotifica Notifica { get; set; } = null!;
    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        Especies = await Db.Especie.ToListAsync();
        ClassificadoresCampo = await Db.ClassificadorCampo.ToListAsync();
        StateHasChanged();
    }
    private async Task AbreDialogoTexto(MouseEventArgs obj)
    {
        var c = new CampoTexto() { Identificador = $"CTT-{Model.CampoTextos.Count}" };
        await AbreDialogoTexto(c);
    }
    private async Task AbreDialogoTexto(CampoTexto campo)
    {
        try
        {
            var parameters = new DialogParameters()
            {
                {"Campo", campo}
            };
            var options = new DialogOptions() { Position = DialogPosition.Center, };
            var dialog = await DialogService.ShowAsync<CampoTextoDialogo>("Campo CampoTexto", parameters, options);
            var result = await dialog.Result;
            if (result is { Canceled: false })
            {
                var salvo = (CampoTexto)result.Data;
                if (Model.CampoTextos.Any(d => d.Identificador == salvo.Identificador))
                {
                    var achou = Model.CampoTextos.First(d => d.Identificador == salvo.Identificador);
                    Model.CampoTextos.Remove(achou);
                }

                Model.CampoTextos.Add((CampoTexto)result.Data);
            }

        }
        catch (Exception ex)
        {
            Notifica.Erro($"Erro em adicionar o campo: {ex.Message}");
        }
    }

    private void ApagaCampoTexto(CampoTexto campo)
    {
        Model.CampoTextos.Remove(campo);
    }
    private void UpCampoTexto(CampoTexto campo)
    {
        var indice = Model.CampoTextos.IndexOf(campo);
        if (indice <= 0) return;
        Model.CampoTextos.Remove(campo);
        Model.CampoTextos.Insert(indice - 1, campo);
    }
    private void DownCampoTexto(CampoTexto campo)
    {
        var indice = Model.CampoTextos.IndexOf(campo);
        if (indice == Model.CampoTextos.Count - 1) return;
        Model.CampoTextos.Remove(campo);
        Model.CampoTextos.Insert(indice + 1, campo);
    }

    private async Task AbreDialogoDecimal(MouseEventArgs obj)
    {
        var c = new CampoDecimal() { Identificador = $"CDE-{Model.CampoDecimal.Count}" };
        await AbreDialogoDecimal(c);
    }
    private async Task AbreDialogoDecimal(CampoDecimal campo)
    {
        try
        {

            var options = new DialogOptions() { Position = DialogPosition.Center, };


            var parameters = new DialogParameters()
            {
                { "ClassificadoresCampo", ClassificadoresCampo },
                {"Campo", campo}
            };
            var dialog = await DialogService.ShowAsync<CampoDecimalDialogo>("Campo PontoFlutuante", parameters, options);
            var result = await dialog.Result;
            if (result is { Canceled: false })
            {
                var salvo = (CampoDecimal)result.Data;
                salvo.ClassificadorCampo = ClassificadoresCampo.Single(d => d.Id == campo.ClassificadorCampoId);
                if (Model.CampoDecimal.Any(d => d.Identificador == salvo.Identificador))
                {
                    Model.CampoDecimal.Remove(Model.CampoDecimal.First(d => d.Identificador == salvo.Identificador));
                }
                Model.CampoDecimal.Add((CampoDecimal)result.Data);
            }

        }
        catch (Exception ex)
        {
            Notifica.Erro($"Erro em adicionar o campo: {ex.Message}");
        }


    }
    private void ApagaCampoDecimal(CampoDecimal campo)
    {
        Model.CampoDecimal.Remove(campo);
    }

    private async Task AbreDialogoData(MouseEventArgs obj)
    {
        var c = new CampoData() { Identificador = $"CDT-{Model.CampoData.Count}" };
        await AbreDialogoData(c);
    }
    private async Task AbreDialogoData(CampoData campo)
    {
        try
        {

            var options = new DialogOptions() { Position = DialogPosition.Center, };


            var parameters = new DialogParameters()
            {
                { "ClassificadoresCampo", ClassificadoresCampo },
                {"Campo", campo}
            };
            var dialog = await DialogService.ShowAsync<CampoDataDialogo>("Campo Data", parameters, options);
            var result = await dialog.Result;
            if (result is { Canceled: false })
            {
                var salvo = (CampoData)result.Data;
                salvo.ClassificadorCampo = ClassificadoresCampo.Single(d => d.Id == campo.ClassificadorCampoId);
                if (Model.CampoData.Any(d => d.Identificador == salvo.Identificador))
                {
                    Model.CampoData.Remove(Model.CampoData.First(d => d.Identificador == salvo.Identificador));
                }
                Model.CampoData.Add((CampoData)result.Data);
            }

        }
        catch (Exception ex)
        {
            Notifica.Erro($"Erro em adicionar o campo: {ex.Message}");
        }
    }
    private void ApagaCampoData(CampoData campo)
    {
        Model.CampoData.Remove(campo);
    }
    private async Task AbreDialogoLista(MouseEventArgs obj)
    {
        var c = new CampoLista() { Identificador = $"CLS-{Model.CampoTextos.Count}" };
        await AbreDialogoLista(c);
    }
    private async Task AbreDialogoLista(CampoLista campo)
    {
        try
        {
            var options = new DialogOptions() { Position = DialogPosition.Center, };

            var parameters = new DialogParameters()
            {
                { "ClassificadoresCampo", ClassificadoresCampo },
                {"Campo", campo}
            };
            var dialog = await DialogService.ShowAsync<CampoListaDialogo>("Campo Lista", parameters, options);
            var result = await dialog.Result;
            if (result is { Canceled: false })
            {
                var salvo = (CampoLista)result.Data;
                salvo.ClassificadorCampo = ClassificadoresCampo.Single(d => d.Id == campo.ClassificadorCampoId);
                if (Model.CampoLista.Any(d => d.Identificador == salvo.Identificador))
                {
                    Model.CampoLista.Remove(Model.CampoLista.First(d => d.Identificador == salvo.Identificador));
                }
                Model.CampoLista.Add((CampoLista)result.Data);
            }

        }
        catch (Exception ex)
        {
            Notifica.Erro($"Erro em adicionar o campo: {ex.Message}");
        }


    }
    private void ApagaCampoLista(CampoLista campo)
    {
        Model.CampoLista.Remove(campo);
    }

    private async Task Submit()
    {
        try
        {
            var r = await new ModeloLaudoValidator().ValidateAsync(Model);
            if (!r.IsValid)
            {
                Notifica.Alerta(r.Errors);
                return;
            }
            foreach (var campoTexto in Model.CampoTextos)
            {
                foreach (var campo in Model.CampoData)
                {
                    campoTexto.Texto = campo.SubstituiIdentificadorId(campoTexto.Texto);
                    campo.ClassificadorCampo = null;

                }
                foreach (var campo in Model.CampoLista)
                {
                    campoTexto.Texto = campo.SubstituiIdentificadorId(campoTexto.Texto);
                    campo.ClassificadorCampo = null;
                }
                foreach (var campo in Model.CampoDecimal)
                {
                    campoTexto.Texto = campo.SubstituiIdentificadorId(campoTexto.Texto);
                    campo.ClassificadorCampo = null;
                }
            }
            await Db.AddAsync(Model);

            await Db.SaveChangesAsync();
            Model = new ModeloLaudo();
            Notifica.Sucesso("Modelo Salvo");
            StateHasChanged();
        }
        catch (Exception ex)
        {
            Notifica.Erro(ex);
        }
    }
    async Task CopyToClipboard(string msg)
    {
        // Writing to the clipboard may be denied, so you must handle the exception
        try
        {
            await ClipboardService.WriteTextAsync(msg);
        }
        catch
        {
            Console.WriteLine("Cannot write text to clipboard");
        }
    }
    string CpFav()
    {
        return "<%fav%>";
    }
    string CpInvolucroInicial()
    {
        return "<%InvolucroInicial%>";
    }
    string CpInvolucroFinal()
    {
        return "<%InvolucroFinal%>";
    }
    async Task CopyToClipboard(Campo campo)
    {
        try
        {
            await ClipboardService.WriteTextAsync($"<%{campo.Identificador}%>");
        }
        catch
        {
            Notifica.Erro("Problema em copiar para o clipboard");

        }
    }

}