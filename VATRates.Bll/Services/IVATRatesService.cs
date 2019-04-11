using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VATRates.Bll.ViewModels;

namespace VATRates.Bll.Services
{
    public interface IVATRatesService
    {
        Task<VATRatesVM> InitializeAsync();
    }
}
