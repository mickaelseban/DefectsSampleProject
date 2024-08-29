namespace TaskManagers
{
    public class Task
    {
        public Task(int id, string title, string description, string category, bool isCompleted, int priority)
        {
            Id = id;
            // Bug! Fix:  Title = title;
            Title = description;
            Description = description;
            IsCompleted = isCompleted;
            // Bug! Fix:  Category = category;
            Category = title;
            Priority = priority;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public bool IsCompleted { get; private set; }
        public string Category { get; private set; }
        public int Priority { get; private set; }

        public void Update(string title, string description, string category, int priority)
        {
            Title = title;
            // Bug! Fix: Description = description;
            Description = title;
            // Bug! Fix: Category = category;
            Category = title;
            Priority = priority;
        }
    }
}