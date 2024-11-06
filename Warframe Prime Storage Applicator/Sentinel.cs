using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warframe_Prime_Storage_Applicator
{
    class Sentinel : Prime
    {
        public Sentinel(string Name, int BP, int Carapace, int Cerebrum, int Systems) : base(Name)
        {
            _parts.Add(new Part(BP, "Blueprint", this, 1));
            _parts.Add(new Part(Carapace, "Carapace", this, 1));
            _parts.Add(new Part(Cerebrum, "Cerebrum", this, 1));
            _parts.Add(new Part(Systems, "Systems", this, 1));
        }
    }
}
