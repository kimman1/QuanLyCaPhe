using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLQuanCF.BUS;
namespace QLQuanCF
{
    public partial class FDangNhap : MetroFramework.Forms.MetroForm
    {

        BUS_Account busAccount = new BUS_Account();
        public FDangNhap()
        {
            InitializeComponent();
           
        }

        private void FDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát chương trình ", "Thông báo",
               MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void btDangNhap_Click(object sender, EventArgs e)
        {
            string Username = textBox1.Text;
            string Password = textBox2.Text;
            int result = busAccount.Login(Username, Password);
            if (result == 1 || result == 0)
            {

                Form fql = new FQL(result);
                fql.Show();
            }
            
        }
        
    }
}
