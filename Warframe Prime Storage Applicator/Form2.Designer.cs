namespace Warframe_Prime_Storage_Applicator
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxBaseStats = new System.Windows.Forms.ListBox();
            this.listBoxModdedStats = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonWriteFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonPullData = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.buttonReprocess = new System.Windows.Forms.Button();
            this.buttonDisplayPlacards = new System.Windows.Forms.Button();
            this.buttonPrimeSort = new System.Windows.Forms.Button();
            this.buttonDispPrime = new System.Windows.Forms.Button();
            this.buttonSpecCall = new System.Windows.Forms.Button();
            this.buttonWriteItem = new System.Windows.Forms.Button();
            this.buttonMakePrime = new System.Windows.Forms.Button();
            this.buttonOutputPrime = new System.Windows.Forms.Button();
            this.buttonMakeThemAll = new System.Windows.Forms.Button();
            this.labelCounterA = new System.Windows.Forms.Label();
            this.labelCounterOF = new System.Windows.Forms.Label();
            this.labelCounterB = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxBaseStats
            // 
            this.listBoxBaseStats.FormattingEnabled = true;
            this.listBoxBaseStats.ItemHeight = 16;
            this.listBoxBaseStats.Location = new System.Drawing.Point(16, 422);
            this.listBoxBaseStats.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxBaseStats.Name = "listBoxBaseStats";
            this.listBoxBaseStats.Size = new System.Drawing.Size(159, 116);
            this.listBoxBaseStats.TabIndex = 0;
            // 
            // listBoxModdedStats
            // 
            this.listBoxModdedStats.FormattingEnabled = true;
            this.listBoxModdedStats.ItemHeight = 16;
            this.listBoxModdedStats.Location = new System.Drawing.Point(351, 22);
            this.listBoxModdedStats.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxModdedStats.Name = "listBoxModdedStats";
            this.listBoxModdedStats.Size = new System.Drawing.Size(1188, 516);
            this.listBoxModdedStats.TabIndex = 1;
            this.listBoxModdedStats.SelectedIndexChanged += new System.EventHandler(this.ListBoxModdedStats_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 58);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 28);
            this.button1.TabIndex = 2;
            this.button1.Text = "Write to Listbox";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // buttonWriteFile
            // 
            this.buttonWriteFile.Location = new System.Drawing.Point(16, 94);
            this.buttonWriteFile.Margin = new System.Windows.Forms.Padding(4);
            this.buttonWriteFile.Name = "buttonWriteFile";
            this.buttonWriteFile.Size = new System.Drawing.Size(160, 28);
            this.buttonWriteFile.TabIndex = 3;
            this.buttonWriteFile.Text = "Write XampSamp";
            this.buttonWriteFile.UseVisualStyleBackColor = true;
            this.buttonWriteFile.Click += new System.EventHandler(this.ButtonWriteFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // buttonPullData
            // 
            this.buttonPullData.Location = new System.Drawing.Point(16, 22);
            this.buttonPullData.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPullData.Name = "buttonPullData";
            this.buttonPullData.Size = new System.Drawing.Size(160, 28);
            this.buttonPullData.TabIndex = 4;
            this.buttonPullData.Text = "Pull Full Data";
            this.buttonPullData.UseVisualStyleBackColor = true;
            this.buttonPullData.Click += new System.EventHandler(this.ButtonPullData_Click);
            // 
            // buttonReprocess
            // 
            this.buttonReprocess.Location = new System.Drawing.Point(16, 130);
            this.buttonReprocess.Margin = new System.Windows.Forms.Padding(4);
            this.buttonReprocess.Name = "buttonReprocess";
            this.buttonReprocess.Size = new System.Drawing.Size(160, 28);
            this.buttonReprocess.TabIndex = 5;
            this.buttonReprocess.Text = "Read XampSamp";
            this.buttonReprocess.UseVisualStyleBackColor = true;
            this.buttonReprocess.Click += new System.EventHandler(this.ButtonReprocess_Click);
            // 
            // buttonDisplayPlacards
            // 
            this.buttonDisplayPlacards.Location = new System.Drawing.Point(17, 167);
            this.buttonDisplayPlacards.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDisplayPlacards.Name = "buttonDisplayPlacards";
            this.buttonDisplayPlacards.Size = new System.Drawing.Size(159, 28);
            this.buttonDisplayPlacards.TabIndex = 6;
            this.buttonDisplayPlacards.Text = "Placards to Listbox";
            this.buttonDisplayPlacards.UseVisualStyleBackColor = true;
            this.buttonDisplayPlacards.Click += new System.EventHandler(this.ButtonDisplayPlacards_Click);
            // 
            // buttonPrimeSort
            // 
            this.buttonPrimeSort.Location = new System.Drawing.Point(17, 204);
            this.buttonPrimeSort.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPrimeSort.Name = "buttonPrimeSort";
            this.buttonPrimeSort.Size = new System.Drawing.Size(159, 28);
            this.buttonPrimeSort.TabIndex = 7;
            this.buttonPrimeSort.Text = "Sort for Prime";
            this.buttonPrimeSort.UseVisualStyleBackColor = true;
            this.buttonPrimeSort.Click += new System.EventHandler(this.ButtonPrimeSort_Click);
            // 
            // buttonDispPrime
            // 
            this.buttonDispPrime.Location = new System.Drawing.Point(17, 241);
            this.buttonDispPrime.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDispPrime.Name = "buttonDispPrime";
            this.buttonDispPrime.Size = new System.Drawing.Size(159, 28);
            this.buttonDispPrime.TabIndex = 8;
            this.buttonDispPrime.Text = "Primes to Listbox";
            this.buttonDispPrime.UseVisualStyleBackColor = true;
            this.buttonDispPrime.Click += new System.EventHandler(this.ButtonDispPrime_Click);
            // 
            // buttonSpecCall
            // 
            this.buttonSpecCall.Location = new System.Drawing.Point(17, 278);
            this.buttonSpecCall.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSpecCall.Name = "buttonSpecCall";
            this.buttonSpecCall.Size = new System.Drawing.Size(159, 28);
            this.buttonSpecCall.TabIndex = 9;
            this.buttonSpecCall.Text = "Test Call Warframe";
            this.buttonSpecCall.UseVisualStyleBackColor = true;
            this.buttonSpecCall.Click += new System.EventHandler(this.ButtonSpecCall_Click);
            // 
            // buttonWriteItem
            // 
            this.buttonWriteItem.Location = new System.Drawing.Point(17, 314);
            this.buttonWriteItem.Margin = new System.Windows.Forms.Padding(4);
            this.buttonWriteItem.Name = "buttonWriteItem";
            this.buttonWriteItem.Size = new System.Drawing.Size(159, 28);
            this.buttonWriteItem.TabIndex = 10;
            this.buttonWriteItem.Text = "Write An Item";
            this.buttonWriteItem.UseVisualStyleBackColor = true;
            this.buttonWriteItem.Click += new System.EventHandler(this.ButtonWriteItem_Click);
            // 
            // buttonMakePrime
            // 
            this.buttonMakePrime.Location = new System.Drawing.Point(17, 351);
            this.buttonMakePrime.Margin = new System.Windows.Forms.Padding(4);
            this.buttonMakePrime.Name = "buttonMakePrime";
            this.buttonMakePrime.Size = new System.Drawing.Size(159, 28);
            this.buttonMakePrime.TabIndex = 11;
            this.buttonMakePrime.Text = "Make an Item";
            this.buttonMakePrime.UseVisualStyleBackColor = true;
            this.buttonMakePrime.Click += new System.EventHandler(this.ButtonMakePrime_Click);
            // 
            // buttonOutputPrime
            // 
            this.buttonOutputPrime.Location = new System.Drawing.Point(17, 388);
            this.buttonOutputPrime.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOutputPrime.Name = "buttonOutputPrime";
            this.buttonOutputPrime.Size = new System.Drawing.Size(159, 28);
            this.buttonOutputPrime.TabIndex = 12;
            this.buttonOutputPrime.Text = "Make File";
            this.buttonOutputPrime.UseVisualStyleBackColor = true;
            this.buttonOutputPrime.Click += new System.EventHandler(this.ButtonOutputPrime_Click);
            // 
            // buttonMakeThemAll
            // 
            this.buttonMakeThemAll.Location = new System.Drawing.Point(184, 278);
            this.buttonMakeThemAll.Margin = new System.Windows.Forms.Padding(4);
            this.buttonMakeThemAll.Name = "buttonMakeThemAll";
            this.buttonMakeThemAll.Size = new System.Drawing.Size(159, 101);
            this.buttonMakeThemAll.TabIndex = 13;
            this.buttonMakeThemAll.Text = "Make All Items";
            this.buttonMakeThemAll.UseVisualStyleBackColor = true;
            this.buttonMakeThemAll.Click += new System.EventHandler(this.ButtonMakeThemAll_Click);
            // 
            // labelCounterA
            // 
            this.labelCounterA.AutoSize = true;
            this.labelCounterA.Location = new System.Drawing.Point(185, 215);
            this.labelCounterA.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCounterA.Name = "labelCounterA";
            this.labelCounterA.Size = new System.Drawing.Size(44, 16);
            this.labelCounterA.TabIndex = 14;
            this.labelCounterA.Text = "label1";
            // 
            // labelCounterOF
            // 
            this.labelCounterOF.AutoSize = true;
            this.labelCounterOF.Location = new System.Drawing.Point(241, 215);
            this.labelCounterOF.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCounterOF.Name = "labelCounterOF";
            this.labelCounterOF.Size = new System.Drawing.Size(18, 16);
            this.labelCounterOF.TabIndex = 15;
            this.labelCounterOF.Text = "of";
            // 
            // labelCounterB
            // 
            this.labelCounterB.AutoSize = true;
            this.labelCounterB.Location = new System.Drawing.Point(296, 215);
            this.labelCounterB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCounterB.Name = "labelCounterB";
            this.labelCounterB.Size = new System.Drawing.Size(44, 16);
            this.labelCounterB.TabIndex = 16;
            this.labelCounterB.Text = "label3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(185, 410);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "Pull Full - WFMarket call";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 426);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "Write/Read XampSamp";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(185, 442);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "Sort Prime";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(185, 458);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 16);
            this.label4.TabIndex = 20;
            this.label4.Text = "Make All";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(185, 474);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "Make File - \"ForNow\"";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(194, 383);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 16);
            this.label6.TabIndex = 22;
            this.label6.Text = "Order of Operations";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1556, 554);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelCounterB);
            this.Controls.Add(this.labelCounterOF);
            this.Controls.Add(this.labelCounterA);
            this.Controls.Add(this.buttonMakeThemAll);
            this.Controls.Add(this.buttonOutputPrime);
            this.Controls.Add(this.buttonMakePrime);
            this.Controls.Add(this.buttonWriteItem);
            this.Controls.Add(this.buttonSpecCall);
            this.Controls.Add(this.buttonDispPrime);
            this.Controls.Add(this.buttonPrimeSort);
            this.Controls.Add(this.buttonDisplayPlacards);
            this.Controls.Add(this.buttonReprocess);
            this.Controls.Add(this.buttonPullData);
            this.Controls.Add(this.buttonWriteFile);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBoxModdedStats);
            this.Controls.Add(this.listBoxBaseStats);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxBaseStats;
        private System.Windows.Forms.ListBox listBoxModdedStats;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonWriteFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonPullData;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button buttonReprocess;
        private System.Windows.Forms.Button buttonDisplayPlacards;
        private System.Windows.Forms.Button buttonPrimeSort;
        private System.Windows.Forms.Button buttonDispPrime;
        private System.Windows.Forms.Button buttonSpecCall;
        private System.Windows.Forms.Button buttonWriteItem;
        private System.Windows.Forms.Button buttonMakePrime;
        private System.Windows.Forms.Button buttonOutputPrime;
        private System.Windows.Forms.Button buttonMakeThemAll;
        private System.Windows.Forms.Label labelCounterA;
        private System.Windows.Forms.Label labelCounterOF;
        private System.Windows.Forms.Label labelCounterB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}