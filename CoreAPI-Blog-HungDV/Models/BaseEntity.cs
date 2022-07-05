using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI_Blog_HungDV.Models
{
    public abstract class BaseEntity
    {
        private int id;
        public BaseEntity()
        {
            this.id = 0;
        }
        public BaseEntity(int id)
        {
            this.id = id;
        }
        public int Id { get => id; set => id = value; }
    }
}
