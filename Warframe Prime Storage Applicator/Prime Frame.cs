using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warframe_Prime_Storage_Applicator
{
    /// <summary>
    /// This class is used to store how many of each prime frame piece stored
    /// </summary>
    class Prime_Frame : Prime
    {
        
        public Prime_Frame(string Name, int Blueprint, int Chassis, int Neuroptics, int Systems) : base(Name)
        {
            _parts.Add(new Part(0, Blueprint, "Blueprint", this, 1));
            _parts.Add(new Part(0, Chassis, "Chassis", this, 1));
            _parts.Add(new Part(0, Neuroptics, "Neuroptics", this, 1));
            _parts.Add(new Part(0, Systems, "Systems", this, 1));
        }
        
    }
}
