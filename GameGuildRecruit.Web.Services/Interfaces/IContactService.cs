using GameGuildRecruit.Web.ViewModels.ContactPlayer;
using GameGuildRecruit.Web.ViewModels.GuildRecruitUser;

namespace GameGuildRecruit.Web.Services.Interfaces
{
    public interface IContactService
    {
        ContactPlayerFormModel GetNewContactModelAsync();

        Task<GuildRecruitUserFormModel?> GetUserByIdAsync(Guid id);

        Task CreateContactAsync(ContactPlayerFormModel contactModel, GuildRecruitUserFormModel userModel);

        Task AddContactToUserAsync(Guid userId, Guid contactId);

        Task<ContactPlayerFormModel?> GetContactByIdAsync(Guid id);

        Task RemoveContactAsync(ContactPlayerFormModel contact);

        Task<IEnumerable<ContactPlayerViewModel>> GetUserContactsAsync(Guid userId);

        Task<ContactPlayerFormModel?> GetContactForFeedbackByIdAsync(Guid id);

        Task CreateContactFeedback(ContactPlayerFormModel contactModel, Guid id);
    }
}
