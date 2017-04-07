using System;
using System.Configuration;
using System.Threading.Tasks;

namespace SMSGlobal.SMS
{
    /// <summary>
    /// The rest api usage demonstation class.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main application entry point.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            RunAsync(args).Wait();
        }

        /// <summary>
        /// Asynchronously run task.
        /// </summary>
        /// <param name="args"></param>
        /// <returns>async</returns>
        static async Task RunAsync(string[] args)
        {
            Transport.Rest rest = new Transport.Rest();

            rest.host = ConfigurationManager.AppSettings["rest_host"].ToString();
            rest.port = ConfigurationManager.AppSettings["rest_port"].ToString();
            rest.version = ConfigurationManager.AppSettings["rest_version"].ToString();
            rest.key = ConfigurationManager.AppSettings["rest_key"].ToString();
            rest.secret = ConfigurationManager.AppSettings["rest_secret"].ToString();

            try
            {
                // get the credit balance
                Console.WriteLine(await rest.getCreditBalance());
            }
            catch (System.Net.Http.HttpRequestException exception)
            {
                // console log non successful type request responses
                Console.WriteLine(exception.Message.ToString());
            }
        }
    }
}
