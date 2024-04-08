using System.ComponentModel.DataAnnotations.Schema;

namespace PocLaudos.Model;

public class CampoListaDetalhada : Campo
{
    public virtual List<ItemLista> Itens { get; set; } = new();
    public bool MultiplosValores { get; set; }
    [NotMapped] public Guid Valor { get; set; }
    [NotMapped] public string Detalhamento { get; set; } = "";
    public string Desc => "Lista Detalhada";
}
public class CampoListaDetalhadaValidator : AbstractValidator<CampoListaDetalhada>
{
    public CampoListaDetalhadaValidator()
    {
        RuleFor(x => x.ClassificadorCampoId).NotNull().WithMessage("ClassificadorCampo inválido");
        RuleFor(x => x.Itens).NotEmpty().WithMessage("Itens inválidos");
    }
}