namespace SchoolAPI.Data.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfClasses { get; set; }
        public List<Student> Students { get; set; }
    }
}
