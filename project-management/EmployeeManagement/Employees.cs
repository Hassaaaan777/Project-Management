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
    Functions Con;
    public partial class Employees : Form
    {
        public Employees()
        {
            InitializeComponent();
            Con = new Functions();
            ShowEmp();
            GetDepartment();
        }
        private void ShowEmp()
        {
            string Query = "Select * from EmployeeTb1";
            EmployeeList.DataSource = Con.GetData(Query);
        }
        private void GetDepartment() {
            string Query = "select * from DepartmentTb1";
            DepCb.DisplayMember = Con.GetData(Query).Columns("DepName").ToString();
            DepCb.ValueMember = Con.GetData(Query).Columns["DepId"].ToString();
            DepCb.DataSource = Con.GetData(Query);

        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (EmpNameTb.Text == "" || GenCb.SelectedIndex == -1 || DepCb.SelectedIndex == -1 || DailySalTb.Text == "") ;
                {
                    MessageBox.Show("Missing Data!!!");
                }
                else
                {
                    string Name = EmpNameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString();
                    int Dep = Convert.ToInt32(GenCb.SelectedValue.ToString());
                    string DOB = DOBTb.Value.ToString();
                    string JDate = JDateTb.Value.ToString();
                    int Salary = Convert.ToInt32( DailySalTb.Text);
                    
                    string Query = "insert into EmployeeTb1 values('{0}','{1}','{2}','{3}','{4}','{5}')";
                    Query = string.Format(Query, Name,Gender,Dep,DOB,JDate,Salary);
                    Con.SetData(Query);
                    ShowEmp();
                    MessageBox.Show("Department Added!!");
                    EmpNameTb.Text = "";
                    DailySalTb.Text = "";
                    GenCb.SelectedIndex = -1;
                    DepCb.SelectedIndex = -1;

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (key == 0) ;
                {
                    MessageBox.Show("Missing Data!!!");
                }
                else
                {
                    

                    string Query = "delete from EmployeeTb1 where EmpId={0}";
                    Query = string.Format(Query, key);
                    Con.SetData(Query);
                    ShowEmp();
                    MessageBox.Show("Department Deleted!!");
                    EmpNameTb.Text = "";
                    DailySalTb.Text = "";
                    GenCb.SelectedIndex = -1;
                    DepCb.SelectedIndex = -1;

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (EmpNameTb.Text == "" || GenCb.SelectedIndex == -1 || DepCb.SelectedIndex == -1 || DailySalTb.Text == "") ;
                {
                    MessageBox.Show("Missing Data!!!");
                }
                else
                {
                    string Name = EmpNameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString();
                    int Dep = Convert.ToInt32(GenCb.SelectedValue.ToString());
                    string DOB = DOBTb.Value.ToString();
                    string JDate = JDateTb.Value.ToString();
                    int Salary = Convert.ToInt32(DailySalTb.Text);

                    string Query = "Updte EmployeeTb1 set EmpName='{0}',EmpGen='{1}',EmpDep='{2}',EmpDOB='{3}',EmpJDate='{4}',EmpSaal='{5}' EmpId={6}";
                    Query = string.Format(Query, Name, Gender, Dep, DOB, JDate, Salary,key);
                    Con.SetData(Query);
                    ShowEmp();
                    MessageBox.Show("Department Added!!");
                    EmpNameTb.Text = "";
                    DailySalTb.Text = "";
                    GenCb.SelectedIndex = -1;
                    DepCb.SelectedIndex = -1;

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }
    }
}
