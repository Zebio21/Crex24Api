# Crex24Api
Implementation of Crex24 BotAPI

This is an open source project created to utilize the Crex24 v2 API to support automated, algorithmic trading. The project was made and tested for Visual Studio C#.

There are no guarentees towards the stability or effectiveness of this project. Comments, contributions, stars and donations are, however, all welcome.

# Installation

https://www.nuget.org/packages/PoissonSoft.Crex24Api/

Alternatively, you can clone/download the repository and import into your project by file path.

# Using the API Wrapper

Once the API wrapper object is created, you can call any of the associated functions. They will return a Promise which can be utlized with .then/.catch or async/await. Note that the Promise based approach will return directly whereas the async/await approach requires calling the function.

```
var credentials = new Crex24ApiClientCredentials
{
	ApiKey = "XXXXX-XXXXX-XXXXX-XXXXX-XXXXXXXXX",
	SecretKey = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"
};

var apiClient = new Crex24ApiClient(credentials, logger);
```
# Account

## Balances
```
GET https://api.crex24.com/v2/account/balance?currency=BBN,ETH&nonZeroOnly=false
/*
Parameters
(string)currency
Optional. Comma-separated list of currencies for which the balance information is requested. If the parameter is not specified, 
the balance information is requested for all currencies

(boolean)nonZeroOnly
Optional. Can have either of the two values:
true - return only non-zero balances;
false - return all balances.
The default value is true
*/

var coinBalanceInfo = apiClient.AccountApi.Balances(currency, true);
```
## Crypto Deposit Address
```
GET https://api.crex24.com/v2/account/depositAddress?currency=USDT&transport=ERC20
/*
Parameters
(string)currency
Identifier of the cryptocurrency, that you would like to deposit
(string)transport
Optional. Identifier of the transport, that you would use to deposit. If the parameter is not specified and currency has multiple transports, the default transport will be used
*/

var coinDepositAddressInfo = apiClient.AccountApi.DepositAddress(currency);
```
## Money Transfer History
```
GET https://api.crex24.com/v2/account/moneyTransfers?currency=ETH
/*
Parameters
(string)type	
Optional. Filters money transfers by type, can have either of the two values:
"deposit" - get deposits only;
"withdrawal" - get withdrawals only.
If the parameter is not specified, both the deposits and withdrawals are returned

(string)currency	
Optional. Comma-separated list of currencies for which the money transfer history is requested. If the parameter is not specified, the money transfers are returned for all currencies

(datetime)from	
Optional. The start point of the time frame from which the money transfer history is collected
(datetime)till	

Optional. The end point of the time frame from which the money transfer history is collected

(int)limit
Optional. Maximum number of results per call. Accepted values: 1 - 1000. If the parameter is not specified, the number of results is limited to 100
*/

var TransferHistoryInfo = apiClient.AccountApi.MoneyTransferHistory(type, currency);
```

## Money Transfer Status
```
GET https://api.crex24.com/v2/account/moneyTransferStatus?id=756446,737551
/*
Parameters
(int)id
Comma-separated list of identifiers of money transfers for which the detailed information is requested
*/
var TransferStatusInfo = apiClient.AccountApi.MoneyTransferStatus(id);
```

## Crypto Withdrawal Preview
```
GET https://api.crex24.com/v2/account/previewWithdrawal?currency=LTC&amount=10&feeCurrency=LTC&includeFee=true
/*
Parameters
(string)currency
The value of parameter currency that will be specified in the actual withdrawal request

(decimal)amount
The value of parameter amount that will be specified in the actual withdrawal request

(sting)feeCurrency
The value of parameter feeCurrency that will be specified in the actual withdrawal request

(bool)includeFee		
Optional. The value of parameter includeFee that will be specified in the actual withdrawal request

(string)transport
Optional. The value of parameter transport that will be specified in the actual withdrawal request
*/
var WithdrawalPreviewInfo = apiClient.AccountApi.WithdrawalPreview(currency, amount, feeCurrency);
```

