using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GiftShop.Models
{
    public class Gift
    {
        // [Key] annotationen, angiver at dette er en primary key, derved behøves man ikke at skrive ID i slutningen af navnet
        public int GiftID { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        //[DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }
        public bool BoyGift { get; set; }
        public bool GirlGift { get; set; }

    }
}
