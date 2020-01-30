using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestSysInfo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            ManagementObjectSearcher searcher =
                new ManagementObjectSearcher("SELECT DNSHostName, Domain, Model, SystemType, TotalPhysicalMemory, UserName FROM " + comboBox1.Text);

            foreach (var mo in searcher.Get())
                foreach (PropertyData pd in mo.Properties)
                    textBox1.Text += pd.Name + ":   " + pd.Value + Environment.NewLine ;

            MessageBox.Show(new ManagementObjectSearcher("SELECT Caption FROM " + comboBox1.Text).Get().OfType<ManagementObject>().FirstOrDefault().Properties["Caption"].Name);
        }
    }
}
