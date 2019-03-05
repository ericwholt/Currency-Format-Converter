using System;
using System.Globalization;


namespace Deliverable1
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] amounts = GetAmounts();
            Console.Clear();
            Console.WriteLine("The Average amount is {0}", FormatAmount(AverageAmount(amounts), "en-US"));
            Console.WriteLine("The Smallest amount is {0}", FormatAmount(SmallestAmount(amounts), "en-US"));
            Console.WriteLine("The Largest amount is {0}", FormatAmount(LargestAmount(amounts), "en-US"));

            Console.WriteLine();
            Console.WriteLine("Totals");
            Console.WriteLine("=======================================");
            //Cultures for this proejct United States en-US, Swedish sv-SE, Japanese ja-JP, Thai th-TH
            Console.WriteLine("US: {0}", FormatAmount(TotalAmount(amounts), "en-US"));
            Console.WriteLine("Swedish: {0}", FormatAmount(TotalAmount(amounts), "sv-SE"));
            Console.WriteLine("Japanese: {0}", FormatAmount(TotalAmount(amounts), "ja-JP"));
            Console.WriteLine("Thai: {0}", FormatAmount(TotalAmount(amounts), "th-TH"));
            Console.ReadLine();
        }

        private static double[] GetAmounts()
        {
            double[] amounts = new double[3];
            int count = 0;
            bool isFirstAmountInputAttempt = true;
            while (count < 3)
            {
                bool notValidAmount = true;

                while (notValidAmount)
                {
                    bool isValidAmount = false;
                    Console.Clear();

                    switch (count)
                    {
                        case 0:
                            break;
                        case 1:
                            Console.WriteLine("First Amount: {0}", amounts[0]);
                            break;
                        case 2:
                            Console.WriteLine("First Amount: {0}", amounts[0]);
                            Console.WriteLine("Second Amount: {0}", amounts[1]);
                            break;
                    }
                    
                    if (isFirstAmountInputAttempt)
                    {
                        
                        Console.WriteLine("Please enter a dollar amount. They must be different.");
                        isValidAmount = Double.TryParse(Console.ReadLine(), out amounts[count]);
                        isFirstAmountInputAttempt = false;
                    }
                    else
                    {
                       
                        Console.WriteLine("Invalid dollar amount! Please enter a valid dollar amount. They must be different.");
                        isValidAmount = Double.TryParse(Console.ReadLine(), out amounts[count]);
                    }

                    if (isValidAmount)
                    {
                        if (count == 1)
                        {
                            if (amounts[0] == amounts[1])
                                isValidAmount = false;
                        } else if (count == 2)
                        {
                            if (amounts[0] == amounts[1] || amounts[0] == amounts[2] || amounts[1] == amounts[2])
                            {
                                isValidAmount = false;
                            }
                        }
                    }

                    if (isValidAmount)
                    {
                        notValidAmount = false;
                    }
                }
                count++;
                isFirstAmountInputAttempt = true;
            }

            return amounts;
        }

        private static double TotalAmount(double[] amountsArray)
        {
            double total = 0;
            foreach (var amount in amountsArray)
            {
                total += amount;
            }

            return total;
        }

        private static double AverageAmount(double[] amountsArray)
        {
            return TotalAmount(amountsArray) / amountsArray.Length;
        }

        private static double SmallestAmount(double[] amountsArray)
        {
            double smallestAmount = double.MaxValue;

            foreach (var amount in amountsArray)
            {
                if (smallestAmount > amount)
                    smallestAmount = amount;
            }

            return smallestAmount;
        }

        private static double LargestAmount(double[] amountsArray)
        {
            double largestAmount = double.MinValue;

            foreach (var amount in amountsArray)
            {
                if (largestAmount < amount)
                    largestAmount = amount;
            }

            return largestAmount;
        }

        private static string FormatAmount(double amount, string culture)
        {
            string currency = "C2";

            if (culture == "ja-JP")
            {
                currency = "C0";
            }

            return amount.ToString(currency, CultureInfo.CreateSpecificCulture(culture));
        }
    }
}
