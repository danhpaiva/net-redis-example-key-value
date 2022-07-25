using RedisKeyValue.Action;
using RedisKeyValue.Faker;
using static System.Console;

var connection = "localhost:6379";
ClientFaker clientFaker = new();
var execute = new Execute();

try
{
    execute.InsertClient(clientFaker.CreateClient(), connection);
}
catch (Exception e)
{
    WriteLine(e);
    throw;
}

try
{
    var client = execute.GetClient("123456789101", connection);
    if (client != null)
        WriteLine(client.Cpf);
    else
        WriteLine("Cliente não encontrado!");
}
catch (Exception e)
{
    WriteLine(e);
    throw;
}

ReadLine();