namespace PocLaudos.Model;

public class LaudoPericial:BaseSemNome
{
    public int Numero { get; set; }
    public DateTime Emissao { get; set; }=DateTime.UtcNow;
    public Guid ModeloLaudoId { get; set; }
    public ModeloLaudo? ModeloLaudo { get; set; }
    public virtual List<ValorData> ValorData { get; set; } = new();
    public virtual List<ValorDecimal> ValorDecimal { get; set; } = new();
    public virtual List<ValorLista> ValorLista { get; set; } = new();
    public LaudoPericial()
    {
        var rnd = new Random();
        Numero = rnd.Next(100000000, 999999999);
        Emissao = Emissao.AddDays(rnd.Next(-365 * 2, 0));
    }
}
