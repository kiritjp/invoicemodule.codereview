using InvoiceModule.Services.Models;
using InvoiceModule.Services.Repository.Interfaces;
using InvoiceModule.Services.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace InvoiceModule.Services.Services
{
    public class InvoiceService : IInvoiceService
    {
        /// <summary>
        /// Service class for all methods which will be called from controller
        /// </summary>

        private readonly IInvoiceRepo _invoiceRepo;

        public InvoiceService(IInvoiceRepo invoiceRepo)
        {
            _invoiceRepo = invoiceRepo;
        }

        public List<Invoice> GetInvoices(int userId)
        {
            return _invoiceRepo.GetInvoices(userId);
        }

        public List<MPDetails> GetMPDetails(int userId, int invoiceId)
        {
            return _invoiceRepo.GetMPDetails(userId, invoiceId);
        }

        public List<RGDetails> GetRGDetails(int userId, int invoiceId)
        {
            return _invoiceRepo.GetRGDetails(userId, invoiceId);
        }

        public Int64 InsertUpdateInvoice(Invoice invoice)
        {
            if (invoice.Id == 0)
            {
                return _invoiceRepo.InsertInvoice(invoice);

            }
            else
            {
                _invoiceRepo.UpdateInvoice(invoice);
                return 0;
            }
        }
        public void UpdateRGNotes(Invoice invoice)
        {
            _invoiceRepo.UpdateRGNotes(invoice);
        }
        public Invoice GetInvoiceByInvoiceId(Int64 id)
        {
            return _invoiceRepo.GetInvoiceByInvoiceId(id);
        }

        public Int64 InsertMPDetails(MPDetails model)
        {
            return _invoiceRepo.InsertMPDetails(model);
        }

        public void DeleteMPDetails(List<int> selectedMPIds)
        {
            _invoiceRepo.DeleteMPDetails(selectedMPIds);
        }

        public Int64 InsertRGDetails(RGDetails model)
        {
            return _invoiceRepo.InsertRGDetails(model);
        }

        public void DeleteRGDetails(List<int> selectedRGIds)
        {
            _invoiceRepo.DeleteRGDetails(selectedRGIds);
        }
    }
}
