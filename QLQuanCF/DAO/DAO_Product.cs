using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQuanCF.DAO
{
    class DAO_Product
    {
        
        QLQuanCFEntities db = new QLQuanCFEntities();
        public List<Product> ListProduct()
        {
            List<Product> listPro = db.Products.Select(s=>s).ToList();
            return listPro;
        }
        public void AddProduct(Product pro)
        {

            db.Products.Add(pro);
            db.SaveChanges();
        }
        public void EditProduct(Product pro)
        {
            Product prodb = new Product();
            prodb = db.Products.Select(s => s).Where(s => s.ProductID == pro.ProductID).FirstOrDefault();
            prodb.ProductName = pro.ProductName;
            prodb.UnitPrice = pro.UnitPrice;
            db.SaveChanges();
        }
        public bool Removepro(int id)
        {
            var proCheck = db.Products.Select(s => s).Where(s => s.ProductID == id).ToList();
            if (proCheck.Count == 0)
            {
                Product tpro = new Product();
                tpro = db.Products.Select(s => s).Where(s => s.ProductID == id).FirstOrDefault();
                db.Products.Remove(tpro);
                db.SaveChanges();
                return true;
            }
            else
                return false;
        }


    }

}
