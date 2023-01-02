namespace PingMessenger.Core.Api.Models.AddressBook
{
    public class AddressBookListContacts
    {
        public List<Contact> Contacts {get;set;}
    }

    public class Contact 
    {
        public Guid ContactId {get;set;}
        public string Username {get;set;}
    }
}