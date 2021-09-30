using QLQuanCF.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQuanCF.BUS
{
    class BUS_OrderDetail
    {
        DAO_OrderDetail daoOrderDetail = new DAO_OrderDetail();
        public void loadGridViewOrderDetail(DataGridView dg, int OrderID)
        {
            dg.DataSource = null;
            
            if (OrderID == -1)
            {
                dg.DataSource = null;
            }
            else
            {
                List<OrderDetail> ListOrderDetail = daoOrderDetail.listOrderDetail(OrderID);
                dg.DataSource = ListOrderDetail;
            }
            
        }
    }
}
