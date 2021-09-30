using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQuanCF.DAO
{
    class DAO_OrderDetail
    {
        QLQuanCFEntities db = new QLQuanCFEntities();
        List<OrderDetail> listOrderDetailForPriceSumary = new List<OrderDetail>();
        public List<OrderDetail> listOrderDetail(int OrderID)
        {
            List<OrderDetail> listTemp = new List<OrderDetail>();
            listTemp = db.OrderDetails.Where(s => s.OrderID == OrderID).ToList();
            listOrderDetailForPriceSumary = listTemp;
            return listTemp;
        }
       
        public int getSumaryPrice() // will get list from listOrderDetail for better performance
        {
            int price = 0;
            foreach (OrderDetail od in listOrderDetailForPriceSumary)
            {
                price += od.Quantity * od.UnitPrice;
            }
            return price;
        }
        public bool EditOrderDetailQuantity(int OrderID, int ProductID, int Quantity)
        {
            OrderDetail od = db.OrderDetails.Where(s => s.OrderID == OrderID && s.ProductID == ProductID).FirstOrDefault();
            if (od == null)
            {
                return false;
            }
            else
            {
                db.Entry(od).State = EntityState.Modified;
                od.Quantity = od.Quantity + Quantity;
                db.SaveChanges();
                return true;
            }
           
        }
        public OrderDetail getOrderDetail(int OrderID, int ProductID)
        {
            OrderDetail od = db.OrderDetails.Where(s => s.OrderID == OrderID && s.ProductID == ProductID).FirstOrDefault();
            return od;
        }
    }
}
