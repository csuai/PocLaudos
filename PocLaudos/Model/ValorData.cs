namespace PocLaudos.Model;

public class ValorData : BaseSemNome
{
    public Guid LaudoPericialId { get; set; }
    public LaudoPericial? LaudoPericial { get; set; }
    public Guid ClassificadorCampoId { get; set; }
    public ClassificadorCampo? ClassificadorCampo { get; set; }
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