## Crypto Withdrawal
```
POST https://api.crex24.com/v2/account/withdraw
/*
Parameters
(string)currency
Currency identifier

(decimal)amount
Withdrawal amount (the precision is limited to a number of decimal places specified in the withdrawalPrecision field of the Currency, the value is rounded automatically to meet the precision limitation)
(string)address	
Crypto address to which the money will be transferred

(string)paymentId
Optional. Additional information (such as Payment ID, Message, Memo, etc.) that specifies the destination of money transfer along with the address. If this information is not required or not supported by the cryptocurrency, the parameter should be omitted

(string)feeCurrency	
Currency identifier to be used to pay the commission

(boolean)includeFee
Optional. Sets whether the specified amount includes fee, can have either of the two values:
true - balance will be decreased by amount, whereas [amount - fee] will be transferred to the specified address;
false - amount will be deposited to the specified address, whereas the balance will be decreased by [amount + fee].
The default value is false

(string)transport
Optional. Transport identifier. If the parameter is not specified and currency has multiple transports, the default transport will be used
*/
var TransferStatusInfo = apiClient.AccountApi.Withdrawal(currency, amount, address, feeCurrency);
```

# Market Data

## Currencies
```
GET https://api.crex24.com/v2/public/currencies
/*
Parameters
(string)currencies	
Optional. Comma-separated list of currencies for which the detailed information is requested. If the parameter is not specified, the detailed information about all available currencies is returned
*/
var CurrenciesInfo = apiClient.MarketDataApi.Currencies(currencies);
```

## Trade Instruments
```
GET https://api.crex24.com/v2/public/instruments?filter=ETH-BTC,BTC-USDT
/*
Parameters
(string)instruments	
Optional. Comma-separated list of instruments for which the detailed information is requested. If the parameter is not specified, the detailed information about all available instruments is returned
*/
var instrumentsInfo = apiClient.MarketDataApi.Instruments(instruments);
```

## Quotes (Tickers)
```
GET https://api.crex24.com/v2/public/tickers?instrument=ETH-BTC,BTC-USDT
/*
Parameters
(string[])instruments	
Optional. Comma-separated list of tickers for which the detailed information is requested. If the parameter is not specified, the detailed information about all available tickers is returned
*/
var instrumentsInfo = apiClient.MarketDataApi.Tickers(instruments);
```

## Recent Trades
```
GET https://api.crex24.com/v2/public/recentTrades?instrument=LTC-BTC
/*
Parameters
(string)instrument	
Trade instrument for which the trades are requested

(int)limit
Optional. Maximum number of results per call. Accepted values: 1 - 1000. If the parameter is not specified, the number of results is limited to 100
*/
var recentTradesInfo = apiClient.MarketDataApi.RecentTrades(instrument, limit);
```

## Order Book
```
GET https://api.crex24.com/v2/public/orderBook?instrument=LTC-BTC
/*
Parameters
(string)instrument	
Trade instrument for which the order book is requested

(int)limit	
Optional. Maximum number of returned price levels (both buying and selling) per call. If the parameter is not specified, the number of levels is limited to 100
*/
var orderBookInfo = apiClient.MarketDataApi.OrderBook(instrument, limit);
```

## OHLCV Data
```
GET https://api.crex24.com/v2/public/ohlcv?instrument=ETH-BTC&granularity=30m
/*
Parameters
(string)instrument	
Trade instrument for which the OHLCV data is requested

(string)granularity
OHLCV data granularity, can have one of the following values:
1m, 3m, 5m, 15m, 30m - 1, 3, 5, 15 or 30 minutes respectively;
1h, 4h - 1 or 4 hours respectively;
1d - 1 day;
1w - 1 week;
1mo - 1 month

(int)limit	
Optional. Maximum number of results per call. Accepted values: 1 - 1000. If the parameter is not specified, the number of results is limited to 100
*/
var OHLCVInfo = apiClient.MarketDataApi.OHLCVData(instrument, granularity, limit);
```

