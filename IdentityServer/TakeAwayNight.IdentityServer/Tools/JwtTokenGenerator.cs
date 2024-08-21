using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;

namespace TakeAwayNight.IdentityServer.Tools
{
    public class JwtTokenGenerator
    {
        //static->tek seferlikyer tutuyor
        //aynı class içinde newleme yapmadan ulaşılabililyor.
        public static TokenResponseViewModel GenerateToken(GetCheckAppUserViewModel model)
        {
            //claim=talep etmek client mantığında çalışıyor masa üsütnd bir yere istekde bulunuyorsunuz size bir yanıt dönüüyor burda o görevi görücek formatta çalışacak.
            var claims = new List<Claim>();
            //if (!string.IsNullOrWhiteSpace(model.Role))
                claims.Add(new Claim(ClaimTypes.Role, model.Role));
            //token üretmek için istekde bulunucaz bazı parametreler göndereceğiz token üretmek gönderilen parametreler claim türünde gönderiliyor.ve biz değer üretmek için bu parametreler değer atamaları yapıyoruz

            claims.Add(new Claim(ClaimTypes.NameIdentifier, model.Id));

            //if (!string.IsNullOrWhiteSpace(model.Username))
                claims.Add(new Claim("Username", model.Username));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));

            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expireDate = DateTime.UtcNow.AddMinutes(JwtTokenDefaults.Expire);

            JwtSecurityToken token = new JwtSecurityToken(issuer: JwtTokenDefaults.ValidIssuer, audience: JwtTokenDefaults.ValidAudience, claims: claims, notBefore: DateTime.UtcNow, expires: expireDate, signingCredentials: signingCredentials);

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            return new TokenResponseViewModel(tokenHandler.WriteToken(token), expireDate);
        }
    }
}
