namespace PocLaudos.Components.Pages;

public partial class FazLaudoPg
{
    public ModeloLaudo? ModeloSelecionado { get; set; }
    public bool Carregando { get; set; } = true;
    public List<ModeloLaudo> Lista { get; set; } = new();
    [Inject] Db Db { get; set; } = null!;
    [Inject] INotifica Notifica { get; set; } = null!;
    [Inject] private IDialogService DialogService { get; set; } = null!;
    public int Fav { get; set; }
    public string InvolucroInicial { get; set; } = "";
    public string InvolucroFinal { get; set; } = "";
    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        Lista = await Db.ModeloLaudo
            .Include(d => d.Especie)
            .Include(d => d.CampoTextos)
            .Include(d => d.CampoDecimal).ThenInclude(d => d.ClassificadorCampo)
            .Include(d => d.CampoData).ThenInclude(d => d.ClassificadorCampo)
            .Include(d => d.CampoLista).ThenInclude(d => d.ClassificadorCampo)
            .Include(d => d.CampoLista).ThenInclude(d => d.Itens)
            .AsNoTrackingWithIdentityResolution().ToListAsync();
        Carregando = false;
        StateHasChanged();
    }
    void Cancelar()
    {
        ModeloSelecionado = null;
    }
    private void Adicionar(CampoLista c)
    {
        if (c.Valor == Guid.Empty)
        {
            Notifica.Alerta("Selecione a opção primeiro");
            return;
        }
        c.Selecionados.Add(c.Itens.Single(d => d.Id == c.Valor));
        c.Valor = Guid.Empty;
        StateHasChanged();
    }

    async Task Salvar()
    {
        if (ValidaFormulario() && ModeloSelecionado != null)
        {
            var l = new LaudoPericial() { ModeloLaudoId = ModeloSelecionado.Id };
            await Db.LaudoPericial.AddAsync(l);
            foreach (var campo in ModeloSelecionado.CampoData)
            {
                var dt = campo.Valor!.Value;
                await Db.ValorData.AddAsync(new ValorData()
                { ClassificadorCampoId = campo.ClassificadorCampoId, LaudoPericialId = l.Id, Valor = dt.ToUniversalTime() });
            }
            foreach (var campo in ModeloSelecionado.CampoDecimal)
            {
                await Db.ValorDecimal.AddAsync(new ValorDecimal()
                { ClassificadorCampoId = campo.ClassificadorCampoId, LaudoPericialId = l.Id, Valor = campo.Valor });
            }
            foreach (var campo in ModeloSelecionado.CampoLista)
            {
                if (campo.MultiplosValores)
                {
                    foreach (var itemLista in campo.Selecionados)
                    {
                        await Db.ValorLista.AddAsync(new ValorLista()
                        { ClassificadorCampoId = campo.ClassificadorCampoId, LaudoPericialId = l.Id, Valor = itemLista.Nome });
                    }
                }
                else
                {
                    var n = campo.Itens.Single(d => d.Id == campo.Valor);
                    await Db.ValorLista.AddAsync(new ValorLista()
                    { ClassificadorCampoId = campo.ClassificadorCampoId, LaudoPericialId = l.Id, Valor = n.Nome});
                }
            }

            await Db.SaveChangesAsync();

            foreach (var campoTexto in ModeloSelecionado.CampoTextos)
            {
                foreach (var campo in ModeloSelecionado.CampoData)
                {
                    campoTexto.SubstituiTextoIdentificador(campo);
                }
                foreach (var campo in ModeloSelecionado.CampoLista)
                {
                    campoTexto.SubstituiTextoIdentificador(campo);
                }
                foreach (var campo in ModeloSelecionado.CampoDecimal)
                {
                    campoTexto.SubstituiTextoIdentificador(campo);
                }
                campoTexto.SubstituiFavInvolucros(InvolucroInicial, InvolucroFinal, Fav);
            }

            await AbreDialogo(ModeloSelecionado.CampoTextos);
        }
    }
    private async Task AbreDialogo(List<CampoTexto> campos)
    {
        try
        {
            var parameters = new DialogParameters()
            {
                {"Campos", campos}
            };
            var options = new DialogOptions() { Position = DialogPosition.Center, };
            await DialogService.ShowAsync<LaudoPericialDialogo>("Laudo Pericial", parameters, options);
        }
        catch (Exception ex)
        {
            Notifica.Erro($"Erro em adicionar o campo: {ex.Message}");
        }
    }
    bool ValidaFormulario()
    {
        if (ModeloSelecionado == null) return false;
        var sb = new StringBuilder();
        foreach (var campoData in ModeloSelecionado.CampoData.Where(campoData => campoData.Valor == null))
        {
            sb.AppendLine($"Campo data {campoData.ClassificadorCampo!.Nome} nulo");
        }

        foreach (var campoDecimal in ModeloSelecionado.CampoDecimal.Where(campoDecimal => campoDecimal.Valor == null))
        {
            sb.AppendLine($"Campo decimal {campoDecimal.ClassificadorCampo!.Nome} nulo");
        }
        foreach (var campoLista in ModeloSelecionado.CampoLista)
        {
            if (campoLista.MultiplosValores)
            {
                if (campoLista.Selecionados.Count == 0)
                {
                    sb.AppendLine($"Campo lista {campoLista.ClassificadorCampo!.Nome} sem seleção");
                }
            }
            else
            {
                if (campoLista.Valor == Guid.Empty)
                {
                    sb.AppendLine($"Campo lista {campoLista.ClassificadorCampo!.Nome} sem seleção");
                }
            }
        }
        var msg = sb.ToString();
        if (msg.Length <= 0) return true;
        Notifica.Alerta(msg);
        return false;
    }
    void Apagar(ItemLista item, CampoLista c)
    {
        c.Selecionados.Remove(c.Selecionados.First(d => d.Id == item.Id));
        StateHasChanged();
    }
}
