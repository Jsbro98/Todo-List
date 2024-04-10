using System.Text;

namespace Todo
{
    public class Program
    {
        static void Main(string[] args)
        {
            //UI ui = new();

            //ui.Start();

            var dataHandler = new DataHandler();

            dataHandler.WriteToCSV("Test");
            dataHandler.WriteToCSV("Hello");
            dataHandler.WriteToCSV("Beep");
            dataHandler.WriteToCSV("Okay");

            dataHandler.PrintCSV();
        }
    }
}
