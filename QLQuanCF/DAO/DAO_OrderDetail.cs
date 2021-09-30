using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQuanCF.DAO
{
    class DAO_OrderDetail
    {
        QLQuanCFEntities db = new QLQuanCFEntities();
        public List<OrderDetail> listOrderDetail(int OrderID)
        {
            List<OrderDetail> listTemp = new List<OrderDetail>();
            listTemp = db.OrderDetails.Select(s => s).Where(s => s.OrderID == OrderID).ToList();
            return listTemp;
        }
    }
}
