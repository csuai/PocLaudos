using System.ComponentModel.DataAnnotations.Schema;

namespace PocLaudos.Model;

public class CampoData : Campo
{
    public string Desc => "Data";
    [NotMapped] public DateTime? Valor { get; set; }
}

public class CampoDataValidator : AbstractValidator<CampoData>
{
    public CampoDataValidator()
    {
        RuleFor(x => x.ClassificadorCampoId).NotEmpty().WithMessage("ClassificadorCampo inválido");
    }

}