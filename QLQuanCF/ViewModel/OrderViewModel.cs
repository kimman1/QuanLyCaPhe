using QLQuanCF.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQuanCF.ViewModel
{
    class OrderViewModel
    {
        public int OrderID { get; set; }
        public string EmployeeName { get; set; }
        public DateTime OrderDate { get; set; }
        public int TableID { get; set; }
        public string TableName { get; set; }
        DAO_Table daoTable = new DAO_Table();
        DAO_Employee daoEmp = new DAO_Employee();
        
        public OrderViewModel convertOrderViewModel(Order od)
        {
            OrderViewModel odm = new OrderViewModel();
            odm.OrderID = od.OrderID;
            odm.EmployeeName = daoEmp.getEmployeeName(od.EmployeeID);
            odm.OrderDate = od.OrderDate;
            odm.TableID = od.TableID;
            odm.TableName = daoTable.getTableName(od.TableID);
            return odm;
        }
        public List<OrderViewModel> convertListOrderViewModel(List<Order> lod)
        {
            List<OrderViewModel> lodm = new List<OrderViewModel>();
            if (lod.Count != 0)
            {
                foreach (Order od in lod)
                {
                    lodm.Add(convertOrderViewModel(od));
                }
                return lodm;
            }
            return lodm = null;
        }
    }
}
