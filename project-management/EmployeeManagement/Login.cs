namespace EmployeeMgmt
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            UNameTb.Text = "";
            PasswordTb.Text = "";
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (UNameTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Missing Data!!");
            }
            else if (UNameTb.Text == "Admin" && PasswordTb.Text == "password")
            {
                Employees Obj = new Employees();
                Obj.Show();
                this.Hide();
            }
            else {
                MessageBox.Show("Wrong UserName Or Password!!");
                UNameTb.Text = "";
                PasswordTb.Text = "";
            }
        }
    }
}