using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using PoissonSoft.CommonUtils.ConsoleUtils;
using PoissonSoft.Crex24Api.Contracts.Enums;
using PoissonSoft.Crex24Api.Contracts.Requests;

namespace CrexApi.Example
{
    internal partial class ActionManager
    {
        private bool ShowTradingPage()
        {
            var actions = new Dictionary<ConsoleKey, string>()
            {
                [ConsoleKey.A] = "Order Placement",
                [ConsoleKey.B] = "Order Status",
                [ConsoleKey.C] = "Order Trades",
                [ConsoleKey.D] = "Order Modification",
                [ConsoleKey.E] = "Active Orders",
                [ConsoleKey.F] = "Order Cancellation",
                [ConsoleKey.G] = "Order History",
                [ConsoleKey.H] = "Trade History",
                [ConsoleKey.I] = "Fee and Rebate",

                [ConsoleKey.Escape] = "Go back (to main menu)",
            };

            var selectedAction = InputHelper.GetUserAction("Select action:", actions);

            switch (selectedAction)
            {
                case ConsoleKey.A:
                    SafeCall(() =>
                    {
                        var reqPlaceOrder = new PlaceOrderRequest
                        {
                            InstrumentTicker = InputHelper.GetString("Instrument: "),
                            Side = InputHelper.GetEnum<OrderSide>("Side: "),
                            Type = InputHelper.GetEnum<OrderType>("Type: "),
                            Volume = InputHelper.GetDecimal("Volume: "),
                            Price = InputHelper.GetDecimal("Price: "),
                            TimeInForce = InputHelper.GetEnum<TimeInForce>("Time in force")
                        };
                        var orderInfo = apiClient.TradingApi.PlaceOrder(reqPlaceOrder);
                        Console.WriteLine(JsonConvert.SerializeObject(orderInfo, Formatting.Indented));
                    });
                    return true;

                case ConsoleKey.B:
                    SafeCall(() =>
                    {
                        long[] orderId = new long[2];
                        orderId[0] = 1528018890;
                        orderId[1] = 1528044768;

                        var orderInfo = apiClient.TradingApi.OrderStatus(orderId);
                        Console.WriteLine(JsonConvert.SerializeObject(orderInfo, Formatting.Indented));
                    });
                    return true;

                case ConsoleKey.C:
                    SafeCall(() =>
                    {
                        var orderId = InputHelper.GetInt("orderId: ");

                        var orderTradesInfo = apiClient.TradingApi.OrderTrades(orderId);
                        Console.WriteLine(JsonConvert.SerializeObject(orderTradesInfo, Formatting.Indented));
                    });
                    return true;

                case ConsoleKey.D:
                    SafeCall(() =>
                    {
                        var id = InputHelper.GetInt("ID: ");
                        var nPrice = InputHelper.GetDecimal("New price: ");
                        var nVolume = InputHelper.GetDecimal("New volume: ");

                        var orderModificationInfo = apiClient.TradingApi.OrderModification(id, nPrice, nVolume);
                        Console.WriteLine(JsonConvert.SerializeObject(orderModificationInfo, Formatting.Indented));
                    });
                    return true;

                case ConsoleKey.E:
                    SafeCall(() =>
                    {
                        //var instrument = InputHelper.GetString("Instrument: ");
                        string[] instrument = new[] {"DOGE-BTC"};

                        var orderInfo = apiClient.TradingApi.ActiveOrders(instrument);
                        Console.WriteLine(JsonConvert.SerializeObject(orderInfo, Formatting.Indented));
                    });
                    return true;

                case ConsoleKey.F:
                    SafeCall(() =>
                    {
                        var cancelType = InputHelper.GetInt("1 - Cancellation by ID, 2 - Cancellation by Instrument, 3 - Cancellation of All Orders: ");

                        long[]? orderInfo = null;
                        switch (cancelType)
                        {
                             case 1:

                                long[] ids = new long[2];
                                ids[0] = 1528527859;
                                ids[1] = 1528527937;


                                orderInfo = apiClient.TradingApi.CancelOrdersById(ids);
                                break;
                            case 2:
                                var intruments = InputHelper.GetString("Cancel by instruments: ");
                                string[] inst = new[] {"DOGE-BTC"};

                                orderInfo = apiClient.TradingApi.CancelOrdersByInstrument(inst);
                                break;
                            case 3:
                                orderInfo = apiClient.TradingApi.CancelAllOrders();
                                break;
                                
                        }
                        Console.WriteLine(JsonConvert.SerializeObject(orderInfo, Formatting.Indented));
                    });
                    return true;

                case ConsoleKey.G:
                    SafeCall(() =>
                    {
                        var instrument = InputHelper.GetString("Instrument: ");
                        var limit = InputHelper.GetInt("Limit: ");

                        string[] inst = new[] {"DOGE-BTC"};

                        var orderInfo = apiClient.TradingApi.OrderHistory(inst, null, null, (ushort)limit);
                        Console.WriteLine(JsonConvert.SerializeObject(orderInfo, Formatting.Indented));
                    });
                    return true;

                case ConsoleKey.H:
                    SafeCall(() =>
                    {
                        var instrument = InputHelper.GetString("Currency: ");
                        var limit = InputHelper.GetInt("Limit: ");

                        var tradeHistoryInfo = apiClient.TradingApi.TradeHistory();
                        Console.WriteLine(JsonConvert.SerializeObject(tradeHistoryInfo, Formatting.Indented));
                    });
                    return true;

                case ConsoleKey.I:
                    SafeCall(() =>
                    {
                        var feeAndRebateInfo = apiClient.TradingApi.FeeAndRebate();
                        Console.WriteLine(JsonConvert.SerializeObject(feeAndRebateInfo, Formatting.Indented));
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
