using DBYTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DBYTest.Controllers
{
    public class DebitController : Controller
    {
        private readonly ILogger<DebitController> _logger;
        private readonly DemirbasYonetimiContext _db;

        public DebitController(ILogger<DebitController> logger, DemirbasYonetimiContext db)
        {
            _db = db;
            _logger = logger;
        }

        // GET: /DebitRegister
        public IActionResult DebitRegister()
        {
            return View("~/Views/Home/Debit/DebitRegister.cshtml");
        }


        public IActionResult Index()
        {
            var result = _db.TblDebitEnters.ToList();

            return View(result);
        }

        // POST: /DebitRegister
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult DebitRegister(TblDebitEnter model)
        {

            if (ModelState.IsValid)
            {
                // Yeni kullanıcıyı oluşturun
                var debit = new TblDebitEnter
                {
                    Id = model.Id,
                    BarkodNo = model.BarkodNo,
                    DemirbasTuru = model.DemirbasTuru,
                    Marka = model.Marka,
                    Model2 = model.Model2,
                    UrunSeriNo = model.UrunSeriNo,
                    Imeino = model.Imeino,
                    Macadres1 = model.Macadres1,
                    Macadres2 = model.Macadres2,
                    TedarikciFirma = model.TedarikciFirma,
                    DemirbasDurumu = model.DemirbasDurumu,
                    Lokasyon = model.Lokasyon,
                    RafSiraNo = model.RafSiraNo,
                    YazilimSistem = model.YazilimSistem,
                    SiparisNo = model.SiparisNo,
                    FaturaTarihi = model.FaturaTarihi,
                    TeminTarihi = model.TeminTarihi,
                    SonKullanmaTarihi = model.SonKullanmaTarihi,
                    GarantiBitisTarihi = model.GarantiBitisTarihi,
                    FaturaTutari = model.FaturaTutari,
                    ZimmetliPersonel = model.ZimmetliPersonel,
                    ServisHizmeti = model.ServisHizmeti,
                    EkDemirbas = model.EkDemirbas,
                    Aciklama = model.Aciklama,
                    Capex = model.Capex,
                    Opex = model.Opex,
                    DuranVarlik = model.DuranVarlik,
                    Yatirim = model.Yatirim,
                    LisansEtiketi = model.LisansEtiketi,
                    Creadate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Owner = model.Owner

                    // Diğer özellikleri buraya ekleyin


                };

                // Combobox'ın değerini alın
                string owner = debit.Owner?.ToString() ?? "";


                // Combobox'ın değerini string veri tipine dönüştürün
                string ownerStr = null;
                if (owner != null)
                {
                    ownerStr = owner;
                }

                // Combobox'ın değerini veritabanına kaydedin
                debit.Owner = ownerStr;

                //Liste 
                List<TblDebitEnter> debits = new List<TblDebitEnter>();
                


                // Kullanıcıyı veritabanına ekleyin
                _db.TblDebitEnters.Add(debit);
                _db.SaveChanges();

                // Kayıt işlemi başarılıysa, başka bir sayfaya yönlendirin
                return RedirectToAction("DebitRegister");
            }

            // Kayıt işlemi başarısız olduysa veya model geçerli değilse, tekrar kayıt formunu gösterin
            return View(model);
        }
    }
}
