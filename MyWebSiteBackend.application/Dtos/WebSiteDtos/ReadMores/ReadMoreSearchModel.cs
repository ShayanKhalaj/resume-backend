using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSiteBackend.application.Dtos.WebSiteDtos.ReadMores
{
    public class ReadMoreSearchModel
    {
        public int Id { get; set; }
        public string LinkName { get; set; }
        public string LinkText { get; set; }
        public string Description { get; set; }
        public int SubArticleID { get; set; }
    }
}
