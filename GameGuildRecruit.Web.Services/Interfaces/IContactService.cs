using GameGuildRecruit.Web.ViewModels.ContactPlayer;
using GameGuildRecruit.Web.ViewModels.GuildRecruitUser;

namespace GameGuildRecruit.Web.Services.Interfaces
{
    public interface IContactService
    {
        Task<ContactPlayerFormModel> GetNewContactModelAsync();

        Task<GuildRecruitUserViewModel?> GetUserByIdAsync(Guid id);

        Task CreateContactAsync(ContactPlayerFormModel contactModel, GuildRecruitUserViewModel userModel);

        Task AddContactToUserAsync(Guid userId, Guid contactId);

        Task<ContactPlayerViewModel?> GetContactByIdAsync(Guid id);

        Task RemoveContactAsync(ContactPlayerViewModel contact);

        Task<IEnumerable<ContactPlayerViewModel>> GetUserContactsAsync(Guid userId);

        Task<ContactPlayerViewModel?> GetContactForFeedbackByIdAsync(Guid id);

        Task CreateContactFeedback(ContactPlayerViewModel contactModel, Guid id);
    }
}
