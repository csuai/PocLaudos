using static MudBlazor.CategoryTypes;

namespace PocLaudos.Components.Pages;

public partial class EspeciesPg
{
    private MudForm form = null!;
    private bool Carregando { get; set; } = true;
    private EspecieValidator Validator { get; set; } = new();
    public Especie Model { get; set; } = new();
    public List<Especie> Lista { get; set; } = new();
    [Inject] public Db Db { get; set; } = null!;
    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        Lista = await Db.Especie.OrderBy(d => d.Nome).ToListAsync();
        Carregando = false;
    }
    private async Task Submit()
    {
        await form.Validate();
        if (form.IsValid)
        {
            Db.Add(Model);
            await Db.SaveChangesAsync();
            Lista.Add(Model);
            Lista = Lista.OrderBy(d => d.Nome).ToList();
            Model = new();
            StateHasChanged();
        }
    }
}
