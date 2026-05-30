using System;
using System.Collections.Generic;
using System.Text;

namespace NecroClock.Application.Models
{
    public class TokenResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
