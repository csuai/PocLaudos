using System.ComponentModel.DataAnnotations.Schema;

namespace PocLaudos.Model;

public class CampoDecimal : Campo
{
    [NotMapped] public double Valor { get; set; }
    public string Desc => "Decimal";
}

public class CampoDecimalValidator : AbstractValidator<CampoDecimal>
{
    public CampoDecimalValidator()
    {
        RuleFor(x => x.ClassificadorCampoId).NotEmpty().WithMessage("ClassificadorCampo inválido");
    }

}