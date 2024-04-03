namespace PocLaudos.Model;

public class ValorLista : ValorCampoLaudo
{
    public string Valor { get; set; } = "";
}
public class ValorListaValidator : AbstractValidator<ValorLista>
{
    public ValorListaValidator()
    {
        RuleFor(x => x.LaudoPericialId).NotEmpty().WithMessage("LaudoPericialId inválido");
        RuleFor(x => x.ClassificadorCampoId).NotEmpty().WithMessage("ClassificadorCampoId inválido");
        RuleFor(x => x.Valor).NotEmpty().WithMessage("Valor inválido");
    }
}