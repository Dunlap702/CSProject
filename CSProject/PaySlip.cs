using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProject
{
    internal class PaySlip
    {
        private int month;
        private int year;

        enum MonthsOfYear
        {
            JAN = 1, FEB = 2, MAR, APR, MAY,
            JUN, JUL, AUG, SEPT, OCT,
            NOV, DEC
        }

        public PaySlip(int payMonth, int payYear)
        {
            this.month = payMonth;
            this.year = payYear;
        }

        public void GeneratePaySlip(List<Staff> myStaff)
        {
            string path;
            foreach (var staff in myStaff)
            {
                path = $"{staff.NameOfStaff}.txt";
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine($"PAYSLIP FOR {(MonthsOfYear)month} {year}");
                    sw.WriteLine($"==========================");
                    sw.WriteLine($"Name of Staff: {staff.NameOfStaff}");
                    sw.WriteLine($"Hours Worked: {staff.HoursWorked}");
                    sw.WriteLine("");
                    sw.WriteLine($"Basic Pay: {staff.BasicPay:c}");

                    if (staff.GetType() == typeof(Manager))
                        sw.WriteLine($"Allowance: {((Manager)staff).Allowance}");
                    else if (staff.GetType() == typeof(Admin))
                        sw.WriteLine($"Overtime Pay: {((Admin)staff).Overtime}");

                    sw.WriteLine($"==========================");
                    sw.WriteLine($"Total Pay: {staff.TotalPay:c}");
                    sw.WriteLine($"==========================");
                    sw.Close(); 
                }
            }
        }
        public void GenerateSummary(List<Staff> myStaff)
        {
            var result =
                from staff in myStaff
                where staff.HoursWorked < 10
                orderby staff.NameOfStaff ascending
                select new { staff.NameOfStaff, staff.HoursWorked };

            string path = "sumarry.txt";
            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine("Staff with less than 10 working hours");
            sw.WriteLine("");
            foreach (var item in result)
            {
                sw.WriteLine($"Name of Staff: {item.NameOfStaff}, Hours Worked: {item.HoursWorked}");
            }
            sw.Close();
        }
        public override string ToString()
        {
            return $"Month: {month}\n" +
                $"Year: {year}\n";
        } 
    }
}
