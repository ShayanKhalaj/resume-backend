﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyWebSiteBackend.application.common;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.Articles;

namespace MyWebSiteBackend.application.Features.Articles.Requests.Commands
{
    public class EditArticleRequest:IRequest<OperationResult>
    {
        public ArticleCreateEditModel ArticleEditModel { get; set; }
    }
}
