using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpenseManager.Core
{
    public interface IIdentifiableEntity
    {
        int EntityId { get; set; }
    }
}