## Trading Fee Schedules
```
GET https://api.crex24.com/v2/public/tradingFeeSchedules
var feeSchedulesInfo = apiClient.MarketDataApi.TradingFeeSchedules();

Withdrawal Fees
GET https://api.crex24.com/v2/public/withdrawalFees?currency=LTC
/*
Parameters
(string)currency	
Currency identifier
*/
var withdrawalFeesInfo = apiClient.MarketDataApi.WithdrawalFees(currency);
```

## Currencies Withdrawal Fees
```
GET https://api.crex24.com/v2/public/currenciesWithdrawalFees?filter=BTC,LTC
/*
Parameters
(string[])currency	
Optional. Comma-separated list of currencies for which the withdrawal fees is requested. If the parameter is not specified, the withdrawal fees about all available currencies is returned
*/
var CurrenciesWithdrawalFeesInfo = apiClient.MarketDataApi.CurrenciesWithdrawalFees(currency);

Currency Transport
GET https://api.crex24.com/v2/public/currencyTransport?currency=USDT&transport=ERC20
/*
Parameters
(string)currency	
Currency identifier

(string)transport	
Transport identifier (all available transports for currency are specified in the transports field of the Currency)
*/
var currencyTransportInfo = apiClient.MarketDataApi.CurrencyTransport(currency, transport);
```

# Trading

## Order Placement
```
POST https://api.crex24.com/v2/trading/placeOrder
/*
Parameters
(string)instrument	
Trade instrument for which the order should be placed, e.g. "ETH-BTC"

(string)side	
Order side, can have either of the two values:
"buy" - buying order;
"sell" - selling order

(string)type	
Optional. Order type. Accepted values:
"limit" - limit order;
"market" - market order;
"stopLimit" - stop-limit order.
The value must comply with the list of order types supported by the instrument (see the value of parameter supportedOrderTypes of the Instrument).
If the parameter is not specified, the default value "limit" is used.

(string)timeInForce	
Optional. Sets the length of time over which the order will continue working before it’s cancelled. Accepted values:
"GTC" - Good-Til-Cancelled;
"IOC" - Immediate-Or-Cancel (currently not supported, reserved for future use);
"FOK" - Fill-Or-Kill (currently not supported, reserved for future use).
If the parameter is not specified, the default value "GTC" is used for limit orders.
More about limit order lifecycle in the section Limit Order

(decimal)volume*	
The amount of base currency to be bought or sold.
The value must be greater than or equal to the minVolume and less than or equal to the maxVolume of the Instrument.
The volume expressed in quote currency (notional value, calculated as price × volume) must be greater than or equal to the minQuoteVolume and less than or equal to the maxQuoteVolume of the Instrument

(decimal)price*	
Order price.
The value must be greater than or equal to the minPrice and less than or equal to the maxPrice of the Instrument.
This parameter is not necessary for market orders (if set explicitly, the value is ignored)

(decimal)stopPrice*	
The price in a stop-limit order that triggers the creation of a limit order.
The value must be greater than or equal to the minPrice and less than or equal to the maxPrice of the Instrument.
This parameter is mandatory for stop-limit orders only. In case of alternate order types, the value is ignored

(boolean)strictValidation*	
Optional. The values of parameters price and stopPrice must be multiples of tickSize, and the value of parameter volume must be a multiple of volumeIncrement of the Instrument. This field defines how such values should be processed, if they don’t meet the requirements:
false - prices and volume will be rounded to meet the requirements;
true - execution of the method will be aborted and an error message will be returned.
The default value is false.
*/
var reqPlaceOrder = new PlaceOrderRequest
{
	InstrumentTicker,
	Side,
	Type,
	Volume,
	Price,
	TimeInForce
};
var orderInfo = apiClient.TradingApi.PlaceOrder(reqPlaceOrder);
```

## Order Status
```
GET https://api.crex24.com/v2/trading/orderStatus?id=466747915,466748077
/*
Parameters
(int)id	
Comma-separated list of identifiers of orders for which the detailed information is requested
*/
var orderInfo = apiClient.TradingApi.OrderStatus(id);

Order Trades
GET https://api.crex24.com/v2/trading/orderTrades?id=416475861
/*
Parameters
(int)id	
ID of the order for which the information about trades is requested
*/
var orderTradesInfo = apiClient.TradingApi.OrderTrades(id);
```

