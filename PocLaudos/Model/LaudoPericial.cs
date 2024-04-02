namespace PocLaudos.Model;

public class LaudoPericial:BaseSemNome
{
    public int Numero { get; set; }
    public Guid ModeloLaudoId { get; set; }
    public ModeloLaudo? ModeloLaudo { get; set; }
    public LaudoPericial()
    {
        var rnd = new Random();
        Numero = rnd.Next(100000000, 999999999);
    }
}
