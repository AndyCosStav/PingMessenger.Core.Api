using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PingMessenger.Core.Api.Models.AddressBook;
using PingMessenger.Data.Authentication;
using PingMessenger.Data.Context;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PingMessenger.Core.Api.Controllers 
{
    [Authorize]
    public class AddressBookController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly PingContext _pingContext;

        
        public AddressBookController(UserManager<IdentityUser> userManager, IConfiguration configuration, PingContext pingContext)
        {
            _userManager = userManager;
            _configuration = configuration;
            _pingContext = pingContext;
        }

        //method that returns user based on username
        [Authorize]
        [HttpPost]
        [Route("searchUser")]
        public async Task<AddressBookSearchResponse?> searchUser([FromBody] string username)
        {
            var user = await _userManager.FindByNameAsync(username);

            if(user == null){
                return null;
            }

            var userToReturn = new AddressBookSearchResponse()
            {
                UserId = Guid.Parse(user.Id),
                Username = user.UserName,
                Email = user.Email
            };

            return userToReturn; 
        }


        public class ListContactRequest
        {
            public string userId { get; set; }
        }

        [Authorize]
        [HttpPost]
        [Route("listContacts")]
        public async Task<AddressBookListContacts> listContacts([FromBody]string userID)
        {
            var ownerID = Guid.Parse(userID);
            var addressBookListContacts = new AddressBookListContacts();
            addressBookListContacts.Contacts = new List<Contact>();

            var contacts = _pingContext.AddressBook
            .Join(
            _pingContext.PingUsers,
            ab => ab.ContactId,
            pu => pu.PingUserId,
            (ab , pu ) => new {AddressBook = ab, PingUser = pu})
            .Where(o => o.AddressBook.OwnerId == ownerID)
            .ToList();

            foreach(var con in contacts)
            {
                addressBookListContacts.Contacts.Add( new Contact{ ContactId = con.AddressBook.ContactId, Username = con.PingUser.UserName});
            }

            return addressBookListContacts;
        }

        [Authorize]
        [HttpPost]
        [Route("addToAddressBook")]
        public async Task<IActionResult> addToAddressBook(Guid ownerId, Guid contactId)
        {
            var checkExisting = _pingContext.AddressBook
            .Where(o => o.OwnerId == ownerId) 
            .Where(c => c.ContactId == contactId)
            .FirstOrDefault();

            if(checkExisting != null){
                return NoContent();
            }
            _pingContext.AddressBook.Add(new PingMessenger.Models.Models.AddressBook{OwnerId = ownerId, ContactId = contactId});
            _pingContext.SaveChanges();

            return Ok();
        }


    }

}

