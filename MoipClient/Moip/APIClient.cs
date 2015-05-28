using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Configuration;

namespace Moip
{
    public class APIClient
    {
        private readonly RestClient _APIClient;
        private readonly string _url = ConfigurationManager.AppSettings["api_url"];
        private readonly string _token = ConfigurationManager.AppSettings["api_token"];

        public APIClient()
        {
            _APIClient = new RestClient { BaseUrl = new Uri(_url) };
            _APIClient.AddDefaultHeader("Authorization", _token);
        }

        #region methods


        /// <summary>
        /// Cria nova assinatura
        /// </summary>
        /// <param name="newCustomer">Cliente novo?</param>
        /// <param name="customer">Moip.Customer</param>
        public void RegisterNewSubscription(bool newCustomer, Customer customer)
        {
            var request = new RestRequest("subscriptions", Method.POST);
            request.AddParameter("new_customer", newCustomer);
            request.AddJsonBody(customer);

            _APIClient.Execute(request);
            
        }

        /// <summary>
        /// Suspende assinatura
        /// </summary>
        /// <param name="subscriptionCode">Código da assinatura</param>
        public void SuspendSubscription(int subscriptionCode)
        {
            string url = String.Format("subscriptions/{0}/suspend", subscriptionCode);
            var request = new RestRequest(url, Method.PUT);

            _APIClient.Execute(request);
        }

        /// <summary>
        /// Ativa/Reativa assinatura
        /// </summary>
        /// <param name="subscriptionCode">Código da assinatura</param>
        public void ActivateSubscription(int subscriptionCode)
        {
            string url = String.Format("subscriptions/{0}/activate", subscriptionCode);
            var request = new RestRequest(url, Method.PUT);

            _APIClient.Execute(request);
        }

        /// <summary>
        /// Retorna detalhes do cliente
        /// </summary>
        /// <param name="customerCode">Código do cliente</param>
        /// <returns>Moip.Customer</returns>
        public Customer GetCustomerInfo(int customerCode)
        {
            string url = String.Format("customers/{0}", customerCode);
            var request = new RestRequest(url, Method.GET);

            var result = _APIClient.Execute<Customer>(request);

            if (result.StatusCode == HttpStatusCode.OK)
                return result.Data;
            else
            {
                var ex = JsonConvert.DeserializeObject<MoipException>(result.Content);
                throw ex;
            }
        }

        /// <summary>
        /// Atualiza cartão de crédito do cliente
        /// </summary>
        /// <param name="customerCode">Código do cliente</param>
        /// <param name="creditCard">Moip.Credit_Card</param>
        public void UpdateCustomerCreditCard(int customerCode, Credit_Card creditCard)
        {
            string url = String.Format("customers/{0}/billing_infos", customerCode);
            var request = new RestRequest(url, Method.PUT);
            request.AddJsonBody(creditCard);

            _APIClient.Execute(request);
        }

        /// <summary>
        /// Retorna lista de assinaturas do cliente
        /// </summary>
        /// <param name="customerCode">Código do cliente</param>
        /// <returns>List<Moip.Subscription></returns>
        public List<Subscription> ListCustomerSubscriptions(int customerCode)
        {
            List<Subscription> subscriptionList = ListAllSubscriptions();

            var customerSubscriptionList = subscriptionList.Where(x => x.customer.code == customerCode.ToString()).ToList();

            return customerSubscriptionList;
        }

        /// <summary>
        /// Retorna lista de faturas de uma assinatura
        /// </summary>
        /// <param name="subscriptionCode">Código da assinatura</param>
        /// <returns>List<Moip.Subscription></returns>
        private List<Invoice> ListInvoicesSubscriptions(int subscriptionCode)
        {
            string url = String.Format("subscriptions/{0}/invoices", subscriptionCode);
            var request = new RestRequest(url, Method.GET);

            var result = _APIClient.Execute<List<Invoice>>(request);

            if (result.StatusCode == HttpStatusCode.OK)
                return result.Data;
            else
            {
                var ex = JsonConvert.DeserializeObject<MoipException>(result.Content);
                throw ex;
            }
        }

        private List<Subscription> ListAllSubscriptions()
        {
            string url = String.Format("subscriptions");
            var request = new RestRequest(url, Method.GET);

            var result = _APIClient.Execute<List<Subscription>>(request);

            if (result.StatusCode == HttpStatusCode.OK)
                return result.Data;
            else
            {
                var ex = JsonConvert.DeserializeObject<MoipException>(result.Content);
                throw ex;
            }
        }

        #endregion
    }
}
