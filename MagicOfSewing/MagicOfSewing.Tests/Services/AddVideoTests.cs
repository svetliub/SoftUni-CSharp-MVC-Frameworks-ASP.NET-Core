namespace MagicOfSewing.Tests.Services
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MagicOfSewing.Common.Admin.BindingModels;
    using MagicOfSewing.Common.Validation;
    using MagicOfSewing.Data;
    using MagicOfSewing.Services.Admin;
    using MagicOfSewing.Tests.Mocks;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    [TestClass]
    public class AddVideoTests
    {
        private const string videoTitle = "New video name";
        private const string videoSlug = "new-video-name";
        private const string videoDescription = "new video description";
        private const string videoYoutubeId = "https://www.youtube.com/watch?v=orp7WHibnaU";
        private const string videoUserId = "someUser";

        private MagicOfSewingDbContext dbContext;
        private AdminVideosService service;

        [TestMethod]
        public async Task AddVideo_WithProperVideo_ShouldAddCorrectly()
        {
            // Arrange
            var videoModel = new VideoCreationBindingModel()
            {
                Title = videoTitle,
                Slug = videoSlug,
                Description = videoDescription,
                YoutubeId = videoYoutubeId,
                PublishDateTime = DateTime.Now,
                UserId = videoUserId
            };

            // Act
            await this.service.AddVideoAsync(videoModel);
            var video = this.dbContext.Videos.First();

            // Assert
            Assert.AreEqual(1, this.dbContext.Videos.Count());
            Assert.AreEqual(videoTitle, video.Title);
            Assert.AreEqual(videoSlug, video.Slug);
            Assert.AreEqual(videoDescription, video.Description);
            Assert.AreEqual("orp7WHibnaU", video.YoutubeId);
            Assert.AreEqual(videoUserId, video.UserId);
        }

        [TestMethod]
        public async Task AddVideo_WithNullNull_ShouldThrowExeption()
        {
            // Arrange
            VideoCreationBindingModel videoModel = null;

            // Act
            Func<Task> addVideo = () => this.service.AddVideoAsync(videoModel);

            // Assert
            var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(addVideo);
            Assert.AreEqual(ValidationConstants.VideoDefinedMessage, exception.Message);
        }

        [TestMethod]
        public async Task AddVideo_WithMissingTitle_ShouldThrowExeption()
        {
            // Arrange
            var videoModel = new VideoCreationBindingModel()
            {
                Title = null,
                Slug = videoSlug,
                Description = videoDescription,
                YoutubeId = videoYoutubeId,
                PublishDateTime = DateTime.Now,
                UserId = videoUserId
            };

            // Act
            Func<Task> addVideo = () => this.service.AddVideoAsync(videoModel);

            // Assert
            var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(addVideo);
            Assert.AreEqual(ValidationConstants.VideoTitleMessage, exception.Message);
        }

        [TestMethod]
        public async Task AddVideo_WithMissingSlug_ShouldThrowExeption()
        {
            // Arrange
            var videoModel = new VideoCreationBindingModel()
            {
                Title = videoTitle,
                Slug = null,
                Description = videoDescription,
                YoutubeId = videoYoutubeId,
                PublishDateTime = DateTime.Now,
                UserId = videoUserId
            };

            // Act
            Func<Task> addVideo = () => this.service.AddVideoAsync(videoModel);

            // Assert
            var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(addVideo);
            Assert.AreEqual(ValidationConstants.VideoSlugMessage, exception.Message);
        }

        [TestMethod]
        public async Task AddVideo_WithMissingDescription_ShouldThrowExeption()
        {
            // Arrange
            var videoModel = new VideoCreationBindingModel()
            {
                Title = videoTitle,
                Slug = videoSlug,
                Description = null,
                YoutubeId = videoYoutubeId,
                PublishDateTime = DateTime.Now,
                UserId = videoUserId
            };

            // Act
            Func<Task> addVideo = () => this.service.AddVideoAsync(videoModel);

            // Assert
            var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(addVideo);
            Assert.AreEqual(ValidationConstants.VideoDescriptionMessage, exception.Message);
        }

        [TestMethod]
        public async Task AddVideo_WithMissingYoutubeId_ShouldThrowExeption()
        {
            // Arrange
            var videoModel = new VideoCreationBindingModel()
            {
                Title = videoTitle,
                Slug = videoSlug,
                Description = videoDescription,
                YoutubeId = null,
                PublishDateTime = DateTime.Now,
                UserId = videoUserId
            };

            // Act
            Func<Task> addVideo = () => this.service.AddVideoAsync(videoModel);

            // Assert
            var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(addVideo);
            Assert.AreEqual(ValidationConstants.VideoYoutubeMessage, exception.Message);
        }

        [TestInitialize]
        public void InitializeTests()
        {
            this.dbContext = MockDbContext.GetDbContext();
            var mapper = MockAutoMapper.GetMapper();
            this.service = new AdminVideosService(dbContext, mapper);
        }
    }
}
