namespace Main
{
    internal class ConsoleClass
    {
        private static string[] _options = new string[] { "Setup", "Something Else" };

        private static void Main()
        {
            while (true)
            {
                for (int i = 0; i < _options.Length; i++)
                {
                    Console.WriteLine(_options[i]);
            }
            }
        }
    }
}
