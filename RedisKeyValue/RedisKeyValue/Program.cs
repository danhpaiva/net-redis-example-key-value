using RedisKeyValue.Model;
using ServiceStack.Redis;

var connection = "localhost:6379";

var cpfOne = "12345678910";
var clientOne = new Client(cpfOne) { Document = "123", Name = "Paiva" };

var cpfTwo = "12345678911";
var clientTwo = new Client(cpfTwo) { Document = "456", Name = "Raphael" };

using (var redisClient = new RedisClient(connection))
{
    redisClient.Set<Client>(clientOne.Cpf.ToString(), clientOne);
    redisClient.Set<Client>(clientTwo.Cpf, clientTwo);

    var clientX = redisClient.Get<Client>(clientOne.Cpf);
}

Console.Read();