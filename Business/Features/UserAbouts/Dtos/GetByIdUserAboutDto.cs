namespace Business.Features.UserAbouts.Dtos
{
    public class GetByIdUserAboutDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string Fullname { get; set; }
        public string CvPath { get; set; }
        public string ImagePath { get; set; }
        public string Email { get; set; }
    }
}
