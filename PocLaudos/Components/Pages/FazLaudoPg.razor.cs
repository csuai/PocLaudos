namespace PocLaudos.Components.Pages;

public partial class FazLaudoPg
{
    public ModeloLaudo? ModeloSelecionado { get; set; }
    public bool Carregando { get; set; } = true;
    public List<ModeloLaudo> Lista { get; set; } = new();
    [Inject] Db Db { get; set; } = null!;
    [Inject] INotifica Notifica { get; set; } = null!;
    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        Lista =await Db.ModeloLaudo.Include(d => d.Especie)
            .Include(d => d.CampoTextos)
            .Include(d => d.CampoDecimal).ThenInclude(d=>d.ClassificadorCampo)
            .Include(d => d.CampoData).ThenInclude(d => d.ClassificadorCampo)
            .Include(d => d.CampoLista).ThenInclude(d => d.ClassificadorCampo)
            .Include(d=>d.CampoLista).ThenInclude(d=>d.Itens)
            .AsNoTrackingWithIdentityResolution().ToListAsync();
        Carregando = false;
        StateHasChanged();
    }
    void Cancelar()
    {
        ModeloSelecionado = null;
    }
    private async Task Adicionar(CampoLista c)
    {
        if (c.Valor == Guid.Empty) 
        {
            Notifica.Alerta("Selecione a opção primeiro");
            return;
        }
        c.Selecionados.Add(c.Itens.Single(d=>d.Id==c.Valor));
        c.Valor = Guid.Empty;
        StateHasChanged();
    }

    async Task Salvar()
    {

    }
    void Apagar(ItemLista item, CampoLista c)
    {
        c.Selecionados.Remove(c.Selecionados.First(d=>d.Id==item.Id));
        StateHasChanged();
    }
}
