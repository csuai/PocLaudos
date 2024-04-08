namespace PocLaudos.Model;

public class ValorListaDetalhada : ValorCampoLaudo
{
    public string Valor { get; set; } = "";
    public string Detalhamento { get; set; } = "";
}
public class ValorListaDetalhadaValidator : AbstractValidator<ValorListaDetalhada>
{
    public ValorListaDetalhadaValidator()
    {
        RuleFor(x => x.LaudoPericialId).NotEmpty().WithMessage("LaudoPericialId inválido");
        RuleFor(x => x.ClassificadorCampoId).NotEmpty().WithMessage("ClassificadorCampoId inválido");
        RuleFor(x => x.Valor).NotEmpty().WithMessage("Valor inválido");
        RuleFor(x => x.Detalhamento).NotEmpty().WithMessage("Detalhamento inválido");
    }
}