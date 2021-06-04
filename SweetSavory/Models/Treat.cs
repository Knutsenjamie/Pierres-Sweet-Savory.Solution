using System.Collections.Generic;


namespace SweetSavory.Models
{
    public class Treat
    {
        public Treat()
        {
            this.JoinIR = new HashSet<FlavorTreat>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<FlavorTreat> JoinIR { get; }
    }
}