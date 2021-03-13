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
using System.Net;
using System.IO.Compression;
using System.Runtime.InteropServices;
using WeAreDevs_API;
using Microsoft.Win32;
using Zapsed.Properties;

namespace Zapsed
{
    public partial class Form1 : Form
    {
        readonly ExploitAPI api = new ExploitAPI();

        public Form1()
        {
            InitializeComponent();
        }

        private void CheckAttached()
        {
            if (api.isAPIAttached())
            {
                label8.Text = "Attached";
                label8.ForeColor = Color.Lime;
            }
            else
            {
                label8.Text = "Not Attached";
                label8.ForeColor = Color.Red;
            }
        }

        private void CheckTopMost()
        {
            if (this.TopMost == true)
            {
                flatCheckBox1.Checked = true;
                topMostToolStripMenuItem.CheckState = CheckState.Checked;
            }
            if (TopMost == false)
            {
                flatCheckBox1.Checked = false;
                topMostToolStripMenuItem.CheckState = CheckState.Unchecked;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string script = fastColoredTextBox1.Text;
            api.SendLimitedLuaScript(script);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            api.LaunchExploit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(saveFileDialog1.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.Write(fastColoredTextBox1.Text);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog opendialogfile = new System.Windows.Forms.OpenFileDialog();
            opendialogfile.Filter = "Lua File (*.lua)|*.lua|Text File (*.txt)|*.txt";
            opendialogfile.FilterIndex = 2;
            opendialogfile.RestoreDirectory = true;
            if (opendialogfile.ShowDialog() != DialogResult.OK)
                return;
            try
            {
                fastColoredTextBox1.Text = "";
                System.IO.Stream stream;
                if ((stream = opendialogfile.OpenFile()) == null)
                    return;
                using (stream)
                    this.fastColoredTextBox1.Text = System.IO.File.ReadAllText(opendialogfile.FileName);
            }
            catch (Exception)
            {
                int num = (int)MessageBox.Show("An error has occured", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void button9_Click(object sender, EventArgs e, string string_LuaCScript)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            button1.Hide();
            button2.Hide();
            button3.Hide();
            button4.Hide();
            panel4.Hide();
            panel3.Show();
            fastColoredTextBox1.Hide();
            listBox1.Enabled = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            button1.Hide();
            button2.Hide();
            button3.Hide();
            button4.Hide();
            panel4.Show();
            panel3.Hide();
            listBox1.Enabled = false;
            fastColoredTextBox1.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            panel2.Show();
            button1.Hide();
            button2.Hide();
            button3.Hide();
            button4.Hide();
            panel4.Hide();
            panel3.Hide();
            listBox1.Enabled = false;
            fastColoredTextBox1.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            button1.Show();
            panel2.Hide();
            button2.Show();
            button3.Show();
            button4.Show();
            panel4.Hide();
            panel3.Hide();
            fastColoredTextBox1.Show();
            listBox1.Enabled = true;
            listBox1.Items.Clear();
            Functions.PopulateListBox(listBox1, "./Scripts", "*.txt");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.lua");
        }

        private void loadTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                fastColoredTextBox1.Text = File.ReadAllText($"./Scripts/{listBox1.SelectedItem}");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            button1.FlatAppearance.MouseOverBackColor = Color.Red;
            button2.FlatAppearance.MouseOverBackColor = Color.Red;
            button3.FlatAppearance.MouseOverBackColor = Color.Red;
            button4.FlatAppearance.MouseOverBackColor = Color.Red;
            button6.FlatAppearance.MouseOverBackColor = Color.Red;
            button12.FlatAppearance.MouseOverBackColor = Color.Red;
            button11.FlatAppearance.MouseOverBackColor = Color.Red;
            button10.FlatAppearance.MouseOverBackColor = Color.Red;
            button9.FlatAppearance.MouseOverBackColor = Color.Red;
            button13.FlatAppearance.MouseOverBackColor = Color.Red;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(179, 0, 35);
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(179, 0, 35);
            button3.FlatAppearance.MouseOverBackColor = Color.FromArgb(179, 0, 35);
            button4.FlatAppearance.MouseOverBackColor = Color.FromArgb(179, 0, 35);
            button6.FlatAppearance.MouseOverBackColor = Color.FromArgb(179, 0, 35);
            button12.FlatAppearance.MouseOverBackColor = Color.FromArgb(179, 0, 35);
            button11.FlatAppearance.MouseOverBackColor = Color.FromArgb(179, 0, 35);
            button10.FlatAppearance.MouseOverBackColor = Color.FromArgb(179, 0, 35);
            button9.FlatAppearance.MouseOverBackColor = Color.FromArgb(179, 0, 35);
            button13.FlatAppearance.MouseOverBackColor = Color.FromArgb(179, 0, 35);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 0);
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 0);
            button3.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 0);
            button4.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 0);
            button6.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 0);
            button12.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 0);
            button11.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 0);
            button10.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 0);
            button9.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 0);
            button13.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 0);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            button1.FlatAppearance.MouseOverBackColor = Color.Gold;
            button2.FlatAppearance.MouseOverBackColor = Color.Gold;
            button3.FlatAppearance.MouseOverBackColor = Color.Gold;
            button4.FlatAppearance.MouseOverBackColor = Color.Gold;
            button6.FlatAppearance.MouseOverBackColor = Color.Gold;
            button12.FlatAppearance.MouseOverBackColor = Color.Gold;
            button11.FlatAppearance.MouseOverBackColor = Color.Gold;
            button10.FlatAppearance.MouseOverBackColor = Color.Gold;
            button9.FlatAppearance.MouseOverBackColor = Color.Gold;
            button13.FlatAppearance.MouseOverBackColor = Color.Gold;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            button1.FlatAppearance.MouseOverBackColor = Color.MediumSeaGreen;
            button2.FlatAppearance.MouseOverBackColor = Color.MediumSeaGreen;
            button3.FlatAppearance.MouseOverBackColor = Color.MediumSeaGreen;
            button4.FlatAppearance.MouseOverBackColor = Color.MediumSeaGreen;
            button6.FlatAppearance.MouseOverBackColor = Color.MediumSeaGreen;
            button12.FlatAppearance.MouseOverBackColor = Color.MediumSeaGreen;
            button11.FlatAppearance.MouseOverBackColor = Color.MediumSeaGreen;
            button10.FlatAppearance.MouseOverBackColor = Color.MediumSeaGreen;
            button9.FlatAppearance.MouseOverBackColor = Color.MediumSeaGreen;
            button13.FlatAppearance.MouseOverBackColor = Color.MediumSeaGreen;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            button1.FlatAppearance.MouseOverBackColor = Color.Blue;
            button2.FlatAppearance.MouseOverBackColor = Color.Blue;
            button3.FlatAppearance.MouseOverBackColor = Color.Blue;
            button4.FlatAppearance.MouseOverBackColor = Color.Blue;
            button6.FlatAppearance.MouseOverBackColor = Color.Blue;
            button12.FlatAppearance.MouseOverBackColor = Color.Blue;
            button11.FlatAppearance.MouseOverBackColor = Color.Blue;
            button10.FlatAppearance.MouseOverBackColor = Color.Blue;
            button9.FlatAppearance.MouseOverBackColor = Color.Blue;
            button13.FlatAppearance.MouseOverBackColor = Color.Blue;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            button1.FlatAppearance.MouseOverBackColor = Color.Aqua;
            button2.FlatAppearance.MouseOverBackColor = Color.Aqua;
            button3.FlatAppearance.MouseOverBackColor = Color.Aqua;
            button4.FlatAppearance.MouseOverBackColor = Color.Aqua;
            button6.FlatAppearance.MouseOverBackColor = Color.Aqua;
            button12.FlatAppearance.MouseOverBackColor = Color.Aqua;
            button11.FlatAppearance.MouseOverBackColor = Color.Aqua;
            button10.FlatAppearance.MouseOverBackColor = Color.Aqua;
            button9.FlatAppearance.MouseOverBackColor = Color.Aqua;
            button13.FlatAppearance.MouseOverBackColor = Color.Aqua;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 192, 192);
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 192, 192);
            button3.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 192, 192);
            button4.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 192, 192);
            button6.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 192, 192);
            button12.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 192, 192);
            button11.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 192, 192);
            button10.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 192, 192);
            button9.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 192, 192);
            button13.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 192, 192);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            button1.FlatAppearance.MouseOverBackColor = Color.Purple;
            button2.FlatAppearance.MouseOverBackColor = Color.Purple;
            button3.FlatAppearance.MouseOverBackColor = Color.Purple;
            button4.FlatAppearance.MouseOverBackColor = Color.Purple;
            button6.FlatAppearance.MouseOverBackColor = Color.Purple;
            button12.FlatAppearance.MouseOverBackColor = Color.Purple;
            button11.FlatAppearance.MouseOverBackColor = Color.Purple;
            button10.FlatAppearance.MouseOverBackColor = Color.Purple;
            button9.FlatAppearance.MouseOverBackColor = Color.Purple;
            button13.FlatAppearance.MouseOverBackColor = Color.Purple;
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            button1.FlatAppearance.MouseOverBackColor = Color.MediumPurple;
            button2.FlatAppearance.MouseOverBackColor = Color.MediumPurple;
            button3.FlatAppearance.MouseOverBackColor = Color.MediumPurple;
            button4.FlatAppearance.MouseOverBackColor = Color.MediumPurple;
            button6.FlatAppearance.MouseOverBackColor = Color.MediumPurple;
            button12.FlatAppearance.MouseOverBackColor = Color.MediumPurple;
            button11.FlatAppearance.MouseOverBackColor = Color.MediumPurple;
            button10.FlatAppearance.MouseOverBackColor = Color.MediumPurple;
            button9.FlatAppearance.MouseOverBackColor = Color.MediumPurple;
            button13.FlatAppearance.MouseOverBackColor = Color.MediumPurple;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 50, 50);
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 50, 50);
            button3.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 50, 50);
            button4.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 50, 50);
            button6.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 50, 50);
            button12.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 50, 50);
            button11.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 50, 50);
            button10.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 50, 50);
            button9.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 50, 50);
            button13.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 50, 50);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            ActiveForm.Opacity = ((double)(trackBar1.Value) / 10.0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckTopMost();
            CheckAttached();
            trackBar1.Value = 10;
            // Script List
            listBox1.Items.Clear();
            Functions.PopulateListBox(listBox1, "./Scripts", "*.txt");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.lua");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.xshd");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.rtf");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.log");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.docx");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.fcf");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.rft");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.smf");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.lst");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.apkg");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.fpt");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.ott");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.doc");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.fodt");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.fdr");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.man");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.sty");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.rtx");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.diz");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.apt");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.docm");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.wtt");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.adoc");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.textclipping");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.readme");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.md");
            // Script Hub
            listBox2.Items.Clear();
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.txt");
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.lua");
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.xshd");
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.rtf");
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.log");
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.docx");
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.fcf");
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.rft");
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.smf");
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.lst");
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.apkg");
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.fpt");
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.ott");
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.doc");
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.fodt");
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.fdr");
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.man");
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.sty");
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.rtx");
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.diz");
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.apt");
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.docm");
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.wtt");
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.adoc");
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.textclipping");
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.readme");
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.md");
            // Local Script Hub
            listBox3.Items.Clear();
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.txt");
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.lua");
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.xshd");
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.rtf");
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.log");
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.docx");
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.fcf");
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.rft");
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.smf");
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.lst");
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.apkg");
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.fpt");
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.ott");
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.doc");
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.fodt");
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.fdr");
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.man");
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.sty");
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.rtx");
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.diz");
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.apt");
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.docm");
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.wtt");
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.adoc");
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.textclipping");
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.readme");
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.md");
        }

        private void flatCheckBox1_CheckedChanged(object sender)
        {
            if (TopMost == true)
            {
                TopMost = false;
                topMostToolStripMenuItem.CheckState = CheckState.Unchecked;
            }
            else
            {
                TopMost = true;
                topMostToolStripMenuItem.CheckState = CheckState.Checked;
            }
        }

        private void refreshListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Functions.PopulateListBox(listBox1, "./Scripts", "*.txt");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.lua");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.xshd");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.rtf");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.log");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.docx");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.fcf");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.rft");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.smf");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.lst");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.apkg");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.fpt");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.ott");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.doc");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.fodt");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.fdr");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.man");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.sty");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.rtx");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.diz");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.apt");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.docm");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.wtt");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.adoc");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.textclipping");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.readme");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.md");
        }

        private void flatCheckBox2_CheckedChanged(object sender)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            api.SendCommand("kill me");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            api.SendCommand("nofloat me");
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            api.SendCommand("float me");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            api.SendCommand("ff me");
        }

        private void button18_Click(object sender, EventArgs e)
        {
            api.SendCommand("fire me");
        }

        private void button21_Click(object sender, EventArgs e)
        {
            api.SendCommand("nosparkles me");
        }

        private void button19_Click(object sender, EventArgs e)
        {
            api.SendCommand("nofire me");
        }

        private void button20_Click(object sender, EventArgs e)
        {
            api.SendCommand("sparkles me");
        }

        private void button23_Click(object sender, EventArgs e)
        {
            api.SendCommand("smoke me");
        }

        private void button24_Click(object sender, EventArgs e)
        {
            api.SendCommand("nosmoke me");
        }

        private void button22_Click(object sender, EventArgs e)
        {
            api.SendCommand("btools me");
        }

        private void button29_Click(object sender, EventArgs e)
        {
            string username = textBox5.Text;
            string text = textBox6.Text;
            api.SendCommand("chat" + username + text);
        }

        private void button30_Click(object sender, EventArgs e)
        {
            
        }

        private void button31_Click(object sender, EventArgs e)
        {
            
        }

        private void fastColoredTextBox1_DragDrop(object sender, DragEventArgs e)
        {
            
        }

        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            string username = textBox3.Text;
            api.SendCommand("nolimbs" + username);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            string username = textBox4.Text;
            api.SendCommand("noarms" + username);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            string walkspeed = textBox1.Text;
            api.SendCommand("game.Players.LocalPlayer.Character.Humanoid.WalkSpeed=" + walkspeed);
        }

        private void button30_Click_1(object sender, EventArgs e)
        {
            string username = textBox7.Text;
            api.SendCommand("teleport " + username);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                fastColoredTextBox1.Text = File.ReadAllText($"./Scripts/{listBox1.SelectedItem}");
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            string jumppower = textBox2.Text;
            api.SendCommand("game.Players.LocalPlayer.Character.Humanoid.JumpPower=" + jumppower);
        }

        private void CheckIfAttached_Tick(object sender, EventArgs e)
        {
            CheckAttached();
        }

        private void attachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            api.LaunchExploit();
        }

        private void injectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            api.LaunchExploit();
        }

        private void loadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.txt");
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.lua");
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.xshd");
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.rtf");
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.log");
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.docx");
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.fcf");
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.rft");
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.smf");
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.lst");
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.apkg");
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.fpt");
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.ott");
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.doc");
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.fodt");
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.fdr");
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.man");
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.sty");
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.rtx");
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.diz");
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.apt");
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.docm");
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.wtt");
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.adoc");
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.textclipping");
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.readme");
            Functions.PopulateListBox(listBox2, "./Script_Hub", "*.md");
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex != 1)
            {
                pictureBox12.BackgroundImageLayout = ImageLayout.Center;
                pictureBox12.BackgroundImage = Resources.DEv2pic;
                fastColoredTextBox2.Text = File.ReadAllText($"./Script_Hub/{listBox2.SelectedItem}");
            }

            if (listBox2.SelectedIndex != 2)
            {
                pictureBox12.BackgroundImageLayout = ImageLayout.Stretch;
                pictureBox12.BackgroundImage = Resources.InfYieldpic;
                fastColoredTextBox2.Text = File.ReadAllText($"./Script_Hub/{listBox2.SelectedItem}");
            }

            if (listBox2.SelectedIndex != 3)
            {
                pictureBox12.BackgroundImageLayout = ImageLayout.Center;
                pictureBox12.BackgroundImage = Resources.InfYieldpic2;
                fastColoredTextBox2.Text = File.ReadAllText($"./Script_Hub/{listBox2.SelectedItem}");
            }

            if (listBox2.SelectedIndex != 4)
            {
                pictureBox12.BackgroundImageLayout = ImageLayout.Center;
                pictureBox12.BackgroundImage = Resources._252_2522915_screenshot;
                fastColoredTextBox2.Text = File.ReadAllText($"./Script_Hub/{listBox2.SelectedItem}");
            }

            if (listBox2.SelectedIndex != 5)
            {
                pictureBox12.BackgroundImageLayout = ImageLayout.None;
                pictureBox12.BackgroundImage = Resources.GmSense;
                fastColoredTextBox2.Text = File.ReadAllText($"./Script_Hub/{listBox2.SelectedItem}");
            }

            if (listBox2.SelectedIndex != 6)
            {
                pictureBox12.BackgroundImageLayout = ImageLayout.Center;
                pictureBox12.BackgroundImage = Resources._252_2522915_screenshot;
                fastColoredTextBox2.Text = File.ReadAllText($"./Script_Hub/{listBox2.SelectedItem}");
            }

            if (listBox2.SelectedIndex != 7)
            {
                pictureBox12.BackgroundImageLayout = ImageLayout.Stretch;
                pictureBox12.BackgroundImage = Resources.REVIZpic;
                fastColoredTextBox2.Text = File.ReadAllText($"./Script_Hub/{listBox2.SelectedItem}");
            }

            if (listBox2.SelectedIndex != 7)
            {
                pictureBox12.BackgroundImageLayout = ImageLayout.Center;
                pictureBox12.BackgroundImage = Resources._252_2522915_screenshot;
                fastColoredTextBox2.Text = File.ReadAllText($"./Script_Hub/{listBox2.SelectedItem}");
            }

            if (listBox2.SelectedIndex != -1)
            {
                fastColoredTextBox2.Text = File.ReadAllText($"./Script_Hub/{listBox2.SelectedItem}");
            }
        }

        private void button33_Click(object sender, EventArgs e)
        {
            string script = fastColoredTextBox2.Text;
            api.SendLimitedLuaScript(script);
        }

        private void button31_Click_1(object sender, EventArgs e)
        {
            panel5.Show();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            panel5.Hide();
        }

        private void topMostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (flatCheckBox1.Checked = true)
            {
                TopMost = true;
                topMostToolStripMenuItem.CheckState = CheckState.Checked;
            }
            else
            {
                TopMost = false;
                topMostToolStripMenuItem.CheckState = CheckState.Unchecked;
            }
        }

        private void CheckIfTopMost_Tick(object sender, EventArgs e)
        {
            CheckTopMost();
        }

        private void executeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string script = fastColoredTextBox1.Text;
            api.SendLimitedLuaScript(script);
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog opendialogfile = new System.Windows.Forms.OpenFileDialog();
            opendialogfile.Filter = "Lua File (*.lua)|*.lua|Text File (*.txt)|*.txt";
            opendialogfile.FilterIndex = 2;
            opendialogfile.RestoreDirectory = true;
            if (opendialogfile.ShowDialog() != DialogResult.OK)
                return;
            try
            {
                fastColoredTextBox1.Text = "";
                System.IO.Stream stream;
                if ((stream = opendialogfile.OpenFile()) == null)
                    return;
                using (stream)
                    this.fastColoredTextBox1.Text = System.IO.File.ReadAllText(opendialogfile.FileName);
            }
            catch (Exception)
            {
                int num = (int)MessageBox.Show("An error has occured", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(saveFileDialog1.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.Write(fastColoredTextBox1.Text);
                }
            }
        }

        private void clearTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Clear();
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox3.SelectedIndex != -1)
            {
                fastColoredTextBox2.Text = File.ReadAllText($"./Local_Script_Hub/{listBox3.SelectedItem}");
            }
        }

        private void refreshListToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.txt");
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.lua");
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.xshd");
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.rtf");
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.log");
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.docx");
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.fcf");
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.rft");
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.smf");
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.lst");
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.apkg");
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.fpt");
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.ott");
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.doc");
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.fodt");
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.fdr");
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.man");
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.sty");
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.rtx");
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.diz");
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.apt");
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.docm");
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.wtt");
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.adoc");
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.textclipping");
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.readme");
            Functions.PopulateListBox(listBox3, "./Local_Script_Hub", "*.md");
        }
    }
}
