using CheapAllegro.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CheapAllegro.Core
{
    public interface IUnitOfWork
    {
        void Complete();
        IAuctionRepository Auction { get; set; }
        ICategoryRepository Category { get; set; }
    }
}
