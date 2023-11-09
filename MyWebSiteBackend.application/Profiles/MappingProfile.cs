using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.ArticleImages;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.Articles;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.Categories;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.Comments;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.Keywords;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.MetaTags;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.ReadMores;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.References;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.RelatedArticles;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.SubArticleImages;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.SubArticles;
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.application.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            #region Articles

            CreateMap<Article, ArticleDto>().ReverseMap();
            CreateMap<Article, ArticleCreateEditModel>().ReverseMap();
            CreateMap<Article, ArticleSearchModel>().ReverseMap();
            CreateMap<Article, ArticlesListItem>().ReverseMap();
            CreateMap<Article, ArticleComplexResult>().ReverseMap();

            #endregion

            #region Categories

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryAddEditModel>().ReverseMap();
            CreateMap<Category, CategoryComplexResult>().ReverseMap();
            CreateMap<Category, CategorySearchModel>().ReverseMap();
            CreateMap<Category, CategoryListItem>().ReverseMap();


            #endregion

            #region ArticleImages

            CreateMap<ArticleImage, ArticleImageDto>().ReverseMap();
            CreateMap<ArticleImage, ArticleImageSearchModel>().ReverseMap();
            CreateMap<ArticleImage, ArticleImageCreateEditModel>().ReverseMap();
            CreateMap<ArticleImage, ArticleImageListItem>().ReverseMap();
            CreateMap<ArticleImage, ArticleImageComplexResult>().ReverseMap();

            #endregion

            #region Commnets

            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<Comment, CommentSearchModel>().ReverseMap();
            CreateMap<Comment, CommentsListItem>().ReverseMap();
            CreateMap<Comment, CommentComplexResult>().ReverseMap();
            CreateMap<Comment, CommentCreateEditModel>().ReverseMap();

            #endregion

            #region Keywords

            CreateMap<Keyword, KeywordDto>().ReverseMap();
            CreateMap<Keyword, KeywordSearchModel>().ReverseMap();
            CreateMap<Keyword, KeywordsListItem>().ReverseMap();
            CreateMap<Keyword, KeywordComplexResult>().ReverseMap();
            CreateMap<Keyword, KeywordCreateEditModel>().ReverseMap();

            #endregion

            #region MetaTags

            CreateMap<MetaTag, MetaTagDto>().ReverseMap();
            CreateMap<MetaTag, MetaTagCreateEditModel>().ReverseMap();
            CreateMap<MetaTag, MetaTagComplexResult>().ReverseMap();
            CreateMap<MetaTag, MetaTagSearchModel>().ReverseMap();
            CreateMap<MetaTag, MetaTagsListItem>().ReverseMap();

            #endregion

            #region ReadMores

            CreateMap<ReadMore, ReadMoreDto>().ReverseMap();
            CreateMap<ReadMore, ReadMoreCreateEditModel>().ReverseMap();
            CreateMap<ReadMore, ReadMoreComplexResult>().ReverseMap();
            CreateMap<ReadMore, ReadMoreSearchModel>().ReverseMap();
            CreateMap<ReadMore, ReadMoresListItem>().ReverseMap();

            #endregion

            #region References

            CreateMap<Reference, ReferenceDto>().ReverseMap();
            CreateMap<Reference, ReferenceSearchModel>().ReverseMap();
            CreateMap<Reference, ReferencesListItem>().ReverseMap();
            CreateMap<Reference, ReferenceComplexResult>().ReverseMap();
            CreateMap<Reference, ReferenceCreateEditModel>().ReverseMap();

            #endregion

            #region RelatedArticles

            CreateMap<RelatedArticle, RelatedArticleDto>().ReverseMap();
            CreateMap<RelatedArticle, RelatedArticleSearchModel>().ReverseMap();
            CreateMap<RelatedArticle, RelatedArticlesListItem>().ReverseMap();
            CreateMap<RelatedArticle, ReadMoreCreateEditModel>().ReverseMap();
            CreateMap<RelatedArticle, ReadMoreComplexResult>().ReverseMap();

            #endregion

            #region SubArticles

            CreateMap<SubArticle, SubArticleDto>().ReverseMap();
            CreateMap<SubArticle, SubArticleSearchModel>().ReverseMap();
            CreateMap<SubArticle, SubArticlesListItem>().ReverseMap();
            CreateMap<SubArticle, SubArticleCreateEditModel>().ReverseMap();
            CreateMap<SubArticle, SubArticleComplexResult>().ReverseMap();

            #endregion

            #region SubArticleImages

            CreateMap<SubArticleImage, SubArticleImageDto>().ReverseMap();
            CreateMap<SubArticleImage, SubArticleImageSearchModel>().ReverseMap();
            CreateMap<SubArticleImage, SubArticleImageCreateEditModel>().ReverseMap();
            CreateMap<SubArticleImage, SubArticleImageComplexResult>().ReverseMap();
            CreateMap<SubArticleImage, SubArticleImagesListItem>().ReverseMap();

            #endregion

        }
    }
}
