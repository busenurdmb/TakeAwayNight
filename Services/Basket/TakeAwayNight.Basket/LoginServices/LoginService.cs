namespace TakeAwayNight.Basket.LoginServices
{
    public class LoginService : ILoginService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LoginService(IHttpContextAccessor contextAccessor)
        {
            _httpContextAccessor = contextAccessor;
        }
        //giriş yapan kullanıcının userıd sini alma
        //İİD BİGİSİ JWT SUB KEYWORDUNDE TUTULUYOR.
        public string GetUserId => _httpContextAccessor.HttpContext.User.FindFirst("sub").Value;
    }
}
