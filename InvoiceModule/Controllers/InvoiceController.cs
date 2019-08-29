using System;
using System.Collections.Generic;
using InvoiceModule.Models;
using InvoiceModule.Services.Models;
using InvoiceModule.Services.Services.Interfaces;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceModule.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        public IActionResult Index()
        {
            try
            {
                var invoices = _invoiceService.GetInvoices(1);
                return View(invoices);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// For listing of Invoice user Id wise
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult GetInvoice(int id)
        {
            try
            {
                if (id > 0)
                {
                    var invoices = _invoiceService.GetInvoices(id);
                    return Json(new { data = invoices });
                }
                return Json(new { data = new List<Invoice>() });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// View for add invoice
        /// </summary>
        /// <returns></returns>
        public IActionResult Add()
        {
            try
            {
                var invoiceViewModel = new InvoiceViewModel()
                {
                    mPDetails = new MPDetails(),
                    invoice = new Invoice()
                };
                ViewBag.invoiceId = 0;
                return View(invoiceViewModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Submit method for add/update invoice
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddUpdateInvoice(Invoice invoice)
        {
            try
            {
                return Json(new { sucess = true, id = _invoiceService.InsertUpdateInvoice(invoice), message = "Invoice saved successfully" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// For updating RegNotes in Particular Invoice
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UpdateRgNotes(Invoice invoice)
        {
            try
            {
                _invoiceService.UpdateRGNotes(invoice);
                return Json(new { sucess = true, message = "RG Notes saved successfully" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Add method for MP detail for particular Invoice
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddMPDetails(MPDetails model)
        {
            try
            {
                return Json(new { sucess = true, id = _invoiceService.InsertMPDetails(model), message = "MP details saved successfully" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Add method for RG detail for particular MP detail
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddRGDetails(RGDetails model)
        {
            try
            {
                return Json(new { sucess = true, id = _invoiceService.InsertRGDetails(model), message = "RG details saved successfully" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get method for Invoice Edit detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Edit(Int64 id)
        {
            try
            {
                var invoiceViewModel = new InvoiceViewModel()
                {
                    mPDetails = new MPDetails(),
                    invoice = _invoiceService.GetInvoiceByInvoiceId(id),
                    IsAdd = false
                };
                ViewBag.invoiceId = id;
                return View("Add", invoiceViewModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// List method for MP details
        /// </summary>
        /// <param name="invoiceId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public IActionResult GetMPDetailsList(int invoiceId, [DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                var userId = 1;
                //invoiceId = 1;
                var mpDetails = _invoiceService.GetMPDetails(userId, invoiceId);
                return Json(mpDetails.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// List method for RG details  
        /// </summary>
        /// <param name="invoiceId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public IActionResult GetRGDetailsList(int mpDetailId, [DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                var userId = 1;
                var rgDetails = _invoiceService.GetRGDetails(userId, mpDetailId);
                return Json(rgDetails.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// delete method for MP details
        /// </summary>
        /// <param name="selectedMPIds"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DeleteMPDetails(List<int> selectedMPIds)
        {
            try
            {
                _invoiceService.DeleteMPDetails(selectedMPIds);
                return Json(new { sucess = true, message = "MP Details deleted successfully" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// delete method for RG details
        /// </summary>
        /// <param name="selectedRGIds"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DeleteRGDetails(List<int> selectedRGIds)
        {
            try
            {
                _invoiceService.DeleteRGDetails(selectedRGIds);
                return Json(new { sucess = true, message = "RG Details deleted successfully" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}