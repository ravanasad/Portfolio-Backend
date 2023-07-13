using Domain.Entities;

namespace Business.Features.Jobs.Dtos
{
    public class GetByIdJobDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value
        {
            get
            {
                return 3000;
            }
            set 
            {
                this.Value= value;
            }
        }
        //public string Email { get; set; }
    }
}