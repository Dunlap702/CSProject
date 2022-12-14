using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProject
{
    internal class Manager : Staff
    {
        private const float managerHourlyRate = 50;
        public int Allowance { get; private set; }

        public Manager(string name) : base(name, managerHourlyRate) { }

        public override void CalculatePay()
        {
            base.CalculatePay();
            Allowance = 1000;
            if (HoursWorked > 160)
                TotalPay = BasicPay + Allowance;
        }
        public override string ToString()
        {
            return $"Name of Staff: {NameOfStaff}\n" +
                $"Manager Hourly Rate: {managerHourlyRate}\n" +
                $"Hours Worked: {HoursWorked}\n" +
                $"Basic Pay: {BasicPay}\n" +
                $"Allowance: {Allowance}\n" +
                $"Total Pay: {TotalPay}";
        }
    }
}
