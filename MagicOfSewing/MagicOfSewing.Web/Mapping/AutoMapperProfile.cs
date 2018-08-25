namespace MagicOfSewing.Web.Mapping
{
    using AutoMapper;
    using MagicOfSewing.Common.Admin.BindingModels;
    using MagicOfSewing.Common.Admin.ViewModels;
    using MagicOfSewing.Models;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<Article, ArticleConciseViewModel>()
                .ForMember(ad => ad.Author, opt => opt.MapFrom(a => a.Author.UserName))
                .ForMember(ad => ad.ShortContent, opt => opt.MapFrom(a => a.Content.Length > 150 ? a.Content.Substring(0, 150) : a.Content));
            this.CreateMap<Article, ArticleDetailsViewModel>()
                .ForMember(ad => ad.Author, opt => opt.MapFrom(a => a.Author.UserName))
                .ForMember(ad => ad.AvatarUrl, opt => opt.MapFrom(a => a.Author.AvatarUrl));
            this.CreateMap<ArticleCreationBindingModel, Article>();
            this.CreateMap<ArticleEditBindingModel, Article>();

            this.CreateMap<Video, VideoConciseViewModel>()
                .ForMember(vc => vc.Author, opt => opt.MapFrom(v => v.Author.UserName));
            this.CreateMap<VideoCreationBindingModel, Video>();
            this.CreateMap<Video, VideoDetailsViewModel>()
                .ForMember(vd => vd.Author, opt => opt.MapFrom(v => v.Author.UserName))
                .ForMember(vd => vd.AvatarUrl, opt => opt.MapFrom(v => v.Author.AvatarUrl));

            this.CreateMap<User, AuthorConciseViewModel>();
            this.CreateMap<ArticleCategory, CategoryConciseViewModel>();

            this.CreateMap<ContactMessage, MessageConciseViewModel>();
            this.CreateMap<ContactMessage, MessageDetailsViewModel>();

            this.CreateMap<Fabric, FabricConciseViewModel>();
            this.CreateMap<Fabric, FabricDetailsViewModel>();
            this.CreateMap<FabricCreationBindingModel, Fabric>();

            this.CreateMap<User, UserConciseViewModel>();

            this.CreateMap<Strategy, StrategyConciseViewModel>();
            this.CreateMap<Strategy, StrategyDetailsViewModel>();
            this.CreateMap<StrategyCreationBindingModel, Strategy>();
            this.CreateMap<StrategyEditBindingModel, Strategy>();

            this.CreateMap<PostCreationBindingModel, Post>();
            this.CreateMap<Post, PostConciseViewModel>()
                .ForMember(pc => pc.Username, opt => opt.MapFrom(p => p.User.UserName))
                .ForMember(pc => pc.Atatar, opt => opt.MapFrom(p => p.User.AvatarUrl))
                .ForMember(pc => pc.UserId, opt => opt.MapFrom(p => p.User.Id));
        }
    }
}
