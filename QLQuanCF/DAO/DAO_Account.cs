using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQuanCF.DAO
{
    class DAO_Account
    {
        QLQuanCFEntities db = new QLQuanCFEntities();

        public List<Account> listAccount()
        {
            List<Account> listemp = db.Accounts.ToList();
            return listemp;
        }
        public Account account(string UserName, string Password)
        {
            Account accountTemp = db.Accounts.Select(s=>s).Where(s=>s.AccountName == UserName & s.Password == Password).FirstOrDefault();
            return accountTemp;
        } 
    }
}
