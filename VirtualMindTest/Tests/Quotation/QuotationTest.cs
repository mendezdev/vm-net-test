using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Domain.Impl.Client;
using Domain;

namespace Tests.Quotation
{
    [TestClass]
    public class QuotationTest
    {
        private Mock<IQuotationDomain> quotationDomain;
        private Mock<IApiClient> apiClient;

        [TestInitialize]
        public void Initialize()
        {
            quotationDomain = new Mock<IQuotationDomain>();
            apiClient = new Mock<IApiClient>();
        }

        //[TestMethod]
        //[TestCategory("Quotation")]
        //public async Task GetQuotationInformationOk()
        //{
        //    apiClient.Setup(a => a.GetAsync(It.IsAny<string>()))
        //        .ReturnsAsync()
        //}
    }
}
