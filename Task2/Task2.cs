using System;

namespace Task2
{
    static class Task2
    { 
        static uint SecretaryJennifer(uint numberOfCopies, uint firstXeroxTime, uint secondXeroxTime)
    {
        uint fasterPrinterTime;
        uint slowerPrinterTime;
        uint minimalTimeOfWork = 0;
        if (firstXeroxTime <= secondXeroxTime)
        {
            fasterPrinterTime = firstXeroxTime;
            slowerPrinterTime = secondXeroxTime;
        }
        else
        {
            fasterPrinterTime = secondXeroxTime;
            slowerPrinterTime = firstXeroxTime;
        }
        minimalTimeOfWork += fasterPrinterTime;

            uint numberOfSlowerPrintings = (numberOfCopies - 1) / (slowerPrinterTime / fasterPrinterTime + 1);
            uint numberOfFasterPrintings = numberOfCopies - 1 - numberOfSlowerPrintings;
            if (numberOfFasterPrintings > numberOfSlowerPrintings) minimalTimeOfWork += numberOfFasterPrintings*fasterPrinterTime;
            else minimalTimeOfWork += numberOfSlowerPrintings*slowerPrinterTime;
           
        return minimalTimeOfWork;
        }

        private static uint GetUIntFromConsole()
        {
            uint value = 0;

            bool valueIsCorrect = false;
            while (!valueIsCorrect)
            {
                valueIsCorrect = uint.TryParse(Console.ReadLine(), out value) && value != 0;
                if (!valueIsCorrect)
                {
                    Console.WriteLine("That's not a correct number, please try again");
                }
            };
            return value;
        }
    
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter Number of copies");
                uint N = GetUIntFromConsole();
                Console.WriteLine("Enter First Xerox Time");
                uint x = GetUIntFromConsole();
                Console.WriteLine("Enter Enter Second Xerox Time");
                uint y = GetUIntFromConsole();
                Console.Write("Minimal Time of Work is: ");
                Console.WriteLine(SecretaryJennifer(N, x, y));
            }
        }
    }
}
