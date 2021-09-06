using System;
using NLog;
using PoissonSoft.Crex24Api;

namespace CrexApi.Example
{
    class Program
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            ICredentialsProvider credentialsProvider = new NppCryptProvider();
            Crex24ApiClientCredentials credentials;
            try
            {
                credentials = credentialsProvider.GetCredentials();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            
            var apiClient = new Crex24ApiClient(credentials, logger);

            new ActionManager(apiClient).Run();

        }
    }
}
