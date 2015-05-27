namespace Moip
{

    public class Subscription
    {
        #region properties
        public string code { get; set; }
        public string amount { get; set; }
        public Plan plan { get; set; }
        public Customer customer { get; set; }
        #endregion

        #region methods
        #endregion
    }

    #region Subscription classes
    public class Billing_Info
    {
        public Credit_Card credit_card { get; set; }
    }
    #endregion
}
