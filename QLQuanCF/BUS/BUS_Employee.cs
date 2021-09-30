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
    class BUS_Employee
    {
        DAO_Employee DAOEmp = new DAO_Employee();
       
        public void loadDataGridViewNV(DataGridView dg)
        {
            dg.DataSource = DAOEmp.ListEmp();
        }
        public void AddEmploy(Employee employee)
        {
            DAOEmp.AddEmployee(employee);
        }
        public void EditEmploy(Employee emp)
        {
            DAOEmp.EditEmployee(emp);
        }
        public void RemoveEmploy(int id)
        {
            Boolean check = DAOEmp.RemoveEmpoyee(id);
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
            cb.DataSource = null;
            cb.DataSource = DAOEmp.ListEmp();
            cb.DisplayMember = "LastName".Trim();
            cb.ValueMember = "EmployeeID".Trim();
        }
    }
}
