using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeMgmt
{
    public partial class Departments : Form
    {
        Functions Con;
        public Departments()
        {
            InitializeComponent();
            Con = new Functions();
            ShowDepartments();

        }

        private void Departments_Load(object sender, EventArgs e)
        {

        }
        private void ShowDepartments() {
            string Query = "Select * from DepartmentTb1";
            DepList.DataSource = Con.GetData(Query);
        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            try {
                if (DepNameTb.Text == "")
                {
                    MessageBox.Show("Missing Data!!!");
                }
                else {
                    string Dep = DepNameTb.Text;
                    string Query = "insert into DepartmentTb1 values('{0}')";
                    Query = string.Format(Query,DepNameTb.Text);
                    Con.SetData(Query);
                    ShowDepartments();
                    MessageBox.Show("Department Added!!");
                    DepNameTb.Text = "";

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        int key = 0;
        private void DepList_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            DepNameTb.Text = DepList.selectedRows[0].Cells[1].Value.ToString();
            if (DepNameTb.Text == "")
            {
                key = 0;
            }
            else {
                key.Convert.ToInt32(DepList.selectedRows[0].Cells[1].Value.ToString());
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (DepNameTb.Text == "")
                {
                    MessageBox.Show("Missing Data!!!");
                }
                else
                {
                    string Dep = DepNameTb.Text;
                    string Query = "Update into DepartmentTb1 set DepName= ('{0}') where DepId = {1} ";
                    Query = string.Format(Query, DepNameTb.Text,key);
                    Con.SetData(Query);
                    ShowDepartments();
                    MessageBox.Show("Department Updated!!");
                    DepNameTb.Text = "";

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (DepNameTb.Text == "")
                {
                    MessageBox.Show("Missing Data!!!");
                }
                else
                {
                    string Dep = DepNameTb.Text;
                    string Query = "Delete from DepartmentTb1  where DepId = {0} ";
                    Query = string.Format(Query, key);
                    Con.SetData(Query);
                    ShowDepartments();
                    MessageBox.Show("Department Deleted!!");
                    DepNameTb.Text = "";

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void EmpLbl_Click(object sender, EventArgs e)
        {
            Employees Obj = new Employees();
            Obj.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }
    }
}
