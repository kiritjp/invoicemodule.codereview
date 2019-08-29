using InvoiceModule.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceModule.Models
{
    public class InvoiceViewModel
    {
        public Invoice invoice { get; set; }
        public bool IsAdd { get; set; } = true;
        public MPDetails mPDetails { get; set; }
        public RGDetails rGDetails { get; set; }
    }
}
