namespace Business.Features.Portfolios.Dtos
{
    public class UpdatePortfolioDto
    {
        public int Id { get; set; }
        public string Budget { get; set; }
        public string Technologies { get; set; }
        public string Duration { get; set; }
        public string Client { get; set; }
        public string Project { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string SiteLink { get; set; }
    }
}
