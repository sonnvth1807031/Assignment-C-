namespace bank1.entity
{
    public class History
    {
        public int id { get; set; }
        public int receiverId { get; set; }
        public int senderId { get; set; }
        public int amount { get; set; }
        public string message { get; set; }
        public long createdAtMLS { get; set; }
        public Type type { get; set; }
        
        public History()
        {
        }
        public enum Type
        {
            Transfer = 1,
            Withdraw = 2,
            Deposit = 3
        }
        public History( int receiverId, int senderId, int amount, string message, Type type)
        {
            this.receiverId = receiverId;
            this.senderId = senderId;
            this.amount = amount;
            this.message = message;
            this.createdAtMLS = createdAtMLS;
            this.type = type;
        }
    }
}