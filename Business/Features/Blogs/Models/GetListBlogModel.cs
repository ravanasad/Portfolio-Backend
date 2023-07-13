using Business.Features.Blogs.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Blogs.Models
{
    public class GetListBlogModel
    {
        public IList<GetByIdBlogDto> Blogs { get; set; }
    }
}
