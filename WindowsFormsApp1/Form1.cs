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
    //public class LoginEventArgs : EventArgs
    //{
    //    public string Username { get; set; }
    //    public LoginEventArgs(string username)
    //    {
    //        Username = username;
    //    }
    //}
    public partial class Form1 : Form
    {
        public delegate void LoginSuccessEventHandler(object sender, LoginEventArgs e);
        public LoginSuccessEventHandler LoginSuccess;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username=txtUserName.Text;
            string password=txtPassword.Text;
            if (username == "admin" && password == "password")
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoginSuccess?.Invoke(this, new LoginEventArgs(username));
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
    public class LoginEventArgs : EventArgs
    {
        public string Username { get; set; }
        public LoginEventArgs(string username)
        {
            Username = username;
        }
    }

}
