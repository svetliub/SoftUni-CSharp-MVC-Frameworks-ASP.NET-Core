namespace MagicOfSewing.Services
{
    using AutoMapper;
    using MagicOfSewing.Data;

    public abstract class BaseEFService
    {
        public BaseEFService(MagicOfSewingDbContext dbContext, IMapper mapper)
        {
            this.DbContext = dbContext;
            this.Mapper = mapper;
        }

        protected MagicOfSewingDbContext DbContext { get; private set; }

        protected IMapper Mapper { get; private set; }
    }
}
