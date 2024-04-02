namespace PocLaudos.Model;

public class ClassificadorCampo :Base
{
    public Guid TipoClassificadorCampoId { get; set; }
    public TipoClassificadorCampo? TipoClassificadorCampo { get; set; }
}
public class ClassificadorCampoValidator : AbstractValidator<ClassificadorCampo>
{
    public ClassificadorCampoValidator()
    {
        RuleFor(x => x.Nome).NotEmpty().WithMessage("Nome inválido");
        RuleFor(x => x.TipoClassificadorCampoId).NotEmpty().WithMessage("TipoClassificadorCampo inválido");
    }

}
