namespace bank1.entity
{
    public class Account
    {
        public string id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int status { get; set; }
        public Account(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    
        public Account()
        {
        }
    }
}