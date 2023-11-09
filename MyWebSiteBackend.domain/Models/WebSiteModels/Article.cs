using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebSiteBackend.domain.Models.WebSiteModels
{
   public class Article:BaseModel
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string VideoUrl { get; set; }
        public string VideoDescription { get; set; }
        public string AudioUrl { get; set; }
        public string AudioDescription { get; set; }
        public int Rate { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public ICollection<ArticleImage> Images { get; set; }
        public ICollection<MetaTag> MetaTags { get; set; }
        public ICollection<RelatedArticle> RelatedArticles { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<SubArticle> SubArticles { get; set; }
        public ICollection<Keyword> Keywords { get; set; }
        public ICollection<Reference> References { get; set; }

        public Article()
        {
            this.Images=new List<ArticleImage>();
            this.MetaTags=new List<MetaTag>();
            this.SubArticles = new List<SubArticle>();
            this.Keywords = new List<Keyword>();
            this.References = new List<Reference>();
            this.Comments = new List<Comment>();
            this.RelatedArticles=new List<RelatedArticle>();
        }
    }
}
