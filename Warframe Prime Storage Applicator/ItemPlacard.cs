using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warframe_Prime_Storage_Applicator
{
    class ItemPlacard
    {
        string IDcode;
        string name;
        string url;
        string thumb;

        public ItemPlacard(string code, string Nam, string youAreEl, string bigFinger)
        {
            IDcode = code;
            name = Nam;
            url = youAreEl;
            thumb = bigFinger;
        }

        public override string ToString()
        {
            return name;
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public string URL
        {
            get
            {
                return url;
            }
        }

        public String[] dataDump
        {
            get
            {
                return new string[] { IDcode, name, url, thumb };
            }
        }
    }
}
