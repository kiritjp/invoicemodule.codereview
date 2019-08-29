using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceModule.Services.Models
{
    public class MPDetails
    {
        public Int64 Id { get; set; }
        public Int64 InvoiceId { get; set; }
        public string ZptName { get; set; }
        public string AgainstCode { get; set; }
        public string MA { get; set; }
        public DateTime? MPFrom { get; set; }
        public DateTime? MPTo { get; set; }
        public DateTime? RptFrom { get; set; }
        public DateTime? RptTo { get; set; }
        public string EngType { get; set; }
        public string Original { get; set; }
        public Int64 Createdby { get; set; }
        public DateTime? Createddate { get; set; }
        public Int64? Modifiedby { get; set; }
        public DateTime? Modifieddate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
