using System.ComponentModel.DataAnnotations.Schema;

namespace PocLaudos.Model;

public class ModeloLaudo:Base
{
    public Guid EspecieId { get; set; }
    public Especie? Especie { get; set; }

    public virtual List<CampoData> CampoData { get; set; } = new();
    public virtual List<CampoDecimal> CampoDecimal { get; set; } = new();
    public virtual List<CampoLista> CampoLista { get; set; } = new();
    public virtual List<CampoTexto> CampoTextos { get; set; } = new();

    public int TotalCampos => CampoTextos.Count;
    [NotMapped] public int Fav { get; set; }
    [NotMapped] public string InvolucroInicial { get; set; } = "";
    [NotMapped] public string InvolucroFinal { get; set; } = "";
}
public class ModeloLaudoValidator : AbstractValidator<ModeloLaudo>
{
    public ModeloLaudoValidator()
    {
        RuleFor(x => x.Nome).NotEmpty().WithMessage("Nome inválido");
        RuleFor(x => x.Especie).NotNull().WithMessage("Espécie inválida");
        RuleFor(x => x.TotalCampos).GreaterThan(0).WithMessage("CampoTextos inválido");
    }

}