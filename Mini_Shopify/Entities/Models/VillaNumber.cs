using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mini_Shopify.Entities.Models
{
    [Table("VillasNumber")]
    public class VillaNumber
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VillaNo { get; set; }
        [ForeignKey("Villa")]
        public int VillaID { get; set; }

        public Villa Villa { get; set; }
        [Required(ErrorMessage = "SpecialDetails is required")]
        [StringLength(60, ErrorMessage = "Special Details can't be longer than 60 characters")]
        public string SpecialDetails { get; set; }
     
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
