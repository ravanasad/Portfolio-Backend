namespace Business.Features.Blogs.Dtos
{
    public class GetByIdBlogDto
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Categories { get; set; }
        public string About { get; set; }
        public string Email { get; set; }
        public string ProfileImage { get; set; }
        public string ImagePath{ get; set; }
    }
}
