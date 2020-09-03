using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace FurryFit.Models
{
    public class BaseModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string RemoteId { get; set; }
        public DateTime CreateDateTime { get; set; }

        public BaseModel()
        {
            CreateDateTime=DateTime.Now;
        }
    }
}
