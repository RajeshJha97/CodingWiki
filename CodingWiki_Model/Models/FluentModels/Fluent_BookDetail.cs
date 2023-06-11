﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_Model.Models
{
    //[Table("tbl_bookDetails")]
    public class Fluent_BookDetail
    {
        [Key]
        public int BookDetail_Id { get; set; }
        public int NumberOfPages { get; set; }
        public string Weight { get; set; }
        //[ForeignKey("Book")]
        public int BookId { get; set; }
        public Fluent_Book Book { get; set; }


    }
}
