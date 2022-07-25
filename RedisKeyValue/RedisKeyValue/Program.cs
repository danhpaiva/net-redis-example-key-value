using RedisKeyValue.Action;
using RedisKeyValue.Faker;
using System.Configuration;
using static System.Console;

string? connection = ConfigurationManager.AppSettings["connectionString"] ;
ClientFaker clientFaker = new();
var execute = new Execute();

try
{
    WriteLine("Inserindo cliente no Redis...");
    var client = clientFaker.CreateClient();
    Execute.InsertClient(client, connection);
    WriteLine($"Cliente {client.Name} inserido com sucesso no redis.");
}
catch (Exception e)
{
    WriteLine($"Erro ao tentar cadastrar cliente no Redis: {e}");
}

try
{
    WriteLine("Inserindo cliente temporário no Redis...");
    var client = clientFaker.CreateClientTemp();
    Execute.InsertClientTemp(client, connection, new TimeSpan(0, 0, 30));
    WriteLine($"Cliente temporário {client.Name} inserido com sucesso no redis.");
}
catch (Exception e)
{
    WriteLine($"Erro ao tentar cadastrar cliente no Redis: {e}");
}

WriteLine("\nDigite um cpf para buscar o cliente: ");
string? cpfFind = Console.ReadLine();

try
{
    var client = Execute.GetClient(cpfFind, connection);
    if (client != null)
        WriteLine($"Cliente {client.Name} encontrado no redis.");
    else
        WriteLine($"Cliente com o cpf {cpfFind} não encontrado no Redis!");
}
catch (Exception e)
{
    WriteLine($"Erro ao resgatar cliente do Redis: {e}");
}

ReadLine();