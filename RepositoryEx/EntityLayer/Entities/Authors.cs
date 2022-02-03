using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Authors
    {

        [Key] public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public int NumOfBooks { get; set; }
    }
}
