using Business.Features.Abouts.Dtos.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Abouts.Models
{
    public class GetListAboutModel
    {
        public IList<GetByIdAboutDto> Abouts { get; set; }
    }
}
