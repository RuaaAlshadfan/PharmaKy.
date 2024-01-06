using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharma_Ky.Models
{
    public class MedicVits
    {
        [Key]
        public int MedicVitId { get; set; }
        public string MedicVitname { get; set; }
        public string MedicVitdescription { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal MedicVitprice { get; set; }
        public string MedicVitimageurl { get; set; }
    }
}
