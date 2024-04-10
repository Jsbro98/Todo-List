namespace Todo
{
    public class Todo
    {
        private readonly List<string> _list;
        private readonly DataHandler _handler;
        public Todo()
        {
            _list = [];
            _handler = new DataHandler(_list);

            InitList();
        }

        public void Add(string input)
        {
            DataHandler.WriteToCSV(input);
        }

        public void Remove(int number)
        {
            if (number < List.Count || number < 1)
            {
                Console.WriteLine("number is not in range!");
                return;
            }

            DataHandler.Remove(List[number]);
        }

        public void Clear()
        {
            DataHandler.Reset(true);
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

        private void InitList()
        {
            string fileName = "data.csv";
            if (File.Exists(fileName) && new FileInfo(fileName).Length != 0)
            {
                DataHandler.ReadCSV();
            }
        }
    }
}
