﻿

namespace GameGuildRecruit.Web.Common
{
    public static class EntityValidations
    {
        public static class GuildRecruitUser
        {
            public const int NicknameMinLength = 2;
            public const int NicknameMaxLength = 100;

            public const int GuildNameMinLength = 2;
            public const int GuildNameMaxLength = 100;

            public const int ServerNameMinLength = 2;
            public const int ServerNameMaxLength = 100;

            public const int GameNameMinLength = 2;
            public const int GameNameMaxLength = 100;

            public const int DescriptionMinLength = 5;
            public const int DescriptionMaxLength = 1000;

        }

        public static class ContactPlayer
        {
            public const int NicknameMinLength = 2;
            public const int NicknameMaxLength = 100;

            public const int DescriptionMinLength = 5;
            public const int DescriptionMaxLength = 1000;

        }

        public static class Game
        {
            public const int GameNameMinLength = 2;
            public const int GameNameMaxLength = 50;
        }

        public static class Banner
        {
            public const int BannerTitleMinLength = 2;
            public const int BannerTitleMaxLength = 20;

            public const int DescriptionMinLength = 5;
            public const int DescriptionMaxLength = 400;
        }

        public static class Avatar
        {
            public const int AvatarNameMinLength = 2;
            public const int AvatarNameMaxLength = 20;
 
        }
    }
}

