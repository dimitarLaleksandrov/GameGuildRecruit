using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GameGuildRecruit.Web.Data.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace GameGuildRecruit.Web.Data
{
    public class GameGuildRecruitDbContext : IdentityDbContext
    {
        public GameGuildRecruitDbContext(DbContextOptions<GameGuildRecruitDbContext> options)
        : base(options)
        {
        }

        public DbSet<GuildRecruitUser> GuildRecruitUsers { get; set; } = null!;

        public DbSet<ContactPlayer> ContactPlayers { get; set; } = null!;

        public DbSet<IdentityUserContact> IdentityUserContacts { get; set; } = null!;




        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityUserContact>().HasKey(x => new
            {
                x.GuildUserId,
                x.ContactId
            });

            base.OnModelCreating(builder);

        }
    }
}