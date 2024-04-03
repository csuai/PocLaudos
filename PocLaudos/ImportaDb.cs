using PocLaudos.Model;

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
        await ImportaModelo();
        await ImportaLaudos();
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

    private async Task ImportaModelo()
    {
        if (Db.ModeloLaudo.Any()) return;
        var especies = await Db.Especie.AsNoTracking().ToListAsync();
        var constatacao = especies.Single(d => d.Id == Especie.ConstatacaoId);

        for (int i = 0; i < 4; i++)
        {
            var modelo = new ModeloLaudo
            {
                Nome = $"Maconha modelo {i}",
                EspecieId = constatacao.Id
            };
            Db.Add(modelo);

            Db.Add(CamposTexto(modelo.Id, i));

            Db.Add(CamposDecimal(modelo.Id, ClassificadorCampo.MaconhaId));

            var campoLista = new CampoLista
            {
                ClassificadorCampoId = ClassificadorCampo.ResultadoPreliminarId,
                ModeloLaudoId = modelo.Id,
            };
            Db.Add(campoLista);
            Db.AddRange(GeraItensLista(campoLista.Id));

            var modeloCocaina = new ModeloLaudo
            {
                Nome = $"Cocaina modelo {i}",
                EspecieId = constatacao.Id
            };
            Db.Add(modeloCocaina);

            Db.Add(CamposTexto(modeloCocaina.Id, i));

            Db.Add(CamposDecimal(modeloCocaina.Id, ClassificadorCampo.CocainaId));

            var campoListaCocaina = new CampoLista
            {
                ClassificadorCampoId = ClassificadorCampo.ResultadoPreliminarId,
                ModeloLaudoId = modeloCocaina.Id
            };
            Db.Add(campoListaCocaina);

            Db.AddRange(GeraItensLista(campoListaCocaina.Id));

            if (i == 3)
            {
                var campoData = new CampoData
                {
                    ClassificadorCampoId = ClassificadorCampo.NascimentoId,
                    ModeloLaudoId = modeloCocaina.Id
                };
                Db.Add(campoData);
            }
        }

        await Db.SaveChangesAsync();
    }

    CampoDecimal CamposDecimal(Guid modeloLaudoId, Guid classificadorLaudoId)
    {
        var campoDecimal = new CampoDecimal
        {
            ClassificadorCampoId = classificadorLaudoId,
            ModeloLaudoId = modeloLaudoId
        };
        return campoDecimal;
    }
    CampoTexto CamposTexto(Guid modeloLaudoId, int i)
    {
        var campoTexto = new CampoTexto
        {
            Texto = $"Maconha do campo {i}",
            Titulo = $"Maconha campo {i}",
            ModeloLaudoId = modeloLaudoId
        };
        return campoTexto;
    }
    List<ItemLista> GeraItensLista(Guid campoListaId)
    {
        var n = new List<ItemLista>
        {
            new()
            {
                CampoListaId = campoListaId,
                Nome = "Negativo"
            },
            new()
            {
                CampoListaId = campoListaId,
                Nome = "Positivo"
            }
        };
        return n;
    }

    async Task ImportaLaudos()
    {
        if (Db.LaudoPericial.Any()) return;

        var rdn = new Random();
        var modelos = await Db.ModeloLaudo
            .Include(d => d.CampoDecimal)
            .Include(d => d.CampoLista).ThenInclude(d => d.Itens)
            .Include(d => d.CampoData)
            .AsNoTracking().ToListAsync();
        foreach (var modelo in modelos)
        {
            var laudos = rdn.Next(1000, 2000);
            List<LaudoPericial> listaLaudos = new();
            List<ValorDecimal> listaDecimal = new();
            List<ValorLista> valorLista = new();
            List<ValorData> valorData = new();

            for (int i = 0; i < laudos; i++)
            {
                var lp = new LaudoPericial
                {
                    ModeloLaudoId = modelo.Id
                };
                listaLaudos.Add(lp);
                foreach (var campo in modelo.CampoLista)
                {
                    valorLista.Add(new ValorLista
                    {
                        ClassificadorCampoId = campo.ClassificadorCampoId,
                        Valor = campo.Itens[i%2].Nome,
                        LaudoPericialId = lp.Id
                    });
                    
                }
                foreach (var campo in modelo.CampoData)
                {
                    valorData.Add(new ValorData()
                    {
                        ClassificadorCampoId = campo.ClassificadorCampoId,
                        Valor = DateTime.MinValue.AddDays(i).ToUniversalTime(),
                        LaudoPericialId = lp.Id
                    });

                }
                foreach (var campoDecimal in modelo.CampoDecimal)
                {
                    var inteiro = rdn.Next(0, 500);
                    var massa = rdn.NextDouble();
                    listaDecimal.Add(new ValorDecimal()
                    {
                        ClassificadorCampoId = campoDecimal.ClassificadorCampoId,
                        Valor = massa+inteiro,
                        LaudoPericialId = lp.Id
                    });
                }
            }
            Db.AddRange(listaLaudos);
            Db.AddRange(listaDecimal);
            Db.AddRange(valorLista);
            Db.AddRange(valorData);
            await Db.SaveChangesAsync();
        }
    }

}
