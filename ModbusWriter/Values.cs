using ModbusWriter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModbusWriteRandom
{
    public partial class Values : Form
    {
        private readonly Form1 main = null;
        private List<int> holdingRegisters;
        public Values(Form1 _main, int start, int quantity)
        {
            pauseLog = false;
            main = _main;
            InitializeComponent();
            startAddr.Text = start.ToString();
            count.Text = quantity.ToString();
            main.Log += (string msg) =>
            {
                if (pauseLog)
                    return;
                msg = DateTime.Now.ToLongTimeString() + " - " + msg;
                if (listBox1.InvokeRequired)
                    listBox1.BeginInvoke(new Action(() =>
                    {
                        listBox1.Items.Insert(0, msg);
                        if (listBox1.Items.Count >= 100)
                            listBox1.Items.RemoveAt(99);
                    }));
                else
                {
                    listBox1.Items.Insert(0, msg);
                    if (listBox1.Items.Count >= 100)
                        listBox1.Items.RemoveAt(99);
                }
            };
        }

        private void SetBoxes(object sender, KeyEventArgs e)
        {
            valuesPanel.Controls.Clear();
            if (int.TryParse(startAddr.Text, out int start))
            {
                if (int.TryParse(count.Text, out int qtt))
                {
                    int x = 45, y = 5;
                    for (int i = 0; i < qtt; i++)
                    {
                        if (i % 20 == 0 && i > 0)
                        {
                            x += 85;
                            y = 5;
                        }
                        y += 22;
                        string currentVal = "0";
                        if (main.IsServer.Checked)
                        {
                            if (main.radHR.Checked)
                                currentVal = main._mbSrv.holdingRegisters.localArray[start + i + 1].ToString();
                            else if (main.radCO.Checked)
                                currentVal = main._mbSrv.coils.localArray[start + i + 1] ? "1" : "0";
                            else if (main.radDis.Checked)
                                currentVal = main._mbSrv.discreteInputs.localArray[start + i + 1] ? "1" : "0";
                            else if (main.radIR.Checked)
                                currentVal = main._mbSrv.inputRegisters.localArray[start + i + 1].ToString();
                        }
                        else if (holdingRegisters != null)
                        {
                            if (holdingRegisters.Count >= start + i + 1)
                                currentVal = holdingRegisters[start + i + 1].ToString();
                        }
                        if (Convert.ToInt32(currentVal) < 0)
                        {
                            currentVal = (65536 + Convert.ToInt32(currentVal)).ToString();
                        }
                        TextBox textBox = new TextBox
                        {
                            Text = currentVal,
                            Location = new Point(x, y),
                            Width = 40,
                            Tag = start + i + 1
                        };
                        textBox.KeyUp += (object s, KeyEventArgs eventArgs) =>
                        {
                            try
                            {
                                var tBox = (TextBox)s;
                                if (Convert.ToInt32(tBox.Text) >= 65535)
                                    tBox.Text = "65535";
                                string curText = tBox.Text;
                                if (Convert.ToInt32(curText) >= 32768)
                                    curText = ((65536 - Convert.ToInt32(curText)) * -1).ToString();
                                var idx = (int)tBox.Tag;
                                if (main.IsServer.Checked)
                                {
                                    if (main.radHR.Checked)
                                        main._mbSrv.holdingRegisters.localArray[idx] = Convert.ToInt16(curText);
                                    else if (main.radCO.Checked)
                                        main._mbSrv.coils.localArray[idx] = curText.EndsWith("1");
                                    else if (main.radDis.Checked)
                                        main._mbSrv.discreteInputs.localArray[idx] = curText.EndsWith("1");
                                    else if (main.radIR.Checked)
                                        main._mbSrv.inputRegisters.localArray[idx] = Convert.ToInt16(curText);
                                }
                                else
                                {
                                    if (main.radHR.Checked)
                                        main._mbClt.WriteSingleRegister(idx - 1, Convert.ToInt16(curText));
                                    else if (main.radCO.Checked)
                                        main._mbClt.WriteSingleCoil(idx - 1, curText.EndsWith("1"));
                                }
                            }
                            catch (Exception)
                            { }
                        };
                        valuesPanel.Controls.Add(
                            new Label
                            {
                                Text = (start + i).ToString(),
                                Location = new Point(x - 40, y - 2),
                                Width = 40,
                                TextAlign = ContentAlignment.MiddleRight
                            }
                        );
                        valuesPanel.Controls.Add(textBox);
                    }
                }
            }
        }
        private void Values_Load(object sender, EventArgs e)
        {
            holdingRegisters = new List<int>();
            valuesPanel.AutoScroll = true;
            SetBoxes(null, null);
            timer1.Interval = Convert.ToInt32(main.delay.Text);
            timer1.Start();
            this.Location = new Point(main.Location.X + main.Width - 17, main.Location.Y);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (main.running)
            {
                try
                {
                    timer1.Interval = Convert.ToInt32(main.delay.Text);
                }
                catch { }
                var type = main.radHR.Checked ? "Holding Registers" :
                    main.radDis.Checked ? "Discrete Inputs (Read Only)" :
                    main.radIR.Checked ? "Input Registers (Read Only)" : "Coils";
                this.Text = "Values (" + type + ")";
                try
                {
                    if (!main.IsServer.Checked)
                    {
                        if (int.TryParse(startAddr.Text, out int start))
                            if (int.TryParse(count.Text, out int qtt))
                            {
                                holdingRegisters.Clear();
                                holdingRegisters.Add(0);
                                if (main.radHR.Checked)
                                    holdingRegisters.AddRange(main._mbClt.ReadHoldingRegisters(start, qtt));
                                else if (main.radCO.Checked)
                                    holdingRegisters.AddRange(main._mbClt.ReadCoils(start, qtt).Select(s => s ? 1 : 0));
                                else if (main.radDis.Checked)
                                    holdingRegisters.AddRange(main._mbClt.ReadDiscreteInputs(start, qtt).Select(s => s ? 1 : 0));
                                else if (main.radIR.Checked)
                                    holdingRegisters.AddRange(main._mbClt.ReadInputRegisters(start, qtt));
                            }
                    }
                    foreach (TextBox item in valuesPanel.Controls.Cast<Control>().Where(w => w is TextBox))
                    {
                        var idx = (int)item.Tag;
                        if (!item.Focused)
                        {
                            string currVal = "0";
                            if (main.IsServer.Checked)
                            {
                                if (main.radHR.Checked)
                                    currVal = main._mbSrv.holdingRegisters.localArray[idx].ToString();
                                else if (main.radCO.Checked)
                                    currVal = main._mbSrv.coils.localArray[idx] ? "1" : "0";
                                else if (main.radDis.Checked)
                                    currVal = main._mbSrv.discreteInputs.localArray[idx] ? "1" : "0";
                                else if (main.radIR.Checked)
                                    currVal = main._mbSrv.inputRegisters.localArray[idx].ToString();
                            }
                            else
                            {
                                if (holdingRegisters.Count >= idx + 1)
                                    currVal = holdingRegisters[idx].ToString();
                            }
                            if (Convert.ToInt32(currVal) < 0)
                                currVal = (65536 + Convert.ToInt32(currVal)).ToString();
                            item.Text = currVal;
                        }
                    }
                }
                catch
                { }
            }
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var str = listBox1.SelectedItem.ToString();
                Clipboard.SetText(str.Substring(str.LastIndexOf(": ") + 2));
            }
            catch
            {
                Clipboard.SetText(listBox1.SelectedItem.ToString());
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
        private bool pauseLog = false;
        private void Button3_Click(object sender, EventArgs e)
        {
            pauseLog = !pauseLog;
            ((Button)sender).Text = pauseLog ? "Resume" : "Pause";
        }
    }
}
