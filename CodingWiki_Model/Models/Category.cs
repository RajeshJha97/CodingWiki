using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_Model.Models
{
    [Table("tbl_categories")]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Column("Name")] //now column name will be Name
        public string CategoryName { get; set; }
       // public int Display { get; set; }
    }
}
