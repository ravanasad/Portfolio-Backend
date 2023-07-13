using Business.Features.Portfolios.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Portfolios.Models
{
    public class GetListPortfolioModel
    {
        public List<GetByIdPortfolioDto> Portfolios { get; set; }
    }
}
