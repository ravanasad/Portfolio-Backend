

namespace Domain.Views
{
    public class BlogView
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string About { get; set; }
        public string Header { get; set; }
        public DateTime Date { get; set; }
        public string Categories { get; set; }

        public string Path { get; set; }
        public string ProfilePhotoPath { get; set; }

        public string Email { get; set; }
    }
}
