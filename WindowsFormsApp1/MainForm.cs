using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Form1 form=new Form1();
            form.LoginSuccess += OnLoginSucess;
            form.ShowDialog();
        }
        private void OnLoginSucess(object sender, LoginEventArgs e)
        {
            MessageBox.Show($"welcome, {e.Username}", "event trigged", MessageBoxButtons.OK, MessageBoxIcon.Information);
            label1.Text = $"welcome,{e.Username}";
        }
    }
}
