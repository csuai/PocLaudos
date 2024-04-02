using System.ComponentModel.DataAnnotations.Schema;

namespace PocLaudos.Model;

public class Especie :Base
{
    public bool Fav { get; set; }
    public string FavSt => Fav ? "Sim" : "Não";
}
public class EspecieValidator : Validador<Especie>
{
    public EspecieValidator()
    {
        RuleFor(x => x.Nome).NotEmpty().WithMessage("Nome inválido");
        RuleFor(x => x.Nome).MinimumLength(5).WithMessage("No mínimo 5 caracteres");
    }
}