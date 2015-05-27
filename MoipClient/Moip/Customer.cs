namespace Moip
{
    public class Customer
    {
        #region properties
        public string code { get; set; }
        public string email { get; set; }
        public string fullname { get; set; }
        public string cpf { get; set; }
        public string phone_number { get; set; }
        public string phone_area_code { get; set; }
        public string birthdate_day { get; set; }
        public string birthdate_month { get; set; }
        public string birthdate_year { get; set; }
        public Address address { get; set; }
        public Billing_Info billing_info { get; set; }
        #endregion

        #region methods
        #endregion
    }

    #region Customer classes
    public class Address
    {
        public string street { get; set; }
        public string number { get; set; }
        public string complement { get; set; }
        public string district { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string zipcode { get; set; }
    }

    #endregion
}
