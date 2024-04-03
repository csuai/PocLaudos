namespace PocLaudos.Model;

public class ValorCampoLaudo : BaseSemNome
{
    public Guid LaudoPericialId { get; set; }
    public LaudoPericial? LaudoPericial { get; set; }
    public Guid ClassificadorCampoId { get; set; }
    public ClassificadorCampo? ClassificadorCampo { get; set; }
}