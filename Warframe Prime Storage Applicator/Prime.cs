using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warframe_Prime_Storage_Applicator
{
    /// <summary>
    /// The basic framework for all prime classes.
    /// Most calls are standard across all sub-classes.
    /// </summary>
    abstract class Prime
    {
        private string _name;
        protected List<Part> _parts = new List<Part>();
        protected bool _owned;
        protected Part _leadPart;

        public Prime(string Name)
        {
            _name = Name;
            _owned = false;
        }              

        public Prime(List<Part> parts)
        {
            _parts = new List<Part>(parts);

            calculateLead();
        }

        public virtual string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public virtual List<string> Names
        {
            get
            {
                List<string> tempList = new List<string>();
                foreach (Part par in _parts) { tempList.Add(par.Name); }
                return tempList;
            }
        }

        public virtual List<Part> Parts
        {
            get
            {
                return _parts;
            }
        }

        public virtual int First
        {
            get
            {
                return _parts[0].Number;
            }
            set
            {
                _parts[0].Number = value;
            }
        }

        public virtual int Second
        {
            get
            {
                return _parts[1].Number;
            }
            set
            {
                _parts[1].Number = value;
            }
        }

        public virtual int Third
        {
            get
            {
                return _parts[2].Number;
            }
            set
            {
                _parts[2].Number = value;
            }
        }

        public virtual int Fourth
        {
            get
            {
                return _parts[3].Number;
            }
            set
            {
                _parts[3].Number = value;
            }
        }

        public virtual int Fifth
        {
            get
            {
                return _parts[4].Number;
            }
            set
            {
                _parts[4].Number = value;
            }
        }
        /// <summary>
        /// Returns the owned value in boolean form.
        /// </summary>
        public virtual bool Owned
        {
            get
            {
                return _owned;
            }
            set
            {
                _owned = value;
            }
        }
        /// <summary>
        /// Returns a string based on the owned boolean.
        /// </summary>
        public virtual string _Owned
        {
            get
            {
                if (_owned)
                {
                    return " Owned";
                }
                else
                {
                    return " Not Owned";
                }
            }
        }
        /// <summary>
        /// Returns something? Update this property.
        /// </summary>
        public virtual string Weights
        {
            get
            {
                return _parts[0].Weight.ToString();
            }
        }

        public override string ToString()
        {
            return Name.PadRight(10) + _Owned;
        }

        public virtual string Output()
        {
            string output = "";
            output += Name.PadLeft(13) + ", " + Owned.ToString().PadLeft(6);
            foreach(Part part in _parts)
            {
                output += ", " + part.ToString().PadLeft(10);
            }
            return output;
        }
        /// <summary>
        /// Returns the total Ducats, with no conditionals.
        /// Weight * Number
        /// </summary>
        public int Ducats
        {
            get
            {
                int value = 0;
                foreach(Part par in _parts)
                {
                    value += par.Ducats;
                }
                return value;
            }
        }

        /// <summary>
        /// Returns Ducat value of the components accounting for item ownership.
        /// </summary>
        public virtual int ODucats
        {
            get
            {
                int value = 0;
                foreach(Part par in _parts)
                {
                    value += par.ODucats(_owned);
                }
                return value;
            }
        }


        //Stuff beyond this point is to allow all Prime parts to be Prime, it is not actually used for everything.

        public virtual bool NeedsFifth
        {
            get
            {
                return false;
            }
        }

        public virtual int Status
        {
            get
            {
                return 0;
            }
        }

        //For warframe market integration

        public virtual Part AssignLead
        {
            get
            {
                return _leadPart;
            }
            set
            {
                _leadPart = value;
            }
        }

        public void calculateLead()
        {
            Part park = null;
            foreach (Part par in _parts)
            {
                if (par.IsRoot)
                {
                    _leadPart = par;
                    park = par;
                }
            }
            _parts.Remove(park);            
        }
    }
}
