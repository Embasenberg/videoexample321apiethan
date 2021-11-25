namespace API.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        public Book()
        {
            this.Id = Id;
            this.Title = Title;
            this.Author = Author;
        }

        public override string ToString()
        {
            return Id + " " + Author;
        }
    }
}