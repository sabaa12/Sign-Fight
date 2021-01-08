using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Data
{
    public class Cause
    {
        public int ID { get; set; }

        [MaxLength(50), Required]
        public string Title { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }
        public string UserID { get; set; }
        public User User { get; set; }

        public ICollection<SubScribes> SubScribes { get; set; }
    }
}
