using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQuanCF
{
    public partial class FQL : MetroFramework.Forms.MetroForm
    {
        private Account loginAccount;
        int AccountType = -1;
        public static List<string> listChildForm = new List<string>();
        public FQL(int resultbypassform)
        {
            InitializeComponent();
            AccountType = resultbypassform;
        }
        public FQL(Account loginAccount)
        {
            this.loginAccount = loginAccount;
        }

        private void FQL_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            if (AccountType == 1)
            {
                btnQLNV.Available = true;
            }
            else if (AccountType == 0)
            {
                btnQLNV.Available = false;
            }
            
         
        }
        private bool CheckExistForm(string name)
        {
            bool check = false;
            foreach(Form frm in this.MdiChildren)
            {
                if(frm.Name == name)
                {
                    check = true;
                    break;
                }
            }
            return check;
        }
        private void ActiveChildForm(string name)
        {
            foreach(Form frm in this.MdiChildren)
            {
                if (frm.Name == name)
                    break;
            }
        }
        private void btnQLNV_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("FQLNhanVien"))
            {
                FQLNhanVien FQLNV = new FQLNhanVien();
                FQLNV.MdiParent = this;
                FQLNV.Show();
                listChildForm.Add("FQLNhanVien");
            }
            else
                ActiveChildForm("FQLNhanVien");
        }
       
       
    }
}
