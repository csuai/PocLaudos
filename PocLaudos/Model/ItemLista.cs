using System.ComponentModel.DataAnnotations.Schema;

namespace PocLaudos.Model;

public class ItemLista:Base
{
    public Guid CampoListaId { get; set; }
    public CampoLista? CampoLista { get; set; }
}
public class ItemListaValidator : AbstractValidator<ItemLista>
{
    public ItemListaValidator()
    {
        RuleFor(x => x.Nome).NotEmpty().WithMessage("Nome inválido");
        RuleFor(x => x.CampoListaId).NotEmpty().WithMessage("CampoListaId inválido");
    }

}