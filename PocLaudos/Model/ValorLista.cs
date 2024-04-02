namespace PocLaudos.Model;

public class ValorLista : BaseSemNome
{
    public Guid LaudoPericialId { get; set; }
    public LaudoPericial? LaudoPericial { get; set; }
    public Guid ClassificadorCampoId { get; set; }
    public ClassificadorCampo? ClassificadorCampo { get; set; }
    public Guid ItemListaId { get; set; }
    public ItemLista? ItemLista { get; set; }
}
public class ValorListaValidator : AbstractValidator<ValorLista>
{
    public ValorListaValidator()
    {
        RuleFor(x => x.LaudoPericialId).NotEmpty().WithMessage("LaudoPericialId inválido");
        RuleFor(x => x.ClassificadorCampoId).NotEmpty().WithMessage("ClassificadorCampoId inválido");
        RuleFor(x => x.ItemListaId).NotEmpty().WithMessage("ItemListaId inválido");
    }
}