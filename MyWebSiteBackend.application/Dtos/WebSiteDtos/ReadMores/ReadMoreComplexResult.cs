using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWebSiteBackend.application.common;

namespace MyWebSiteBackend.application.Dtos.WebSiteDtos.ReadMores
{
    public class ReadMoreComplexResult:IComplexObjectResult<List<ReadMoresListItem>,List<string>>
    {
        public List<ReadMoresListItem> Results { get; set; }
        public List<string> Errors { get; set; }
    }
}
