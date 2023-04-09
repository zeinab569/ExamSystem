namespace Examsystem
{
    public class Subject
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Subject(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }

}
