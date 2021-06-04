using System.ComponentModel.DataAnnotations;

namespace SweetSavory.Models
{
    public class FlavorTreat
    {
        [Key]
        public int FlavorTreatId { get; set; }
        public int TreatId { get; set; }
        public int FlavorId { get; set; }
        public virtual Treat Treat { get; set; }
        public virtual Flavor Flavor { get; set; }
    }
}