using QLQuanCF.BUS;
using QLQuanCF.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQuanCF
{
    public partial class QLDonHang : MetroFramework.Forms.MetroForm
    {
        BUS_Order busOrder = new BUS_Order();
        BUS_Employee busEmp = new BUS_Employee();
        BUS_Table busTable = new BUS_Table();
        BUS_OrderDetail busOderDetail = new BUS_OrderDetail();
        int idTable = -1;
        int idOrder = -1;
        public QLDonHang()
        {
            InitializeComponent();
        }

        private void QLDonHang_Load(object sender, EventArgs e)
        {
            busOrder.loadcbProduct(cbProduct);
            busEmp.loadcbEmp(cbNhanVien);
            busTable.loadCbTable(cbTableName);
            busOrder.loadDgOrder(dgOrder);
            busOderDetail.loadGridViewOrderDetail(dgOrderDetail,idOrder);
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            if (idTable == -1)
            {
                MessageBox.Show("Vui lòng chọn bàn từ Thông Tin Bàn");
            }
            else
            {
                busOrder.addOrderDetail(idOrder, (int)cbProduct.SelectedValue, (int)nmSoLuong.Value);
                busOderDetail.loadGridViewOrderDetail(dgOrderDetail,idOrder);
                idOrder = -1;
                idTable = -1;
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {

            busOrder.addOrder((int)cbNhanVien.SelectedValue, dtpVao.Value, (int)cbTableName.SelectedValue);
            busOrder.loadDgOrder(dgOrder);
            busTable.loadCbTable(cbTableName);
            idOrder = -1;
            idTable = -1;
        }

        private void dgOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dgOrder.Rows[e.RowIndex];
                idTable = (int)row.Cells["TableID"].Value;
                idOrder = (int)row.Cells["OrderID"].Value;
                //MessageBox.Show(idTable.ToString());
                busOderDetail.loadGridViewOrderDetail(dgOrderDetail, idOrder);
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {

            if (idOrder == -1 || idTable == -1)
            {
                MessageBox.Show("Vui lòng chọn Order muốn thanh toán");
            }
            else
            {
                busTable.changeTableStatus(idTable, 0);
                busOrder.changeOrderStatus(idOrder, 0);
                busTable.loadCbTable(cbTableName);
                busOrder.loadDgOrder(dgOrder);
                busOderDetail.loadGridViewOrderDetail(dgOrderDetail, -1);
                idOrder = -1;
                idTable = -1;
            }
            
        }
    }
}
