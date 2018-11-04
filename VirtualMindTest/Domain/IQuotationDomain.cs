﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Domain
{
    public interface IQuotationDomain
    {
        Task<Response<QuotationResponse>> GetQuotation(string currency);
    }
}
