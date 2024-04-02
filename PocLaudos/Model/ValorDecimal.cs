namespace PocLaudos.Model;

public class ValorDecimal:BaseSemNome
{
    public Guid LaudoPericialId { get; set; }
    public LaudoPericial? LaudoPericial { get; set; }
    public Guid ClassificadorCampoId { get; set; }
    public ClassificadorCampo? ClassificadorCampo { get; set; }
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