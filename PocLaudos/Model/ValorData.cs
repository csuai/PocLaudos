namespace PocLaudos.Model;

public class ValorData : ValorCampoLaudo
{
    public DateTime? Valor { get; set; }
}
public class ValorDataValidator : AbstractValidator<ValorData>
{
    public ValorDataValidator()
    {
        RuleFor(x => x.LaudoPericialId).NotEmpty().WithMessage("LaudoPericialId inválido");
        RuleFor(x => x.ClassificadorCampoId).NotEmpty().WithMessage("ClassificadorCampoId inválido");
        RuleFor(x => x.Valor).NotNull().WithMessage("Valor inválido");
    }
}