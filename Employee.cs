using System;

namespace EmployeeOOP2
{
    public class Employee
    {
        //  Create program constants
        static public decimal MINHOURS =  0.00m;
        static public decimal MAXHOURS = 84.00m;
        static public decimal MINHRATE =  0.00m;
        static public decimal MAXHRATE = 99.990m;

        private string firstName;
        private string lastName;
        private string employeeNumber;
        private decimal hoursWorked;
        private decimal hourlyRate;

        public Employee (string fn, string ln, string en, 
                        decimal hw, decimal hr)
        {
            firstName       = fn;
            LastName        = ln;
            EmployeeNumber  = en;
            HoursWorked     = hw;
            HourlyRate      = hr;
        }

        public string FirstName
        {
            get => firstName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("First name cannot be empty.");
                }

                firstName = value;
            }
        }

        public string LastName
        {
            get => lastName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Last name cannot be empty.");
                }

                lastName = value;
            }
        }

        public string EmployeeNumber
        {
            get => employeeNumber;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Employee number cannot be empty.");
                }

                employeeNumber = value;
            }
        }

        public decimal HoursWorked
        {
            get => hoursWorked;
            set
            {
                if (value < MINHOURS || value > MAXHOURS)
                {
                    throw new ArgumentException("Hours worked must be between " +
                                                MINHOURS + " and " + MAXHOURS);
                }
                hoursWorked = value;
            }
        }

        public decimal HourlyRate
        {
            get => hourlyRate;
            set
            {
                if (value < MINHRATE || value > MAXHRATE)
                {
                    throw new ArgumentException("Hourly rate must be between " +
                                                MINHRATE + " and " + MAXHRATE);
                }
                hourlyRate = value;
            }
        }

        public decimal GrossPay { get; private set; }

        public decimal CalculateGrossPay()
        {
            if (HoursWorked <= 40)
            {
                //  No overtime worked
                GrossPay = Convert.ToDecimal(HoursWorked * HourlyRate);
            }
            else
            {
                //  Overtime worked
                GrossPay = Convert.ToDecimal(40m * HourlyRate)
                    + Convert.ToDecimal((HoursWorked - 40m) * HourlyRate * 1.5m);
            }

            return GrossPay;
        }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName}\nEmployee #: {EmployeeNumber}\nHours Worked: {HoursWorked:n2}\nHourly Rate: {HourlyRate:c}\nGross Pay: {GrossPay:c}";
        }
    }
}
