using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Navimod.Web.Models
{
    public class Quote
    {
        public int Id { get; set; }
        public string Mode { get; set; }
        public string MovementType { get; set; }
        public string Incoterm { get; set; }
        public string OriginCountry { get; set; }
        public string OriginCity { get; set; }
        public string DestinationCountry { get; set; }
        public string DestinationCity { get; set; }

        [Required(ErrorMessage = "Bos Bırakılamaz")]
        public int Zip { get; set; }
        public string PackageType { get; set; }
        public int Quantity { get; set; }
        public int Lenght { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string UnitHeight { get; set; }
        public int Weight { get; set; }
        public string UnitWeight { get; set; }
        public string CargoDescription { get; set; }
        public string Currency { get; set; }

        [DisplayName("Hazardous Material")]
        public bool IsHazardous { get; set; }
        [DisplayName("Event Cargo")]
        public bool IsEventCargo { get; set; }
        [DisplayName("Personal Goods")]
        public bool IsPersonalGoods { get; set; }

        public List<SelectListItem> ModeList = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "LCL", Value="LCL" },
            new SelectListItem() { Text = "FCL", Value="FCL" },
            new SelectListItem() { Text = "Air", Value="Air" },
        };
        public List<SelectListItem> MovementTypeList = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Door to Door", Value="Door to Door" },
            new SelectListItem() { Text = " Port to Door", Value=" Port to Door" },
            new SelectListItem() { Text = "Door to Port", Value="Door to Port" },
            new SelectListItem() { Text = "Port to Port", Value="Port to Port" },
        };
        public List<SelectListItem> IncotermList = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Delivered Duty Paid", Value="Delivered Duty Paid" },
            new SelectListItem() { Text = "Delivered At Place", Value="Delivered At Place" },
        };
        public List<SelectListItem> PackageTypeList = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Pallets", Value="Pallets" },
            new SelectListItem() { Text = "Boxes", Value="Boxes" },
            new SelectListItem() { Text = "Cartons", Value="Cartons" },
        };
        public List<SelectListItem> UnitHeightList = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "CM", Value="CM" },
            new SelectListItem() { Text = "IN", Value="IN" },
        };
        public List<SelectListItem> UnitWeightList = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "KG", Value="KG" },
            new SelectListItem() { Text = "LB", Value="LB" },
        };
        public List<SelectListItem> CurrencyList = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "USD-US DOLLAR", Value="USD-US DOLLAR" },
            new SelectListItem() { Text = "CNY-CHINESE YUAN", Value="CNY-CHINESE YUAN" },
            new SelectListItem() { Text = "TRY–Turkish Lira", Value="TRY–Turkish Lira" },
        };
    }
}

