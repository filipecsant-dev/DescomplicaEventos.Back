using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DescomplicaEventos.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; init; }
        public DateTimeOffset? DateDelete { get; private set; }
        public bool Active { get; private set; }

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            Active = true;
        }

        public void disabledEntity()
        {
            DateDelete = DateTimeOffset.UtcNow;
            Active = false;
        }
    }
}