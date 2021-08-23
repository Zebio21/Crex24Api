using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using PoissonSoft.CommonUtils.ConsoleUtils;
using PoissonSoft.Crex24Api;

namespace CrexApi.Example
{
    internal partial class ActionManager
    {
        private readonly Crex24ApiClient apiClient;

        public ActionManager(Crex24ApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public void Run()
        {
            while (ShowMainPage()) { }
            Console.WriteLine("> The program stopped. Press any key to exit...");
            Console.ReadKey();
        }

        private bool ShowMainPage()
        {
            Console.Clear();
            var actions = new Dictionary<ConsoleKey, string>()
            {
                [ConsoleKey.A] = "Account API",
                [ConsoleKey.B] = "Market Data API",
                [ConsoleKey.C] = "Trading API",
                

                [ConsoleKey.Escape] = "Go back (exit)",
            };

            var selectedAction = InputHelper.GetUserAction("Select action:", actions);

            switch (selectedAction)
            {
                case ConsoleKey.A:
                    while (ShowAccountPage()) { }
                    return true;

                case ConsoleKey.B:
                    while (ShowMarketDataPage()) { }
                    return true;

                case ConsoleKey.C:
                    while (ShowTradingPage()) { }
                    return true;

                case ConsoleKey.Escape:
                    return false;
                default:
                    return true;
            }
        }

        private void SafeCall(Action action)
        {
            try
            {
                action();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

    }
}
