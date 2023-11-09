using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Framework.Utilities;

namespace MyWebSiteBackend.application.common
{
    public class OperationResult
    {
        public string OperationName { get; set; }
        public string OperationDate { get;private set; }
        public bool Success { get;private set; }
        public HttpStatusCode? StatusCode { get; set; }
        public object ResponseBody { get;private set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }

        public OperationResult(string operationName, HttpStatusCode statusCode, object responseBody,List<string> errors)
        {
            this.OperationName = operationName;
            this.OperationDate = new DateTime().ToPersianCalendar();
            this.Success = false;
            this.StatusCode = statusCode;
            this.ResponseBody = responseBody;
            this.Errors = errors;
        }

        public OperationResult(string operationName, HttpStatusCode statusCode, object responseBody)
        {
            this.OperationName = operationName;
            this.OperationDate = new DateTime().ToPersianCalendar();
            this.Success = false;
            this.StatusCode = statusCode;
            this.ResponseBody = responseBody;
        }
        public OperationResult(string operationName, object responseBody)
        {
            this.OperationName = operationName;
            this.OperationDate = new DateTime().ToPersianCalendar();
            this.Success = false;
            this.ResponseBody = responseBody;
        }
        public OperationResult(string operationName)
        {
            this.OperationName = operationName;
            this.OperationDate = new DateTime().ToPersianCalendar();
            this.Success = false;
        }
        public OperationResult()
        {
            this.OperationDate = new DateTime().ToPersianCalendar();
            this.Success = false;
        }
        
        public OperationResult Failed(string message, HttpStatusCode? statusCode, List<string> errors)
        {
            this.Success = false;
            this.Message = message;
            if(errors!=null)
            {
                this.Errors = errors;
            }
            if(statusCode!=null)
            {
                this.StatusCode = statusCode.Value;
            }
            return this;
        }
        public OperationResult Succeeded(string message, HttpStatusCode? statusCode, object responseBody)
        {
            this.Success = true;
            this.Message = message;
            if (responseBody != null)
            {
                this.ResponseBody = responseBody;
            }
            if (statusCode != null)
            {
                this.StatusCode = statusCode.Value;
            }
            return this;
        }
    }
}
