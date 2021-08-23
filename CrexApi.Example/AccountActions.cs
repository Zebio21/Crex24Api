using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using NLog.Attributes;
using PoissonSoft.CommonUtils.ConsoleUtils;

namespace CrexApi.Example
{
    internal partial class ActionManager
    {
        private bool ShowAccountPage()
        {
            var actions = new Dictionary<ConsoleKey, string>()
            {
                [ConsoleKey.A] = "Balances",
                [ConsoleKey.B] = "Crypto Deposit Address",
                [ConsoleKey.C] = "Money Transfer History",
                [ConsoleKey.D] = "Money Transfer Status",
                [ConsoleKey.E] = "Crypto Withdrawal Preview",
                [ConsoleKey.F] = "Crypto Withdrawal",

                [ConsoleKey.Escape] = "Go back (to main menu)",
            };

            var selectedAction = InputHelper.GetUserAction("Select action:", actions);

            switch (selectedAction)
            {
                case ConsoleKey.A:
                    SafeCall(() =>
                    {
                        var currency = InputHelper.GetString("Currency: ");

                        var coinBalanceInfo = apiClient.AccountApi.Balances(currency, true);
                        Console.WriteLine(JsonConvert.SerializeObject(coinBalanceInfo, Formatting.Indented));
                    });
                    return true;

                case ConsoleKey.B:
                    SafeCall(() =>
                    {
                        var currency = InputHelper.GetString("Currency: ");

                        var coinDepositAddressInfo = apiClient.AccountApi.DepositAddress(currency);
                        Console.WriteLine(JsonConvert.SerializeObject(coinDepositAddressInfo, Formatting.Indented));
                    });
                    return true;

                case ConsoleKey.C:
                    SafeCall(() =>
                    {   //проверить не могу
                        var type = InputHelper.GetString("Type of money transfers: ");
                        var currency = InputHelper.GetString("Currency: ");

                        var TransferHistoryInfo = apiClient.AccountApi.MoneyTransferHistory(type);
                        Console.WriteLine(JsonConvert.SerializeObject(TransferHistoryInfo, Formatting.Indented));
                    });
                    return true;

                case ConsoleKey.D:
                    SafeCall(() =>
                    {
                        var id = InputHelper.GetLong("Identifier of money transfer: ");
                        var TransferStatusInfo = apiClient.AccountApi.MoneyTransferStatus((ulong)id);
                        Console.WriteLine(JsonConvert.SerializeObject(TransferStatusInfo, Formatting.Indented));
                    });
                    return true;

                case ConsoleKey.E:
                    SafeCall(() =>
                    {
                        var currency = InputHelper.GetString("Currency: ");
                        var amount = InputHelper.GetDecimal("Amount: ");
                        var feeCurrency = InputHelper.GetString("Fee currency: ");

                        var WithdrawalPreviewInfo = apiClient.AccountApi.WithdrawalPreview(currency, amount, feeCurrency);
                        Console.WriteLine(JsonConvert.SerializeObject(WithdrawalPreviewInfo, Formatting.Indented));
                    });
                    return true;

                case ConsoleKey.F:
                    SafeCall(() =>
                    {
                        var currency = InputHelper.GetString("Currency: ");
                        var amount = InputHelper.GetDecimal("Amount: ");
                        var address = InputHelper.GetString("Address: ");
                        var feeCurrency = InputHelper.GetString("Fee currency: ");

                        var TransferStatusInfo = apiClient.AccountApi.Withdrawal(currency, amount, address, feeCurrency);
                        Console.WriteLine(JsonConvert.SerializeObject(TransferStatusInfo, Formatting.Indented));
                    });
                    return true;


                case ConsoleKey.Escape:
                    return false;
                default:
                    return true;
            }
        }

    }
}
