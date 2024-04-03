namespace PocLaudos.Model;

public class ClassificadorCampo :Base
{
    public Guid TipoClassificadorCampoId { get; set; }
    public TipoClassificadorCampo? TipoClassificadorCampo { get; set; }

    public override string ToString()
    {
        if (TipoClassificadorCampo != null)
        {
            return $"{Nome} - {TipoClassificadorCampo.Nome}";
        }
        return base.ToString() ;
    }

    public static readonly Guid CalibreId = new("2249f144-4cdc-4232-8898-d6928d6ef537");
    public static readonly Guid MaconhaId = new ("6da0f0a5-36de-4b36-a6dc-6cbfabaa7ad1");
    public static readonly Guid CocainaId = new ("93eb6514-3683-4dbb-8f18-f8ee7f6e900a");
    public static readonly Guid SubstanciaTxId = new ("ad6e91c6-e131-4228-a91a-f7d1957c861f");
    public static readonly Guid MorteId = new ("e0f88bdc-1a35-4db9-b8da-931fabad6bd7");
    public static readonly Guid NascimentoId = new("f0f88bdc-1a35-4db9-b8da-931fabad6bd7");
    public static readonly Guid ResultadoPreliminarId = new("f0f54bdc-1a35-4db9-b8da-931fabad6bd7");

    public static List<ClassificadorCampo> CargaInicial()
    {
        var lista = new List<ClassificadorCampo>
        {
            new () { Nome = "Calibre", TipoClassificadorCampoId = TipoClassificadorCampo.ListaId, Id = CalibreId },
            new () { Nome = "Massa de Maconha", TipoClassificadorCampoId = TipoClassificadorCampo.DecimalId, Id = MaconhaId },
            new () { Nome = "Substância TX", TipoClassificadorCampoId = TipoClassificadorCampo.ListaId, Id = SubstanciaTxId },
            new () { Nome = "Massa de Cocaína", TipoClassificadorCampoId = TipoClassificadorCampo.DecimalId, Id = CocainaId },
            new () { Nome = "Morte", TipoClassificadorCampoId = TipoClassificadorCampo.DataId, Id = MorteId },
            new () { Nome = "Nascimento", TipoClassificadorCampoId = TipoClassificadorCampo.DataId, Id = NascimentoId },
            new () { Nome = "ResultadoPreliminar", TipoClassificadorCampoId = TipoClassificadorCampo.ListaId, Id = ResultadoPreliminarId }
        };
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
