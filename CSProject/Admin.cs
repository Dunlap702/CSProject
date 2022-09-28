using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProject
{
    internal class Admin : Staff
    {
        private const float overtimeRate = 15.5f;
        private const float adminHourlyRate = 30f;
        public float Overtime { get; private set; }

        public Admin(string name) : base(name, adminHourlyRate) { }
        public override void CalculatePay()
        {
            base.CalculatePay();
            if(HoursWorked > 160)
            {
                Overtime = overtimeRate * (HoursWorked - 160);
                TotalPay = BasicPay + Overtime;
            }    
        }
        public override string ToString()
        {
            return $"Name of Staff: {NameOfStaff}\n" +
                $"Admin Hourly Rate: {adminHourlyRate}\n" +
                $"Hours Worked: {HoursWorked}\n" +
                $"Overtime: {Overtime}\n" +
                $"Basic Pay: {BasicPay}\n" +
                $"Total Pay: {TotalPay}";
        }
    }
}
