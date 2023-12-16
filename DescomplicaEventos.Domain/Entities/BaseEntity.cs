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

        protected BaseEntity(bool active = true)
        {
            Id = Guid.NewGuid();
            Active = active;
        }

        public void disabledEntity()
        {
            DateDelete = DateTimeOffset.UtcNow;
            Active = false;
        }
    }
}