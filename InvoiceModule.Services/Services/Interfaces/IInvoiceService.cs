using InvoiceModule.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceModule.Services.Services.Interfaces
{
    public interface IInvoiceService
    {
        List<Invoice> GetInvoices(int userId);
        List<MPDetails> GetMPDetails(int userId, int invoiceId);
        List<RGDetails> GetRGDetails(int userId, int invoiceId);
        Invoice GetInvoiceByInvoiceId(Int64 id);
        Int64 InsertUpdateInvoice(Invoice invoice);
        Int64 InsertMPDetails(MPDetails model);
        void UpdateRGNotes(Invoice invoice);
        void DeleteMPDetails(List<int> selectedMPIds);
        Int64 InsertRGDetails(RGDetails model);
        void DeleteRGDetails(List<int> selectedRGIds);
    }
}
