using System;
using System.Text.RegularExpressions;

namespace CountingValleysCodeExcercise
{
    class Program
    {
        private static string valleyWallUp = "U";
        private static string valleyWallDown = "D";

        /// <summary>
        /// Main method of the console app program.
        /// The purpose of this excercise is to figure out the number of times you came back up to sea level.
        /// Up's and down's are represented by letters U and D.
        /// Example:
        /// </summary>
        /// <param name="args">Application arguments.</param>
        public static void Main(string[] args)
        {
            // Get string valley simulation to start the test.
            Console.WriteLine("Please provide a string to simulate valleys and hit enter to continue (Example: UUDUUDDDDUUD, expected result: 1): ");
            string valleySimulationString = Console.ReadLine();

            // Analyze the string to count valleys
            int valleyCountResult = GetValleyCount(valleySimulationString);

            Console.WriteLine("Number of valleys: " + valleyCountResult);
            Console.WriteLine("Please type any key to end the test.");
            Console.ReadLine();
        }

        #region Private functions

        /// <summary>
        /// Count the valleys.
        /// </summary>
        /// <param name="valleySimulationString"></param>
        /// <returns></returns>
        private static int GetValleyCount(string valleySimulationString)
        {
            // Check for any characters different from up and down.
            var characterExceptionsCount = Regex.Matches(valleySimulationString.ToUpper(), $@"[^{valleyWallUp}{valleyWallDown}]").Count;

            // Throw exception if the string contains other caracters than the allowed.
            if (characterExceptionsCount > 0)
                throw new ArgumentException("Only the following characters are allowed for this test: U, D");

            // Check for the minimum characters to create a valley
            if (valleySimulationString.Length < 2)
            {
                return 0;
            }

            // Convert the string content into a char array.
            char[] valleyCharArray = valleySimulationString
                                        .ToUpper()
                                        .ToCharArray();

            // Set sea level to 0 value.
            int seaLevel = 0;

            // Set vallye counter to 0 value.
            int valleyCounter = 0;

            // Iterate char array looking for ups and downs and count the valleys.
            foreach (char valleyWall in valleyCharArray)
            {
                // Check for Up's
                if (valleyWall.ToString() == valleyWallUp)
                {
                    seaLevel++;
                }

                // Check for Down's
                if (valleyWall.ToString() == valleyWallDown)
                {
                    seaLevel--;
                }

                // Check for valley
                if (seaLevel == 0 && valleyWall.ToString() == "U")
                {
                    valleyCounter++;
                }
            }

            return valleyCounter;
        }

        #endregion
    }
}
