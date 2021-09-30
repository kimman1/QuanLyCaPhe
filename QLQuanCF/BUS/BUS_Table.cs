using QLQuanCF.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQuanCF.BUS
{
    class BUS_Table
    {
        DAO_Table daoTable = new DAO_Table();
        public void loadCbTable(ComboBox cb)
        {
            List<Table> listTemp = new List<Table>();
            foreach (Table t in daoTable.listTableStatusNotUse())
            {
                Table temp = new Table();
                temp.TableName = t.TableName.Trim();
                temp.TableID = t.TableID;
                temp.Status = t.Status;
                listTemp.Add(temp);
            }
            cb.DataSource = null;
            cb.DataSource = listTemp;
            if (listTemp.Count == 0)
            {
                cb.Text = "Bàn đã sử dụng hết";
                cb.Enabled = false;
            }
            else
            {
                cb.Enabled = true;
                cb.DisplayMember = "TableName";
                cb.ValueMember = "TableID";
            }
            
        }
        public void changeTableStatus(int TableID, int TableStatus)
        {
           int result =  daoTable.changeTableStatus(TableID, TableStatus);
            if (result == 1)
            {
                MessageBox.Show("Thay đổi trạng thái bàn thành công");
            }
            else
            {
                MessageBox.Show("Thay đổi trạng thái bàn thất bại");
            }
        }
    }
}
