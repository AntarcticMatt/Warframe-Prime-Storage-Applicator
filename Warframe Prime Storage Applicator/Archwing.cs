using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warframe_Prime_Storage_Applicator
{
    class Archwing : Prime
    {
        public Archwing(string Name, int BP, int Harness, int Systems, int Wings) : base(Name)
        {
            _parts.Add(new Part(BP, "Blueprint", this, 1));
            _parts.Add(new Part(Harness, "Harness", this, 1));
            _parts.Add(new Part(Systems, "Systems", this, 1));
            _parts.Add(new Part(Wings, "Wings", this, 1));
        }
     }
}
