using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI_Blog_HungDV.Models
{
    public class PositionItem : BaseEntity
    {
        private int positionId;
        private int listPositionId;

        public PositionItem() : base()
        {

        }

        public PositionItem(int id, int positionId, int listPositionId) : base(id)
        {
            this.positionId = positionId;
            this.listPositionId = listPositionId;
        }

        public int ListPositionId { get => listPositionId; set => listPositionId = value; }
        public int PositionId { get => positionId; set => positionId = value; }
    }
}
