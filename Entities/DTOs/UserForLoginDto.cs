using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class UserForLoginDto : IDto
    {
        //burası ise giriş yapmak ısteyen bır kısı
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
