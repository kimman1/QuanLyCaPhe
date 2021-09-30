using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace QLQuanCF.DAO
{
    class DAO_Table
    {
        QLQuanCFEntities db = new QLQuanCFEntities();
        List<Table> listTableforChangeStatus = new List<Table>();
        public List<Table> listTable()
        {
            List < Table > listTemp = new List<Table>();
            listTemp = db.Tables.ToList();
            listTableforChangeStatus = listTemp;
            return listTemp;
        }
        public List<Table> listTableStatusNotUse()
        {
            List<Table> listTempNotUse = new List<Table>();
            listTempNotUse = db.Tables.Select(s => s).Where(s => s.Status == 0).ToList();
            return listTempNotUse;
        }
        public string getTableName(int TableID)
        {
            Table t = db.Tables.Find(TableID);
            return t.TableName;
        }
        public int changeTableStatus(int TableID, int TableStatus)
        {
            Table tempTable = db.Tables.Find(TableID);
            tempTable.Status = TableStatus;
            db.Entry(tempTable).State = EntityState.Modified;
            if (db.SaveChanges() == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
