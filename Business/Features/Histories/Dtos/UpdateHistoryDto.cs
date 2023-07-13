namespace Business.Features.Histories.Dtos
{
    public class UpdateHistoryDto
    {
        public int Id { get; set; }
        public bool Type { get; set; }
        public string Year { get; set; }
        public string JobName { get; set; }
        public string Description { get; set; }
    }
}
