using WaterOverflow.Models;

namespace WaterOverflow
{
    internal class WaterOverflow
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Water Overflow");
            Console.WriteLine("------------------------------------");

            // ask for and determine number of rows of glasses
            int rowNumber = AskForRowNumber();

            // ask for and determine which glass to check
            int glassIndex = AskForGlassIndex(rowNumber);
            Console.WriteLine($"Glass number: {glassIndex}\n");

            var game = new GameEngine(rowNumber, glassIndex);
            var result = game.Run();
            Console.WriteLine($"Total time to fill glass {glassIndex} at row {rowNumber}: {result} seconds.");
            
        }

        /// <summary>
        /// Loop a prompt to the user to determine which index to check
        /// Continue as long as the input is invalid
        /// </summary>
        /// <param name="rowNumber"></param>
        /// <returns></returns>
        private static int AskForGlassIndex(int rowNumber)
        {
            int glassIndex = 0;
            var errorMsg = $"Please enter a number between 1 and {rowNumber}.\n";
            while (true) 
            {
                if (glassIndex >= 1 && glassIndex <= rowNumber) return glassIndex;
                Console.WriteLine($"Which glass do you want to check? (1-{rowNumber})");
                string input = Console.ReadLine()!;
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine(errorMsg);
                    continue;
                }
                // parse input and continue to loop unless input is valid
                int.TryParse(input, out glassIndex);
                if (glassIndex < 1 && glassIndex < rowNumber)
                {
                    Console.WriteLine(errorMsg);
                    continue;
                }
            }
        }

        /// <summary>
        /// Loop a prompt to the user to determine which row to check
        /// Continue as long as the input is invalid
        /// </summary>
        /// <returns></returns>
        private static int AskForRowNumber()
        {
            var rows = 0;
            var errorMsg = "Please enter a number between 2 and 50.\n";
            while (true)
            {
                if (rows > 1 && rows < 51) return rows;
                Console.Write("Enter a row number: ");
                string input = Console.ReadLine()!;
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine(errorMsg);
                    continue;
                }
                // parse input and continue to loop unless input is valid
                int.TryParse(input, out rows);
                if (!(rows > 1 && rows < 51))
                {
                    Console.WriteLine(errorMsg);
                    continue;
                }
            }
        }
    }
}
