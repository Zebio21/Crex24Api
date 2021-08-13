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
        public CrexTrade[] OrderTrades(ulong orderId)
        {
            return client.MakeRequest<ReqOrderTrades, CrexTrade[]>(HttpMethod.Get, "orderTrades", new ReqOrderTrades
            {
                OrderId = orderId
            });
        }

        /// <inheritdoc />
        public CrexOrder[] ActiveOrders(string[] instruments = null)
        {
            return client.MakeRequest<ReqInstrumentFilter, CrexOrder[]>(HttpMethod.Get, "activeOrders", 
                new ReqInstrumentFilter { InstrumentTickers = instruments });
        }

        /// <inheritdoc />
        public ulong[] CancelOrdersById(ulong[] ids)
        {
            if (ids == null)
                throw new Exception("В метод отмены ордеров по списку ID вместо массива передано значение null");

            return client.MakeRequest<ReqCancelOrders, ulong[]>(HttpMethod.Post, "cancelOrdersById", new ReqCancelOrders
            {
                OrderIds = ids
            });
        }

        /// <inheritdoc />
        public ulong[] CancelOrdersByInstrument(string[] instruments)
        {
            if (instruments == null)
                throw new Exception("В метод отмены ордеров по списку инструментов вместо массива передано значение null");

            return client.MakeRequest<ReqCancelOrders, ulong[]>(HttpMethod.Post, "cancelOrdersByInstrument",
                new ReqCancelOrders
                {
                    InstrumentTickers = instruments.Select(ConvertingHelper.InstrumentHumanToApi).ToArray()
                });
        }

        /// <inheritdoc />
        public ulong[] CancelAllOrders()
        {
            return client.MakeRequest<ReqCancelOrders, ulong[]>(HttpMethod.Post, "cancelAllOrders", null);
        }

        /// <inheritdoc />
        public void Dispose()
        {
            client?.Dispose();
        }
    }
}
