using System;

namespace Task2
{

    static class Task2
    {
        /*
         * Function that returns minimal time of work
         * Two xerox time compare and  the faster and the slower printer determine.
         * Add the time of the faster printer to minimal time of work
         * and get one copy two printers to work at the same time
         * The number of slower printings will be = copies to do/(slowerPrintertime/fasterPrinterTime+1)
         * and the number of faster printings will = number of copies last - number of slower printings (by calculations)
         * As printers work at the same time the minimal time of parallel work will be a time of work of the printer
         * that works longer
         */
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
            if (numberOfFasterPrintings > numberOfSlowerPrintings)
                minimalTimeOfWork += numberOfFasterPrintings * fasterPrinterTime;
            else minimalTimeOfWork += numberOfSlowerPrintings * slowerPrinterTime;

            return minimalTimeOfWork;
        }
        /* 
         * Gets a value from console, if it's convertable to unsigned int and the value is not a 0, 
         * returns an unsigned int value, otherwise writes a message asking to enter a new value while not correct.
         */
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

            Console.WriteLine("Enter Number of copies");
            uint N = GetUIntFromConsole();
            Console.WriteLine("Enter First Xerox Time");
            uint x = GetUIntFromConsole();
            Console.WriteLine("Enter Enter Second Xerox Time");
            uint y = GetUIntFromConsole();
            Console.Write("Minimal Time of Work is: ");
            Console.WriteLine(SecretaryJennifer(N, x, y)); //Function invokation

        }
    }
}
