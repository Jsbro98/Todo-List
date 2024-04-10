using System;

namespace Todo
{
    public class DataHandler
    {

        private readonly List<string> _data;
        private const string _path = "data.csv";

        public DataHandler(List<string> list)
        {
            _data = list;

            if (!File.Exists(_path))
            {
                File.Create($@"./{_path}").Close();
            }
        }

        public void WriteToCSV(string data)
        {
            try
            {

                string input;

                if (_data.Count > 0)
                {
                    input = $",{data}";
                } else
                {
                    input = $"{data}";
                }

                using StreamWriter sw = new(_path, true);

                sw.Write(input);
                _data.Add(data);

            } catch (IOException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void Remove(string key)
        {
            try
            {
                _data.Remove(key);
                Reset(false);
                
                using StreamWriter sw = new(_path, true);
                for (int i = 0; i < _data.Count; i++)
                {
                    if (i == 0)
                    {
                        sw.Write(_data[i]);
                        continue;
                    }

                    sw.Write($",{_data[i]}");
                }

            } catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void Reset(bool clearDataToo)
        {
            if (clearDataToo)
            {
                _data.Clear();
            }

            using StreamWriter sw = new(_path);
            sw.Write("");
        }

        internal List<string> Data
        {
            get { return _data; }
        }

        internal void ReadCSV()
        {
            string[] words = File.ReadAllLines(_path);

            if (!words[0].Contains(',') && words.Length > 0)
            {
                _data.Add(words[0]);
                return;
            }
            
            foreach(string word in words[0].Split(','))
            {
                _data.Add(word);
            }
        }
    }
}