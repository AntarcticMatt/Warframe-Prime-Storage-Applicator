using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warframe_Prime_Storage_Applicator
{
    class Part
    {
        private int _number;
        private int _weight;
        private string _name;
        private Prime _daddy;
        private int _reductor;

        private bool _setRoot;
        private string _thumb, _id, _icon, _urlName, _iconFormat, _subIcon;
        private int _tradingTax, _masteryLevel, _ducats, _quantityForSet;
        private string[] _tags;

        public Part(int number, int weight, string name, Prime dad, int reduce)
        {
            _number = number;
            _weight = weight;
            _name = name;
            _daddy = dad;
            _reductor = reduce;
        }

        public Part(int weight, string name, Prime dad, int reduce)
        {
            _number = 0;
            _weight = weight;
            _name = name;
            _daddy = dad;
            _reductor = reduce;
        }

        public Part(bool setRoot, string thumb, string IDD, string icon, string urlName, string iconFormat, string subIcon, int tradingTax, int masteryLevel, int ducats, int quantityForSet, List<string> tags)
        {
            _setRoot = setRoot;
            _thumb = thumb;
            _id = IDD;
            _icon = icon;
            _urlName = urlName;
            _iconFormat = iconFormat;
            _subIcon = subIcon;
            _tradingTax = tradingTax;
            _masteryLevel = masteryLevel;
            _ducats = ducats;
            _quantityForSet = quantityForSet;
            _tags = new string[tags.Count - 1];
            for(int i = 0; i < tags.Count - 1; i++)
            {
                _tags[i] = tags[i];
            }
        }

        public Part(bool setRoot, string thumb, string IDD, string icon, string urlName, string iconFormat, string subIcon, int tradingTax, int masteryLevel, int ducats, List<string> tags)
        {
            _setRoot = setRoot;
            _thumb = thumb;
            _id = IDD;
            _icon = icon;
            _urlName = urlName;
            _iconFormat = iconFormat;
            _subIcon = subIcon;
            _tradingTax = tradingTax;
            _masteryLevel = masteryLevel;
            _ducats = ducats;
            _tags = new string[tags.Count];
            for (int i = 0; i < tags.Count; i++)
            {
                _tags[i] = tags[i];
            }
        }

        public string[] Tags
        {
            get
            {
                return _tags;
            }
        }

        public bool IsRoot
        {
            get
            {
                return _setRoot;
            }
        }

        public string ComponentTitle
        {
            get
            {
                /*foreach(string str in _tags)
                {
                    if (_urlName.Contains(str) && str != "prime")
                    {
                        //str = char.ToUpper(str[0]) + str.Substring(1);
                        return str;
                    }
                }
                return null;*/
                string[] dataPoint = _urlName.Split('_');
                bool nextOne = false;
                string dataOut = null;
                foreach (string str in dataPoint)
                {
                    if (nextOne)
                    {
                        nextOne = false;
                        dataOut = str.Replace("\"", "");
                        if (str.Contains("kubrow"))
                        {
                            dataOut = "blueprint";
                        }
                    }
                    if (str.Contains("prime"))
                    {
                        nextOne = true;
                    }
                }
                //dataOut = dataPoint[dataPoint.Length - 1].Replace("\"", "");
                
                return char.ToUpper(dataOut[0]) + dataOut.Substring(1);
            }
        }

        public string URLIMP
        {
            get
            {
                return _urlName;
            }
        }

        public int DucatsIMP
        {
            get
            {
                return _ducats;
            }
        }

        public int QtySetIMP
        {
            get
            {
                return _quantityForSet;
            }
        }

        public int Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                _weight = value;
            }
        }

        public int Number
        {
            get
            {
                return _number;
            }
            set
            {
                _number = value;
            }
        }

        public string Name
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

        public int Ducats
        {
            get
            {
                return Number * Weight;
            }
        }

        /// <summary>
        /// Returns a value, floored at 0, of how many items there are, lowered by imput.
        /// </summary>
        /// <param name="down"></param>
        /// <returns></returns>
        public int LessNum(int down)
        {
            if(_number <= down)
            {
                return 0;
            }
            else
            {
                return (_number - down);
            }
        }

        /// <summary>
        /// Returns Ducat value of the 'stack' accounting for item ownership.
        /// </summary>
        /// <param name="Owned">Do you own the item this part is a set of?</param>
        /// <returns></returns>
        public int ODucats(bool Owned)
        {
            if (Owned)
            {
                return Number * Weight;
            }
            else
            {
                if(Number <= 0)
                {
                    return 0;
                }
                else
                {
                    return (Number - 1) * Weight;
                }
            }
        }

        /// <summary>
        /// Returns Ducat value of the 'stack' accounting for item ownership. For exclusive use in Secondary weapons.
        /// </summary>
        /// <param name="Owned">Do you own the item this part is a set of?</param>
        /// <returns></returns>
        public int OSDucats(bool Owned, int Status)
        {
            if (Owned)
            {
                return Number * Weight;                
            }
            else
            {
                if (Number <= 1)
                {
                    return 0;
                }
                else
                {
                    if (Status == 1)
                    {
                        if (Name == "Barrel" || Name == "Receiver")
                        {
                            return (Number - 2) * Weight;
                        }
                        else
                        {
                            return (Number - 1) * Weight;
                        }
                    }
                    else
                    {
                        return (Number - 1) * Weight;
                    }
                }
            }
        }
        
        public virtual string SListGen
        {
            get
            {
                return _daddy.Name + " " + Name + " x" + Reduced;
            }
        }

        public virtual string Reduced
        {
            get
            {
                if (_daddy.Owned)
                {
                    return _number.ToString();
                }
                else
                {
                    return (_number - _reductor).ToString();
                }
            }
        }

        public virtual bool SListCheck
        {
            get
            {
                if (_daddy.Owned && Number > 0)
                {
                    return true;
                }
                else
                {
                    if (Number > _reductor)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public override string ToString()
        {
            return _number.ToString();
        }
    }
}
