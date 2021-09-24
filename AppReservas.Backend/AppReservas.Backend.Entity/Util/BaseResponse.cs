using System;
using System.Collections.Generic;
using System.Text;

namespace AppReservas.Backend.Entity
{
    public class BaseResponse<T>
    {
        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public string Message { get; set; } = "";
    }
}
