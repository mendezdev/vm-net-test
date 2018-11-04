using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Tests.Quotation
{
    public class QuotationFakeData
    {
        public List<string>  GetCorrectQuotationInformation()
        {
            return new List<string>
            {
                "10.00",
                "12.20",
                ""
            };
        }

        public QuotationResponse GetCorrectQuotationResponse()
        {
            return new QuotationResponse
            {
                PurchasePrice = (decimal)10.00,
                SalePrice = (decimal)12.20
            };
        }
    }
}
