using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceModule.Services.Models
{
    public class RGDetails
    {
        public Int64 Id { get; set; }
        public Int64 MPDetailsId { get; set; }
        public string POS { get; set; }
        public string SubPOS { get; set; }
        public decimal? VATExclusive { get; set; } = 0;
        public decimal ? VATInclusive { get; set; } = 0;
        public decimal ? Unit { get; set; } = 0;
        public decimal ? VAT { get; set; } = 0;
        public Int64 Createdby { get; set; } = 1;
        public DateTime? Createddate { get; set; }
        public Int64? Modifiedby { get; set; } = 1;
        public DateTime? Modifieddate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
    }
}
