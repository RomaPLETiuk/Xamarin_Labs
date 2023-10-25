using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Lab6
{
    public class Book
    {
        [PrimaryKey, AutoIncrement ]
        public int ID { get; set; }
     
        public string Title { get; set; }

        public string Autor  { get; set; }
 
        public int Year { get; set; }

        public int Page { get; set; }
    }
}
