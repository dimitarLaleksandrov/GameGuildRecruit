using GameGuildRecruit.Web.Services;
using GameGuildRecruit.Web.Services.Interfaces;
using GameGuildRecruit.Web.ViewModels.ContactPlayer;
using Microsoft.AspNetCore.Mvc;

namespace GameGuildRecruit.Web.Controllers
{
    public class ContactController : BaseController
    {

        private readonly IContactService contactService;


        public ContactController(IContactService contactService)
        {
            this.contactService = contactService;

        }



        [HttpGet]
        public IActionResult AddContact(Guid id)
        {
            var contactModel = contactService.GetNewContactModelAsync();

            return View(contactModel);
        }


        [HttpPost]
        public async Task<IActionResult> AddContact(Guid id, ContactPlayerFormModel contactModel)
        {
            var user = await contactService.GetUserByIdAsync(id);

            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }

            contactModel.Id = Guid.NewGuid();

            await contactService.CreateContactAsync(contactModel, user);

            var contactId = contactModel.Id;

            var userId = user.Id;

            await contactService.AddContactToUserAsync(userId, contactId);

            return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> DeleteContact(Guid id)
        {
            var contact = await contactService.GetContactByIdAsync(id);

            if (contact == null)
            {
                return RedirectToAction("Index", "Home");
            }

            await contactService.RemoveContactAsync(contact);

            return RedirectToAction("MyContacts", "GuildUser");
        }

        [HttpPost]
        public async Task<IActionResult> UserContacts(Guid id)
        {

            var contactsModels = await contactService.GetUserContactsAsync(id);

            return View(contactsModels);
        }

        [HttpPost]
        public async Task<IActionResult> GetUserWithSameGameContactFeedback(Guid id)
        {

            var contactModel = await contactService.GetContactForFeedbackByIdAsync(id);

            return View(contactModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContactFeedback(Guid id)
        {
            var userModel = await contactService.GetContactForFeedbackByIdAsync(id);

            return View(userModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddContactFeedback(Guid id, ContactPlayerFormModel contactModel)
        {
            await contactService.CreateContactFeedback(contactModel, id);

            if (contactModel == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("MyContacts", "GuildUser");
        }

    }
}
