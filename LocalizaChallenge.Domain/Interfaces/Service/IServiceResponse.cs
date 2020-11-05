using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace LocalizaChallenge.Domain.Interfaces
{
    public interface IServiceResponse<T> : IBaseService
    {
        HttpStatusCode StatusCode { get; set; }

        string Message { get; set; }

        T Retorno { get; set; }
    }
}
