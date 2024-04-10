namespace Todo
{
    public class UI
    {
        private readonly Todo _todo;
        public UI()
        {
            _todo = new Todo();
        }

        public void Start()
        {
            while (true)
            {
                string input = AskForCommand();

                if (input == "exit")
                {
                    break;
                }

                ProcessCommand(input);
            }
        }

        private void ProcessCommand(string input)
        {
            switch (input)
            {
                case "1":
                    AddItem();
                    NewLine();
                    break;

                case "2":
                    RemoveItem();
                    NewLine();
                    break;

                case "3":
                    Clear();
                    NewLine();
                    break;

                case "4":
                    PrintList();
                    NewLine();
                    break;

                default:
                    Console.WriteLine("Please input a number between 1-4");
                    break;
            }
        }
        private string AskForCommand()
        {
            Console.WriteLine("What would you like to do with your todo list?");
            Console.WriteLine("""
                1. Add an item
                2. Remove an item
                3. Clear the list
                4. Print the list
                type "exit" to stop
                """);
            Console.WriteLine();

            string input = Console.ReadLine()!;

            if (input.ToLower() == "exit")
            {
                return "exit";
            }

            if (input != "1" && input != "2" && input != "3" && input != "4")
            {
                return AskForCommand();
            }

            return input;
        }

        private void AddItem()
        {
            Console.WriteLine("Enter the item you wish to add\n");
            string? addedItem = Console.ReadLine();

            if (!string.IsNullOrEmpty(addedItem))
            {
                _todo.Add(addedItem);
            }
        }

        private void RemoveItem()
        {
            if (_todo.Count == 0)
            {
                Console.WriteLine("Cannot remove items, List is empty");
                return;
            }

            Console.WriteLine("Which item would you like to remove? Please enter the number associated\n");
            PrintList();

            int numberToRemove;
            try
            {
                numberToRemove = int.Parse(Console.ReadLine()!) - 1;

            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

            _todo.Remove(numberToRemove);

            Console.WriteLine(numberToRemove);
        }

        private void Clear()
        {
            _todo.Clear();
            Console.WriteLine("The list is clear!");
        }

        private void PrintList()
        {
            if (_todo.Count == 0)
            {
                Console.WriteLine("The list is empty!");
                return;
            }

            foreach (var item in _todo.List.Select((value, index) => new { value, index }))
            {
                Console.WriteLine($"{item.index + 1}: {item.value}");
            }
        }

        private void NewLine() => Console.WriteLine();
    }
}
