using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Color defaultColor = new Color();
        Color defaultFontColor = new Color();
        ContextMenu cm = null;
        string currentFile = null;
        bool curFileWriting = false;

        List<string> fonts = new List<string>();

        public Form1()
        {
            InitializeComponent();
            textBox1.Enabled = false;
            defaultColor = this.BackColor;
            defaultFontColor = this.ForeColor;
            menuStrip2.Visible = false;
            cm = new ContextMenu();
            MenuItem item = new MenuItem("Open");
            MenuItem item2 = new MenuItem("Rus");
            MenuItem item3 = new MenuItem("Eng");
            cm.MenuItems.Add(item);
            cm.MenuItems.Add(item2);
            cm.MenuItems.Add(item3);
            textBox1.ContextMenu = cm;
            item.Click += openToolStripMenuItem_Click;
            item2.Click += russiaToolStripMenuItem_Click;
            item3.Click += englishToolStripMenuItem_Click;

            defaultToolStripMenuItem_rus.Checked = true;
            

            blackToolStripMenuItem_rus.Click += blackToolStripMenuItem_Click;
            redToolStripMenuItem_rus.Click += redToolStripMenuItem_Click;
            defaultToolStripMenuItem_rus.Click += defaultToolStripMenuItem_Click;

            blackToolStripMenuItem_rus.Click += AddFlagToItem_Black;
            redToolStripMenuItem_rus.Click += AddFlagToItem_Red;
            defaultToolStripMenuItem_rus.Click += AddFlagToItem_Default;

            toolStripComboBox_Fonts.SelectedIndexChanged += ChangeFont;
            toolStripComboBox_Size.SelectedIndexChanged += ChangeSize;

            foreach (FontFamily font in System.Drawing.FontFamily.Families)
            {
                toolStripComboBox_Fonts.Items.Add(font.Name);

            }
            toolStripComboBox_Fonts.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void AddFlagToItem_Default(object sender, EventArgs e)
        {
            blackToolStripMenuItem_rus.Checked = false;
            redToolStripMenuItem_rus.Checked = false;
            defaultToolStripMenuItem_rus.Checked = true;
        }

        private void AddFlagToItem_Red(object sender, EventArgs e)
        {
            blackToolStripMenuItem_rus.Checked = false;
            redToolStripMenuItem_rus.Checked = true;
            defaultToolStripMenuItem_rus.Checked = false;
        }

        private void AddFlagToItem_Black(object sender, EventArgs e)
        {
            blackToolStripMenuItem_rus.Checked = true;
            redToolStripMenuItem_rus.Checked = false;
            defaultToolStripMenuItem_rus.Checked = false;
        }

        private void ChangeSize(object sender, EventArgs e)
        {
            textBox1.Font = new Font(textBox1.Font.FontFamily, float.Parse(toolStripComboBox_Size.SelectedItem.ToString()));
        }

        private void ChangeFont(object sender, EventArgs e)
        {
            textBox1.Font = new Font(toolStripComboBox_Fonts.Text, textBox1.Font.Size);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
           
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = File.ReadAllText(dialog.FileName, Encoding.Default);
                currentFile = dialog.FileName;
                
                textBox1.Enabled = true;
                curFileWriting = true;
            }
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Enabled = true;
            curFileWriting = false;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(dialog.FileName, textBox1.Text,Encoding.Default);
            }
            curFileWriting = true;
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (curFileWriting)
            {
                File.WriteAllText(currentFile, textBox1.Text, Encoding.Default);
            }
            else
            {
                SaveFileDialog dialog = new SaveFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(dialog.FileName, textBox1.Text, Encoding.Default);
                }
                curFileWriting = true;
            }
            
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste();
        }

        private void blackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.Black;
            textBox1.ForeColor = Color.White;


            blackToolStripMenuItem.Checked = true;
            redToolStripMenuItem.Checked = false;
            defaultToolStripMenuItem.Checked = false;
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.Red;

            blackToolStripMenuItem.Checked = false;
            redToolStripMenuItem.Checked = true;
            defaultToolStripMenuItem.Checked = false;
        }

        private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = defaultColor;
            textBox1.ForeColor = defaultFontColor;

            blackToolStripMenuItem.Checked = false;
            redToolStripMenuItem.Checked = false;
            defaultToolStripMenuItem.Checked = true;
        }

        private void russiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip2.Visible = true;
            menuStrip1.Visible = false;

        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip2.Visible = false;
            menuStrip1.Visible = true;
        }

        
    }
}
