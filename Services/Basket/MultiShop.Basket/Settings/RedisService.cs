using StackExchange.Redis;

namespace MultiShop.Basket.Settings
{
    public class RedisService
    {
        public string _host { get; set; }
        public int _port { get; set; }

        private ConnectionMultiplexer _connectionMultiplexer;//Redis e bağlanmamız için köprü görevi görür.
        public RedisService(string host, int port)
        {
            _host = host;
            _port = port;
        }

        public void Connect() => _connectionMultiplexer = ConnectionMultiplexer.Connect($"{_host}:{_port}");
        public IDatabase GetDb(int db = 1) => _connectionMultiplexer.GetDatabase(0);
        //parametre de ki db redis kurulduktan sonra default olarak 16 db vardır(0-15 e kadar). Bu db de hangisini
        //kullanacağını belirler.
        //Bizde GetDatabase(0) da 0.Db yi getiririz.
    }
}
