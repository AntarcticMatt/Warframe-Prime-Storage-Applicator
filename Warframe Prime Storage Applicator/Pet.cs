using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warframe_Prime_Storage_Applicator
{
    class Pet : Prime
    {

        public Pet(string Name, int BP, int Band, int Buckle) : base(Name)
        {
            _parts.Add(new Part(BP, "Blueprint", this, 1));
            _parts.Add(new Part(Band, "Band", this, 1));
            _parts.Add(new Part(Buckle, "Buckle", this, 1));
        }
        
        
    }
}
