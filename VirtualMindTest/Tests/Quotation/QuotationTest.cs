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
using Core.QuotationException;

namespace Tests.Quotation
{
    [TestClass]
    public class QuotationTest
    {
        private Mock<IQuotationDomain> quotationDomainMock;
        private Mock<IApiClient> apiClient;
        private QuotationFakeData quotationFakeData;
        private const string quotationUrl = GlobalFakeData.QUOTATION_URL;

        [TestInitialize]
        public void Initialize()
        {
            ConfigurationManager.AppSettings[quotationUrl] = quotationUrl;
            quotationDomainMock = new Mock<IQuotationDomain>();
            apiClient = new Mock<IApiClient>();
            quotationFakeData = new QuotationFakeData();
        }

        [TestMethod]
        [TestCategory("Quotation")]
        public async Task GetQuotationInformationOk()
        {
            var currency = "Dolar";
            var quotationInformation = quotationFakeData.GetCorrectQuotationInformation();
            var quotationResponse = quotationFakeData.GetCorrectQuotationResponse();

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

        [ExpectedException(typeof(NotExistCurrencyIdException))]
        [TestMethod]
        [TestCategory("Quotation")]
        public async Task GetQuotationInformation_NotExistCurrencyIdException()
        {
            var currency = "Dolarss";
            var quotationInformation = quotationFakeData.GetCorrectQuotationInformation();
            var quotationResponse = quotationFakeData.GetCorrectQuotationResponse();

            apiClient.Setup(a => a.GetAsync<List<string>>(quotationUrl))
                .ReturnsAsync(quotationInformation);
            quotationDomainMock.Setup(q => q.GetQuotation(currency))
                .ThrowsAsync(new NotExistCurrencyIdException(It.IsAny<string>()));

            var domain = new QuotationDomain(apiClient.Object);
            var result = await domain.GetQuotation(currency);
        }

        //NotAvailableCurrencyException
        [ExpectedException(typeof(NotAvailableCurrencyException))]
        [TestMethod]
        [TestCategory("Quotation")]
        public async Task GetQuotationInformation_NotAvailableCurrencyException()
        {
            var currency = "Real";
            var quotationInformation = quotationFakeData.GetCorrectQuotationInformation();
            var quotationResponse = quotationFakeData.GetCorrectQuotationResponse();

            apiClient.Setup(a => a.GetAsync<List<string>>(quotationUrl))
                .ReturnsAsync(quotationInformation);
            quotationDomainMock.Setup(q => q.GetQuotation(currency))
                .ThrowsAsync(new NotAvailableCurrencyException(It.IsAny<string>()));

            var domain = new QuotationDomain(apiClient.Object);
            var result = await domain.GetQuotation(currency);
        }
    }
}
