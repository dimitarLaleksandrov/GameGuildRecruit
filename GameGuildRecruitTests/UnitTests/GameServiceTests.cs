using GameGuildRecruit.Web.Data;
using GameGuildRecruit.Web.Services.Interfaces;
using GameGuildRecruit.Web.Services;
using Microsoft.EntityFrameworkCore;
using static GameGuildRecruit.Tests.UnitTests.DataBaseSeeder;
using GameGuildRecruit.Tests.Mocks;
using GameGuildRecruit.Web.ViewModels.Game;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GameGuildRecruit.Web.Data.Migrations;

namespace GameGuildRecruit.Tests.UnitTests
{

    [TestFixture]
    public class GameServiceTests
    {
        private DbContextOptions<GameGuildRecruitDbContext> dbOptions;
        private GameGuildRecruitDbContext dbContext;

        private IGameService gameService;


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            dbOptions = new DbContextOptionsBuilder<GameGuildRecruitDbContext>()
               .UseInMemoryDatabase("GameGuildRecruitInMemoryDb" + Guid.NewGuid().ToString())
               .Options;

            dbContext = new GameGuildRecruitDbContext(dbOptions);

            dbContext.Database.EnsureCreated();

            SeedDataBase(dbContext);

            gameService = new GameService(dbContext);

        }

        [Test]
        public async Task AddGameAsyncShouldAddGameInDb()
        {
            var gameId = new Guid("01C54ED3-63E5-41A5-BA3D-ACC4AFEC36FE");

            var newGame = new GameFormModel()
            {
                GameName = "WoW2",
                GameSlideImageURL = "Test2",
                GameLogoImageURL = "Test2",
                IsGameHasView = false
            };

            await gameService.AddGameAsync(newGame, gameId);

            Assert.That(dbContext.Games.Count() == 4);

        }

        [Test]
        public async Task GetGamesAsyncShouldReturnAllGames()
        {           
            var games = await gameService.GetGamesAsync();

            Assert.That(games != null);

        }

        [Test]
        public async Task GetGameByIdAsyncShouldReturnGame()
        {

            var game = FakeData.GameViewModel[0];

            var gameFromDb = await gameService.GetGameByIdAsync(game.Id);

            Assert.That(gameFromDb!.Id, Is.EqualTo(game.Id));

        }

        [Test]
        public async Task GetGameByIdAsyncShouldReturnNull()
        {

            var gameId = new Guid("4BFC888A-EBCD-459A-B1B9-756AC08F0EFA");

            var gameFromDb = await gameService.GetGameByIdAsync(gameId);

            Assert.That(gameFromDb == null);

        }

        [Test]
        public async Task GetGameByIdAsyncShouldReturnGameProp()
        {

            var game = FakeData.GameViewModel[0];

            var gameFromDb = await gameService.GetGameByIdAsync(game.Id);

            Assert.That(gameFromDb!.Id, Is.EqualTo(game.Id));
            Assert.That(gameFromDb!.GameName, Is.EqualTo(game.GameName));
            Assert.That(gameFromDb!.GameLogoImageURL, Is.EqualTo(game.GameLogoImageURL));
            Assert.That(gameFromDb!.GameSlideImageURL, Is.EqualTo(game.GameSlideImageURL));
            Assert.That(gameFromDb!.IsGameHasView, Is.EqualTo(game.IsGameHasView));

        }

        [Test]
        public async Task GetGameForEditByIdAsyncShouldReturnGame()
        {

            var game = FakeData.GameFormModel[0];

            var gameFromDb = await gameService.GetGameForEditByIdAsync(game.Id);

            Assert.That(gameFromDb!.Id, Is.EqualTo(game.Id));

        }

        [Test]
        public async Task GetGameForEditByIdAsyncShouldReturnNull()
        {

            var gameId = new Guid("4BFC888A-EBCD-459A-B1B9-756AC08F0EFA");

            var gameFromDb = await gameService.GetGameForEditByIdAsync(gameId);

            Assert.That(gameFromDb == null);

        }

        [Test]
        public async Task GetGameForEditByIdAsyncShouldReturnGameProp()
        {

            var game = FakeData.GameFormModel[0];

            var gameFromDb = await gameService.GetGameForEditByIdAsync(game.Id);

            Assert.That(gameFromDb!.Id, Is.EqualTo(game.Id));
            Assert.That(gameFromDb!.GameName, Is.EqualTo(game.GameName));
            Assert.That(gameFromDb!.GameLogoImageURL, Is.EqualTo(game.GameLogoImageURL));
            Assert.That(gameFromDb!.GameSlideImageURL, Is.EqualTo(game.GameSlideImageURL));
            Assert.That(gameFromDb!.IsGameHasView, Is.EqualTo(game.IsGameHasView));

        }

        //[Test]
        //public async Task RemoveGameAsyncShouldRemoveGame()
        //{
        //    var game = new GameViewModel()
        //    {
        //        Id = new Guid("4BFC818A-EBCD-459A-B1B9-756AC08F0EFA")
        //    };

        //    await gameService.RemoveGameAsync(game);

        //    Assert.That(dbContext.Games.Count() == 2);

        //}


    }
}
