using System.Collections.Generic;

namespace SweetSavory.Models
{
    public class Flavor
    {
        public Flavor()
        {
        this.JoinIR = new HashSet<FlavorTreat>();
        }
        public int FlavorId {get; set;}
        public string Name {get; set;}
        public virtual ApplicationUser User {get; set;}
        public virtual ICollection<FlavorTreat> JoinIR {get; set;}
    }
}