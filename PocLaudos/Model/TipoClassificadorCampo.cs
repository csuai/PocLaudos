namespace PocLaudos.Model;

public class TipoClassificadorCampo : Base
{
    public static Guid ListaId = new Guid("20dc207c-b5ce-4ee1-ad5a-33d5c9e7a207");
    public static Guid DecimalId = new Guid("83619b3a-ad84-4eef-94e7-a5ecedd9eea7");
    public static Guid DataId = new Guid("feafe3ec-6084-432f-b992-52f29d284e24");

    public static List<TipoClassificadorCampo>CargaInicial()
    {
        var lista = new List<TipoClassificadorCampo>();
        lista.Add(new TipoClassificadorCampo() { Nome = "Lista", Id = TipoClassificadorCampo.ListaId });
        lista.Add(new TipoClassificadorCampo() { Nome = "Decimal", Id = TipoClassificadorCampo.DecimalId });
        lista.Add(new TipoClassificadorCampo() { Nome = "Data", Id = TipoClassificadorCampo.DataId });
        return lista;
    }
}
