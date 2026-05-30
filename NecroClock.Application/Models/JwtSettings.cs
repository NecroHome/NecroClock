using System;
using System.Collections.Generic;
using System.Text;

namespace NecroClock.Application.Models
{
    public class JwtSettings
    {
        public string TokenKey { get; set; }
        public string RefreshTokenKey { get; set; }
        public string Issuer {  get; set; }
        public string Audience {  get; set; }
        public int AccessTokenExpirationTimeMinutes {  get; set; }
        public int RefreshTokenExpirationTimeDays {  get; set; }
    }
}
