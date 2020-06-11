using ModbusWriteRandom;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModbusWriter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private readonly Random _rnd = new Random();
        private readonly string path = Application.StartupPath + "\\c.txt";
        public ModbusServer _mbSrv;
        public ModbusClient _mbClt;
        public bool running = false;
        public delegate void AddLog(string msg);
        public event AddLog Log;
        private void Form1_Load(object sender, EventArgs e)
        {
            startAddr.Text = "0";
            endAddr.Text = "99";
            startRange.Text = "10";
            endRange.Text = "100";
            port.Text = "502";
            uID.Text = "1";
            baudRate.Text = "9600";
            if (File.Exists(path))
            {
                var c = File.ReadAllText(path).Split('\n');
                try { startAddr.Text = c[0]; }
                catch { }
                try { endAddr.Text = c[1]; }
                catch { }
                try { startRange.Text = c[2]; }
                catch { }
                try { endRange.Text = c[3]; }
                catch { }
                try { delay.Text = c[4]; }
                catch { }
                try { port.Text = c[6]; }
                catch { }
                try { uID.Text = c[7]; }
                catch { }
                try { IsServer.Checked = c[8] == "True"; }
                catch { }
                IsServer_CheckedChanged(null, null);
            }
            RadioButton1_CheckedChanged(null, null);
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            SetEnableds(false);
            File.WriteAllText(path, startAddr.Text + "\n" + endAddr.Text + "\n" + startRange.Text + "\n" + endRange.Text + "\n" + delay.Text + "\n" + port.Text + "\n" + port.Text + "\n" + uID.Text + "\n" + IsServer.Checked);
        }
        private byte[] TrimeZeros(byte[] bytes)
        {
            var byteList = bytes.ToList();
            while (byteList.Count > 0 && byteList.Last() == 0)
                byteList.RemoveAt(byteList.Count - 1);
            //byteList.Add(0);
            return byteList.ToArray();
        }
        void SetEnableds(bool val)
        {
            var gogo = true;
            if (!val)
            {
                if (startAddr.Text.Trim() == "")
                {
                    startAddr.Focus();
                    return;
                }
                if (endAddr.Text.Trim() == "")
                    endAddr.Text = startAddr.Text;
                if (startRange.Text.Trim() == "")
                {
                    startRange.Focus();
                    return;
                }
                if (endRange.Text.Trim() == "")
                    endRange.Text = (Convert.ToInt32(startRange.Text) + 100).ToString();
                if (IsServer.Checked)
                {
                    _mbSrv = new ModbusServer();
                    _mbSrv._output += (byte[] bytes, string type) =>
                        Log?.Invoke(type + " : " + BitConverter.ToString(TrimeZeros(bytes)).Replace('-', ' '));
                    if (radioButton1.Checked)
                    {
                        _mbSrv.Port = Convert.ToInt32(port.Text);
                        _mbSrv.Listen();
                    }
                    else
                    {
                        if (serialPort.Items.Count <= 0)
                        {
                            MessageBox.Show("Comport yok dedik ya..");
                            return;
                        }
                        _mbSrv.SerialPort = serialPort.SelectedItem.ToString();
                        _mbSrv.StopBits = System.IO.Ports.StopBits.One;
                        _mbSrv.Parity = System.IO.Ports.Parity.None;
                        _mbSrv.Baudrate = Convert.ToInt32(baudRate.Text);
                    }
                    _mbSrv.UnitIdentifier = Convert.ToByte(uID.Text);
                }
                else
                {
                    _mbClt = new ModbusClient(ipAddr.Text, Convert.ToInt32(port.Text))
                    {
                        UnitIdentifier = Convert.ToByte(uID.Text)
                    };
                    _mbClt._output += (byte[] bytes, string type) =>
                        Log?.Invoke(type + " : " + BitConverter.ToString(TrimeZeros(bytes)).Replace('-', ' '));
                    try
                    {
                        _mbClt.Connect();
                    }
                    catch (Exception ex)
                    {
                        gogo = false;
                        MessageBox.Show(ex.Message);
                    }
                }
                if (!gogo)
                    return;
                running = true;
                Task.Run(async () =>
                {
                    var dly = Convert.ToInt32(delay.Text);
                    var startAddress = Convert.ToInt32(startAddr.Text);
                    var endAddress = Convert.ToInt32(endAddr.Text);
                    var startRn = Convert.ToInt32(startRange.Text);
                    var endRn = Convert.ToInt32(endRange.Text);
                    while (running)
                    {
                        if (randomWriteChk.Checked)
                        {
                            if (IsServer.Checked)
                            {
                                for (int i = startAddress; i < endAddress; i++)
                                {
                                    var rndVal = Convert.ToInt32(_rnd.Next(startRn, endRn >= 65536 ? 65535 : endRn));
                                    if (rndVal >= 32768)
                                        rndVal = ((65536 - rndVal) * -1);
                                    var booVal = _rnd.Next(0, 2) == 1;
                                    if (radHR.Checked)
                                        _mbSrv.holdingRegisters.localArray[i] = Convert.ToInt16(rndVal);
                                    else if (radIR.Checked)
                                        _mbSrv.inputRegisters.localArray[i] = Convert.ToInt16(rndVal);
                                    else if (radCO.Checked)
                                        _mbSrv.coils.localArray[i] = booVal;
                                    else if (radDis.Checked)
                                        _mbSrv.discreteInputs.localArray[i] = booVal;
                                }
                            }
                            else
                            {
                                if (radHR.Checked)
                                {
                                    List<int> _values = new List<int>();
                                    for (int i = startAddress; i < endAddress; i++)
                                    {
                                        var rndVal = _rnd.Next(startRn, endRn >= 65536 ? 65535 : endRn);
                                        if (rndVal >= 32768)
                                            rndVal = ((65536 - rndVal) * -1);
                                        _values.Add(rndVal);
                                    }
                                    _mbClt.WriteMultipleRegisters(startAddress, _values.ToArray());
                                }
                                else if (radCO.Checked)
                                {
                                    List<bool> _values = new List<bool>();
                                    for (int i = startAddress; i < endAddress; i++)
                                        _values.Add(_rnd.Next(0, 2) == 1);
                                    _mbClt.WriteMultipleCoils(startAddress, _values.ToArray());
                                }
                            }
                        }
                        await Task.Delay(dly);
                    }
                });
            }
            else
            {
                running = false;
                if (IsServer.Checked)
                    _mbSrv.StopListening();
                else
                    _mbClt.Disconnect();
            }
            button2.Enabled = !val;
            button1.Enabled = val;
            startAddr.Enabled = val;
            endAddr.Enabled = val;
            startRange.Enabled = val;
            endRange.Enabled = val;
            delay.Enabled = val;
            port.Enabled = val;
            uID.Enabled = val;
            radioButton1.Enabled = val;
            radioButton2.Enabled = val;
            showSignalPanel.Enabled = !val;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            SetEnableds(true);
        }

        private void RandomWriteChk_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = !randomWriteChk.Checked;
        }
        Values valuesForm;
        bool valuesAppears = false;
        private void ShowSignalPanel_Click(object sender, EventArgs e)
        {
            if (_mbSrv == null && _mbClt == null)
            {
                return;
            }
            if (valuesAppears)
            {
                valuesForm.Hide();
                valuesAppears = false;
            }
            else if (valuesForm != null)
            {
                valuesForm.Show();
                valuesAppears = true;
            }
            if (valuesForm == null)
            {
                var startAddress = Convert.ToInt32(startAddr.Text);
                valuesForm = new Values(this, startAddress, Convert.ToInt32(endAddr.Text) - startAddress);
                valuesForm.FormClosing += (object s, FormClosingEventArgs eventArgs) =>
                {
                    eventArgs.Cancel = true;
                    valuesAppears = false;
                    valuesForm.Hide();
                };
                valuesForm.Show();
                valuesAppears = true;
            }
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            var stat = radioButton1.Checked;
            port.Visible = stat;
            ipAddr.Visible = stat && !IsServer.Checked;
            serialPort.Visible = !stat;
            baudRate.Visible = !stat;
            if (!stat)
            {
                serialPort.Items.Clear();
                serialPort.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
                if (serialPort.Items.Count > 0)
                    serialPort.SelectedIndex = 0;
                else
                    MessageBox.Show("Comport bulunamadı.");
            }
        }

        private void Form1_Move(object sender, EventArgs e)
        {
            if (valuesForm != null)
                valuesForm.Location = new Point(this.Location.X + this.Width - 17, this.Location.Y);
        }

        private void IsServer_CheckedChanged(object sender, EventArgs e)
        {
            ipAddr.Visible = !IsServer.Checked && radioButton1.Checked;
        }
    }
}
