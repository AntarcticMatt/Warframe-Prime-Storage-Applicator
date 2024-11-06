using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warframe_Prime_Storage_Applicator
{
    class MeleeWeapon : Prime
    {
        int _status;
        public MeleeWeapon(int Status, string Name, int bp, int blade, int handle, string comp, string on) : base(Name)
        {
            _status = Status;
            _parts.Add(new Part(0, bp,"Blueprint", this, 1));
            if(_status == 1 || _status == 2)
            {

                _parts.Add(new Part(0, blade, comp, this, 2));
            }
            else
            {
                _parts.Add(new Part(0, blade, comp, this, 1));
            }
            if(_status == 1)
            {
                _parts.Add(new Part(0, handle, on, this, 2));
            }
            else
            {
                _parts.Add(new Part(0, handle, on, this, 1));
            }            
        }

        public MeleeWeapon(int Status, string Name, int bp, int blade, int handle, int guard, string comp, string on, string ents) : base(Name)
        {
            _status = Status;
            _parts.Add(new Part(0, bp, "Blueprint", this, 1));
            _parts.Add(new Part(0, blade, comp, this, 1));
            _parts.Add(new Part(0, handle, on, this, 1));
            _parts.Add(new Part(0, guard, ents, this, 1));
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
                int vale = 0;
                if (Owned)
                {
                    foreach (Part par in _parts)
                    {
                        vale += par.Ducats;
                    }
                }
                else
                {
                    if (Status == 0 || Status == 3)
                    {
                        foreach (Part par in _parts)
                        {
                            vale += par.ODucats(Owned);
                        }
                    }
                    else
                    {
                        if (Status == 1)
                        {
                            vale += _parts[0].LessNum(1) * _parts[0].Weight;
                            vale += _parts[1].LessNum(2) * _parts[1].Weight;
                            vale += _parts[2].LessNum(2) * _parts[2].Weight;
                        }
                        else
                        {
                            vale += _parts[0].LessNum(1) * _parts[0].Weight;
                            vale += _parts[1].LessNum(2) * _parts[1].Weight;
                            vale += _parts[2].LessNum(1) * _parts[2].Weight;
                        }
                    }
                }
                return vale;
            }
        }
    }
}
