using System.ComponentModel.DataAnnotations.Schema;

namespace PocLaudos.Model;

public class CampoLista : Campo
{
    public virtual List<ItemLista> Itens { get; set; } = new();
    public bool MultiplosValores { get; set; }
    [NotMapped] public Guid Valor { get; set; }
    [NotMapped] public List<Guid> Valores { get; set; } = new();
    public string Desc => "Lista";
}
public class CampoListaValidator : AbstractValidator<CampoLista>
{
    public CampoListaValidator()
    {
        RuleFor(x => x.ClassificadorCampoId).NotNull().WithMessage("ClassificadorCampo inválido");
        RuleFor(x => x.Itens).NotEmpty().WithMessage("Itens inválidos");
    }

}