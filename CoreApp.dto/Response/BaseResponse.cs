using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp.dto.Response
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        public string Errors { get; set; }

        public BaseResponse()
        {
            this.Success = false;
            this.Errors = null;
        }

    }

    public class BaseResponse<T> : BaseResponse
    {
        public T Data { get; set; }
        public BaseResponse(bool success, T data)
        {
            this.Data = data;
            this.Success = success;
        }
        public BaseResponse() { }
    }
}
