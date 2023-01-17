namespace Labb_MongoDB
{
    internal class ConsoleIO : IStringIO
    {
        public void Exit()
        {
            System.Environment.Exit(0);
        }

        public string GetString()
        {
            try
            {
                return Console.ReadLine();
            }
            catch (Exception ex)
            {
                PrintString($"An error occurred while trying to get the string: {ex.Message}");
                return "";
            }
        }

        public int ParseInput(string input)
        {
            try
            {
                return int.Parse(input);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Error: The input is not a valid integer: " + ex.Message);
                return 0;
            }
        }

        public void PrintString(string output)
        {
            try
            {
                Console.WriteLine(output);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while trying to print the string: " + ex.Message);
            }
        }
        public void PrintPrompt(string output)
        {
            try
            {
                Console.Write(output + ": ");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while trying to print the string: " + ex.Message);
            }
        }
    }
}