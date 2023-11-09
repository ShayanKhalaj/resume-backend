using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebSiteBackend.domain.Models.WebSiteModels
{
    public class SubArticle:BaseModel
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string VideoUrl { get; set; }
        public string VideoDescription { get; set; }
        public string AudioUrl { get; set; }
        public string AudioDescription { get; set; }
        public int ArticleID { get; set; }
        public Article Article { get; set; }
        public ICollection<SubArticleImage> Images { get; set; }
        public ICollection<ReadMore> ReadMores { get; set; }

        public SubArticle()
        {
            this.Images=new List<SubArticleImage>();
            this.ReadMores = new List<ReadMore>();
        }
    }
}
