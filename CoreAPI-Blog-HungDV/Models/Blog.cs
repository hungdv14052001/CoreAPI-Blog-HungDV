using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI_Blog_HungDV.Models
{
    public class Blog : BaseEntity
    {
        private string title;
        private string des;
        private string detail;
        private int category;
        private bool isPublic;
        private DateTime datePublic;
        private int listPositionId;
        private string thumbs;

        public Blog() : base()
        {
            this.title = "";
            this.des = "";
            this.detail = "";
            this.category = 0;
            this.isPublic = true;
            this.datePublic = DateTime.Now;
            this.listPositionId = 0;
            this.thumbs = "thumbs.jpg";
        }

        public Blog(int id, string title, string des, string detail, int category, bool isPublic, DateTime datePublic, int listPositionId, string thumbs) : base(id)
        {
            this.title = title;
            this.des = des;
            this.detail = detail;
            this.category = category;
            this.isPublic = isPublic;
            this.datePublic = datePublic;
            this.listPositionId = listPositionId;
            this.thumbs = thumbs;
        }

        public string Title { get => title; set => title = value; }
        public string Des { get => des; set => des = value; }
        public string Detail { get => detail; set => detail = value; }
        public int Category { get => category; set => category = value; }
        public bool IsPublic { get => isPublic; set => isPublic = value; }
        public DateTime DatePublic { get => datePublic; set => datePublic = value; }
        public int ListPositionId { get => listPositionId; set => listPositionId = value; }
        public string Thumbs { get => thumbs; set => thumbs = value; }
    }
}
