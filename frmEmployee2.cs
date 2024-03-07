using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EmployeeOOP2
{
    public partial class frmEmployee2 : Form
    {
        //  Declare and initialize class variables
        List<Employee> employees = new List<Employee>();

        int totalEmployees =        0;
        decimal totalGross =        0.00m;
        decimal highGross  = -1000000.00m;
        decimal lowGross   =  1000000.00m;
        decimal avgGross   =        0.00m;

        public frmEmployee2()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                string firstName = txtFirstName.Text.Trim();
                string lastName  = txtLastName.Text.Trim();
                string empNumber = txtEmployeeNuber.Text.Trim();
                decimal hours    = Convert.ToDecimal(txtHoursWorked.Text.Trim());
                decimal rate     = Convert.ToDecimal(txtHourlyRate.Text.Trim());
                decimal grossPay = 0m;

                Employee employee = new Employee(firstName, lastName, 
                                        empNumber, hours, rate);
                
                //  Increment total employees
                //  And set associated textbox
                ++totalEmployees;
                txtTotalEmployees.Text = totalEmployees.ToString();

                //  Increment total gross
                //  And set associated textboxes
                grossPay += employee.CalculateGrossPay();
                totalGross += grossPay;
                txtGrossPay.Text = employee.GrossPay.ToString("c");
                txtTotalGrossPay.Text = totalGross.ToString("c");

                //  Check for low gross pay.
                //  If found, update associated textbox
                if (grossPay < lowGross)
                {
                    lowGross = grossPay;
                    txtLowGrossPay.Text = lowGross.ToString("c");
                }

                //  Check for high gross pay.
                //  If found, update associated textbox
                if (grossPay > highGross)
                {
                    highGross = grossPay;
                    txtHighGrossPay.Text = highGross.ToString("c");
                }

                //  Calculate average gross pay
                //  And update the associated textbox
                avgGross = totalGross / totalEmployees;
                txtAvgGrossPay.Text = avgGross.ToString("c");

                //	Add the Employee to a employee list
                employees.Add(employee);

                ShowErrorMessage(employee.ToString(), "CURRENT EMPLOYEE");
            }
        }

        private bool IsValidData()
        {
            bool success = true;
            string errorMessage = "";

            errorMessage += Validator.IsPresent(txtFirstName.Text, nameof(Employee.FirstName));

            errorMessage += Validator.IsPresent(txtLastName.Text, nameof(Employee.LastName));

            errorMessage += Validator.IsPresent(txtEmployeeNuber.Text, nameof(Employee.EmployeeNumber));

            errorMessage += Validator.IsPresent(txtHoursWorked.Text, nameof(Employee.HoursWorked));
            errorMessage += Validator.IsDecimal(txtHoursWorked.Text, nameof(Employee.HoursWorked));
            errorMessage += Validator.IsWithinRange(txtHoursWorked.Text, nameof(Employee.HoursWorked),
                                                    Employee.MINHOURS, Employee.MAXHOURS);

            errorMessage += Validator.IsPresent(txtHourlyRate.Text, nameof(Employee.HourlyRate));
            errorMessage += Validator.IsDecimal(txtHourlyRate.Text, nameof(Employee.HourlyRate));
            errorMessage += Validator.IsWithinRange(txtHourlyRate.Text, nameof(Employee.HourlyRate),
                                                    Employee.MINHRATE, Employee.MAXHRATE);

            if (errorMessage != "")
            {
                success = false;
                ShowErrorMessage(errorMessage, "Entry Error");
            }

            return success;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmployeeNuber.Text = "";
            txtHoursWorked.Text = "";
            txtHourlyRate.Text = "";
            txtGrossPay.Text = "";
            txtFirstName.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ExitProgramOrNot();
        }

        private void ExitProgramOrNot()
        {
            DialogResult dialog = MessageBox.Show(
                        "Do You Really Want To Exit The Program?",
                        "EXIT NOW?",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void ShowErrorMessage(string msg, string title)
        {
            MessageBox.Show(msg, title,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
