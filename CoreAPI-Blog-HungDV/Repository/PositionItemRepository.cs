using CoreAPI_Blog_HungDV.Dal;
using CoreAPI_Blog_HungDV.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI_Blog_HungDV.Repository
{
    public class PositionItemRepository : BaseRepository, IBaseRepository
    {
        /// <summary>
        /// Initialization Blog Position Item
        /// </summary>
        /// <param name="ctx"></param>
        public PositionItemRepository(EntityContext ctx) : base(ctx)
        {
        }
    }
}
