namespace PocLaudos;

public class Db(DbContextOptions<Db> options) : DbContext(options)
{
    public DbSet<ItemLista> ItemLista { get; init; } = null!;
    public DbSet<TipoClassificadorCampo> TipoClassificadorCampo { get; init; } = null!;
    public DbSet<ClassificadorCampo> ClassificadorCampo { get; init; } = null!;
    public DbSet<CampoTexto> Texto { get; init; } = null!;
    public DbSet<CampoLista> Lista { get; init; } = null!;
    public DbSet<CampoListaDetalhada> CampoListaDetalhada { get; init; } = null!;
    public DbSet<CampoDecimal> CampoDecimal { get; init; } = null!;
    public DbSet<CampoData> Data { get; init; } = null!;
    public DbSet<ModeloLaudo> ModeloLaudo { get; init; } = null!;
    public DbSet<Especie> Especie { get; init; } = null!;
    public DbSet<LaudoPericial> LaudoPericial { get; init; } = null!;
    public DbSet<ValorLista> ValorLista { get; init; } = null!;
    public DbSet<ValorListaDetalhada> ValorListaDetalhada { get; init; } = null!;
    public DbSet<ValorDecimal> ValorDecimal { get; init; } = null!;
    public DbSet<ValorData> ValorData { get; init; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetProperties()).Where(p => p.ClrType == typeof(string)))
        {
            if (property.GetMaxLength() == null)
            {
                property.SetMaxLength(255);
            }
        }

        foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetProperties()).Where(p => p.ClrType == typeof(DateTime) || p.ClrType == typeof(DateTime?)))
        {
            property.SetPrecision(0);
        }

        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}