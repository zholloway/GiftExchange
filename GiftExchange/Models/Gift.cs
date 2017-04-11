using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace GiftExchange.Models
{
    public class Gift
    {
        public int ID { get; set; }
        public string Contents { get; set; }
        public string GiftHint { get; set; }
        public string ColorWrappingPaper { get; set; }
        public double Height { get; set; }
        public double Depth { get; set; }
        public double Weight { get; set; }
        public bool IsOpened { get; set; }

        public Gift() { }
        public Gift(SqlDataReader reader)
        {
            this.ID = (int)reader["ID"];
            this.Contents = reader["Contents"].ToString();
            this.GiftHint = reader["GiftHint"].ToString();
            this.ColorWrappingPaper = reader["ColorWrappingPaper"].ToString();
            this.Height = (double)reader["Height"];
            this.Depth = (double)reader["Depth"];
            this.Weight = (double)reader["Weight"];
            this.IsOpened = (bool)reader["IsOpened"];
        }
    }
}   