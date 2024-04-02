namespace PocLaudos;

public class ImportaDb(Db db)
{
    private Db Db { get; set; } = db;

    public async Task ImportaTudo()
    {
        if ((await Db.Database.GetPendingMigrationsAsync()).Any())
        {
            await Db.Database.MigrateAsync();
        }
        await ImportaTipoClassificadorCampo();
        await ImportaClassificadorCampo();
        await ImportaEspecie();
    }
    private async Task ImportaClassificadorCampo()
    {
        if (Db.ClassificadorCampo.Any()) return;
        await Db.AddRangeAsync(ClassificadorCampo.CargaInicial());
        await Db.SaveChangesAsync();
    }
    private async Task ImportaEspecie()
    {
        if (Db.Especie.Any()) return;
        await Db.AddRangeAsync(Especie.CargaInicial());
        await Db.SaveChangesAsync();
    }
    private async Task ImportaTipoClassificadorCampo()
    {
        if (Db.TipoClassificadorCampo.Any()) return;
        await Db.AddRangeAsync(TipoClassificadorCampo.CargaInicial());
        await Db.SaveChangesAsync();
    }
}
