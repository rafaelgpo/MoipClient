using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moip
{

    public class Plan
    {
        #region properties

        public string code { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int amount { get; set; }
        public int setup_fee { get; set; }
        public int max_qty { get; set; }
        public string status { get; set; }
        public Interval interval { get; set; }
        public int billing_cycles { get; set; }
        public Trial trial { get; set; }

        #endregion

        #region methods
        #endregion
    }

    #region Plan classes

    public class Interval
    {
        public int length { get; set; }
        public string unit { get; set; }
    }

    public class Trial
    {
        public int days { get; set; }
        public bool enabled { get; set; }
        public bool hold_setup_fee { get; set; }
    }

    #endregion

}
