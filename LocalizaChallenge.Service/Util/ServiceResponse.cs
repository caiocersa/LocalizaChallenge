using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using LocalizaChallenge.Domain.Interfaces;

namespace LocalizaChallenge.Service.Util
{
    public class ServiceResponse<T> : IServiceResponse<T>
    {
        public HttpStatusCode StatusCode { get; set; }

        public string Message { get; set; }

        public T Retorno { get; set; }
    }
}
