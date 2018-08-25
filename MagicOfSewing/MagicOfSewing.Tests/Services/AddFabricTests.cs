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
    public class AddFabricTests
    {
        private const string fabricName = "New fabric name";
        private const string fabricSlug = "new-fabric-name";
        private const string fabricDescription = "new fabric description";
        private const string fabricImageUrl = "https://www.joann.com/on/demandware.static/-/Sites-joann-product-catalog/default/dwb9f3bad6/images/hi-res/14/14444012.jpg";

        private MagicOfSewingDbContext dbContext;
        private AdminFabricsService service;
        
        [TestMethod]
        public async Task AddFabric_WithProperFabric_ShouldAddCorrectly()
        {
            // Arrange
            var fabricModel = new FabricCreationBindingModel()
            {
                Name = fabricName,
                Slug = fabricSlug,
                Description = fabricDescription,
                ImageUrl = fabricImageUrl
            };

            // Act
            await this.service.AddFabricAsync(fabricModel);
            var fabric = this.dbContext.Fabrics.First();

            // Assert
            Assert.AreEqual(1, this.dbContext.Fabrics.Count());
            Assert.AreEqual(fabricName, fabric.Name);
            Assert.AreEqual(fabricSlug, fabric.Slug);
            Assert.AreEqual(fabricDescription, fabric.Description);
            Assert.AreEqual(fabricImageUrl, fabric.ImageUrl);
        }

        [TestMethod]
        public async Task AddFabric_WithNullFabric_ShouldThrowExeption()
        {
            // Arrange
            FabricCreationBindingModel fabricModel = null;

            // Act
            Func<Task> addFabric = () => this.service.AddFabricAsync(fabricModel);

            // Assert
            var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(addFabric);
            Assert.AreEqual(ValidationConstants.FabricDefinedMessage, exception.Message);
        }

        [TestMethod]
        public async Task AddFabric_WithMissingName_ShouldThrowExeption()
        {
            // Arrange
            FabricCreationBindingModel fabricModel = new FabricCreationBindingModel()
            {
                Name = null,
                Slug = fabricSlug,
                Description = fabricDescription,
                ImageUrl = fabricImageUrl
            };

            // Act
            Func<Task> addFabric = () => this.service.AddFabricAsync(fabricModel);

            // Assert
            var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(addFabric);
            Assert.AreEqual(ValidationConstants.FabricNameMessage, exception.Message);
        }

        [TestMethod]
        public async Task AddFabric_WithMissingSlug_ShouldThrowExeption()
        {
            // Arrange
            FabricCreationBindingModel fabricModel = new FabricCreationBindingModel()
            {
                Name = fabricName,
                Slug = null,
                Description = fabricDescription,
                ImageUrl = fabricImageUrl
            };

            // Act
            Func<Task> addFabric = () => this.service.AddFabricAsync(fabricModel);

            // Assert
            var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(addFabric);
            Assert.AreEqual(ValidationConstants.FabricSlugMessage, exception.Message);
        }

        [TestInitialize]
        public void InitializeTests()
        {
            this.dbContext = MockDbContext.GetDbContext();
            var mapper = MockAutoMapper.GetMapper();
            this.service = new AdminFabricsService(dbContext, mapper);
        }
    }
}
