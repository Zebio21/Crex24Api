using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using PoissonSoft.CommonUtils.ConsoleUtils;
using PoissonSoft.Crex24Api.Contracts.Enums;

namespace CrexApi.Example
{
    internal partial class ActionManager
    {
        private bool ShowMarketDataPage()
        {
            var actions = new Dictionary<ConsoleKey, string>()
            {
                [ConsoleKey.A] = "Currencies",
                [ConsoleKey.B] = "Trade Instruments",
                [ConsoleKey.C] = "Quotes (Tickers)",
                [ConsoleKey.D] = "Recent Trades",
                [ConsoleKey.E] = "Order Book",
                [ConsoleKey.F] = "OHLCV Data",
                [ConsoleKey.G] = "Trading Fee Schedules",
                [ConsoleKey.H] = "Withdrawal Fees",
                [ConsoleKey.I] = "Currencies Withdrawal Fees",
                [ConsoleKey.J] = "Currency Transport",

                [ConsoleKey.Escape] = "Go back (to main menu)",
            };

            var selectedAction = InputHelper.GetUserAction("Select action:", actions);

            switch (selectedAction)
            {
                case ConsoleKey.A:
                    SafeCall(() =>
                    {
                        string[] currencies = new[] {"BTC", "ETH"};

                        var CurrenciesInfo = apiClient.MarketDataApi.Currencies(currencies);
                        Console.WriteLine(JsonConvert.SerializeObject(CurrenciesInfo, Formatting.Indented));
                    });
                    return true;

                case ConsoleKey.B:
                    SafeCall(() =>
                    {
                        string[] instruments = new[] { "BTC-USDT", "ETH-BTC" };

                        var instrumentsInfo = apiClient.MarketDataApi.Instruments(instruments);
                        Console.WriteLine(JsonConvert.SerializeObject(instrumentsInfo, Formatting.Indented));
                    });
                    return true;

                case ConsoleKey.C:
                    SafeCall(() =>
                    {
                        string[] instruments = new[] { "BTC-USDT", "ETH-BTC" };

                        var instrumentsInfo = apiClient.MarketDataApi.Tickers(instruments);
                        Console.WriteLine(JsonConvert.SerializeObject(instrumentsInfo, Formatting.Indented));
                    });
                    return true;

                case ConsoleKey.D:
                    SafeCall(() =>
                    {
                        var instrument = InputHelper.GetString("Instrument: ");
                        var limit = InputHelper.GetInt("Limit: ");

                        var recentTradesInfo = apiClient.MarketDataApi.RecentTrades(instrument, limit);
                        Console.WriteLine(JsonConvert.SerializeObject(recentTradesInfo, Formatting.Indented));
                    });
                    return true;

                case ConsoleKey.E:
                    SafeCall(() =>
                    {
                        var instrument = InputHelper.GetString("Instrument: ");
                        var limit = InputHelper.GetInt("Limit: ");

                        var orderBookInfo = apiClient.MarketDataApi.OrderBook(instrument, limit);
                        Console.WriteLine(JsonConvert.SerializeObject(orderBookInfo, Formatting.Indented));
                    });
                    return true;

                case ConsoleKey.F:
                    SafeCall(() =>
                    {
                        var instrument = InputHelper.GetString("Instrument: ");
                        var granularity = InputHelper.GetEnum<Granularity>("");
                        var limit = InputHelper.GetInt("Limit: ");

                        var OHLCVInfo = apiClient.MarketDataApi.OHLCVData(instrument, granularity, limit);
                        Console.WriteLine(JsonConvert.SerializeObject(OHLCVInfo, Formatting.Indented));
                    });
                    return true;

                case ConsoleKey.G:
                    SafeCall(() =>
                    {
                        var FeeSchedulesInfo = apiClient.MarketDataApi.TradingFeeSchedules();
                        Console.WriteLine(JsonConvert.SerializeObject(FeeSchedulesInfo, Formatting.Indented));
                    });
                    return true;

                case ConsoleKey.H:
                    SafeCall(() =>
                    {
                        var currency = InputHelper.GetString("Currency: ");

                        var WithdrawalFeesInfo = apiClient.MarketDataApi.WithdrawalFees(currency);
                        Console.WriteLine(JsonConvert.SerializeObject(WithdrawalFeesInfo, Formatting.Indented));
                    });
                    return true;

                case ConsoleKey.I:
                    SafeCall(() =>
                    {
                        string[] currency = new[] { "BTC", "ETH" };

                        var CurrenciesWithdrawalFeesInfo = apiClient.MarketDataApi.CurrenciesWithdrawalFees(currency);
                        Console.WriteLine(JsonConvert.SerializeObject(CurrenciesWithdrawalFeesInfo, Formatting.Indented));
                    });
                    return true;

                case ConsoleKey.J:
                    SafeCall(() =>
                    {
                        var currency = InputHelper.GetString("Currency: ");
                        var transport = InputHelper.GetString("Transport: ");

                        var CurrencyTransportInfo = apiClient.MarketDataApi.CurrencyTransport(currency, transport);
                        Console.WriteLine(JsonConvert.SerializeObject(CurrencyTransportInfo, Formatting.Indented));
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
