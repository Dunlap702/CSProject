namespace CSProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Staff> myStaff = new();
            FileReader fr = new();
            int month = 0;
            int year = 0;

            while (year == 0)
            {
                Console.WriteLine("\nPlease enter the year: ");

                try
                {
                    year = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{e.Message} Please try again.");
                }
            }

            while (month == 0)
            {
                Console.WriteLine("\nPlease enter the month: ");

                try
                {
                    month = Convert.ToInt32(Console.ReadLine());
                    if (month < 1 || month > 12)
                    {
                        Console.WriteLine("You have entered an invalid month");
                        month = 0;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{e.Message} Please try again.");
                }
            }

            myStaff = fr.ReadFile();

            for (int i = 0; i < myStaff.Count; i++)
            {
                try
                {
                    Console.WriteLine($"\nEnter hours work for {myStaff[i].NameOfStaff}");
                    myStaff[i].HoursWorked = Convert.ToInt32(Console.ReadLine());
                    myStaff[i].CalculatePay();
                    Console.WriteLine(myStaff[i].ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    i--;
                }
            }

            PaySlip ps = new(month, year);

            ps.GeneratePaySlip(myStaff);
            ps.GenerateSummary(myStaff);

        }
    }
}