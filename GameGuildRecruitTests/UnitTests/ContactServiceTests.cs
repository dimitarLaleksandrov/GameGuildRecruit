using GameGuildRecruit.Web.Data;
using GameGuildRecruit.Web.Services.Interfaces;
using GameGuildRecruit.Web.Services;
using Microsoft.EntityFrameworkCore;
using static GameGuildRecruit.Tests.UnitTests.DataBaseSeeder;
using  GameGuildRecruit.Tests.Mocks;
using GameGuildRecruit.Web.ViewModels.ContactPlayer;

namespace GameGuildRecruit.Tests.UnitTests
{

    [TestFixture]
    public class ContactServiceTests
    {


        private DbContextOptions<GameGuildRecruitDbContext> dbOptions;
        private GameGuildRecruitDbContext dbContext;

        private IContactService contactService;


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            dbOptions = new DbContextOptionsBuilder<GameGuildRecruitDbContext>()
               .UseInMemoryDatabase("GameGuildRecruitInMemoryDb" + Guid.NewGuid().ToString())
               .Options;

            dbContext = new GameGuildRecruitDbContext(dbOptions);

            dbContext.Database.EnsureCreated();

            SeedDataBase(dbContext);

            contactService = new ContactService(dbContext);

        }


        [Test]
        public async Task GetUserByIdAsyncShouldGetUserFromDb()
        {
            var guildUser = FakeData.GuildRecruitUsers[1];

            var result = await contactService.GetUserByIdAsync(guildUser.Id);

            Assert.That(result != null);

        }

        [Test]
        public async Task GetUserByIdAsyncShouldReturnNull()
        {
            var guildUserId = new Guid("5467F493-0FF1-420E-9284-4A1802C7D342");

            var result = await contactService.GetUserByIdAsync(guildUserId);

            Assert.That(result == null);

        }

        [Test]
        public async Task GetUserByIdAsyncShouldReturnUserProp()
        {

            var user = FakeData.GuildRecruitUserFormModel[0];

            var result = await contactService.GetUserByIdAsync(user.Id);

            Assert.That(user.Id, Is.EqualTo(result!.Id));
            Assert.That(user.NickName, Is.EqualTo(result!.NickName));
            Assert.That(user.UrlLink, Is.EqualTo(result!.UrlLink));
            Assert.That(user.GuildName, Is.EqualTo(result!.GuildName));
            Assert.That(user.ServerName, Is.EqualTo(result!.ServerName));
            Assert.That(user.GameName, Is.EqualTo(result!.GameName));
            Assert.That(user.Description, Is.EqualTo(result!.Description));
            Assert.That(user.UserName, Is.EqualTo(result!.UserName));

        }

        [Test]
        public async Task CreateContactAsyncShouldAddContactInDb()
        {
            var guildUser = FakeData.GuildRecruitUserViewModel[0];
            var contact = new ContactPlayerFormModel()
            {
                Id = new Guid("5767F493-0FF1-420E-9284-4A1802C7D342"),
                NickName = "TestName2",
                Description = "TestDescription2",
                UrlLink = "Test2",

            };

            await contactService.CreateContactAsync(contact, guildUser);

            Assert.That(dbContext.ContactPlayers.Count() == 4);

        }

        [Test]
        public async Task AddContactToUserAsyncShouldAddContactInIdentityUserContacts()
        {
            var guildUser = FakeData.GuildRecruitUserViewModel[0];
            var contact = FakeData.ContactPlayerFormModel[1];
          

            await contactService.AddContactToUserAsync(contact.Id, guildUser.Id);

            Assert.That(dbContext.IdentityUserContacts.Count() == 1);

        }

        [Test]
        public async Task GetContactByIdAsyncShouldGetContact()
        {
            var contact = FakeData.ContactPlayerFormModel[0];

            var result = await contactService.GetContactByIdAsync(contact.Id);

            Assert.That(result!.Id, Is.EqualTo(contact.Id));

        }

        [Test]
        public async Task GetContactByIdAsyncShouldReturnNull()
        {
            var contactId = new Guid("4BFC838A-EBCD-459A-B1B9-756AC08F0EFA");

            var result = await contactService.GetContactByIdAsync(contactId);

            Assert.That(result == null);

        }

        [Test]
        public async Task GetContactByIdAsyncShouldReturnContactProp()
        {

            var contact = FakeData.ContactPlayerFormModel[0];

            var result = await contactService.GetContactByIdAsync(contact.Id);

            Assert.That(contact.Id, Is.EqualTo(result!.Id));
            Assert.That(contact.NickName, Is.EqualTo(result!.NickName));
            Assert.That(contact.UrlLink, Is.EqualTo(result!.UrlLink));
            Assert.That(contact.Description, Is.EqualTo(result!.Description));

        }

        [Test]
        public async Task RemoveContactAsyncShouldRemoveContact()
        {
            var contact = FakeData.ContactPlayerViewModel[0];

            await contactService.RemoveContactAsync(contact);

            Assert.That(dbContext.ContactPlayers.Count() == 4);

        }


        [Test]
        public async Task GetUserContactsAsyncShouldGetContact()
        {
            var userId = new Guid("1D67F493-0FF1-420E-9284-4A1802C7D342");

            var contactId = new Guid("5D67F493-0FF1-420E-9284-4A1802C7D342");

            var result = await contactService.GetUserContactsAsync(userId);

            var contacts = result.ToArray();

            Assert.That(contacts[0].GuildUserId, Is.EqualTo(userId));

        }

        [Test]
        public async Task GetContactForFeedbackByIdAsyncShouldReturnContact()
        {

            var contactId = new Guid("4BFC818A-EBCD-459A-B1B9-756AC08F0EFA");

            var result = await contactService.GetContactForFeedbackByIdAsync(contactId);

            Assert.That(result!.Id == contactId);

        }

        [Test]
        public async Task GetContactForFeedbackByIdAsyncShouldReturnNull()
        {

            var contactId = new Guid("4BFC878A-EBCD-459A-B1B9-756AC08F0EFA");

            var result = await contactService.GetContactForFeedbackByIdAsync(contactId);

            Assert.That(result == null);

        }

        [Test]
        public async Task GetContactForFeedbackByIdAsyncReturnContactProp()
        {

            var contact = FakeData.ContactPlayerFormModel[0];

            var result = await contactService.GetContactForFeedbackByIdAsync(contact.Id);

            Assert.That(contact.Id, Is.EqualTo(result!.Id));
            Assert.That(contact.NickName, Is.EqualTo(result!.NickName));
            Assert.That(contact.UrlLink, Is.EqualTo(result!.UrlLink));
            Assert.That(contact.Description, Is.EqualTo(result!.Description));

        }

        [Test]
        public async Task CreateContactFeedbackShouldCreateFeedback()
        {
            var contact = FakeData.ContactPlayerFormModel[2];

            var contactId = new Guid("5D67F493-0FF1-420E-9284-4A1802C7D342");

            var contactFeedback = "TestFeedback2";

            await contactService.CreateContactFeedback(contact, contactId);

            Assert.That(contact.Feedback == contactFeedback);

        }

        [Test]
        public async Task CreateContactFeedbackShouldBeDifferentFeedback()
        {
            var contact = FakeData.ContactPlayerFormModel[1];

            var contactId = new Guid("5D67F493-0FF1-420E-9284-4A1802C7D342");

            var contactFeedback = "TestFeedback2";

            await contactService.CreateContactFeedback(contact, contactId);

            Assert.That(contact.Feedback != contactFeedback);

        }
    }
}
