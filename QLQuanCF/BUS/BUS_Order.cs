using QLQuanCF.DAO;
using QLQuanCF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQuanCF.BUS
{
    class BUS_Order
    {
        DAO_Product daoProduct = new DAO_Product();
        DAO_Order daoOrder = new DAO_Order();
        DAO_Table daoTable = new DAO_Table();
        OrderViewModel odm = new OrderViewModel();
        public void loadcbProduct(ComboBox cb)
        {
            cb.DataSource = null;
            cb.DataSource = daoProduct.ListProduct();
            cb.DisplayMember = "ProductName".Trim();
            cb.ValueMember = "ProductID".Trim();
        }
        public void loadDgOrder(DataGridView dg)
        {
            dg.DataSource = null;
            dg.DataSource = odm.convertListOrderViewModel(daoOrder.listOrder());
        }
        public void addOrder(int EmployeeID, DateTime OrderDate, int TableID)
        {
            Order od = new Order();
            od.TableID = TableID;
            od.OrderDate = OrderDate;
            od.EmployeeID = EmployeeID;
            daoOrder.AddOrder(od);
             daoTable.changeTableStatus(TableID, 1);
            
        }
        public void addOrderDetail(int OrderID, int ProductID, int Quantity)
        {
            OrderDetail od = new OrderDetail();
            od.OrderID = OrderID;
            od.ProductID = ProductID;
            od.Quantity = Quantity;
            daoOrder.AddOrderDetail(od);
        }
        public void changeOrderStatus(int OrderID, int OrderStatus)
        {
            daoOrder.changeOrderStatus(OrderID, OrderStatus);
        }
    }
}
