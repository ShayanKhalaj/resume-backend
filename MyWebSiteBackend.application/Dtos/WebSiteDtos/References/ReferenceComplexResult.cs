using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWebSiteBackend.application.common;

namespace MyWebSiteBackend.application.Dtos.WebSiteDtos.References
{
    public class ReferenceComplexResult:IComplexObjectResult<List<ReferencesListItem>,List<string>>
    {
        public List<ReferencesListItem> Results { get; set; }
        public List<string> Errors { get; set; }
    }
}
