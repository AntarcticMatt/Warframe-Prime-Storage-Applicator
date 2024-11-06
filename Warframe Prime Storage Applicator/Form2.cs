using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;

namespace Warframe_Prime_Storage_Applicator
{
    public partial class Form2 : Form
    {
        const string URL = "https://api.warframe.market/v1/";
        //const string Key = "";

        string urlParam;
            //= "items";
        //?api_key=thepurplefrogateagreenfish

        BindingList<string> jklLol = new BindingList<string>();
        String[] dataII;
        StreamWriter writer;
        StreamReader reader;

        BindingList<ItemPlacard> itemPlacards = new BindingList<ItemPlacard>();
        BindingList<ItemPlacard> primePlacards = new BindingList<ItemPlacard>();

        BindingList<string> placardDisplay = new BindingList<string>();

        HttpClient client = new HttpClient();

        //Variables for building Items/Sets
        String[] itemMold = new string[11];//{ "", "", "", "", "", "", "", "", "", "", "" };
        List<string> tagsMold = new List<string>();
        //Bool, String, String, String, String, String, String, Int, Int, Int, Int
        List<string> checks = new List<string> { "\"set_root\"", "\"thumb\"", "\"id\"", "\"icon\"", "\"url_name\"", "\"icon_format\"", "\"sub_icon\"", "\"trading_tax\"", "\"mastery_level\"", "\"ducats\"", "\"quantity_for_set\"" };
        String[] splited;
        bool tagged = false;
        //Output storage
        List<ItemsSets> _accumulatedMass = new List<ItemsSets>();

