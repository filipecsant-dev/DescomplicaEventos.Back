using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DescomplicaEventos.Domain.Entities;

namespace DescomplicaEventos.Application.ViewModel.Shared
{
    public class BaseVM<TViewModel>
    {
        public TViewModel Data { get; private set; }
        public IEnumerable<string> Errors { get; private set; }
        
        public BaseVM(TViewModel data, IEnumerable<string> errors)
        {
            Data = data;
            Errors = errors;
        }
    }
}