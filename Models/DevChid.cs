using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharma_Ky.Models
{
    public class DevChid
    {
        [Key]
        public int DevChidId { get; set; }
        public string DevChidname { get; set; }
        public string DevChiddescription { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal DevChidprice { get; set; }
        public string DevChidimageurl { get; set; }
    }
}
