using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proje.Api.Model;
using Proje.Bll.Abstract;
using Proje.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RezervasyonController : ControllerBase
    {
        private ITrenService trenService;
        private IVagonService vagonService;
        public RezervasyonController(ITrenService _trenService, IVagonService _vagonService)
        {
            trenService = _trenService;
            vagonService = _vagonService;
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult Rezervasyon(Tren data)
        {
            var tren = trenService.Get(x => x.Id == data.Id).Data;
            var vagon = vagonService.GetAll(x => x.TrenId == data.Id).Data;

            var yerlestirilenYolcu = 0;
            Responses res = new Responses();
            res.responseDetail = new List<ResponseDetail>();

            foreach (var item in vagon)
            {
                var kapasiteOran = item.Kapasite * 0.7;

                if (yerlestirilenYolcu < data.RezervasyonYapilacakKisiSayisi)
                {
                    if (Convert.ToInt32(kapasiteOran) - item.DoluKoltukAdet >= 1)
                    {
                        if (data.RezervasyonYapilacakKisiSayisi > Convert.ToInt32(kapasiteOran) - item.DoluKoltukAdet)
                        {
                            var yolcu = new ResponseDetail { VagonAdi = item.Ad, KisiSayisi = Convert.ToInt32(kapasiteOran) - item.DoluKoltukAdet };
                            yerlestirilenYolcu += Convert.ToInt32(kapasiteOran) - item.DoluKoltukAdet;

                            res.responseDetail.Add(yolcu);
                        }

                        if (data.RezervasyonYapilacakKisiSayisi <= Convert.ToInt32(kapasiteOran) - item.DoluKoltukAdet)
                        {
                            var yolcu = new ResponseDetail { VagonAdi = item.Ad, KisiSayisi = data.RezervasyonYapilacakKisiSayisi - yerlestirilenYolcu };
                            yerlestirilenYolcu = data.RezervasyonYapilacakKisiSayisi;

                            res.responseDetail.Add(yolcu);
                        }
                    }
                }
                else
                {
                    res.Ad = tren.Ad;
                    res.RezervasyonYapilacakKisiSayisi = data.RezervasyonYapilacakKisiSayisi;
                    res.KisilerFarkliVagonlaraYerlestirilebilir = data.KisilerFarkliVagonlaraYerlestirilebilir;

                    return Ok(res);
                }
            }
            if (yerlestirilenYolcu != 0)
            {
                res.Ad = tren.Ad;
                res.RezervasyonYapilacakKisiSayisi = yerlestirilenYolcu;
                res.KisilerFarkliVagonlaraYerlestirilebilir = data.KisilerFarkliVagonlaraYerlestirilebilir;

                return Ok(res);
            }
            else
            {
                List<ResponseDetail> lst = new List<ResponseDetail>();
                Responses res2 = new Responses();
                res2.RezervasyonYapilabilir = false;
                res2.responseDetail = lst;

                return BadRequest(res2);
            }
        }
    }
}
