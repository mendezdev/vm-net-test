using Domain;
using Domain.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Tests
{
    [TestClass]
    public class QuotationTest
    {
        private Mock<IQuotationDomain> quotationDomainMock;

        [TestInitialize]
        public void Initialize()
        {
            quotationDomainMock = new Mock<IQuotationDomain>();
        }

        [TestMethod]
        [TestCategory("Quotation")]
        public async Task GetQuotationInformationOk()
        {
            quotationDomainMock.Setup(q => q.GetQuotation("Dolar"))
                .ReturnsAsync(new QuotationResponse { PurchasePrice = 100, SalePrice = 100 });
            var quotationDomain = new QuotationDomain();

            var result = await quotationDomain.GetQuotation("Dolar");

            Assert.IsNotNull(result);
            Assert.AreEqual(result.PurchasePrice, 100);
            Assert.AreEqual(result.SalePrice, 100);
        }
    }
}
