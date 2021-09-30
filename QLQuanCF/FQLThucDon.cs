using QLQuanCF.BUS;
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
    public partial class FQLThucDon : MetroFramework.Forms.MetroForm
    {
        public FQLThucDon()
        {
            InitializeComponent();
        }

        BUS_Product Pro_BUS = new BUS_Product();
        int id = -1;
        private void LoadForm()
        {
            Pro_BUS.loadDataGridViewSP(dgTD);

        }

        private void FQLThucDon_Load(object sender, EventArgs e)
        {
            LoadForm();
        }
       
        private void btnRemove_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Product pro = new Product();
            pro.ProductName = txtProductName.Text;
            pro.UnitPrice = int.Parse(txtUnitPrice.Text);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Product proEdit = new Product();
            proEdit.ProductID = id;
            proEdit.ProductName = txtProductName.Text;
            proEdit.UnitPrice = Int32.Parse(txtUnitPrice.Text);
            Pro_BUS.EditEmploy(proEdit);
            LoadForm();
        }

        private void dgTD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtProductName.Text = dgTD.Rows[e.RowIndex].Cells["ProductName"].Value.ToString();
                txtUnitPrice.Text = dgTD.Rows[e.RowIndex].Cells["UnitPrice"].Value.ToString();
                
            }
        }
    }
}
