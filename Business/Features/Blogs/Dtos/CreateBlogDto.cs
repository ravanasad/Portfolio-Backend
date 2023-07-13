namespace Business.Features.Blogs.Dtos
{
    public class CreateBlogDto
    {
        public int Id { get; set; }
        public string Header { get; set; } 
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
