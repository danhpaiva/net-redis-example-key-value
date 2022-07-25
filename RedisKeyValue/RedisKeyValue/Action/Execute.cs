using RedisKeyValue.Model;
using ServiceStack.Redis;

namespace RedisKeyValue.Action
{
    public class Execute
    {
        public static void InsertClient(Client client, string? connection)
        {
            using (var redisClient = new RedisClient(connection))
            {
                redisClient.Set<Client>(client.Cpf, client);
            }
        }

        public static void InsertClientTemp(Client client, string? connection, TimeSpan timeSpan)
        {
            using (var redisClient = new RedisClient(connection))
            {
                redisClient.Set<Client>(client.Cpf, client, timeSpan);
            }
        }

        public static Client GetClient(string? cpf, string? connection)
        {
            using (var redisClient = new RedisClient(connection))
            {
                return redisClient.Get<Client>(cpf);
            }
        }
    }
}