        public Form2()
        {
            InitializeComponent();

            client.BaseAddress = new Uri(URL);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));            
        }               

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.F1Toggle();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            listBoxModdedStats.DataSource = jklLol;
        }

        private void ButtonWriteFile_Click(object sender, EventArgs e)
        {
            writer = File.CreateText("References/exampleSample.txt");

            foreach(string str in dataII)
            {
                writer.WriteLine(str);
            }

            writer.Close();
        }

        private void ButtonPullData_Click(object sender, EventArgs e)
        {
            urlParam = "items";

            HttpResponseMessage response = client.GetAsync(urlParam).Result;
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Pink Fish");
                dataII = response.Content.ReadAsStringAsync().Result.Split(',');
                foreach (string str in dataII)
                {
                    jklLol.Add(str);
                }

            }
            else
            {
                MessageBox.Show(response.ToString());
            }
        }

        private void ButtonReprocess_Click(object sender, EventArgs e)
        {
            string[] line1 = null, line2 = null, line3 = null, line4 = null;
            string[] line0;

            reader = File.OpenText("References/exampleSample.txt");

            while (!reader.EndOfStream)
            {
                while (line1 == null || line2 == null || line3 == null || line4 == null)
                {
                    line0 = reader.ReadLine().Split('"');
                    if (line0.Contains<string>("id"))
                    { line1 = line0; }
                    else
                    {
                        if (line0.Contains<string>("item_name"))
                        { line2 = line0; }
                        else
                        {
                            if (line0.Contains<string>("url_name"))
                            { line3 = line0; }
                            else
                            {
                                if (line0.Contains<string>("thumb")) { line4 = line0; }
                            }
                        }
                    }
                }                

                itemPlacards.Add(new ItemPlacard(line1[3], line2[3], line3[3], line4[3]));
                line1 = null;
                line2 = null;
                line3 = null;
                line4 = null;
            }

            reader.Close();
        }

        private void ButtonDisplayPlacards_Click(object sender, EventArgs e)
        {
            listBoxModdedStats.DataSource = itemPlacards;
        }

        private void ButtonPrimeSort_Click(object sender, EventArgs e)
        {
            foreach (ItemPlacard ippy in itemPlacards)
            {
                if (ippy.Name.Contains("Prime") && ippy.Name.Contains("Set"))
                {
                    primePlacards.Add(ippy);
                }
            }
            InsertSortPrime(primePlacards);
        }

        private void ButtonDispPrime_Click(object sender, EventArgs e)
        {
            listBoxModdedStats.DataSource = primePlacards;
        }

        private void ButtonSpecCall_Click(object sender, EventArgs e)
        {
            // This is posing an issue to the new 'Make Everything' button
            urlParam = "items/" + primePlacards[listBoxModdedStats.SelectedIndex].URL;
            // This is posing an issue to the new 'Make Everything' button
            CallAnItem();
        }

        private void CallAnItem()
        {
            jklLol.Clear();

            HttpResponseMessage response = client.GetAsync(urlParam).Result;
            if (response.IsSuccessStatusCode)
            {
                dataII = response.Content.ReadAsStringAsync().Result.Split(',');
                foreach (string str in dataII)
                {
                    jklLol.Add(str);
                }
            }
            else
            {
                MessageBox.Show(response.ToString());
            }
        }

        private void ListBoxModdedStats_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxModdedStats.DataSource == primePlacards)
            {
                placardDisplay.Clear();
                foreach (string str in primePlacards[listBoxModdedStats.SelectedIndex].dataDump)
                {
                    placardDisplay.Add(str);
                }
                listBoxBaseStats.DataSource = placardDisplay;
            }
        }

        private void ButtonWriteItem_Click(object sender, EventArgs e)
        {
            writer = File.CreateText("References/" + placardDisplay[1] + ".txt");

            foreach (string str in jklLol)
            {
                writer.WriteLine(str);
            }

            writer.Close();
        }

        private void ButtonMakePrime_Click(object sender, EventArgs e)
        {
            ConstructAnItem();
        }

        private void ConstructAnItem()
        {
            ClearSetMolds();

            List<Part> toBuild = new List<Part>();

            foreach (string str in jklLol)
            {
                if (str.Contains("\"tags\""))
                {
                    tagged = true;
                    splited = str.Split('"');
                    tagsMold.Add(splited[3]);
                    if (str.Contains("]"))
                    {
                        tagged = false;
                    }
                }
                else
                {
                    if (tagged)
                    {
                        if (str.Contains("]"))
                        {
                            tagged = false;
                        }
                        splited = str.Split('"');
                        tagsMold.Add(splited[1]);
                    }
                    else
                    {
                        if (str.Contains("\"payload\"") == false)
                        {
                            for (int x = 0; x < checks.Count; x++)
                            {
                                if (str.Contains(checks[x]))
                                {
                                    if (str.Contains("\"items_in_set\""))
                                    {
                                        splited = str.Split(':');
                                        splited[2].Replace("\"", "");
                                        itemMold[x] = splited[2].Trim();
                                    }
                                    else
                                    {
                                        splited = str.Split(':');
                                        splited[1].Replace("\"", "");
                                        itemMold[x] = splited[1].Trim();
                                    }
                                }
                            }
                        }
                    }
                }
                splited = null;

                if (str.Contains("\"ru\""))
                {
                    if (itemMold[7] == "") { itemMold[7] = "0"; }
                    if (itemMold[8] == "") { itemMold[8] = "0"; }
                    if (itemMold[9] == "") { itemMold[9] = "0"; }
                    if (itemMold[10] == "")
                    {
                        toBuild.Add(new Part(bool.Parse(itemMold[0]), itemMold[1], itemMold[2], itemMold[3], itemMold[4], itemMold[5], itemMold[6], int.Parse(itemMold[7]), int.Parse(itemMold[8]), int.Parse(itemMold[9]), tagsMold));
                    }
                    else
                    {
                        toBuild.Add(new Part(bool.Parse(itemMold[0]), itemMold[1], itemMold[2], itemMold[3], itemMold[4], itemMold[5], itemMold[6], int.Parse(itemMold[7]), int.Parse(itemMold[8]), int.Parse(itemMold[9]), int.Parse(itemMold[10]), tagsMold));
                    }

                    ClearSetMolds();
                }
            }
            _accumulatedMass.Add(new ItemsSets(toBuild));
        }

        private void ClearSetMolds()
        {
            for(int x = 0; x < itemMold.Count<string>(); x++)
            {
                itemMold[x] = "";
            }
            tagsMold.Clear();
        }

        private void ButtonOutputPrime_Click(object sender, EventArgs e)
        {
            writer = File.CreateText("References/"+ "ForNow" +".txt");
            foreach (ItemsSets pri in _accumulatedMass)
            {
                writer.WriteLine(pri.OutputText());
            }
            writer.Close();
        }

        private void InsertSortPrime(BindingList<ItemPlacard> LIP)
        {
            //Check each object after the first.
            for (int i = 1; i < LIP.Count; i++)
            {
                //Compare it's name
                string Obj1 = LIP[i].Name;

                //Against every later object
                for (int j = 0; j < i; j++)
                {
                    //For it's name
                    string Obj2 = LIP[j].Name;

                    //If earlier
                    if (StringCompare(Obj1, Obj2))
                    {
                        //Add it
                        LIP.Insert(j, LIP[i]);
                        //Remove the old
                        LIP.RemoveAt(i + 1);
                        //And stop it checking.
                        j = i;
                    }
                }
            }
        }

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

        private void ButtonMakeThemAll_Click(object sender, EventArgs e)
        {
            labelCounterA.Text = "0";
            int counterise = 0;
            labelCounterB.Text = primePlacards.Count.ToString();
            foreach(ItemPlacard ite in primePlacards)
            {
                counterise = counterise + 1;
                labelCounterA.Text = counterise.ToString();
                urlParam = "items/" + ite.URL;
                CallAnItem();
                ConstructAnItem();
            }
        }
    }
}
