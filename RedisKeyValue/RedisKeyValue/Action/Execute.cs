using RedisKeyValue.Model;
using ServiceStack.Redis;

namespace RedisKeyValue.Action
{
    public class Execute
    {
        public void InsertClient(Client client, string connection)
        {
            using (var redisClient = new RedisClient(connection))
            {
                redisClient.Set<Client>(client.Cpf, client);
            }
        }

        public Client GetClient(string cpf, string connection)
        {
            using (var redisClient = new RedisClient(connection))
            {
                return redisClient.Get<Client>(cpf);
            }
        }
    }
}
