﻿using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SMSGlobal.SMS.Transport
{
    /// <summary>
    /// The rest api class.
    /// </summary>
    class Rest
    {
        private Uri uri;

        public string host { get; set; }
        public string port { get; set; }
        public string version { get; set; }
        public string key { get; set; }
        public string secret { get; set; }

        /// <summary>
        /// Gets the credit balance.
        /// </summary>
        /// <returns></returns>
        public async Task<Response.CreditBalance> getCreditBalance()
        {
            HttpResponseMessage response = await Request("user/credit-balance");

            return await response.Content.ReadAsAsync<Response.CreditBalance>();
        }

        /// <summary>
        /// Requests information from the rest api.
        /// </summary>
        /// <param name="path">The rest api path.</param>
        /// <returns>The http response message object.</returns>
        private async Task<HttpResponseMessage> Request(string path)
        {
            using (var client = new HttpClient())
            {
                string credentials = Credentials(path, "GET");

                client.BaseAddress = new Uri(string.Format("{0}://{1}", uri.Scheme, uri.Host));
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("MAC", credentials);

                HttpResponseMessage response = await client.GetAsync(uri.PathAndQuery);

                response.EnsureSuccessStatusCode();

                return response;
            }
        }

        /// <summary>
        /// Compiles the mac oauth2 credentials.
        /// </summary>
        /// <param name="path">The request path.</param>
        /// <param name="method">The request method.</param>
        /// <returns>The credential string.</returns>
        private string Credentials(string path, string method = "GET")
        {
            uri = new Uri(string.Format("https://{0}/{1}/{2}/", host, version, path));

            string timestamp = ((int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds).ToString();
            string nonce = Guid.NewGuid().ToString("N");
            string mac = string.Format("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n\n", timestamp, nonce, method, uri.PathAndQuery, uri.Host, port);

            mac = Convert.ToBase64String((new HMACSHA256(Encoding.ASCII.GetBytes(secret))).ComputeHash(Encoding.ASCII.GetBytes(mac)));

            return string.Format("id=\"{0}\", ts=\"{1}\", nonce=\"{2}\", mac=\"{3}\"", key, timestamp, nonce, mac);
        }
    }
}
