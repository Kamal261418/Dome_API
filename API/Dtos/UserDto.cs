using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace API.Dtos
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Passord { get; set; }

        public List<CertificateDto>  certificates { get; set; }
    }
}
