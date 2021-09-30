using QLQuanCF.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQuanCF.BUS
{
    class BUS_Account
    {
        DAO_Account DAOaccount = new DAO_Account();
        public int Login(string Username, string Password)
        {
            Account accountLogin =  DAOaccount.account(Username, Password);
            if (accountLogin == null)
            {
                MessageBox.Show("Đăng nhập thất bại");
                return -1;
            }
            else
            {
                MessageBox.Show("Đăng nhập thành công");
                return accountLogin.AccountType;
            }
        }
    }
}
