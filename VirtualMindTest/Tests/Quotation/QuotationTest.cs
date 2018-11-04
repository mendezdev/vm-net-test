using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Domain.Impl.Client;
using Domain;
using ViewModels;
using Domain.Impl;
using System.Configuration;

namespace Tests.Quotation
{
    [TestClass]
    public class QuotationTest
    {
        private Mock<IQuotationDomain> quotationDomainMock;
        private Mock<IApiClient> apiClient;
        private const string quotationUrl = "QuotationUrl";

        [TestInitialize]
        public void Initialize()
        {
            ConfigurationManager.AppSettings[quotationUrl] = quotationUrl;
            quotationDomainMock = new Mock<IQuotationDomain>();
            apiClient = new Mock<IApiClient>();
        }

        [TestMethod]
        [TestCategory("Quotation")]
        public async Task GetQuotationInformationOk()
        {
            var currency = "Dolar";
            var quotationInformation = new List<string>
            {
                "10.00",
                "12.20",
                ""
            };
            var quotationResponse = new QuotationResponse
            {
                PurchasePrice = (decimal)10.00,
                SalePrice = (decimal)12.20
            };

            apiClient.Setup(a => a.GetAsync<List<string>>(quotationUrl))
                .ReturnsAsync(quotationInformation);
            quotationDomainMock.Setup(q => q.GetQuotation(currency))
                .ReturnsAsync(quotationResponse);

            var domain = new QuotationDomain(apiClient.Object);
            var result = await domain.GetQuotation(currency);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.PurchasePrice, quotationResponse.PurchasePrice);
            Assert.AreEqual(result.SalePrice, quotationResponse.SalePrice);
        }
    }
}
