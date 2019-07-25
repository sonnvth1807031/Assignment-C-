namespace bank1.entity
{
    public class accBank
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int money { get; set; }
        public int status { get; set; }

        public accBank()
        {
        }

        public accBank(int id, string username, string password, int money, int status)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.money = money;
            this.status = status;
        }
    }
}