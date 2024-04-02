namespace PocLaudos.Model;

public class CampoTexto: CampoBase
{
    public string Titulo { get; set; } = "";
    public string Texto { get; set; } = "";

    public void SubstituiTextoIdentificador(CampoDecimal campo)
    {
        var id = $"<%{campo.Id}%>";
        Texto = Texto.Replace(id, campo.Valor.ToString());
    }
    public void SubstituiTextoIdentificador(CampoData campo)
    {
        var id = $"<%{campo.Id}%>";
        Texto = Texto.Replace(id, campo.Valor!.Value.ToString("dd/MM/yyyy"));
    }
    public void SubstituiTextoIdentificador(CampoLista campo)
    {
        var id = $"<%{campo.Id}%>";
        if (campo.MultiplosValores)
        {
            var sb = new StringBuilder();
            foreach (var item in campo.Selecionados)
            {
                sb.AppendLine($"- {item.Nome}.");
            }
            Texto = Texto.Replace(id, sb.ToString());
        }
        else
        {
            var item = campo.Itens.Single(d => d.Id == campo.Valor);
            Texto = Texto.Replace(id, item.Nome);
        }
        
    }
}
public class CampoTextoValidator : AbstractValidator<CampoTexto>
{
    public CampoTextoValidator()
    {
        RuleFor(x => x.Texto).NotEmpty().WithMessage("CampoTexto inválido");
    }

}