namespace PocLaudos.Model;

public class ValorDecimal: ValorCampoLaudo
{
    public double? Valor { get; set; }
}
public class ValorDecimalValidator: AbstractValidator<ValorDecimal>
{
    public ValorDecimalValidator()
    {
        RuleFor(x => x.LaudoPericialId).NotEmpty().WithMessage("LaudoPericialId inválido");
        RuleFor(x => x.ClassificadorCampoId).NotEmpty().WithMessage("ClassificadorCampoId inválido");
        RuleFor(x => x.Valor).NotNull().WithMessage("Valor inválido");
    }
}