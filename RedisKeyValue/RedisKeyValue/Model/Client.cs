namespace RedisKeyValue.Model
{
    public class Client
    {
        public string Cpf { get; private set; }
        public string? Name { get; set; }
        public string? Document { get; set; }

        public Client(string cpf)
        {
            Cpf = cpf;
        }
    }
}
