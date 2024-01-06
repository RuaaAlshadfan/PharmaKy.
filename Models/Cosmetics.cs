using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharma_Ky.Models
{
    public class Cosmetics
    {

        [Key]
        public int CosmeticsId { get; set; }
        public string Cosmeticsname { get; set; }
        public string Cosmeticsdescription { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Cosmeticsprice { get; set; }
        public string Cosmeticsimageurl { get; set; }
    }
}
