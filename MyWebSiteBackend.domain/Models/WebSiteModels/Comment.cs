using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebSiteBackend.domain.Models.WebSiteModels
{
    public class Comment:BaseModel
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string Answer { get; set; }
        public bool IsAccepted { get; set; }
        public bool HasSeen { get; set; }
        public bool IsAnswered { get; set; }
        public int LikedCount { get; set; }
        public int DislikedCount { get; set; }
        public int ArticleID { get; set; }
        public Article Article { get; set; }
    }
}
