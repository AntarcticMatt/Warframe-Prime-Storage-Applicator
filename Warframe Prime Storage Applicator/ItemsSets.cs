using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warframe_Prime_Storage_Applicator
{
    class ItemsSets : Prime
    {
        private Part _blueprint;

        public ItemsSets(List<Part> pars) : base(pars)
        {
            DetermineBlueprint();
            InsertSortPart(_parts);
        }

        public string OutputText()
        {
            string comma = ",";
            string outputy = _leadPart.URLIMP.Replace("\"",""); //+ comma + _leadPart.Name?;
            outputy = outputy + comma + _blueprint.DucatsIMP + comma + _blueprint.ComponentTitle;
            foreach(Part par in _parts)
            {
                outputy = outputy + comma + par.DucatsIMP + comma + par.QtySetIMP + comma + par.ComponentTitle;
            }
            return outputy;
        }

        private void DetermineBlueprint()
        {
            Part park = null;
            foreach (Part par in _parts)
            {
                if(par.ComponentTitle == "Blueprint")
                {
                    _blueprint = par;
                    park = par;                    
                }
            }
            _parts.Remove(park);
        }

        /// <summary>
        /// Sorts any list of 'Part' it is given alphabetically.
        /// </summary>
        /// <param name="LP"></param>
        private void InsertSortPart(List<Part> LP)
        {
            //Check each object after the first.
            for (int i = 1; i < LP.Count; i++)
            {
                //Compare it's name
                string Obj1 = LP[i].ComponentTitle;

                //Against every later object
                for (int j = 0; j < i; j++)
                {
                    //For it's name
                    string Obj2 = LP[j].ComponentTitle;

                    //If earlier
                    if (StringCompare(Obj1, Obj2))
                    {
                        //Add it
                        LP.Insert(j, LP[i]);
                        //Remove the old
                        LP.RemoveAt(i + 1);
                        //And stop it checking.
                        j = i;
                    }
                }
            }
        }

        /// <summary>
        /// Determines which comes first alphabetically. True == theFirst, false == theSecond.
        /// </summary>
        /// <param name="theFirst">Compare this.</param>
        /// <param name="theSecond">Against this.</param>
        /// <returns></returns>
        private bool StringCompare(string theFirst, string theSecond)
        {
            for (int i = 0; (i < theFirst.Length) && (i < theSecond.Length); i++)
            {
                if (theFirst[i] < theSecond[i])
                {
                    return true;
                }
                else
                {
                    if (theFirst[i] > theSecond[i])
                    {
                        return false;
                    }
                }
            }
            if (theFirst.Length < theSecond.Length)
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
