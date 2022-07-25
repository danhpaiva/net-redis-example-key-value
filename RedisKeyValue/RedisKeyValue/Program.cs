using RedisKeyValue.Action;
using RedisKeyValue.Faker;
using System.Configuration;
using static System.Console;

string? connection = ConfigurationManager.AppSettings["connectionString"] ;
ClientFaker clientFaker = new();
var execute = new Execute();

try
{
    var client = clientFaker.CreateClient();
    execute.InsertClient(client, connection);
    WriteLine($"Cliente {client.Name} inserido com sucesso no redis.");
}
catch (Exception e)
{
    WriteLine($"Erro ao tentar cadastrar cliente no Redis{e}");
}

try
{
    var client = execute.GetClient("12345678910", connection);
    if (client != null)
        WriteLine($"Cliente {client.Cpf} encontrado no redis");
    else
        WriteLine("Cliente não encontrado!");
}
catch (Exception e)
{
    WriteLine($"Erro ao resgatar cliente do Redis: {e}");
}

ReadLine();