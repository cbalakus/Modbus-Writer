namespace ModbusWriter
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.startAddr = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.endAddr = new System.Windows.Forms.TextBox();
            this.endRange = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.delay = new System.Windows.Forms.TextBox();
            this.startRange = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.port = new System.Windows.Forms.TextBox();
            this.uID = new System.Windows.Forms.TextBox();
            this.radHR = new System.Windows.Forms.RadioButton();
            this.radIR = new System.Windows.Forms.RadioButton();
            this.radCO = new System.Windows.Forms.RadioButton();
            this.radDis = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.randomWriteChk = new System.Windows.Forms.CheckBox();
            this.showSignalPanel = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.serialPort = new System.Windows.Forms.ComboBox();
            this.baudRate = new System.Windows.Forms.ComboBox();
            this.IsServer = new System.Windows.Forms.CheckBox();
            this.ipAddr = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 49);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(42, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(52, 49);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(43, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Stop";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // startAddr
            // 
            this.startAddr.Location = new System.Drawing.Point(35, 14);
            this.startAddr.Name = "startAddr";
            this.startAddr.Size = new System.Drawing.Size(67, 20);
            this.startAddr.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(122, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "ms";
            // 
            // endAddr
            // 
            this.endAddr.Location = new System.Drawing.Point(104, 14);
            this.endAddr.Name = "endAddr";
            this.endAddr.Size = new System.Drawing.Size(67, 20);
            this.endAddr.TabIndex = 3;
            // 
            // endRange
            // 
            this.endRange.Location = new System.Drawing.Point(104, 40);
            this.endRange.Name = "endRange";
            this.endRange.Size = new System.Drawing.Size(67, 20);
            this.endRange.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Addr";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Btw";
            // 
            // delay
            // 
            this.delay.Location = new System.Drawing.Point(148, 51);
            this.delay.Name = "delay";
            this.delay.Size = new System.Drawing.Size(38, 20);
            this.delay.TabIndex = 5;
            this.delay.Text = "1000";
            // 
            // startRange
            // 
            this.startRange.Location = new System.Drawing.Point(35, 40);
            this.startRange.Name = "startRange";
            this.startRange.Size = new System.Drawing.Size(67, 20);
            this.startRange.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Conn";
            // 
            // port
            // 
            this.port.Location = new System.Drawing.Point(115, 25);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(42, 20);
            this.port.TabIndex = 9;
            // 
            // uID
            // 
            this.uID.Location = new System.Drawing.Point(159, 25);
            this.uID.Name = "uID";
            this.uID.Size = new System.Drawing.Size(27, 20);
            this.uID.TabIndex = 10;
            // 
            // radHR
            // 
            this.radHR.AutoSize = true;
            this.radHR.Checked = true;
            this.radHR.Location = new System.Drawing.Point(10, 78);
            this.radHR.Name = "radHR";
            this.radHR.Size = new System.Drawing.Size(84, 17);
            this.radHR.TabIndex = 11;
            this.radHR.TabStop = true;
            this.radHR.Text = "Holding Reg";
            this.radHR.UseVisualStyleBackColor = true;
            // 
            // radIR
            // 
            this.radIR.AutoSize = true;
            this.radIR.Location = new System.Drawing.Point(100, 78);
            this.radIR.Name = "radIR";
            this.radIR.Size = new System.Drawing.Size(72, 17);
            this.radIR.TabIndex = 11;
            this.radIR.Text = "Input Reg";
            this.radIR.UseVisualStyleBackColor = true;
            // 
            // radCO
            // 
            this.radCO.AutoSize = true;
            this.radCO.Location = new System.Drawing.Point(10, 101);
            this.radCO.Name = "radCO";
            this.radCO.Size = new System.Drawing.Size(42, 17);
            this.radCO.TabIndex = 11;
            this.radCO.Text = "Coil";
            this.radCO.UseVisualStyleBackColor = true;
            // 
            // radDis
            // 
            this.radDis.AutoSize = true;
            this.radDis.Location = new System.Drawing.Point(58, 101);
            this.radDis.Name = "radDis";
            this.radDis.Size = new System.Drawing.Size(64, 17);
            this.radDis.TabIndex = 11;
            this.radDis.Text = "Discrete";
            this.radDis.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.endRange);
            this.groupBox1.Controls.Add(this.endAddr);
            this.groupBox1.Controls.Add(this.startRange);
            this.groupBox1.Controls.Add(this.startAddr);
            this.groupBox1.Location = new System.Drawing.Point(10, 121);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(176, 66);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Random Write";
            // 
            // randomWriteChk
            // 
            this.randomWriteChk.AutoSize = true;
            this.randomWriteChk.Location = new System.Drawing.Point(93, 120);
            this.randomWriteChk.Name = "randomWriteChk";
            this.randomWriteChk.Size = new System.Drawing.Size(15, 14);
            this.randomWriteChk.TabIndex = 13;
            this.randomWriteChk.UseVisualStyleBackColor = true;
            this.randomWriteChk.CheckedChanged += new System.EventHandler(this.RandomWriteChk_CheckedChanged);
            // 
            // showSignalPanel
            // 
            this.showSignalPanel.Enabled = false;
            this.showSignalPanel.Location = new System.Drawing.Point(151, 101);
            this.showSignalPanel.Name = "showSignalPanel";
            this.showSignalPanel.Size = new System.Drawing.Size(35, 23);
            this.showSignalPanel.TabIndex = 14;
            this.showSignalPanel.Text = ">>";
            this.showSignalPanel.UseVisualStyleBackColor = true;
            this.showSignalPanel.Click += new System.EventHandler(this.ShowSignalPanel_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(4, 3);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(46, 17);
            this.radioButton1.TabIndex = 15;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "TCP";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.RadioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(56, 3);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(48, 17);
            this.radioButton2.TabIndex = 15;
            this.radioButton2.Text = "RTU";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Location = new System.Drawing.Point(78, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(103, 22);
            this.panel1.TabIndex = 16;
            // 
            // serialPort
            // 
            this.serialPort.FormattingEnabled = true;
            this.serialPort.Location = new System.Drawing.Point(38, 25);
            this.serialPort.Name = "serialPort";
            this.serialPort.Size = new System.Drawing.Size(62, 21);
            this.serialPort.TabIndex = 17;
            this.serialPort.Visible = false;
            // 
            // baudRate
            // 
            this.baudRate.FormattingEnabled = true;
            this.baudRate.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.baudRate.Location = new System.Drawing.Point(101, 25);
            this.baudRate.Name = "baudRate";
            this.baudRate.Size = new System.Drawing.Size(56, 21);
            this.baudRate.TabIndex = 17;
            this.baudRate.Visible = false;
            // 
            // IsServer
            // 
            this.IsServer.AutoSize = true;
            this.IsServer.Location = new System.Drawing.Point(10, 6);
            this.IsServer.Name = "IsServer";
            this.IsServer.Size = new System.Drawing.Size(57, 17);
            this.IsServer.TabIndex = 18;
            this.IsServer.Text = "Server";
            this.IsServer.UseVisualStyleBackColor = true;
            this.IsServer.CheckedChanged += new System.EventHandler(this.IsServer_CheckedChanged);
            // 
            // ipAddr
            // 
            this.ipAddr.Location = new System.Drawing.Point(38, 25);
            this.ipAddr.Name = "ipAddr";
            this.ipAddr.Size = new System.Drawing.Size(74, 20);
            this.ipAddr.TabIndex = 19;
            this.ipAddr.Text = "127.0.0.1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(191, 192);
            this.Controls.Add(this.ipAddr);
            this.Controls.Add(this.IsServer);
            this.Controls.Add(this.baudRate);
            this.Controls.Add(this.serialPort);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.showSignalPanel);
            this.Controls.Add(this.randomWriteChk);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.radDis);
            this.Controls.Add(this.radIR);
            this.Controls.Add(this.radCO);
            this.Controls.Add(this.radHR);
            this.Controls.Add(this.uID);
            this.Controls.Add(this.port);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.delay);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Modbus Writer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Move += new System.EventHandler(this.Form1_Move);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox startAddr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox endAddr;
        private System.Windows.Forms.TextBox endRange;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox delay;
        private System.Windows.Forms.TextBox startRange;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox port;
        private System.Windows.Forms.TextBox uID;
        public System.Windows.Forms.RadioButton radHR;
        public System.Windows.Forms.RadioButton radIR;
        public System.Windows.Forms.RadioButton radCO;
        public System.Windows.Forms.RadioButton radDis;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox randomWriteChk;
        private System.Windows.Forms.Button showSignalPanel;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox serialPort;
        private System.Windows.Forms.ComboBox baudRate;
        public System.Windows.Forms.CheckBox IsServer;
        private System.Windows.Forms.TextBox ipAddr;
    }
}

