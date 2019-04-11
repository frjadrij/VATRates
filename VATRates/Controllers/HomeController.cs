using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VATRates.Bll.Services;
using VATRates.Bll.ViewModels;

namespace VATRates.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVATRatesService _VATRatesService;

        public HomeController(IVATRatesService VATRatesService)
        {
            this._VATRatesService = VATRatesService;
        }

        public async Task<ActionResult> Index()
        {
            VATRatesVM viewModel = new VATRatesVM();
            try
            {
                viewModel = await _VATRatesService.InitializeAsync();
            }
            catch(Exception)
            {          
               
            }
            return View(viewModel);
        }
    }
}