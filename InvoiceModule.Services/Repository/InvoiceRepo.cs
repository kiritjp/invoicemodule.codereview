using InvoiceModule.Services.DBContext;
using InvoiceModule.Services.Models;
using InvoiceModule.Services.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InvoiceModule.Services.Repository
{
    public class InvoiceRepo : IInvoiceRepo
    {
        /// <summary>
        /// Repository class for all methods which will be called from controller
        /// From here we will call our Db, will perform all DB actions
        /// </summary>

        public List<Invoice> GetInvoices(int userId)
        {
            using (InvoiceModuleContext dbContext = new InvoiceModuleContext())
            {
                var invoices = dbContext.invoices.Where(x => x.Createdby.Equals(userId) && x.IsDeleted.Equals(false));
                return invoices.ToList();
            }
        }

        public List<MPDetails> GetMPDetails(int userId, int invoiceId)
        {
            using (InvoiceModuleContext dbContext = new InvoiceModuleContext())
            {
                var invoices = dbContext.mpDetails.Where(x => x.InvoiceId.Equals(invoiceId) && x.Createdby.Equals(userId) && x.IsDeleted.Equals(false)).ToList();
                return invoices.ToList();
            }
        }

        public List<RGDetails> GetRGDetails(int userId, int invoiceId)
        {
            using (InvoiceModuleContext dbContext = new InvoiceModuleContext())
            {
                var invoices = dbContext.rgDetails.Where(x => x.MPDetailsId.Equals(invoiceId) && x.Createdby.Equals(userId) && x.IsDeleted.Equals(false));
                return invoices.ToList();
            }
        }
        public Invoice GetInvoiceByInvoiceId(Int64 id)
        {
            using (InvoiceModuleContext dbContext = new InvoiceModuleContext())
            {
                return dbContext.invoices.Where(x => x.Id == id).FirstOrDefault();
            }
        }
        public Int64 InsertInvoice(Invoice invoice)
        {
            using (InvoiceModuleContext dbContext = new InvoiceModuleContext())
            {
                dbContext.invoices.Add(invoice);
                dbContext.SaveChanges();
                return invoice.Id;
            }
        }
        public void UpdateInvoice(Invoice invoice)
        {
            using (InvoiceModuleContext dbContext = new InvoiceModuleContext())
            {
                invoice.Modifieddate = DateTime.Now;
                dbContext.Update(invoice);
                dbContext.SaveChanges();
            }
        }
        public void UpdateRGNotes(Invoice notes)
        {
            using (InvoiceModuleContext dbContext = new InvoiceModuleContext())
            {
                var invoice = dbContext.invoices.Where(x => x.Id == notes.Id).First();
                invoice.RGNotes = notes.RGNotes;
                invoice.Modifieddate = DateTime.Now;
                dbContext.SaveChanges();
            }
        }

        public Int64 InsertMPDetails(MPDetails model)
        {
            using (InvoiceModuleContext dbContext = new InvoiceModuleContext())
            {
                model.Createdby = 1;
                model.Createddate = DateTime.Now;

                dbContext.mpDetails.Add(model);
                dbContext.SaveChanges();
                return model.Id;
            }
        }

        public void DeleteMPDetails(List<int> selectedMPIds)
        {
            using (InvoiceModuleContext dbContext = new InvoiceModuleContext())
            {
                selectedMPIds.ForEach(x =>
                {
                    var mpDetails = dbContext.mpDetails.Where(m => m.Id.Equals(x)).FirstOrDefault();
                    mpDetails.IsDeleted = true;
                    dbContext.SaveChanges();
                });
            }
        }

        public Int64 InsertRGDetails(RGDetails model)
        {
            using (InvoiceModuleContext dbContext = new InvoiceModuleContext())
            {
                model.Createddate = DateTime.Now;

                dbContext.rgDetails.Add(model);
                dbContext.SaveChanges();
                return model.Id;
            }
        }

        public void DeleteRGDetails(List<int> selectedRGIds)
        {
            using (InvoiceModuleContext dbContext = new InvoiceModuleContext())
            {
                selectedRGIds.ForEach(x =>
                {
                    var rgDetails = dbContext.rgDetails.Where(m => m.Id.Equals(x)).FirstOrDefault();
                    rgDetails.IsDeleted = true;
                    dbContext.SaveChanges();
                });
            }
        }
    }
}
