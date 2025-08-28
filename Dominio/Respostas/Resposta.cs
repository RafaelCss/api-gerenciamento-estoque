using Flunt.Notifications;

namespace Dominio.Respostas;

public class ErroResposta
{
    public string Campo { get; set; }
    public string Mensagem { get; set; }

    public ErroResposta(string campo, string mensagem)
    {
        Campo = campo;
        Mensagem = mensagem;
    }
}

public class Resposta<T>
{
    public T? Data { get; }
    public IReadOnlyCollection<ErroResposta> Erros { get; }
    public bool Invalid => Erros?.Count > 0;

    public Resposta(T data)
    {
        Data = data;
        Erros = Array.Empty<ErroResposta>();
    }

    public Resposta(IReadOnlyCollection<Notification> erros)
    {
        Data = default;
        Erros = MontarErros(erros);
    }
    public static List<ErroResposta> MontarErros(IReadOnlyCollection<Notification> erros)
    {
        var errosModificado = new List<ErroResposta>();
        foreach (var erro in erros)
        {
            errosModificado.Add(new ErroResposta(erro.Key, erro.Message));
        }
        return errosModificado;
    }
}
