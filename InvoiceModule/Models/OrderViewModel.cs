using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceModule.Models
{
    public class OrderViewModel
    {
        [Key]
        public int OrderID
        {
            get;
            set;
        }

        [Required]
        public decimal? Freight
        {
            get;
            set;
        }

        public DateTime? OrderDate
        {
            get;
            set;
        }

        public string ShipCity
        {
            get;
            set;
        }

        public string ShipName
        {
            get;
            set;
        }
    }
}