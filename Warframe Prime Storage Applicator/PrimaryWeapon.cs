using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warframe_Prime_Storage_Applicator
{
    class PrimaryWeapon : Prime
    {
        bool _requiresFifth;

        public PrimaryWeapon(string Name, int Blueprint, int Barrel, int Receiver, int Stock, string com, string po, string nents) : base(Name)
        {
            _parts.Add(new Part(Blueprint, "Blueprint", this, 1));
            _parts.Add(new Part(Barrel, com, this, 1));
            _parts.Add(new Part(Receiver, po, this, 1));
            _parts.Add(new Part(Stock, nents, this, 1));
            _requiresFifth = false;
        }

        public PrimaryWeapon(string Name, int Blueprint, int Barrel, int Receiver, int Stock, int fifth, string com, string po, string nen, string ts) : base(Name)
        {
            _parts.Add(new Part(Blueprint, "Blueprint", this, 1));
            _parts.Add(new Part(Barrel, com, this, 1));
            _parts.Add(new Part(Receiver, po, this, 1));
            _parts.Add(new Part(Stock, nen, this, 1));
            _parts.Add(new Part(Stock, ts, this, 1));
            _requiresFifth = true;
        }

        public override bool NeedsFifth
        {
            get
            {
                return _requiresFifth;
            }
        }
    }
}