## Order Modification
```
POST https://api.crex24.com/v2/trading/modifyOrder
/*
(int)id	
Identifier of the order that should be modified

(decimal)newPrice*	
Optional. New value of price.
If the parameter is not specified or its value is null or 0, the current value of price is used.
The value must be greater than or equal to the minPrice and less than or equal to the maxPrice of the Instrument

(decimal)newVolume*	
Optional. New value of volume.
If the parameter is not specified or its value is null or 0, the current value of remainingVolume is used.
The value must be greater than or equal to the minVolume and less than or equal to the maxVolume of the Instrument.
The volume expressed in quote currency (notional value, calculated as newPrice × newVolume) must be greater than or equal to the minQuoteVolume and less than or equal to the maxQuoteVolume of the Instrument

(boolean)strictValidation*	
Optional. The value of parameter newPrice must be a multiple of tickSize, and the value of parameter newVolume must be a multiple of volumeIncrement of the Instrument. This field defines how such values should be processed, if they are set explicitly in the request and don’t meet the requirements:
false - price and volume will be rounded to meet the requirements;
true - execution of the method will be aborted and an error message will be returned.
The default value is false
*/

var orderModificationInfo = apiClient.TradingApi.OrderModification(id, nPrice, nVolume);
```

## Active Orders
```
GET https://api.crex24.com/v2/trading/activeOrders?instrument=ETH-BTC,BTC-USDT
/*
Parameters
(string[])instrument	
Optional. Comma-separated list of trade instruments for which the active orders are requested. If the parameter is not specified, the active orders for all instruments are returned
*/
var orderInfo = apiClient.TradingApi.ActiveOrders(instrument);
```

## Order Cancellation

### Cancellation by ID
```
POST https://api.crex24.com/v2/trading/cancelOrdersById
/*
Parameters
(int[])ids	
Array of identifiers of orders that should be cancelled
*/
cancelOrderInfo = apiClient.TradingApi.CancelOrdersById(ids);
```

### Cancellation by Instrument
```
POST https://api.crex24.com/v2/trading/cancelOrdersByInstrument
/*
(string[])instruments	
Array of identifiers of trade instruments for which all orders should be cancelled
*/
cancelOrderInfo = apiClient.TradingApi.CancelOrdersByInstrument(instruments);
```

### Cancellation of All Orders
```
cancelOrderInfo = apiClient.TradingApi.CancelAllOrders();
```

## Order History
```
GET https://api.crex24.com/v2/trading/orderHistory?instrument=ETH-BTC,BTC-USDT
/*
Parameters
(string)instrument	
Optional. Comma-separated list of trade instruments for which the information about orders is requested. If the parameter is not specified, the information about orders is provided for all instruments
(datetime)from	
Optional. The start point of the time frame from which the information about orders should be collected
(datetime)till	
Optional. The end point of the time frame from which the information about orders should be collected
(int)limit	
Optional. Maximum number of results per call. Accepted values: 1 - 1000. If the parameter is not specified, the number of results is limited to 100
*/
var orderInfo = apiClient.TradingApi.OrderHistory(inst, null, null, limit);
```

## Trade History
```
GET https://api.crex24.com/v2/trading/tradeHistory?instrument=LTC-BTC
/*
Parameters

(string)instrument	
Optional. Comma-separated list of trade instruments for which the information about trades is requested. If the parameter is not specified, the information about trades is provided for all instruments

(datetime)from	
Optional. The start point of the time frame from which the information about trades should be collected

(datetime)till	
Optional. The end point of the time frame from which the information about trades should be collected

(int)limit	
Optional. Maximum number of results per call. Accepted values: 1 - 1000. If the parameter is not specified, the number of results is limited to 100
*/

var tradeHistoryInfo = apiClient.TradingApi.TradeHistory(instrument, null, null, limit);
```

## Fee and Rebate
```
GET https://api.crex24.com/v2/trading/tradingFee

var feeAndRebateInfo = apiClient.TradingApi.FeeAndRebate();
```
