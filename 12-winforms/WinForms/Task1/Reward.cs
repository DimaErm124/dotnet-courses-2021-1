namespace Task1
{
    public class Reward
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Reward(int id, string title, string description = "")
        {
            ID = id;
            Title = title;
            Description = description;
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
