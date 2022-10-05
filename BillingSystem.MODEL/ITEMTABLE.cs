using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BillingSystem.MODEL
{
    public class ITEMTABLE
    {
        public int ITEMID { get; set; }
        public string ITEMCODE { get; set; }
        public string ITEMNAME { get; set; }
        public string RATE { get; set; }
        public string MOU { get; set; }
        public string STOCKQTY { get; set; }
        public string PhotoUrl { get; set; }
        [Display(Name = "ITEM IMAGE")]
        [NotMapped]
        public IFormFile ITEMIMAGE { get; set; }
    }
}
