using System.ComponentModel.DataAnnotations.Schema;

namespace PocLaudos.Model;

public class Especie : Base
{
    public bool Fav { get; set; }
    public string FavSt => Fav ? "Sim" : "Não";

    public static Guid ConstatacaoId = new Guid("2249f144-4cdc-4232-8898-d6928d6ef537");
    public static Guid DefinitivoId = new Guid("6da0f0a5-36de-4b36-a6dc-6cbfabaa7ad1");
    public static Guid EficienciaArmaId = new Guid("93eb6514-3683-4dbb-8f18-f8ee7f6e900a");
    public static Guid DeterminacaoCalibreId = new Guid("ad6e91c6-e131-4228-a91a-f7d1957c861f");
    public static Guid NecropsiaId = new Guid("e0f88bdc-1a35-4db9-b8da-931fabad6bd7");

    public static List<Especie> CargaInicial()
    {
        var lista = new List<Especie>();
        lista.Add(new Especie() { Id = NecropsiaId, Nome = "Necropsia", Fav = false });
        lista.Add(new Especie() { Id = DeterminacaoCalibreId, Nome = "Determinação de Calibre", Fav = true });
        lista.Add(new Especie() { Id = EficienciaArmaId, Nome = "Eficiência de Arma de Fogo", Fav = true });
        lista.Add(new Especie() { Id = ConstatacaoId, Nome = "Constatação de Droga de Abuso", Fav = true });
        lista.Add(new Especie() { Id = DefinitivoId, Nome = "Exame Definitivo de Droga", Fav = true });
        return lista;
    }
}
public class EspecieValidator : Validador<Especie>
{
    public EspecieValidator()
    {
        RuleFor(x => x.Nome).NotEmpty().WithMessage("Nome inválido");
        RuleFor(x => x.Nome).MinimumLength(5).WithMessage("No mínimo 5 caracteres");
    }
}