using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.MODEL
{
    public class BILLDETAILTABLE
    {
        public int BILLDETID { get; set; }
        public int BILLID { get; set; }
        public int ITEMID { get; set; }
        public string BILLQTY { get; set; }
        public string MOU { get; set; }
        public string RATE { get; set; }

    }
}
