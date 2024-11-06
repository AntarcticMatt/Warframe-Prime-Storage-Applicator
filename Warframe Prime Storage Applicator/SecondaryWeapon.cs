using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warframe_Prime_Storage_Applicator
{
    class SecondaryWeapon : Prime
    {
        string _linked;
        int _status;

        public SecondaryWeapon(string Name, int Blueprint, int Barrel, int Receiver) : base(Name)
        {
            _parts.Add(new Part(Blueprint, "Blueprint", this, 1));
            _parts.Add(new Part(Barrel, "Barrel", this, 1));
            _parts.Add(new Part(Receiver, "Receiver", this, 1));
            _status = 0;
        }

        public SecondaryWeapon(string Name, int Blueprint, int Barrel, int Receiver, int Link) : base(Name)
        {
            _parts.Add(new Part(Blueprint, "Blueprint", this, 1));
            _parts.Add(new Part(Barrel, "Barrel", this, 2));
            _parts.Add(new Part(Receiver, "Receiver", this, 2));
            _parts.Add(new Part(Link, "Link", this, 1));
            _status = 1;
        }

        public SecondaryWeapon(string Name, int Blueprint, int Link, string Linked) : base(Name)
        {
            _parts.Add(new Part(Blueprint, "Blueprint", this, 1));
            _parts.Add(new Part(Link, "Link", this, 1));
            _linked = Linked;
            _status = 2;
        }

        public SecondaryWeapon(string Name, int Blueprint, int Barrel, int Receiver, int Link, int Fifth) : base(Name)
        {
            _parts.Add(new Part(Blueprint, "Blueprint", this, 1));
            _parts.Add(new Part(Blueprint, "Lower Limb", this, 1));
            _parts.Add(new Part(Blueprint, "Upper Limb", this, 1));
            _parts.Add(new Part(Blueprint, "Receiver", this, 1));
            _parts.Add(new Part(Blueprint, "String", this, 1));
            _status = 3;
        }

        public override int Status
        {
            get
            {
                return _status;
            }
        }

        /// <summary>
        /// Returns Ducat value of the components accounting for item ownership.
        /// </summary>
        public override int ODucats
        {
            get
            {
                int value = 0;                 
                    foreach (Part par in _parts)
                    {
                        value += par.OSDucats(_owned, Status);
                    }
                return value;
            }
        }
    }
}
