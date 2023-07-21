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
        public async Task<IActionResult> AddContact(Guid id)
        {
            try
            {
                var contactModel = await contactService.GetNewContactModelAsync();

                return View(contactModel);
            }
            catch (Exception)
            {

                return RedirectToAction("AddingContactError", "Errors");
            }
           
        }


        [HttpPost]
        public async Task<IActionResult> AddContact(Guid id, ContactPlayerFormModel contactModel)
        {
            var user = await contactService.GetUserByIdAsync(id);

            if (user == null)
            {
                return RedirectToAction("GetUsersError", "Errors");
            }

            try
            {
                contactModel.Id = Guid.NewGuid();

                await contactService.CreateContactAsync(contactModel, user);

                var contactId = contactModel.Id;

                var userId = user.Id;

                await contactService.AddContactToUserAsync(userId, contactId);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {

                return RedirectToAction("AddingContactError", "Errors");

            }
        }

        
        public async Task<IActionResult> DeleteContact(Guid id)
        {
            var contact = await contactService.GetContactByIdAsync(id);

            if (contact == null)
            {
                return RedirectToAction("GetContactErrors", "Errors");
            }

            try
            {
                await contactService.RemoveContactAsync(contact);

                return RedirectToAction("MyContacts", "GuildUser");
            }
            catch (Exception)
            {
                return RedirectToAction("RemoveContactError", "Errors");
            }

        }

        [HttpPost]
        public async Task<IActionResult> UserContacts(Guid id)
        {
            try
            {
                var contactsModels = await contactService.GetUserContactsAsync(id);

                return View(contactsModels);
            }
            catch (Exception)
            {

                return RedirectToAction("GetContactError", "Errors");
            }
           
        }

        [HttpPost]
        public async Task<IActionResult> GetUserWithSameGameContactFeedback(Guid id)
        {
            try
            {
                var contactModel = await contactService.GetContactForFeedbackByIdAsync(id);

                return View(contactModel);
            }
            catch (Exception)
            {
                return RedirectToAction("GetContactError", "Errors");
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> CreateContactFeedback(Guid id)
        {
            try
            {
                var userModel = await contactService.GetContactForFeedbackByIdAsync(id);

                return View(userModel);
            }
            catch (Exception)
            {

                return RedirectToAction("GetContactError", "Errors");
            }
        }
           

        [HttpPost]
        public async Task<IActionResult> AddContactFeedback(Guid id, ContactPlayerFormModel contactModel)
        {
            await contactService.CreateContactFeedback(contactModel, id);

            if (contactModel == null)
            {
                return RedirectToAction("GetContactError", "Errors");
            }

            return RedirectToAction("MyContacts", "GuildUser");
        }

    }
}
