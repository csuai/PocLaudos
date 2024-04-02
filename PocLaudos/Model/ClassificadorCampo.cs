namespace PocLaudos.Model;

public class ClassificadorCampo :Base
{
    public Guid TipoClassificadorCampoId { get; set; }
    public TipoClassificadorCampo? TipoClassificadorCampo { get; set; }

    public static Guid CalibreId = new Guid("2249f144-4cdc-4232-8898-d6928d6ef537");
    public static Guid MaconhaId = new Guid("6da0f0a5-36de-4b36-a6dc-6cbfabaa7ad1");
    public static Guid CocainaId = new Guid("93eb6514-3683-4dbb-8f18-f8ee7f6e900a");
    public static Guid SubstanciaTxId = new Guid("ad6e91c6-e131-4228-a91a-f7d1957c861f");
    public static Guid MorteId = new Guid("e0f88bdc-1a35-4db9-b8da-931fabad6bd7");


    public static List<ClassificadorCampo> CargaInicial()
    {
        var lista = new List<ClassificadorCampo>();
        lista.Add(new ClassificadorCampo() { Nome = "Calibre", TipoClassificadorCampoId = TipoClassificadorCampo.ListaId, Id = CalibreId });
        lista.Add(new ClassificadorCampo() { Nome = "Massa de Maconha", TipoClassificadorCampoId = TipoClassificadorCampo.DecimalId, Id = MaconhaId });
        lista.Add(new ClassificadorCampo() { Nome = "Substância TX", TipoClassificadorCampoId = TipoClassificadorCampo.ListaId, Id = SubstanciaTxId });
        lista.Add(new ClassificadorCampo() { Nome = "Massa de Cocaína", TipoClassificadorCampoId = TipoClassificadorCampo.DecimalId, Id = CocainaId });
        lista.Add(new ClassificadorCampo() { Nome = "Morte", TipoClassificadorCampoId = TipoClassificadorCampo.DataId, Id = MorteId });
        return lista;
    }
}
public class ClassificadorCampoValidator : AbstractValidator<ClassificadorCampo>
{
    public ClassificadorCampoValidator()
    {
        RuleFor(x => x.Nome).NotEmpty().WithMessage("Nome inválido");
        RuleFor(x => x.TipoClassificadorCampoId).NotEmpty().WithMessage("TipoClassificadorCampo inválido");
    }

}
