using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Publishers
    {
        [Key]
        public int PublisherId { get; set; }
        public string PublisherName { get; set; }
        public string Adress { get; set; }
    }
}
