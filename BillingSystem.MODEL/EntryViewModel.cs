using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.MODEL
{
    public class EntryViewModel
    {
        public virtual List<CUSTOMER> CUSTOMER { get; set; }
        public int CUSTID { get; set; }
        public virtual List<ITEMTABLE> ITEMTABLE { get; set; }
        public virtual BILLHEADERTABLE BILLHEADERTABLE { get; set; }
        public virtual BILLDETAILTABLE BILLDETAILTABLES { get; set; }
        public List<ITEMTABLE> Items { get; set; } = new List<ITEMTABLE>();
        public float TotalAmount { get; set; }
        public float GivenAmount { get; set; }
        public float ChangeAmount { get; set; }
        public string BILLNO { get; set; }
        public DateTime BILLDATE { get; set; }
        public int ITEMID { get; set; }
        public string RATE { get; set; }
        public string BILLQTY { get; set; }
        public int  BILLID { get; set; }

    }
}
