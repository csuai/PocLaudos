using System.ComponentModel.DataAnnotations.Schema;

namespace PocLaudos.Model;

public class Base:BaseSemNome
{
    public string Nome { get; set; } = "";
}
public class BaseSemNome
{
    public Guid Id { get; set; } = Guid.NewGuid();
    [NotMapped] public string Identificador { get; set; } = Guid.NewGuid().ToString();
    public string SubstituiIdentificadorId(string txt)
    {
        var id = $"<%{Id}%>";
        var identificador = $"<%{Identificador}%>";
        var r = txt.Replace(identificador, id) ;
        return r;
    }
}
public abstract class Campo : CampoBase
{
    public Guid ClassificadorCampoId { get; set; }
    public ClassificadorCampo? ClassificadorCampo { get; set; }
}
public abstract class CampoBase:BaseSemNome
{
    public Guid ModeloLaudoId { get; set; }
    public ModeloLaudo? ModeloLaudo { get; set; }
}