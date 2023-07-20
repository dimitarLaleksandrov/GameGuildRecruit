using GameGuildRecruit.Web.Services.Interfaces;
using GameGuildRecruit.Web.ViewModels.ContactPlayer;
using GameGuildRecruit.Web.ViewModels.GuildRecruitUser;
using GameGuildRecruit.Web.Data;
using GameGuildRecruit.Web.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GameGuildRecruit.Web.Services
{
    public class ContactService : IContactService
    {

        private readonly GameGuildRecruitDbContext dbContext;

        public ContactService(GameGuildRecruitDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task AddContactToUserAsync(Guid userId, Guid contactId)
        {

            var newContactUser = new IdentityUserContact
            {

                GuildUserId = userId,

                ContactId = contactId

            };

            await dbContext.IdentityUserContacts.AddAsync(newContactUser);

            await dbContext.SaveChangesAsync();

        }

        public async Task CreateContactAsync(ContactPlayerFormModel contactModel, GuildRecruitUserFormModel userModel)
        {

            ContactPlayer contact = new ContactPlayer()
            {
                Id = contactModel.Id,
                NickName = contactModel.NickName,
                Description = contactModel.Description,
                UrlLink = contactModel.UrlLink,
                GuildUserId = userModel.Id,
                UserNickName = userModel.NickName,
                GuildName = userModel.GuildName,
                ServerName = userModel.ServerName,
                GameName = userModel.GameName,
                Feedback = contactModel.Feedback,
                IsAccepted = contactModel.IsAccepted

            };

            await dbContext.ContactPlayers.AddAsync(contact);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task CreateContactFeedback(ContactPlayerFormModel contactModel, Guid id)
        {
            var contact = await dbContext.ContactPlayers.FindAsync(id);

            if (contact != null)
            {
                contact.Feedback = contactModel.Feedback;

                await this.dbContext.SaveChangesAsync();
            }

        }

        public async Task<ContactPlayerFormModel?> GetContactByIdAsync(Guid id)
        {
            return await dbContext.ContactPlayers
                 .Where(c => c.Id == id)
                 .Select(p => new ContactPlayerFormModel
                 {
                     Id = p.Id,
                     NickName = p.NickName,
                     Description = p.Description,
                     UrlLink = p.UrlLink,
                     UserId = p.GuildUserId,
                     UserNickName = p.NickName,
                     GuildName = p.GuildName,
                     ServerName = p.ServerName,
                     GameName = p.GameName,
                     Feedback = p.Feedback,
                     IsAccepted = p.IsAccepted

                 })
                 .FirstOrDefaultAsync();
        }

        public async Task<ContactPlayerFormModel?> GetContactForFeedbackByIdAsync(Guid id)
        {
            return await dbContext.ContactPlayers
                .Where(c => c.Id == id)
                .Select(p => new ContactPlayerFormModel
                {
                    Id = p.Id,
                    NickName = p.NickName,
                    Description = p.Description,
                    UrlLink = p.UrlLink,
                    Feedback = p.Feedback
                })
                .FirstOrDefaultAsync();
        }

        public async Task<ContactPlayerFormModel> GetNewContactModelAsync()
        {

            var contactModel = new ContactPlayerFormModel()
            {

            };

            return contactModel;
        }

        public async Task<GuildRecruitUserFormModel?> GetUserByIdAsync(Guid id)
        {
            return await dbContext.GuildRecruitUsers
                 .Where(x => x.Id == id)
                 .Select(u => new GuildRecruitUserFormModel
                 {
                     Id = u.Id,
                     UserName = u.UserName,
                     UrlLink = u.UrlLink,
                     NickName = u.NickName,
                     GuildName = u.GuildName,
                     ServerName = u.ServerName,
                     GameName = u.GameName,
                     Description = u.Description

                 })
                 .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ContactPlayerViewModel>> GetUserContactsAsync(Guid userId)
        {
            return await dbContext.ContactPlayers
               .Where(x => x.GuildUserId == userId)
               .Select(c => new ContactPlayerViewModel
               {
                   Id = c.Id,
                   NickName = c.NickName,
                   UrlLink = c.UrlLink,
                   Description = c.Description,
                   GuildName = c.GuildName,
                   UserId = c.GuildUserId,
                   GameName = c.GameName,
                   ServerName = c.ServerName,
                   UserNickName = c.UserNickName,
                   Feedback = c.Feedback,
                   IsAccepted = c.IsAccepted
               })
               .ToArrayAsync();
        }


        public async Task RemoveContactAsync(ContactPlayerFormModel contact)
        {
            var userContact = await dbContext.IdentityUserContacts.FirstOrDefaultAsync(x => x.ContactId == contact.Id && x.GuildUserId == contact.UserId);

            var contactToDelete = await dbContext.ContactPlayers.Where(c => c.Id == contact.Id)
                                                                .Select(x => new ContactPlayer
                                                                {
                                                                    Id = x.Id,
                                                                    GuildUserId = x.GuildUserId,
                                                                    NickName = x.NickName,
                                                                    UrlLink = x.UrlLink,
                                                                    Description = x.Description,
                                                                    UserNickName = x.UserNickName,
                                                                    GuildName = x.GuildName,
                                                                    ServerName = x.ServerName,
                                                                    GameName = x.GameName,
                                                                    Feedback = x.Feedback,
                                                                    IsAccepted = x.IsAccepted

                                                                })
                                                                .FirstOrDefaultAsync();

            if (userContact != null && contactToDelete != null)
            {
                dbContext.ContactPlayers.Remove(contactToDelete);

                dbContext.IdentityUserContacts.Remove(userContact);

                await dbContext.SaveChangesAsync();
            }

        }

    }
}
