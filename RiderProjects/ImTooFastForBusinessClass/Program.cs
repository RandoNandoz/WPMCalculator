using System;

// ReSharper disable once IdentifierTypo
namespace BusinessClassTypingTimerCalculato
{
    internal static class Program
    {
        private static bool _confirmed;
        public static void Main(string[] args)
        {
            GetInput();
            GetConfirmation();
            if (_confirmed)
            {
                GetWords();
            }
            else
            {
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                Main(null);
            }

            var calculator = new Calculator();
            calculator.DoCalculate();
            // ReSharper disable once HeapView.BoxingAllocation
            Console.WriteLine($"Your WPM is: {Calculator.WPM}");
            Console.ReadKey();
        }

        private static void GetInput()
        {
            try
            {
                Console.WriteLine("Input your time in minutes");
                Calculator.InputTimeMinutes = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Input your time in seconds");
                Calculator.InputTimeSeconds = Convert.ToDouble(Console.ReadLine());
                // Prevents the user from inputting a zero.
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                if (Calculator.InputTimeMinutes + Calculator.InputTimeSeconds == 0)
                {
                    // ReSharper disable once HeapView.ObjectAllocation.Evident
                    throw new FormatException();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid format - please try again.");
                GetInput();
            }
        }

        private static void GetConfirmation()
        {
            while (true)
            {
                // ReSharper disable twice HeapView.BoxingAllocation
                Console.WriteLine($"Are you sure?, your time is {Calculator.InputTimeMinutes} minutes and {Calculator.InputTimeSeconds} seconds. y/n?");
                string inputConfirmation = Console.ReadLine();
                switch (inputConfirmation)
                {
                    case "y":
                        _confirmed = true;
                        break;
                    case "n":
                        _confirmed = false;
                        break;
                    default:
                        continue;
                }

                break;
            }
        }

        private static void GetWords()
        {
            try
            {
                Console.WriteLine("How many words?");
                Calculator.Words = Convert.ToDouble(Console.ReadLine());
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                if (Calculator.Words == 0)
                {
                    throw new FormatException();
                }
                // ReSharper disable once HeapView.BoxingAllocation
                Console.WriteLine($"Are you sure? Your words typed are {Calculator.Words} y/n");
                string inputConfirmation = Console.ReadLine();
                if (inputConfirmation != "y")
                {
                    GetWords();
                }
            }
            catch (Exception e)
            {
                GetWords();
                throw;
            }
        }
    }
}