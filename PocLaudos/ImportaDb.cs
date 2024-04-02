namespace PocLaudos;

public class ImportaDb(Db db)
{
    private Db Db { get; set; } = db;

    public async Task ImportaTudo()
    {
        if((await Db.Database.GetPendingMigrationsAsync()).Any())
        {
            await Db.Database.MigrateAsync();
        }
        await ImportaTipoClassificadorCampo();
    }


    private async Task ImportaTipoClassificadorCampo()
    {
        if (Db.TipoClassificadorCampo.Any()) return;
        Db.Add(new TipoClassificadorCampo() { Nome = "Lista", Id=TipoClassificadorCampo.ListaId });
        Db.Add(new TipoClassificadorCampo() { Nome = "Decimal", Id = TipoClassificadorCampo.DecimalId});
        Db.Add(new TipoClassificadorCampo() { Nome = "Data", Id = TipoClassificadorCampo.DataId });
        await Db.SaveChangesAsync();
    }
}
