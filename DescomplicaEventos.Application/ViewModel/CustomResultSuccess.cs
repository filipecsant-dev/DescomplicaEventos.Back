using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DescomplicaEventos.Application.ViewModel
{
    public class CustomResultSuccess
    {
        public bool Success { get; private set; }
        public object Data { get; private set; }

        public CustomResultSuccess(bool success)
        {
            Success = success;
        }

        public CustomResultSuccess(bool success, object data) : this(success) =>
            Data = data;
    }
}