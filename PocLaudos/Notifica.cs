using System.Text;

namespace PocLaudos;

public class Notifica(ISnackbar snackbar) : INotifica
{
    ISnackbar Snackbar { get; set; } = snackbar;

    public void Sucesso(string msg)
    {
        Snackbar.Add(msg, MudBlazor.Severity.Success);
        Console.WriteLine($"Sucesso: {msg}");
    }
    public void Info(string msg)
    {
        Snackbar.Add(msg, MudBlazor.Severity.Info);
        Console.WriteLine($"Info: {msg}");
    }
    public void Alerta(string msg)
    {
        Snackbar.Add(msg, MudBlazor.Severity.Warning);
        Console.WriteLine($"Alerta: {msg}");
    }
    public void Alerta(List<FluentValidation.Results.ValidationFailure> erros)
    {
        var sb = new StringBuilder();
        sb.AppendLine("Ocorreram os seguintes erros de validação:");
        foreach (var erro in erros)
        {
            sb.AppendLine(erro.ToString());
        }
        var msg = sb.ToString();
        Snackbar.Add(msg, MudBlazor.Severity.Warning);
        Console.WriteLine($"Alerta: {msg}");
    }
    public void Erro(string msg)
    {
        Snackbar.Add($"{msg}", MudBlazor.Severity.Error);
        Console.WriteLine($"Erro: {msg}");
    }

    public void Erro(Exception ex)
    {
        Snackbar.Add($"{ex.Message}", MudBlazor.Severity.Error);
        Console.WriteLine($"Erro: {ex.Message}");
    }

    public void Erro(Exception ex, string metodo)
    {
        Snackbar.Add($"Erro ocorrido no método {metodo}: {ex.Message}", MudBlazor.Severity.Error);
        Console.WriteLine($"Erro método {metodo}: {ex.Message}");
    }
}
public interface INotifica
{
    void Alerta(string msg);
    void Erro(string msg);
    void Erro(Exception ex);
    void Erro(Exception ex, string metodo);
    void Info(string msg);
    void Sucesso(string msg);
    void Alerta(List<FluentValidation.Results.ValidationFailure> erros);
}