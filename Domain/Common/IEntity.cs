using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Common
{
    public interface IEntity
    {
        public Guid Id { get; set; }
    }
}
