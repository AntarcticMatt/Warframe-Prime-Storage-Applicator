using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Warframe_Prime_Storage_Applicator
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Form1 : Form
    {
        //Making my more permanent variables and objects
        StreamReader reader;
        StreamWriter writer;

        BindingList<Prime> Frames = new BindingList<Prime>();
        BindingList<Prime> Primaries = new BindingList<Prime>();
        BindingList<Prime> Secondaries = new BindingList<Prime>();
        BindingList<Prime> Melee = new BindingList<Prime>();
        BindingList<Prime> Archwings = new BindingList<Prime>();
        BindingList<Prime> Sentinels = new BindingList<Prime>();
        BindingList<Prime> Pets = new BindingList<Prime>();

        /// <summary>
        /// List of List of Primes.
        /// Frames, Primaries, Secondaries, Melee, Archwings, Sentinels, Pets.
        /// </summary>
        List<BindingList<Prime>> PrimeArray = new List<BindingList<Prime>>();

        /// <summary>
        /// List of all items to sell for ducats.
        /// Generated on click.
        /// </summary>
        List<Part> SList = new List<Part>();

        /// <summary>
        /// List of all prime things.
        /// Sorted alphabetically.
        /// Generated on start up.
        /// </summary>
        BindingList<Prime> AllPrimes = new BindingList<Prime>();

        int checker = 0;
        int prevIndex = 0;
        int prevCheck = 0;
        string[] import = new string[2];
        int[] ducats = new int[7];
        int[] ducatsO = new int[7];

        /// <summary>
        /// If true, need to do a save.
        /// If false, good to quit.
        /// </summary>
        bool saveCheck = true;
        bool listRefresh = true;
        const string startPath = "References/Startup.txt";

        bool onTop = false;

        public Form1()
        {
            string[] tempRead = { "" };
            string name;
            int bp;
            int chas;
            int neur;
            int sys;
            int fifth;
            int changer = 0;
            string linked;

            InitializeComponent();

            PrimeArray.Add(Frames);
            PrimeArray.Add(Primaries);
            PrimeArray.Add(Secondaries);
            PrimeArray.Add(Melee);
            PrimeArray.Add(Archwings);
            PrimeArray.Add(Sentinels);
            PrimeArray.Add(Pets);

            tabControlDucats.SelectedIndex = 0;

            try
            {
                reader = File.OpenText("References/Frame Weights.txt");

                while (!reader.EndOfStream)
                {
                    tempRead = reader.ReadLine().Split(',');
                    name = tempRead[0].Trim();
                    bp = Int32.Parse(tempRead[1]);
                    chas = Int32.Parse(tempRead[2]);
                    neur = Int32.Parse(tempRead[3]);
                    sys = Int32.Parse(tempRead[4]);

                    Frames.Add(new Prime_Frame(name, bp, chas, neur, sys));
                }
                reader.Close();

                reader = File.OpenText("References/Primary Weights.txt");

                while (!reader.EndOfStream)
                {
                    tempRead = reader.ReadLine().Split(',');
                    bp = Int32.Parse(tempRead[1]);
                    chas = Int32.Parse(tempRead[2]);
                    neur = Int32.Parse(tempRead[3]);
                    sys = Int32.Parse(tempRead[4]);
                    if (tempRead.Length >= 9)
                    {
                        fifth = Int32.Parse(tempRead[5]);
                        Primaries.Add(new PrimaryWeapon(tempRead[0].Trim(), bp, chas, neur, sys, fifth, tempRead[6], tempRead[7], tempRead[8], tempRead[9]));
                    }
                    else
                    {
                        Primaries.Add(new PrimaryWeapon(tempRead[0].Trim(), bp, chas, neur, sys, tempRead[5], tempRead[6], tempRead[7]));
                    }
                }
                reader.Close();

                reader = File.OpenText("References/Secondary Weights.txt");

                while (!reader.EndOfStream)
                {
                    tempRead = reader.ReadLine().Split(',');
                    changer = Int32.Parse(tempRead[0]);
                    name = tempRead[1].Trim();
                    bp = Int32.Parse(tempRead[2]);
                    chas = Int32.Parse(tempRead[3]);

                    if (changer != 2)
                    {
                        neur = Int32.Parse(tempRead[4]);
                        if(changer != 0)
                        {
                            sys = Int32.Parse(tempRead[5]);
                            if(changer == 3)
                            {
                                fifth = Int32.Parse(tempRead[6]);
                                Secondaries.Add(new SecondaryWeapon(name, bp, chas, neur, sys, fifth));
                            }
                            else
                            {
                                Secondaries.Add(new SecondaryWeapon(name, bp, chas, neur, sys));
                            }
                        }
                        else
                        {
                            Secondaries.Add(new SecondaryWeapon(name, bp, chas, neur));
                        }
                    }
                    else
                    {
                        linked = tempRead[4];
                        Secondaries.Add(new SecondaryWeapon(name, bp, chas, linked));
                    }
                }
                reader.Close();

                reader = File.OpenText("References/Melee Weights.txt");

                while (!reader.EndOfStream)
                {
                    tempRead = reader.ReadLine().Split(',');
                    changer = Int32.Parse(tempRead[0]);
                    name = tempRead[1].Trim();
                    bp = Int32.Parse(tempRead[2]);
                    if (changer == 3)
                    {
                        Melee.Add(new MeleeWeapon(changer, name, bp, Int32.Parse(tempRead[3]), Int32.Parse(tempRead[4]), Int32.Parse(tempRead[5]), tempRead[6].Trim(), tempRead[7].Trim(), tempRead[8].Trim()));
                    }
                    else
                    {
                        Melee.Add(new MeleeWeapon(changer, name, bp, Int32.Parse(tempRead[3]), Int32.Parse(tempRead[4]), tempRead[5].Trim(), tempRead[6].Trim()));
                    }
                }
                reader.Close();

                reader = File.OpenText("References/Archwing Weights.txt");

                while (!reader.EndOfStream)
                {
                    tempRead = reader.ReadLine().Split(',');
                    name = tempRead[0].Trim();
                    bp = Int32.Parse(tempRead[1]);
                    chas = Int32.Parse(tempRead[2]);
                    neur = Int32.Parse(tempRead[3]);
                    sys = Int32.Parse(tempRead[4]);

                    Archwings.Add(new Archwing(name, bp, chas, neur, sys));

                }
                reader.Close();

                reader = File.OpenText("References/Sentinel Weights.txt");

                while (!reader.EndOfStream)
                {
                    tempRead = reader.ReadLine().Split(',');
                    name = tempRead[0].Trim();
                    bp = Int32.Parse(tempRead[1]);
                    chas = Int32.Parse(tempRead[2]);
                    neur = Int32.Parse(tempRead[3]);
                    sys = Int32.Parse(tempRead[4]);

                    Sentinels.Add(new Sentinel(name, bp, chas, neur, sys));

                }
                reader.Close();

                reader = File.OpenText("References/Pet Weights.txt");

                while (!reader.EndOfStream)
                {
                    tempRead = reader.ReadLine().Split(',');
                    name = tempRead[0].Trim();
                    bp = Int32.Parse(tempRead[1]);
                    chas = Int32.Parse(tempRead[2]);
                    neur = Int32.Parse(tempRead[3]);

                    Pets.Add(new Pet(name, bp, chas, neur));

                }
                reader.Close();

                if (File.Exists(startPath))
                {
                    reader = File.OpenText(startPath);
                    import[0] = reader.ReadLine();
                    import[1] = reader.ReadLine();
                    reader.Close();
                    this.Text = "Warframe Prime Storage Applicator - " + import[0];
                    ReadSave(import[1]);
                }

            }
            catch
            {
                MessageBox.Show("Error in initialization: " + tempRead[0]);
                reader.Close();
            }

            try
            {
                foreach(BindingList<Prime> li in PrimeArray)
                {
                    foreach(Prime pri in li)
                    {
                        AllPrimes.Add(pri);
                    }
                }
                InsertSortPrime(AllPrimes);
            }
            catch
            {
                MessageBox.Show("Error in intialization: Sorted List");
            }


            listBoxFrames.DataSource = Frames;

            numericUpDownFirst.Value = Frames[0].First;
            numericUpDownSecond.Value = Frames[0].Second;
            numericUpDownThird.Value = Frames[0].Third;
            numericUpDownFourth.Value = Frames[0].Fourth;
        }

        private void OpenFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Comma Separated Values (*.csv)|*.csv|All Files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ReadSave(openFileDialog1.FileName);
                this.Text = "Warframe Prime Storage Applicator - " + openFileDialog1.SafeFileName;
            }
            else
            {
                MessageBox.Show("Please select a file.");
            }
        }

        public void ReadSave(string path)
        {
            string[] tempRead = { };
            int counter = 0;
            int timer = 0;

            try
            {

                reader = File.OpenText(path);

                while (!reader.EndOfStream)
                {
                    tempRead = reader.ReadLine().Split(',');
                    if (tempRead[0].Trim() == "Frame")
                    {
                        timer = 0;
                        counter = 0;

                        tempRead = reader.ReadLine().Split(',');
                    }
                    if (tempRead[0].Trim() == "Primary")
                    {
                        timer = 1;
                        counter = 0;

                        tempRead = reader.ReadLine().Split(',');
                    }
                    if (tempRead[0].Trim() == "Secondary")
                    {
                        timer = 2;
                        counter = 0;

                        tempRead = reader.ReadLine().Split(',');
                    }
                    if (tempRead[0].Trim() == "Melee")
                    {
                        timer = 3;
                        counter = 0;

                        tempRead = reader.ReadLine().Split(',');
                    }
                    if (tempRead[0].Trim() == "Archwing")
                    {
                        timer = 4;
                        counter = 0;

                        tempRead = reader.ReadLine().Split(',');
                    }
                    if (tempRead[0].Trim() == "Sentinel")
                    {
                        timer = 5;
                        counter = 0;

                        tempRead = reader.ReadLine().Split(',');
                    }
                    if (tempRead[0].Trim() == "Pet")
                    {
                        timer = 6;
                        counter = 0;

                        tempRead = reader.ReadLine().Split(',');
                    }
                    if (timer == 0)
                    {
                        while (Frames[counter].Name != tempRead[0].Trim())
                        {
                            counter++;
                        }
                        Frames[counter].Owned = bool.Parse(tempRead[1]);
                        Frames[counter].First = Int32.Parse(tempRead[2]);
                        Frames[counter].Second = Int32.Parse(tempRead[3]);
                        Frames[counter].Third = Int32.Parse(tempRead[4]);
                        Frames[counter].Fourth = Int32.Parse(tempRead[5]);
                    }

                    if (timer == 1)
                    {
                        while (Primaries[counter].Name != tempRead[0].Trim())
                        {
                            counter++;
                        }
                        Primaries[counter].Owned = bool.Parse(tempRead[1]);
                        Primaries[counter].First = Int32.Parse(tempRead[2]);
                        Primaries[counter].Second = Int32.Parse(tempRead[3]);
                        Primaries[counter].Third = Int32.Parse(tempRead[4]);
                        Primaries[counter].Fourth = Int32.Parse(tempRead[5]);
                        if (Primaries[counter].NeedsFifth)
                        {
                            Primaries[counter].Fifth = Int32.Parse(tempRead[6]);
                        }
                    }
                    if (timer == 2)
                    {
                        while (Secondaries[counter].Name != tempRead[0].Trim())
                        {
                            counter++;
                        }
                        Secondaries[counter].Owned = bool.Parse(tempRead[1]);
                        Secondaries[counter].First = Int32.Parse(tempRead[2]);
                        Secondaries[counter].Second = Int32.Parse(tempRead[3]);
                        if (Secondaries[counter].Status != 2)
                        {
                            Secondaries[counter].Third = Int32.Parse(tempRead[4]);
                        }
                        if (Secondaries[counter].Status == 1)
                        {
                            Secondaries[counter].Fourth = Int32.Parse(tempRead[5]);
                        }
                        if (Secondaries[counter].Status == 3)
                        {
                            Secondaries[counter].Fourth = Int32.Parse(tempRead[5]);
                            Secondaries[counter].Fifth = Int32.Parse(tempRead[6]);
                        }
                    }
                    if (timer == 3)
                    {
                        while (Melee[counter].Name != tempRead[0].Trim())
                        {
                            counter++;
                        }
                        Melee[counter].Owned = bool.Parse(tempRead[1]);
                        Melee[counter].First = Int32.Parse(tempRead[2]);
                        Melee[counter].Second = Int32.Parse(tempRead[3]);
                        Melee[counter].Third = Int32.Parse(tempRead[4]);
                        if (Melee[counter].Status == 3)
                        {
                            Melee[counter].Fourth = Int32.Parse(tempRead[5]);
                        }
                    }
                    if (timer == 4)
                    {
                        while (Archwings[counter].Name != tempRead[0].Trim())
                        {
                            counter++;
                        }
                        Archwings[counter].Owned = bool.Parse(tempRead[1]);
                        Archwings[counter].First = Int32.Parse(tempRead[2]);
                        Archwings[counter].Second = Int32.Parse(tempRead[3]);
                        Archwings[counter].Third = Int32.Parse(tempRead[4]);
                        Archwings[counter].Fourth = Int32.Parse(tempRead[5]);
                    }
                    if (timer == 5)
                    {
                        while (Sentinels[counter].Name != tempRead[0].Trim())
                        {
                            counter++;
                        }
                        Sentinels[counter].Owned = bool.Parse(tempRead[1]);
                        Sentinels[counter].First = Int32.Parse(tempRead[2]);
                        Sentinels[counter].Second = Int32.Parse(tempRead[3]);
                        Sentinels[counter].Third = Int32.Parse(tempRead[4]);
                        Sentinels[counter].Fourth = Int32.Parse(tempRead[5]);
                    }
                    if (timer == 6)
                    {
                        while (Pets[counter].Name != tempRead[0].Trim())
                        {
                            counter++;
                        }
                        Pets[counter].Owned = bool.Parse(tempRead[1]);
                        Pets[counter].First = Int32.Parse(tempRead[2]);
                        Pets[counter].Second = Int32.Parse(tempRead[3]);
                        Pets[counter].Third = Int32.Parse(tempRead[4]);
                    }
                    counter++;
                }
                reader.Close();

                listRefresh = false;
                listBoxFrames.DataSource = null;
                listBoxFrames.DataSource = Frames;

                listBoxFrames.SelectedIndex = 0;

                PullData();

                listRefresh = true;

                string[] that = path.Split('\\');

                import[0] = that[that.Length - 1];
                import[1] = path;

                writer = File.CreateText(startPath);
                writer.WriteLine(import[0]);
                writer.WriteLine(import[1]);
                writer.Close();
            }
            catch
            {
                MessageBox.Show("Formatting Error: " + tempRead[0]);
                reader.Close();
            }
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AsToFile();
        }

        public void (string path)
        {
            WriteIn();
            saveCheck = false;

            writer = File.CreateText(path);

            writer.WriteLine("Frame".PadRight(13) + ",Owned".PadRight(8) + ",Blueprint".PadRight(12) + ",Chassis".PadRight(12) + ",Neuroptics".PadRight(12) + ",Systems".PadRight(12));

            foreach (Prime_Frame prime in Frames)
            {
                writer.WriteLine(prime.Output());
            }

            writer.WriteLine("Primary".PadRight(13) + ",Owned".PadRight(8) + ",Blueprint".PadRight(12) + ",Barrel".PadRight(12) + ",Receiver".PadRight(12) + ",Stock".PadRight(12) + ",Fifth".PadRight(12));

            foreach (PrimaryWeapon prime in Primaries)
            {
                writer.WriteLine(prime.Output());
            }

            writer.WriteLine("Secondary".PadRight(13) + ",Owned".PadRight(8) + ",Blueprint".PadRight(12) + ",Barrel".PadRight(12) + ",Receiver".PadRight(12) + ",Link".PadRight(12) + ",Fifth".PadRight(12));

            foreach (SecondaryWeapon prime in Secondaries)
            {
                writer.WriteLine(prime.Output());
            }

            writer.WriteLine("Melee".PadRight(13) + ",Owned".PadRight(8) + ",Blueprint".PadRight(12) + ",Blade".PadRight(12) + ",Handle".PadRight(12) + ",Guard".PadRight(12));

            foreach (MeleeWeapon prime in Melee)
            {
                writer.WriteLine(prime.Output());
            }

            writer.WriteLine("Archwing".PadRight(13) + ",Owned".PadRight(8) + ",Blueprint".PadRight(12) + ",Harness".PadRight(12) + ",Systems".PadRight(12) + ",Wings".PadRight(12));

            foreach (Archwing prime in Archwings)
            {
                writer.WriteLine(prime.Output());
            }

            writer.WriteLine("Sentinel".PadRight(13) + ",Owned".PadRight(8) + ",Blueprint".PadRight(12) + ",Carapace".PadRight(12) + ",Cerebrum".PadRight(12) + ",Systems".PadRight(12));

            foreach (Sentinel prime in Sentinels)
            {
                writer.WriteLine(prime.Output());
            }

            writer.WriteLine("Pet".PadRight(13) + ",Owned".PadRight(8) + ",Blueprint".PadRight(12) + ",Band".PadRight(12) + ",Buckle".PadRight(12));

            foreach (Pet prime in Pets)
            {
                writer.WriteLine(prime.Output());
            }

            writer.Close();
        }

        public void AsToFile()
        {
            saveFileDialog1.Filter = "Comma Separated Values (*.csv)|*.csv|All Files (*.*)|*.*";
            saveFileDialog1.DefaultExt = ".csv";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] that = saveFileDialog1.FileName.Split('\\');
                writer = File.CreateText(startPath);
                writer.WriteLine(that[that.Length - 1]);
                writer.WriteLine(saveFileDialog1.FileName);
                writer.Close();

                import[0] = that[that.Length - 1];
                import[1] = saveFileDialog1.FileName;

                ToFile(saveFileDialog1.FileName);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Frames[0].Output());
            if (radioButtonFrames.Checked)
            {
                numericUpDownFirst.Visible = false;
            }
            else
            {
                numericUpDownFirst.Visible = true;
            }
        }
        
        private void RadioButtonFrames_CheckedChanged(object sender, EventArgs e)
        {
            WriteIn();
            PullData();
            checker = 0;
            listBoxFrames.DataSource = Frames;
        }

        private void RadioButtonPrimary_CheckedChanged(object sender, EventArgs e)
        {
            WriteIn();
            PullData();
            checker = 1;
            listBoxFrames.DataSource = Primaries;
        }

        private void RadioButtonSecondary_CheckedChanged(object sender, EventArgs e)
        {
            WriteIn();
            PullData();
            checker = 2;
            listBoxFrames.DataSource = Secondaries;
        }

        private void RadioButtonMelee_CheckedChanged(object sender, EventArgs e)
        {
            WriteIn();
            PullData();
            checker = 3;
            listBoxFrames.DataSource = Melee;
        }

        private void RadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            WriteIn();
            PullData();
            checker = 4;
            listBoxFrames.DataSource = Archwings;
        }

        private void RadioButton6_CheckedChanged(object sender, EventArgs e)
        {
            WriteIn();
            PullData();
            checker = 5;
            listBoxFrames.DataSource = Sentinels;
        }

        private void RadioButton7_CheckedChanged(object sender, EventArgs e)
        {
            WriteIn();
            PullData();
            checker = 6;
            listBoxFrames.DataSource = Pets;
        }
    
        private void Labels()
        {
            labelSecond.Visible = true;
            labelThird.Visible = true;
            labelFourth.Visible = true;
            labelFifth.Visible = false;

            numericUpDownSecond.Visible = true;
            numericUpDownThird.Visible = true;
            numericUpDownFourth.Visible = true;
            numericUpDownFifth.Visible = false;

            if (checker == 0)
            {
                labelSecond.Text = "Chassis";
                labelThird.Text = "Neuroptics";
                labelFourth.Text = "Systems";

                if (Frames[listBoxFrames.SelectedIndex].Owned)
                {
                    buttonOwned.Text = "Not Owned";
                }
                else
                {
                    buttonOwned.Text = "Owned";
                }
            }

            if (checker == 1)
            {

                if (Primaries[listBoxFrames.SelectedIndex].NeedsFifth)
                {
                    labelSecond.Text = Primaries[listBoxFrames.SelectedIndex].Names[1];
                    labelThird.Text = Primaries[listBoxFrames.SelectedIndex].Names[2];
                    labelFourth.Text = Primaries[listBoxFrames.SelectedIndex].Names[3];
                    labelFifth.Text = Primaries[listBoxFrames.SelectedIndex].Names[4];

                    labelFifth.Visible = true;
                    numericUpDownFifth.Visible = true;
                }
                else
                {
                    labelSecond.Text = Primaries[listBoxFrames.SelectedIndex].Names[1];
                    labelThird.Text = Primaries[listBoxFrames.SelectedIndex].Names[2];
                    labelFourth.Text = Primaries[listBoxFrames.SelectedIndex].Names[3];
                }
                if (Primaries[listBoxFrames.SelectedIndex].Owned)
                {
                    buttonOwned.Text = "Not Owned";
                }
                else
                {
                    buttonOwned.Text = "Owned";
                }
            }

            if (checker == 2)
            {
                labelSecond.Text = Secondaries[listBoxFrames.SelectedIndex].Names[1];

                labelThird.Visible = false;
                labelFourth.Visible = false;
                numericUpDownThird.Visible = false;
                numericUpDownFourth.Visible = false;

                if(Secondaries[listBoxFrames.SelectedIndex].Status != 2)
                {
                    labelThird.Text = Secondaries[listBoxFrames.SelectedIndex].Names[2];
                    labelThird.Visible = true;
                    numericUpDownThird.Visible = true;
                }
                if(Secondaries[listBoxFrames.SelectedIndex].Status == 1)
                {
                    labelFourth.Text = Secondaries[listBoxFrames.SelectedIndex].Names[3];
                    labelFourth.Visible = true;
                    numericUpDownFourth.Visible = true;
                }
                if(Secondaries[listBoxFrames.SelectedIndex].Status == 3)
                {
                    labelFourth.Text = Secondaries[listBoxFrames.SelectedIndex].Names[3];
                    labelFifth.Text = Secondaries[listBoxFrames.SelectedIndex].Names[4];
                    labelFourth.Visible = true;
                    labelFifth.Visible = true;
                    numericUpDownFourth.Visible = true;
                    numericUpDownFifth.Visible = true;
                }

                if (Secondaries[listBoxFrames.SelectedIndex].Owned)
                {
                    buttonOwned.Text = "Not Owned";
                }
                else
                {
                    buttonOwned.Text = "Owned";
                }
            }
            if (checker == 3)
            {
                labelSecond.Text = Melee[listBoxFrames.SelectedIndex].Names[1];
                labelThird.Text = Melee[listBoxFrames.SelectedIndex].Names[2];

                if (Melee[listBoxFrames.SelectedIndex].Status == 3)
                {
                    labelFourth.Text = Melee[listBoxFrames.SelectedIndex].Names[3];
                }
                else
                {
                    labelFourth.Visible = false;
                    numericUpDownFourth.Visible = false;
                }
                if (Melee[listBoxFrames.SelectedIndex].Owned)
                {
                    buttonOwned.Text = "Not Owned";
                }
                else
                {
                    buttonOwned.Text = "Owned";
                }
            }
            if (checker == 4)
            {
                labelSecond.Text = Archwings[listBoxFrames.SelectedIndex].Names[1];
                labelThird.Text = Archwings[listBoxFrames.SelectedIndex].Names[2];
                labelFourth.Text = Archwings[listBoxFrames.SelectedIndex].Names[3];
                if (Archwings[listBoxFrames.SelectedIndex].Owned)
                {
                    buttonOwned.Text = "Not Owned";
                }
                else
                {
                    buttonOwned.Text = "Owned";
                }
            }
            if (checker == 5)
            {
                labelSecond.Text = Sentinels[listBoxFrames.SelectedIndex].Names[1];
                labelThird.Text = Sentinels[listBoxFrames.SelectedIndex].Names[2];
                labelFourth.Text = Sentinels[listBoxFrames.SelectedIndex].Names[3];
                if (Sentinels[listBoxFrames.SelectedIndex].Owned)
                {
                    buttonOwned.Text = "Not Owned";
                }
                else
                {
                    buttonOwned.Text = "Owned";
                }
            }
            if (checker == 6)
            {
                labelSecond.Text = Pets[listBoxFrames.SelectedIndex].Names[1];
                labelThird.Text = Pets[listBoxFrames.SelectedIndex].Names[2];

                labelFourth.Visible = false;
                numericUpDownFourth.Visible = false;
                if (Pets[listBoxFrames.SelectedIndex].Owned)
                {
                    buttonOwned.Text = "Not Owned";
                }
                else
                {
                    buttonOwned.Text = "Owned";
                }
            }
            OwnedLists();
        }

        private void ListBoxFrames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listRefresh)
            {
                WriteIn();
                PullData();
                Labels();
                prevIndex = listBoxFrames.SelectedIndex;
            }            
        }

        public void PullData()
        {
            if (checker == 0)
            {
                numericUpDownFirst.Value = Frames[listBoxFrames.SelectedIndex].First;
                numericUpDownSecond.Value = Frames[listBoxFrames.SelectedIndex].Second;
                numericUpDownThird.Value = Frames[listBoxFrames.SelectedIndex].Third;
                numericUpDownFourth.Value = Frames[listBoxFrames.SelectedIndex].Fourth;
            }
            if (checker == 1)
            {
                numericUpDownFirst.Value = Primaries[listBoxFrames.SelectedIndex].First;
                numericUpDownSecond.Value = Primaries[listBoxFrames.SelectedIndex].Second;
                numericUpDownThird.Value = Primaries[listBoxFrames.SelectedIndex].Third;
                numericUpDownFourth.Value = Primaries[listBoxFrames.SelectedIndex].Fourth;
                if (Primaries[listBoxFrames.SelectedIndex].NeedsFifth)
                {
                    numericUpDownFifth.Value = Primaries[listBoxFrames.SelectedIndex].Fifth;
                    numericUpDownFifth.Visible = true;
                }
            }
            if (checker == 2)
            {
                numericUpDownFirst.Value = Secondaries[listBoxFrames.SelectedIndex].First;
                numericUpDownSecond.Value = Secondaries[listBoxFrames.SelectedIndex].Second;
                if ((Secondaries[listBoxFrames.SelectedIndex].Status != 2))
                {
                    numericUpDownThird.Value = Secondaries[listBoxFrames.SelectedIndex].Third;
                }
                if ((Secondaries[listBoxFrames.SelectedIndex].Status == 1))
                {
                    numericUpDownFourth.Value = Secondaries[listBoxFrames.SelectedIndex].Fourth;
                }
                if (Secondaries[listBoxFrames.SelectedIndex].Status == 3)
                {
                    numericUpDownFourth.Value = Secondaries[listBoxFrames.SelectedIndex].Fourth;
                    numericUpDownFifth.Value = Secondaries[listBoxFrames.SelectedIndex].Fifth;
                }
            }
            if (checker == 3)
            {
                numericUpDownFirst.Value = Melee[listBoxFrames.SelectedIndex].First;
                numericUpDownSecond.Value = Melee[listBoxFrames.SelectedIndex].Second;
                numericUpDownThird.Value = Melee[listBoxFrames.SelectedIndex].Third;
                if (Melee[listBoxFrames.SelectedIndex].Status == 3)
                {
                    numericUpDownFourth.Value = Melee[listBoxFrames.SelectedIndex].Fourth;
                }
            }
            if (checker == 4)
            {
                numericUpDownFirst.Value = Archwings[listBoxFrames.SelectedIndex].First;
                numericUpDownSecond.Value = Archwings[listBoxFrames.SelectedIndex].Second;
                numericUpDownThird.Value = Archwings[listBoxFrames.SelectedIndex].Third;
                numericUpDownFourth.Value = Archwings[listBoxFrames.SelectedIndex].Fourth;
            }
            if (checker == 5)
            {
                numericUpDownFirst.Value = Sentinels[listBoxFrames.SelectedIndex].First;
                numericUpDownSecond.Value = Sentinels[listBoxFrames.SelectedIndex].Second;
                numericUpDownThird.Value = Sentinels[listBoxFrames.SelectedIndex].Third;
                numericUpDownFourth.Value = Sentinels[listBoxFrames.SelectedIndex].Fourth;
            }
            if (checker == 6)
            {
                numericUpDownFirst.Value = Pets[listBoxFrames.SelectedIndex].First;
                numericUpDownSecond.Value = Pets[listBoxFrames.SelectedIndex].Second;
                numericUpDownThird.Value = Pets[listBoxFrames.SelectedIndex].Third;
            }
        }

        public void WriteIn()
        {
            if (prevCheck == 0)
            {
                Frames[prevIndex].First = (Int32)numericUpDownFirst.Value;
                Frames[prevIndex].Second = (Int32)numericUpDownSecond.Value;
                Frames[prevIndex].Third = (Int32)numericUpDownThird.Value;
                Frames[prevIndex].Fourth = (Int32)numericUpDownFourth.Value;
            }
            if (prevCheck == 1)
            {
                Primaries[prevIndex].First = (Int32)numericUpDownFirst.Value;
                Primaries[prevIndex].Second = (Int32)numericUpDownSecond.Value;
                Primaries[prevIndex].Third = (Int32)numericUpDownThird.Value;
                Primaries[prevIndex].Fourth = (Int32)numericUpDownFourth.Value;
                if (Primaries[prevIndex].NeedsFifth)
                {
                    Primaries[prevIndex].Fifth = (Int32)numericUpDownFifth.Value;
                }
            }
            if (prevCheck == 2)
            {
                Secondaries[prevIndex].First = (Int32)numericUpDownFirst.Value;
                Secondaries[prevIndex].Second = (Int32)numericUpDownSecond.Value;
                if (Secondaries[prevIndex].Status != 2)
                {
                    Secondaries[prevIndex].Third = (Int32)numericUpDownThird.Value;
                }
                if (Secondaries[prevIndex].Status == 1)
                {
                    Secondaries[prevIndex].Fourth = (Int32)numericUpDownFourth.Value;
                }
                if (Secondaries[prevIndex].Status == 3)
                {
                    Secondaries[prevIndex].Fourth = (Int32)numericUpDownFourth.Value;
                    Secondaries[prevIndex].Fifth = (Int32)numericUpDownFifth.Value;
                }
            }
            if (prevCheck == 3)
            {
                Melee[prevIndex].First = (Int32)numericUpDownFirst.Value;
                Melee[prevIndex].Second = (Int32)numericUpDownSecond.Value;
                Melee[prevIndex].Third = (Int32)numericUpDownThird.Value;
                if (Melee[prevIndex].Status == 3)
                {
                    Melee[prevIndex].Fourth = (Int32)numericUpDownFourth.Value;
                }
            }
            if (prevCheck == 4)
            {
                Archwings[prevIndex].First = (Int32)numericUpDownFirst.Value;
                Archwings[prevIndex].Second = (Int32)numericUpDownSecond.Value;
                Archwings[prevIndex].Third = (Int32)numericUpDownThird.Value;
                Archwings[prevIndex].Fourth = (Int32)numericUpDownFourth.Value;
            }
            if (prevCheck == 5)
            {
                Sentinels[prevIndex].First = (Int32)numericUpDownFirst.Value;
                Sentinels[prevIndex].Second = (Int32)numericUpDownSecond.Value;
                Sentinels[prevIndex].Third = (Int32)numericUpDownThird.Value;
                Sentinels[prevIndex].Fourth = (Int32)numericUpDownFourth.Value;
            }
            if (prevCheck == 6)
            {
                Pets[prevIndex].First = (Int32)numericUpDownFirst.Value;
                Pets[prevIndex].Second = (Int32)numericUpDownSecond.Value;
                Pets[prevIndex].Third = (Int32)numericUpDownThird.Value;
            }
            saveCheck = true;
            prevCheck = checker;
            Ducatiis();
        }

        /// <summary>
        /// Sorts any list of 'Prime' it is given alphabetically.
        /// </summary>
        /// <param name="LP"></param>
        private void InsertSortPrime(BindingList<Prime> LP)
        {
            //Check each object after the first.
            for(int i = 1; i < LP.Count; i++)
            {
                //Compare it's name
                string Obj1 = LP[i].Name;

                //Against every later object
                for (int j = 0; j < i; j++)
                {
                    //For it's name
                    string Obj2 = LP[j].Name;

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
        /// Sorts any list of 'Part' it is given alphabetically.
        /// </summary>
        /// <param name="LP"></param>
        private void InsertSortPart(List<Part> LP)
        {
            //Check each object after the first.
            for (int i = 1; i < LP.Count; i++)
            {
                //Compare it's name
                string Obj1 = LP[i].Name;

                //Against every later object
                for (int j = 0; j < i; j++)
                {
                    //For it's name
                    string Obj2 = LP[j].Name;

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
            for(int i = 0; (i < theFirst.Length) && (i < theSecond.Length); i++)
            {
                if(theFirst[i] < theSecond[i])
                {
                    return true;
                }
                else
                {
                    if(theFirst[i] > theSecond[i])
                    {
                        return false;
                    }
                }
            }
            if(theFirst.Length < theSecond.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Populates both lists on the Owned List tab
        /// </summary>
        public void OwnedLists()
        {
            listBoxOwned.Items.Clear();
            listBoxNotOwn.Items.Clear();
            foreach (Prime pri in PrimeArray[checker])
            {
                if (pri.Owned)
                {
                    listBoxOwned.Items.Add(pri.Name);
                }
                else
                {
                    listBoxNotOwn.Items.Add(pri.Name);
                }
            }
            
        }

        /// <summary>
        /// Sets all the textboxes in the Ducats Tab
        /// </summary>
        public void Ducatiis()
        {
            for (int i = 0; i < 7; i++) 
            {
                ducats[i] = 0;
                ducatsO[i] = 0;
            }

            foreach (Prime pri in Frames)
            {
                ducats[0] += pri.Ducats;
                ducatsO[0] += pri.ODucats;
            }
            textBoxDFrames.Text = ducats[0].ToString();

            foreach (Prime pri in Primaries)
            {
                ducats[1] += pri.Ducats;
                ducatsO[1] += pri.ODucats;
            }
            textBoxDPrimary.Text = ducats[1].ToString();

            foreach (Prime pri in Secondaries)
            {
                ducats[2] += pri.Ducats;
                ducatsO[2] += pri.ODucats;
            }
            textBoxDSecondary.Text = ducats[2].ToString();

            foreach (Prime pri in Melee)
            {
                ducats[3] += pri.Ducats;
                ducatsO[3] += pri.ODucats;
            }
            textBoxDMelee.Text = ducats[3].ToString();

            foreach (Prime pri in Archwings)
            {
                ducats[4] += pri.Ducats;
                ducatsO[4] += pri.ODucats;
            }
            textBoxDArchwing.Text = ducats[4].ToString();

            foreach (Prime pri in Sentinels)
            {
                ducats[5] += pri.Ducats;
                ducatsO[5] += pri.ODucats;
            }
            textBoxDSentinel.Text = ducats[5].ToString();

            foreach (Prime pri in Pets)
            {
                ducats[6] += pri.Ducats;
                ducatsO[6] += pri.ODucats;
            }
            textBoxDPet.Text = ducats[6].ToString();

            textBoxDTot.Text = (ducats[0] + ducats[1] + ducats[2] + ducats[3] + ducats[4] + ducats[5] + ducats[6]).ToString();
            textBoxDDupes.Text = (ducatsO[0] + ducatsO[1] + ducatsO[2] + ducatsO[3] + ducatsO[4] + ducatsO[5] + ducatsO[6]).ToString();
        }

        private void ButtonOwned_Click(object sender, EventArgs e)
        {
            if (checker == 0)
            {
                Frames[listBoxFrames.SelectedIndex].Owned = !Frames[listBoxFrames.SelectedIndex].Owned;
                listRefresh = false;
                listBoxFrames.DataSource = null;
                listRefresh = true;
                listBoxFrames.DataSource = Frames;
            }
            if (checker == 1)
            {
                Primaries[listBoxFrames.SelectedIndex].Owned = !Primaries[listBoxFrames.SelectedIndex].Owned;
                listRefresh = false;
                listBoxFrames.DataSource = null;
                listRefresh = true;
                listBoxFrames.DataSource = Primaries;
            }
            if (checker == 2)
            {
                Secondaries[listBoxFrames.SelectedIndex].Owned = !Secondaries[listBoxFrames.SelectedIndex].Owned;
                listRefresh = false;
                listBoxFrames.DataSource = null;
                listRefresh = true;
                listBoxFrames.DataSource = Secondaries;
            }
            if (checker == 3)
            {
                Melee[listBoxFrames.SelectedIndex].Owned = !Melee[listBoxFrames.SelectedIndex].Owned;
                listRefresh = false;
                listBoxFrames.DataSource = null;
                listRefresh = true;
                listBoxFrames.DataSource = Melee;
            }
            if (checker == 4)
            {
                Archwings[listBoxFrames.SelectedIndex].Owned = !Archwings[listBoxFrames.SelectedIndex].Owned;
                listRefresh = false;
                listBoxFrames.DataSource = null;
                listRefresh = true;
                listBoxFrames.DataSource = Archwings;
            }
            if (checker == 5)
            {
                Sentinels[listBoxFrames.SelectedIndex].Owned = !Sentinels[listBoxFrames.SelectedIndex].Owned;
                listRefresh = false;
                listBoxFrames.DataSource = null;
                listRefresh = true;
                listBoxFrames.DataSource = Sentinels;
            }
            if (checker == 6)
            {
                Pets[listBoxFrames.SelectedIndex].Owned = !Pets[listBoxFrames.SelectedIndex].Owned;
                listRefresh = false;
                listBoxFrames.DataSource = null;
                listRefresh = true;
                listBoxFrames.DataSource = Pets;
            }
            Labels();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (saveCheck)
            {
                if (MessageBox.Show("Do you want to save changes to your file?", "WPSA", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (File.Exists(startPath))
                    {
                        ToFile(import[1]);
                    }
                    else
                    {
                        AsToFile();
                    }
                }
            }            
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(startPath))
            {
                ToFile(import[1]);
            }
            else
            {
                AsToFile();
            }
        }

        private void ButtonSLGenerate_Click(object sender, EventArgs e)
        {
            SList.Clear();
            listBoxSL.Items.Clear();

            List<Part> geoff = new List<Part>();

            foreach (Prime pri in AllPrimes)
            {
                geoff.Clear();

                foreach (Part par in pri.Parts)
                {
                    if (par.SListCheck == true)
                    {
                        geoff.Add(par);
                    }
                }

                InsertSortPart(geoff);

                foreach (Part par in geoff)
                {
                    SList.Add(par);
                }
            }            

            foreach(Part par in SList)
            {
                listBoxSL.Items.Add(par.SListGen);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            listBoxSL.Items.Clear();
            foreach (Prime pri in AllPrimes)
            {
                listBoxSL.Items.Add(pri.ToString());
            }
        }

        private void AlwaysOnTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            onTop = !onTop;
            Form.ActiveForm.TopMost = onTop;
            alwaysOnTopToolStripMenuItem.Checked = onTop;
        }

        private void RivenCalculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Program.f1Show = false;
            //this.Hide();
            Program.F1Toggle();

            Form2 f2 = new Form2();
            f2.Show();
        }
    }    
}
