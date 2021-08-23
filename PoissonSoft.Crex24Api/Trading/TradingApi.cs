using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using NLog;
using PoissonSoft.Crex24Api.Contracts;
using PoissonSoft.Crex24Api.Contracts.Requests;
using PoissonSoft.Crex24Api.Transport;
using PoissonSoft.Crex24Api.Transport.Rest;
using PoissonSoft.Crex24Api.Utils;

namespace PoissonSoft.Crex24Api.Trading
{
    /// <summary>
    /// Trading API
    /// </summary>
    public class TradingApi: ITradingApi, IDisposable
    {

        private readonly RestClient client;

        internal TradingApi(Throttler throttler, ILogger logger, Crex24ApiClientCredentials credentials)
        {
            client = new RestClient(logger, "https://api.crex24.com/v2/trading", throttler, credentials);
        }

        /// <inheritdoc />
        public CrexOrder PlaceOrder(PlaceOrderRequest placeOrderRequest)
        {
            return client.MakeRequest<PlaceOrderRequest, CrexOrder>(HttpMethod.Post, "placeOrder", placeOrderRequest);
        }

        /// <inheritdoc />
        public CrexOrder[] OrderStatus(ulong orderId)// TODO
        {
            return client.MakeRequest<ReqOrderTrades, CrexOrder[]>(HttpMethod.Get, "orderStatus", new ReqOrderTrades
            {
                OrderId = orderId
            });
        }

        /// <inheritdoc />
        public CrexTrade[] OrderTrades(ulong orderId)
        {
            return client.MakeRequest<ReqOrderTrades, CrexTrade[]>(HttpMethod.Get, "orderTrades", new ReqOrderTrades
            {
                OrderId = orderId
            });
        }

        /// <inheritdoc />
        public CrexOrder OrderModification(ulong orderId, decimal? newPrice = null, decimal? newVolume = null, bool? strictValidation = null)
        {
            return client.MakeRequest<ReqOrderModification, CrexOrder>(HttpMethod.Post, "modifyOrder", new ReqOrderModification
            {
                OrderId = orderId,
                NewPrice = newPrice,
                NewVolume = newVolume,
                StrictValidation = strictValidation
            });
        }

        /// <inheritdoc />
        public CrexOrder[] ActiveOrders(string[] instruments = null)
        {
            return client.MakeRequest<ReqInstrumentFilter, CrexOrder[]>(HttpMethod.Get, "activeOrders", 
                new ReqInstrumentFilter { InstrumentTickers = instruments });
        }

        /// <inheritdoc />
        public long[] CancelOrdersById(long[] ids)
        {
            if (ids == null)
                throw new Exception("В метод отмены ордеров по списку ID вместо массива передано значение null");

            return client.MakeRequest<ReqCancelOrders, long[]>(HttpMethod.Post, "cancelOrdersById", new ReqCancelOrders
            {
                OrderIds = ids
            });
        }

        /// <inheritdoc />
        public long[] CancelOrdersByInstrument(string[] instruments)
        {
            if (instruments == null)
                throw new Exception("В метод отмены ордеров по списку инструментов вместо массива передано значение null");

            return client.MakeRequest<ReqCancelOrders, long[]>(HttpMethod.Post, "cancelOrdersByInstrument",
                new ReqCancelOrders
                {
                    InstrumentTickers = instruments.Select(ConvertingHelper.InstrumentHumanToApi).ToArray()
                });
        }

        /// <inheritdoc />
        public long[] CancelAllOrders()
        {
            return client.MakeRequest<ReqCancelOrders, long[]>(HttpMethod.Post, "cancelAllOrders", null);
        }

        /// <inheritdoc />
        public CrexOrder[] OrderHistory(string[] instruments = null, DateTime? from = null, DateTime? till = null, ushort? limit = null)
        {
            return client.MakeRequest<ReqOrderHistory, CrexOrder[]>(HttpMethod.Get, "orderHistory", new ReqOrderHistory
            {
                InstrumentTicker = instruments,
                From = from,
                Till = till,
                Limit = limit
            });
        }

        /// <inheritdoc />
        public CrexTrade[] TradeHistory(string[] instruments = null, DateTime? from = null, DateTime? till = null, ushort? limit = null)
        {
            return client.MakeRequest<ReqOrderHistory, CrexTrade[]>(HttpMethod.Get, "tradeHistory", new ReqOrderHistory
            {
                InstrumentTicker = instruments,
                From = from,
                Till = till,
                Limit = limit
            });
        }

        /// <inheritdoc />
        public CrexFeeAndRebate FeeAndRebate()
        {
            return client.MakeRequest<ReqFilter, CrexFeeAndRebate>(HttpMethod.Get, "tradingFee", null);
        }

        /// <inheritdoc />
        public void Dispose()
        {
            client?.Dispose();
        }
    }
}
