using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWebSiteBackend.application.common;

namespace MyWebSiteBackend.application.Dtos.WebSiteDtos.Comments
{
    public class CommentComplexResult:IComplexObjectResult<List<CommentsListItem>,List<string>>
    {
        public List<CommentsListItem> Results { get; set; }
        public List<string> Errors { get; set; }
    }
}
