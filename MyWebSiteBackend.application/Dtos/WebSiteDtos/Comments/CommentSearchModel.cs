using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSiteBackend.application.Dtos.WebSiteDtos.Comments
{
    public class CommentSearchModel
    {
        public int Id { get; set; }
        public bool IsAccepted { get; set; }
        public bool HasSeen { get; set; }
        public bool IsAnswered { get; set; }
        public int LikedCount { get; set; }
        public int DislikedCount { get; set; }
        public int ArticleID { get; set; }
    }
}
