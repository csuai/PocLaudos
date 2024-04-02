using FluentValidation;

using System.ComponentModel.DataAnnotations.Schema;

namespace PocLaudos.Components.Pages;

public partial class ClassificadorCampoPg
{
    public int Id { get; set; }
    [MaxLength(100)]
    public string Nome { get; set; } = "";
    [NotMapped] public Guid Identificador { get; set; } = Guid.NewGuid();
    private bool Carregando { get; set; } = true;
    public ClassificadorCampo Model { get; set; } = new();
    public List<ClassificadorCampo> Lista { get; set; } = new();
    public List<TipoClassificadorCampo> Tipos { get; set; } = new();
    [Inject] public Db Db { get; set; } = null!;
    [Inject] public INotifica Notifica { get; set; } = null!;
    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        Lista = await Db.ClassificadorCampo.Include(d => d.TipoClassificadorCampo).OrderBy(d => d.Nome).AsNoTracking().ToListAsync();
        Tipos = await Db.TipoClassificadorCampo.AsNoTracking().OrderBy(d => d.Nome).ToListAsync();
        Tipos.Add(new TipoClassificadorCampo(){ Id = Guid.Empty, Nome = "" });
        Tipos = Tipos.OrderBy(d => d.Nome).ToList();
        Carregando = false;
        StateHasChanged();
    }
    private async Task Submit()
    {
        var r = await new ClassificadorCampoValidator().ValidateAsync(Model);
        if (r.IsValid)
        {
            Db.Add(Model);
            await Db.SaveChangesAsync();
            Model.TipoClassificadorCampo = Tipos.Single(d => d.Id == Model.TipoClassificadorCampoId);
            Lista.Add(Model);
            Lista = Lista.OrderBy(d => d.Nome).ToList();
            Model = new();
            StateHasChanged();
        }
        else
        {
            Notifica.Alerta(r.Errors);
        }

    }
}
