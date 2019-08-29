using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InvoiceModule.Services.Models
{
    public class Invoice
    {
        [Key]
        public Int64 Id { get; set; }
        public string RGNotes { get; set; }
        public int Status { get; set; } = 1;
        public Int64 Assigned { get; set; } = 1;
        public string SWXNo { get; set; }
        public string RGType { get; set; }
        public string Type { get; set; }
        public string NB { get; set; }
        public DateTime InvoiceDate { get; set; } = DateTime.Now;
        public DateTime Createddate { get; set; } = DateTime.Now;
        public DateTime? Modifieddate { get; set; } = DateTime.Now;
        public Int64 Createdby { get; set; } = 1;
        public bool IsDeleted { get; set; }
        public Int64? Modifiedby { get; set; } = 1;
        public string Warning { get; set; }
        public string BLInfo { get; set; }
        public string CRGInfo { get; set; }
        public string Comment { get; set; }
        public decimal VATExclusive { get; set; }
        public decimal VATInclusive { get; set; }
        public decimal KalkTotal { get; set; }
        public decimal Rounding { get; set; }
        public string Receiver { get; set; }
        public string Account { get; set; }
        public decimal Total { get; set; }
        public string PayableTo { get; set; }
        public string E2Ref { get; set; }
        public DateTime TransferDate { get; set; } = DateTime.Now;
        public string PaymentStatus { get; set; }
    }
}
