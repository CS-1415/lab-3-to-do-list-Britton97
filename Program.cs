//Britton Whitaker
//September 18, 2024
//Lab 3 - To Do List
using System;

class Program
{
    public static List<Task> tasks = new List<Task>();
    static void Main(string[] args)
    {
        //read input from user
        bool running = true;
        while (running)
        {
            DisplayTasks();
            string input = Console.ReadLine() ?? string.Empty;
            switch (input.ToLower())
            {
                case "+":
                    AddTask();
                    break;
                case "i":
                    InfoOnTask();
                    break;
                case "x":
                    ToggleCompleteStatus();
                    break;
                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    static void DisplayTasks()
    {
        Console.Clear();
        Console.WriteLine("ID Tasks");
        Console.WriteLine("--------");
        foreach (Task task in tasks)
        {
            Console.WriteLine(task.DisplayTask());
        }
        Console.WriteLine("Press '+' to add a task. Press 'x' to toggle whether or not the task is complete. Press 'i' to view a task's information.");
    }

    static void AddTask()
    {
        Task task = new Task();
        Console.WriteLine("Enter the task title:");
        task.Title = Console.ReadLine() ?? string.Empty;
        Console.WriteLine("Enter the task description:");
        task.Description = Console.ReadLine() ?? string.Empty;
        task.ID = tasks.Count + 1;
        tasks.Add(task);
    }

    static void InfoOnTask()
    {
        //ask for the task ID
        Console.WriteLine("Enter the task ID:");
        string input = Console.ReadLine() ?? string.Empty;
        if (int.TryParse(input, out int id))
        {
            try
            {
                Console.WriteLine(tasks[id - 1].DisplayDescription());
            }
            catch
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please try again.");
        }
    }

    static void ToggleCompleteStatus()
    {
        //ask for the task ID
        Console.WriteLine("Enter the task ID:");
        string input = Console.ReadLine() ?? string.Empty;
        if (int.TryParse(input, out int id))
        {
            try
            {
                tasks[id - 1].MarkAsCompleted();
            }
            catch
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please try again.");
        }
    }
}

class Task
{
    #region Variables and Properties
    private int id;
    private string description;
    private string title;
    private bool isComplete;

    public int ID
    {
        get { return id; }
        set { id = value; }
    }

    public string Description
    {
        get { return description; }
        set { description = value; }
    }

    public string Title
    {
        get { return title; }
        set { title = value; }
    }

    public bool IsComplete
    {
        get { return isComplete; }
        set { isComplete = value; }
    }
    #endregion
    public string DisplayTask()
    {
        return $"[{(IsComplete ? "X" : " ")}] {ID} {Title}";
    }
    public string DisplayDescription()
    {
        return Description;
    }
    public void MarkAsCompleted()
    {
        IsComplete = true;
    }
}