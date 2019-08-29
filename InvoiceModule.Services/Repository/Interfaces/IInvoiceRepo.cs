using InvoiceModule.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceModule.Services.Repository.Interfaces
{
    public interface IInvoiceRepo
    {
        List<Invoice> GetInvoices(int userId);
        List<RGDetails> GetRGDetails(int userId, int invoiceId);
        List<MPDetails> GetMPDetails(int userId, int invoiceId);
        Invoice GetInvoiceByInvoiceId(Int64 id);
        void UpdateInvoice(Invoice invoice);
        void UpdateRGNotes(Invoice notes);
        Int64 InsertInvoice(Invoice invoice);
        Int64 InsertMPDetails(MPDetails model);
        void DeleteMPDetails(List<int> selectedMPIds);
        Int64 InsertRGDetails(RGDetails model);
        void DeleteRGDetails(List<int> selectedRGIds);
    }
}
