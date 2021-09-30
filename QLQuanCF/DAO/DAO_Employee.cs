using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQuanCF.DAO
{
    class DAO_Employee
    {
        QLQuanCFEntities db = new QLQuanCFEntities();

        public List<Employee> ListEmp()
        {
            List<Employee> listemp = db.Employees.ToList();
            return listemp;
            
        }
        public string getEmployeeName(int EmployeeID)
        {
            return db.Employees.Find(EmployeeID).LastName;
        }
        public void AddEmployee(Employee emp)
        {
            
            db.Employees.Add(emp);
            db.SaveChanges();
        }
        public void EditEmployee(Employee emp)
        {
            Employee empdb = new Employee();
            empdb = db.Employees.Select(s => s).Where(s => s.EmployeeID == emp.EmployeeID).FirstOrDefault();
            empdb.FirstName = emp.FirstName;
            empdb.LastName = emp.LastName;
            empdb.Phone = emp.Phone;
            empdb.Sex = emp.Sex;
            empdb.BirthDate = emp.BirthDate;
            empdb.Address = emp.Address;
            
            db.SaveChanges();
        }
        public bool RemoveEmpoyee(int id)
        {
            var tempEmpCheck = db.Orders.Select(s => s).Where(s => s.EmployeeID == id).ToList();
            if (tempEmpCheck.Count == 0)
            {
                Employee temp = new Employee();
                temp = db.Employees.Select(s => s).Where(s => s.EmployeeID == id).FirstOrDefault();
                db.Employees.Remove(temp);
                db.SaveChanges();
                return true;
            }
            else
                return false;
        }
    }
}
