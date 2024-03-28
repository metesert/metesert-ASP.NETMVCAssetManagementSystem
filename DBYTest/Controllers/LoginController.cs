using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DBYTest.Models;
using System.Linq;

namespace DBYTest.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly DemirbasYonetimiContext _db;

        public LoginController(ILogger<LoginController> logger, DemirbasYonetimiContext db)
        {
            _logger = logger;
            _db = db;
        }

        // GET: /Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string Email, string Password)
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                ViewData["ErrorMessage"] = "E-posta ve şifre gerekli alanlardır.";
                return View();
            }

            var user = _db.TblUsers.FirstOrDefault(x => x.UserName == Email && x.Password == Password);

            if (user != null)
            {
                // Kullanıcı girişi başarılı, oturumu aç
                // Burada oturumu açmak için Identity veya özel bir oturum yönetimi kullanabilirsiniz.
                // Örneğin, Identity kullanımı projenize bağlı olarak değişiklik gösterebilir.
                // Identity hakkında daha fazla bilgi için resmi belgelere başvurabilirsiniz.
                // Örneğin:
                // await _signInManager.PasswordSignInAsync(user, Password, false, lockoutOnFailure: false);

                // Başarılı giriş durumunda yönlendirme
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Yanlış giriş durumunda hata mesajı ekle
                ViewData["ErrorMessage"] = "Geçersiz giriş denemesi.";
                return View();
            }
        }

        // GET: /Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(TblUser model)
        {
            if (ModelState.IsValid)
            {
                // Yeni kullanıcıyı oluşturun
                var user = new TblUser
                {
                    //Id = model.Id,
                    UserName = model.UserName,
                    Password = model.Password,
                    // Diğer özellikleri buraya ekleyin
                };

                // Kullanıcıyı veritabanına ekleyin
                _db.TblUsers.Add(user);
                _db.SaveChanges();

                // Kayıt işlemi başarılıysa, giriş sayfasına yönlendirin
                return RedirectToAction("Login");
            }

            // Kayıt işlemi başarısız olduysa veya model geçerli değilse, tekrar kayıt formunu gösterin
            return View(model);
        }
    }
}
