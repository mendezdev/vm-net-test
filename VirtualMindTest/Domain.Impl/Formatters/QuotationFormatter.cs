using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Domain.Impl.Formatters
{
    public class QuotationFormatter
    {
        public QuotationResponse ToQuotationResponse(IList<string> quotation)
        {
            // 0 -> purchase, 1 -> sale, 2 -> last update
            var purchasePrice = Convert.ToDecimal(quotation[0]);
            var salePrice = Convert.ToDecimal(quotation[1]);
            return new QuotationResponse
            {
                SalePrice = salePrice,
                PurchasePrice = purchasePrice
            };
        }
    }
}
