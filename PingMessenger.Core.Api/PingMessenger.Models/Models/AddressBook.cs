namespace PingMessenger.Models.Models
{
    public class AddressBook
    {
        public int Id { get; set; }
        public Guid OwnerId {get;set;} 
        public Guid ContactId {get;set;}

    }
}
