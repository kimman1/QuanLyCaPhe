using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQuanCF.DAO
{
    class DAO_Order
    {
        QLQuanCFEntities db = new QLQuanCFEntities();

        public List<Order> listOrder()
        {
            List<Order> listOrder = db.Orders.Where(s=>s.OrderStatus == 1).ToList();
            return listOrder;
        }
        public void AddOrder(Order od)
        {
            db.Orders.Add(od);
            Table t = db.Tables.Select(s => s).Where(s => s.TableID == od.TableID).FirstOrDefault();
            t.Status = 1;
            od.OrderStatus = 1;
            db.SaveChanges();
        }
        public void AddOrderDetail(OrderDetail od)
        {
            Product temp = db.Products.Select(s => s).Where(s => s.ProductID == od.ProductID).FirstOrDefault();
            od.UnitPrice = temp.UnitPrice;
            db.OrderDetails.Add(od);
            db.SaveChanges();
        }
        public void changeOrderStatus(int OrderID, int OrderStatus)
        {
            Order od = new Order();
            od = db.Orders.Select(s => s).Where(s => s.OrderID == OrderID).First();
            od.OrderStatus = OrderStatus;
            db.SaveChanges();
        }
    }
}
