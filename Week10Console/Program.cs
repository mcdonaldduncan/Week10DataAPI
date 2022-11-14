namespace Week10Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Process Started...");

            Actions actions = new Actions();

            actions.GetAllMonsters();
            actions.GetMonsterByID(5);
            actions.UpdateMonsterByID(5, "Gobbler", "Ghastly Gourd", "100", "150", "Haunted Forest");
            actions.DeleteMonsterByID(10);
            actions.GenerateLogFile();

            actions.ReportErrors();
        }
    }
}