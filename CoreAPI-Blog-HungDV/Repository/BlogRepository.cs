using CoreAPI_Blog_HungDV.Dal;
using CoreAPI_Blog_HungDV.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI_Blog_HungDV.Repository
{
    public class BlogRepository : BaseRepository, IBaseRepository
    {
        /// <summary>
        /// Initialization Blog Repository
        /// </summary>
        /// <param name="ctx"></param>
        public BlogRepository(EntityContext ctx) : base(ctx)
        {
        }
    }
}
