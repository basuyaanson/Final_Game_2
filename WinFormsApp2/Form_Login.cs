using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form_Login : Form
    {
        public Form_Login()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userName = textBoxName.Text;

            if (string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("請輸入名稱。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"歡迎, {userName}!", "登入成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetLogininfo.UserName = userName;
                GetLogininfo.StartMenu = true;
                this.Close();
              
            }
        }

       
    }

  
}
