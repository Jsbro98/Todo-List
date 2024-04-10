namespace Todo
{
    public class Todo
    {
        private readonly List<string> _list;
        private DataHandler _handler;
        public Todo()
        {
            _list = [];
            _handler = new DataHandler();
        }

        public void Add(string input)
        {
            List.Add(input);
            DataHandler.WriteToCSV(input);
        }

        public void Remove(int number)
        {
            List.RemoveAt(number);

        }

        public void Clear()
        {
            List.Clear();
            File.Delete("data.csv");
            File.Create("data.csv").Close();
        }

        public int Count
        {
            get { return _list.Count; }
        }


        internal List<string> List
        {
            get { return _list; }
        }

        private DataHandler DataHandler
        {
            get { return _handler; }
        }
    }
}
