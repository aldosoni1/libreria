using PJENL.Shared.Kernel.Responses;
using PJENL.Shared.Kernel.Utils;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Domain.Exceptions
{
    public class LibreriaException<T> : Exception, IResponse where T : struct
    {
        public LibreriaException(T code, HttpStatusCode statuscode = HttpStatusCode.InternalServerError, params string[] parametros)
        {
            Code = (int)(object)code;
            Success = false;
            RequestDate = DateTime.Now;
            StatusCode = (int)statuscode;
            if(parametros != null)
            {
                this.ResponseMessage = string.Format(EnumExtensions.GetDescription<T>(code),parametros);
            }
            else
            {
                this.ResponseMessage = string.Format(EnumExtensions.GetDescription<T>(code));
            }
        }
        public LibreriaException(Exception ex, T code):base(ex.Message,ex)
        {
            Code = (int)(object)code;
            Success = false;
            RequestDate = DateTime.Now;
            StatusCode = (int)HttpStatusCode.InternalServerError;
            this.ResponseMessage = string.Format(EnumExtensions.GetDescription<T>(code), ex.Message);
        }
        public int Code { get; set; }
        public string ResponseMessage { get; set; }
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime ResponseDate { get; set; }
    }
}
