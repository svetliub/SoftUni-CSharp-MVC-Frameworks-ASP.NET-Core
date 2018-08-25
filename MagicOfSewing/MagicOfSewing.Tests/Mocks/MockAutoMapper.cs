namespace MagicOfSewing.Tests.Mocks
{
    using AutoMapper;
    using MagicOfSewing.Web.Mapping;

    public static class MockAutoMapper
    {
        static MockAutoMapper()
        {
            Mapper.Initialize(config => config.AddProfile<AutoMapperProfile>());
        }

        public static IMapper GetMapper() => Mapper.Instance;
    }
}
