using RedisKeyValue.Model;

namespace RedisKeyValue.Faker
{
    public class ClientFaker
    {
        public Client CreateClient()
        {
            return new Client() { Cpf = "12345678910", Document = "123", Name = "Paiva" };
        }

        public Client CreateClientTemp()
        {
            return new Client() { Cpf = "12345678911", Document = "123", Name = "Julia" };
        }
    }
}
