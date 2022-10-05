using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.MODEL
{
    public class BILLHEADERTABLE
    {
        public int BILLID { get; set; }
        public string BILLNO { get; set; }
        public DateTime BILLDATE { get; set; }
        public int CUSTID { get; set; }
    }
}
