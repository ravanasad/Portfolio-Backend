using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Files.Dtos
{
    public class GetByIdFileDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Path { get; set; }
        public string Filename { get; set; }     
    }
}
