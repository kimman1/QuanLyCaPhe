using QLQuanCF.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQuanCF.BUS
{
    class BUS_Product
    {
        DAO_Product DAOEmp = new DAO_Product();

        public void loadDataGridViewSP(DataGridView dg)
        {
            dg.DataSource = null;
            dg.DataSource = DAOEmp.ListProduct();
        }
        public void AddEmploy(Product product)
        {
            DAOEmp.AddProduct(product);
        }
        public void EditEmploy(Product pro)
        {
            DAOEmp.EditProduct(pro);
        }
        public void RemoveEmploy(int id)
        {
            Boolean check = DAOEmp.Removepro(id);
            if (check == false)
            {
                MessageBox.Show("Xoa loi");
            }
            else
            {
                MessageBox.Show("Xoa thanh cong");
            }
        }
        public void loadcbEmp(ComboBox cb)
        {
            List<Product> listPro = DAOEmp.ListProduct();
            List<Product> t = new List<Product>();
            foreach (Product temp in listPro)
            {
                Product tempProduct = new Product();
                tempProduct.ProductID = temp.ProductID;
                tempProduct.ProductName = temp.ProductName.Trim();
                tempProduct.UnitPrice = temp.UnitPrice;
                t.Add(tempProduct);
            }
            cb.DataSource = null;
            cb.DataSource = t;
            cb.DisplayMember = "ProductName".Trim();
            cb.ValueMember = "ProductID";
        }
    }
}
