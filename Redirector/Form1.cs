using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace Redirector
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = ConfigurationManager.AppSettings["app"];
            textBox2.Text = ConfigurationManager.AppSettings["num"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }
        public static void Set(string key, string value)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var entry = config.AppSettings.Settings[key];
            if (entry == null)
                config.AppSettings.Settings.Add(key, value);
            else
                config.AppSettings.Settings[key].Value = value;
            config.Save(ConfigurationSaveMode.Modified);
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            textBox1.Text = openFileDialog1.FileName;
            Set("app", openFileDialog1.FileName);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            bool check = true;
            try
            {
                int temp = Int32.Parse(textBox2.Text);
            }
            catch (Exception exception)
            {
                check = false;
            }
            if (check)
            {
                Set("num", textBox2.Text);
            }
        }
    }
}
