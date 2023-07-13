
using Business.Dtos;

namespace Business.Features.Auth.Dtos
{
    public class LoginDto
    {
        public Token Token { get; set; }
        public string Message { get; set; }
    }
}
