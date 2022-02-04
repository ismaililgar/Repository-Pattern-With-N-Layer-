using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Books
    {
        [Key]
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int NumOfPages { get; set; }
        public virtual Authors Authors { get; set; }
        public virtual Publishers Publisher { get; set; }
    }
}
