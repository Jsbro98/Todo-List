using System;

namespace Todo
{
    public class DataHandler
    {

        private List<string> _data;
        private const string _path = "data.csv";

        public DataHandler()
        {
            _data = [];

            if (!File.Exists(_path))
            {
                File.Create($@"./{_path}").Close();
            }

            ReadCSV();
        }

        public void PrintCSV()
        {
            ReadCSV();

            foreach (string line in _data)
            {
                foreach (string word in line.Split(','))
                {
                    Console.WriteLine(word);
                }
            }
        }

        public void WriteToCSV(string data)
        {
            try
            {

                string input = $"{data},";

                using StreamWriter sw = new(_path, true);

                sw.Write(input);
                _data.Add(input);

            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void ReadCSV()
        {
            _data = [.. File.ReadAllLines(_path)];
        }
    }
}