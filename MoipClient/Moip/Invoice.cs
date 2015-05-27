namespace Moip
{

    public class Invoice
    {
        #region properties
        public int id { get; set; }
        public int amount { get; set; }
        public string subscription_code { get; set; }
        public int occurrence { get; set; }
        public Status status { get; set; }
        public Creation_Date creation_date { get; set; }
        #endregion

        #region methods
        #endregion
    }

    #region Invoice classes
    public class Status
    {
        public int code { get; set; }
        public string description { get; set; }
    }

    public class Creation_Date
    {
        public int day { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public int hour { get; set; }
        public int minute { get; set; }
        public int second { get; set; }
    }

    #endregion

}
