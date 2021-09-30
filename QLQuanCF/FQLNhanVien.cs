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
    public partial class FQLNhanVien : MetroFramework.Forms.MetroForm
    {
        public FQLNhanVien()
        {
            InitializeComponent();
        }
        BUS_Employee Emp_BUS = new BUS_Employee();
        int id = -1; 

        private void FQLNhanVien_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void LoadForm()
        {
            Emp_BUS.loadDataGridViewNV(DgNV);
            txtEmployeeID.Text = null;
            txtEmployName.Text = null;
            txtPhone.Text = null;
            txtSex.Text = null;
            txtAddress.Text = null;
            dtpBirthDate.Text = null;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            string fullname = txtEmployName.Text;
            string firstName = fullname.Substring(0, fullname.IndexOf(" "));
            string lastName = fullname.Substring(fullname.IndexOf(" ") + 1);
            emp.LastName = lastName;
            emp.FirstName = firstName;
            emp.Phone = txtPhone.Text;
            emp.Address = txtAddress.Text;
            emp.BirthDate = dtpBirthDate.Value;
            emp.Sex = txtSex.Text;
            Emp_BUS.AddEmploy(emp);
            LoadForm();
        }

        private void DgNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtEmployeeID.Text = DgNV.Rows[e.RowIndex].Cells["EmployeeID"].Value.ToString();
                txtEmployName.Text = DgNV.Rows[e.RowIndex].Cells["FirstName"].Value.ToString().Trim() + " " + DgNV.Rows[e.RowIndex].Cells["LastName"].Value.ToString().Trim();
                dtpBirthDate.Text = DgNV.Rows[e.RowIndex].Cells["BirthDate"].Value.ToString();
                txtPhone.Text = DgNV.Rows[e.RowIndex].Cells[4].Value.ToString().Trim();
                if (DgNV.Rows[e.RowIndex].Cells["Sex"].Value != null)
                {
                    txtSex.Text = DgNV.Rows[e.RowIndex].Cells["Sex"].Value.ToString().Trim();
                }
                txtAddress.Text = DgNV.Rows[e.RowIndex].Cells[6].Value.ToString().Trim();
                id = (int)DgNV.Rows[e.RowIndex].Cells[0].Value;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string fullname = txtEmployName.Text;
            string firstName = fullname.Substring(0, fullname.IndexOf(" ")).Trim();
            string lastName = fullname.Substring(fullname.IndexOf(" ") + 1).Trim();
            Employee employToEdit = new Employee();
            employToEdit.EmployeeID = id;
            employToEdit.FirstName = firstName;
            employToEdit.LastName = lastName;
            employToEdit.BirthDate = dtpBirthDate.Value;
            employToEdit.Address = txtAddress.Text;
            employToEdit.Phone = txtPhone.Text;
            employToEdit.Sex = txtSex.Text;
            Emp_BUS.EditEmploy(employToEdit);
            LoadForm();
            id = -1;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult dlrs = MessageBox.Show("Bạn có muốn xóa không?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dlrs == DialogResult.Yes)
            {
                Emp_BUS.RemoveEmploy(id);
                id = -1;
            }
            else
            {
                id = -1;
                return;
            }
            LoadForm();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
