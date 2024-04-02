namespace PocLaudos.Model;

public class CampoTexto: CampoBase
{
    public string Titulo { get; set; } = "";
    public string Texto { get; set; } = "";
}
public class CampoTextoValidator : AbstractValidator<CampoTexto>
{
    public CampoTextoValidator()
    {
        RuleFor(x => x.Texto).NotEmpty().WithMessage("CampoTexto inválido");
    }

}