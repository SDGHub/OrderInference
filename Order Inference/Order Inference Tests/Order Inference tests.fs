namespace tests

open System
open Microsoft.VisualStudio.TestTools.UnitTesting
open Quantix.OrderInference
open Test_Helper_Functions
//open DataWrangler.Structures

[<TestClass>]
type Default_Tick_Data_Structure_tests() = 

    // bid record test set up
    let bidTime = (DateTime.MinValue.AddTicks(int64 1))
    let bidPrice = 13700.
    let bidSize = 10
    let bidLevel =  1
    let bidQuote = Bid {defaultQuote with time = bidTime; price = bidPrice; size = bidSize; depth = bidLevel}

    // ask record test set up
    let askTime = (DateTime.MinValue.AddTicks(int64 2))
    let askPrice = 13710.
    let askSize = 20
    let askLevel =  2
    let askQuote = Ask {defaultQuote with time = askTime; price = askPrice; size = askSize; depth = askLevel}

    // trade record test set up
    let tradeTime = (DateTime.MinValue.AddTicks(int64 3))
    let tradePrice = 13720.
    let tradeSize = 5
    let tradeQuote = Trade {defaultTrade with time = tradeTime; price = tradePrice; size = tradeSize;}
    
    [<TestMethod>]        
    member this.Bid_Tick_matches_Tick_DUs_Bid_choice() =
        let isBidType = (
            match bidQuote with
            | Bid _ -> true
            | _ -> false )
        Assert.IsTrue(isBidType)

    [<TestMethod>]        
    member this.Bid_Tick_matches_Bid_Time() = 
        let time = (
            match bidQuote with
            | Bid q -> q.time
            | _ -> System.DateTime.MaxValue)
        Assert.AreEqual(time, bidTime)

    [<TestMethod>]        
    member this.Bid_Tick_matches_Bid_price() = 
        let price = (
            match bidQuote with
            | Bid q -> q.price
            | _ -> System.Double.MinValue )
        Assert.AreEqual(price, bidPrice)

    [<TestMethod>]        
    member this.Bid_Tick_matches_Bid_size() = 
        let size = (
            match bidQuote with
            | Bid q -> q.size
            | _ -> System.Int32.MaxValue )
        Assert.AreEqual(size, bidSize)        

    [<TestMethod>]        
    member this.Bid_Tick_matches_Bid_depth() = 
        let depth = (
            match bidQuote with
            | Bid q -> q.depth
            | _ -> System.Int32.MaxValue )
        Assert.AreEqual(depth, bidLevel)

    [<TestMethod>]        
    member this.ask_Tick_matches_ask_Time() = 
        let time = (
            match askQuote with
            | Ask q -> q.time
            | _ -> System.DateTime.MaxValue)
        Assert.AreEqual(time, askTime)

    [<TestMethod>]        
    member this.ask_Tick_matches_ask_price() = 
        let price = (
            match askQuote with
            | Ask q -> q.price
            | _ -> System.Double.MinValue )
        Assert.AreEqual(price, askPrice)

    [<TestMethod>]        
    member this.ask_Tick_matches_ask_size() = 
        let size = (
            match askQuote with
            | Ask q -> q.size
            | _ -> System.Int32.MaxValue )
        Assert.AreEqual(size, askSize)        

    [<TestMethod>]        
    member this.ask_Tick_matches_ask_depth() = 
        let depth = (
            match askQuote with
            | Ask q -> q.depth
            | _ -> System.Int32.MaxValue )
        Assert.AreEqual(depth, askLevel)

    [<TestMethod>]        
    member this.trade_Tick_matches_trade_Time() = 
        let time = (
            match tradeQuote with
            | Trade q -> q.time
            | _ -> System.DateTime.MaxValue)
        Assert.AreEqual(time, tradeTime)

    [<TestMethod>]        
    member this.trade_Tick_matches_trade_price() = 
        let price = (
            match tradeQuote with
            | Trade q -> q.price
            | _ -> System.Double.MinValue )
        Assert.AreEqual(price, tradePrice)

    [<TestMethod>]        
    member this.trade_Tick_matches_trade_size() = 
        let size = (
            match tradeQuote with
            | Trade q -> q.size
            | _ -> System.Int32.MaxValue )
        Assert.AreEqual(size, tradeSize)        
        
[<TestClass>]
type Default_Order_Data_Structure_tests() = 

    // Buy order test set up
    let buyTime = (DateTime.MinValue.AddTicks(int64 1))
    let buyPrice = 13700.
    let buySize = 10
    let buyIntensity =  5.0
    let buyOrder = Buy {defaultOrder with time = buyTime; price = buyPrice; size = buySize; intensity = buyIntensity}

    // Sell order test set up
    let sellTime = (DateTime.MinValue.AddTicks(int64 2))
    let sellPrice = 13710.
    let sellSize = 20
    let sellIntensity =  10.
    let sellOrder = Sell {defaultOrder with time = sellTime; price = sellPrice; size = sellSize; intensity = sellIntensity}
    
    [<TestMethod>]        
    member this.buy_Tick_matches_Tick_DUs_buy_choice() = 
        let isbuyType = (
            match buyOrder with
            | Buy _ -> true
            | _ -> false )
        Assert.IsTrue(isbuyType)

    [<TestMethod>]        
    member this.buy_Tick_matches_buy_Time() = 
        let time = (
            match buyOrder with
            | Buy q -> q.time
            | _ -> System.DateTime.MaxValue)
        Assert.AreEqual(time, buyTime)

    [<TestMethod>]        
    member this.buy_Tick_matches_buy_price() = 
        let price = (
            match buyOrder with
            | Buy q -> q.price
            | _ -> System.Double.MinValue )
        Assert.AreEqual(price, buyPrice)

    [<TestMethod>]        
    member this.buy_Tick_matches_buy_size() = 
        let size = (
            match buyOrder with
            | Buy q -> q.size
            | _ -> System.Int32.MaxValue )
        Assert.AreEqual(size, buySize)        

    [<TestMethod>]        
    member this.buy_Tick_matches_buy_intensity() = 
        let intensity = (
            match buyOrder with
            | Buy q -> q.intensity
            | _ -> System.Double.MaxValue )
        Assert.AreEqual(intensity, buyIntensity)

    [<TestMethod>]        
    member this.sell_Tick_matches_Tick_DUs_sell_choice() = 
        let isSellType = (
            match sellOrder with
            | Sell _ -> true
            | _ -> false )
        Assert.IsTrue(isSellType)

    [<TestMethod>]        
    member this.sell_Tick_matches_sell_Time() = 
        let time = (
            match sellOrder with
            | Sell q -> q.time
            | _ -> System.DateTime.MaxValue)
        Assert.AreEqual(time, sellTime)

    [<TestMethod>]        
    member this.sell_Tick_matches_sell_price() = 
        let price = (
            match sellOrder with
            | Sell q -> q.price
            | _ -> System.Double.MinValue )
        Assert.AreEqual(price, sellPrice)

    [<TestMethod>]        
    member this.sell_Tick_matches_sell_size() = 
        let size = (
            match sellOrder with
            | Sell q -> q.size
            | _ -> System.Int32.MaxValue )
        Assert.AreEqual(size, sellSize)        

    [<TestMethod>]        
    member this.sell_Tick_matches_sell_intensity() = 
        let intensity = (
            match sellOrder with
            | Sell q -> q.intensity
            | _ -> System.Double.MaxValue )
        Assert.AreEqual(intensity, sellIntensity)
        
[<TestClass>]
type Default_PriceNode_Data_Structure_tests() = 

    let updateTime = (DateTime.MinValue.AddTicks(int64 1))
    let price = 13700.
    let bidSize = 10
    let askSize =  5
    let pNode = { defaultPriceNode with price = price; bid = bidSize; ask = askSize; time = updateTime; }
    
    [<TestMethod>]        
    member this.priceNode_matches_updateTime() = 
        Assert.AreEqual(updateTime, pNode.time)

    [<TestMethod>]        
    member this.priceNode_matches_price() = 
        Assert.AreEqual(price, pNode.price)

    [<TestMethod>]        
    member this.priceNode_matches_bidSize() = 
        Assert.AreEqual(bidSize, pNode.bid)
    [<TestMethod>]        
    member this.priceNode_matches_askSize() = 
        Assert.AreEqual(askSize, pNode.ask)
        
[<TestClass>]
type Default_Market_Data_Structure_tests() = 

    // market record test set up
    let updateTime = (DateTime.MinValue.AddTicks(int64 1))
    let bestBidP = 13700.
    let bestAskP = 13710.
    let lastP =  13720.
    let market = { defaultMarket with bestBid = bestBidP; bestAsk = bestAskP; last = lastP; time = updateTime; }
    let isOpen2 = false
    let market2 = { market with isOpen = isOpen2 }
    
    [<TestMethod>]        
    member this.market_matches_updateTime() = 
        Assert.AreEqual(updateTime, market.time)

    [<TestMethod>]        
    member this.market_matches_bestBid() = 
        Assert.AreEqual(bestBidP, market.bestBid)

    [<TestMethod>]        
    member this.market_matches_bestAsk() = 
        Assert.AreEqual(bestAskP, market.bestAsk)

    [<TestMethod>]        
    member this.market_matches_last() = 
        Assert.AreEqual(lastP, market.last)

    [<TestMethod>]        
    member this.market_matches_isOpen_default_flag() = 
        Assert.IsTrue(market.isOpen)
        
    [<TestMethod>]        
    member this.market2_matches_isOpen_modified_flag() = 
        Assert.AreEqual(market2.isOpen, isOpen2)

[<TestClass>]
type Default_Orders_Sequence_tests() = 

    // set up
    let emptyOrdersSeqType = List.empty<Order>.GetType()
    
    [<TestMethod>]        
    member this.defaultOrders_is_of_correct_Type_of_Order_Sequence() = 
        Assert.AreEqual(defaultOrders.GetType(), emptyOrdersSeqType)

    [<TestMethod>]   
    member this.defaultOrders_returns_empty_sequence() = 
        Assert.IsTrue((Seq.isEmpty defaultOrders))
    
[<TestClass>]
type modifyMarket_with_Bid_quote_tests() = 

    // market record test set up
    let updateTime = (DateTime.MinValue.AddTicks(int64 1))
    let bestBidP = 13700.
    let bestAskP = 13710.
    let lastP =  13720.
    let marketBeforeBidQuote = { bestBid = bestBidP; bestAsk = bestAskP; last = lastP; time = updateTime; isOpen = true; }

     // bid record test set up
    let bidTime = (DateTime.MinValue.AddTicks(int64 2))
    let bidPrice = 13690.
    let bidSize = 10
    let bidLevel =  1
    let bidQuote = Bid {defaultQuote with time = bidTime; price = bidPrice; size = bidSize; depth = bidLevel}

    let marketAfterBidQuote = modifyMarket marketBeforeBidQuote bidQuote
    
    [<TestMethod>]        
    member this.modifyMarket_with_bid_quote_correctly_modifies_bestBid() = 
        Assert.AreEqual(marketAfterBidQuote.bestBid, bidPrice)

    [<TestMethod>]        
    member this.modifyMarket_with_bid_quote_correctly_modifies_update_time() = 
        Assert.AreEqual(marketAfterBidQuote.time, bidTime)
        
    [<TestMethod>]        
    member this.modifyMarket_with_bid_quote_return_same_bestAsk() = 
        Assert.AreEqual(marketAfterBidQuote.bestAsk, marketBeforeBidQuote.bestAsk)

    [<TestMethod>]        
    member this.modifyMarket_with_bid_quote_return_same_last() = 
        Assert.AreEqual(marketAfterBidQuote.last, marketBeforeBidQuote.last)
        
[<TestClass>]
type modifyMarket_with_Ask_quote_tests() = 

    // price record test set up
    let updateTime = (DateTime.MinValue.AddTicks(int64 1))
    let bestBidP = 13700.
    let bestAskP = 13710.
    let lastP =  13720.
    let marketBeforeAskQuote = { bestBid = bestBidP; bestAsk = bestAskP; last = lastP; time = updateTime; isOpen = true; }

     // ask record test set up
    let askTime = (DateTime.MinValue.AddTicks(int64 2))
    let askPrice = 13720.
    let askSize = 10
    let askLevel =  1
    let askQuote = Ask {defaultQuote with time = askTime; price = askPrice; size = askSize; depth = askLevel}

    let marketAfterAskQuote = modifyMarket marketBeforeAskQuote askQuote
    
    [<TestMethod>]        
    member this.modifyMarket_with_Ask_quote_correctly_modifies_bestAsk() = 
        Assert.AreEqual(marketAfterAskQuote.bestAsk, askPrice)

    [<TestMethod>]        
    member this.modifyMarket_with_Ask_quote_correctly_modifies_update_time() = 
        Assert.AreEqual(marketAfterAskQuote.time, askTime)
        
    [<TestMethod>]        
    member this.modifyMarket_with_Ask_quote_return_same_bestBid() = 
        Assert.AreEqual(marketBeforeAskQuote.bestBid, marketBeforeAskQuote.bestBid)

    [<TestMethod>]        
    member this.modifyMarket_with_Ask_quote_return_same_last() = 
        Assert.AreEqual(marketBeforeAskQuote.last, marketBeforeAskQuote.last)

[<TestClass>]
type modifyMarket_with_Trade_tests() = 

    // price record test set up
    let updateTime = (DateTime.MinValue.AddTicks(int64 1))
    let bestBidP = 13700.
    let bestAskP = 13710.
    let lastP =  13700.
    let marketBeforeTrade = { bestBid = bestBidP; bestAsk = bestAskP; last = lastP; time = updateTime; isOpen = true;}

     // ask record test set up
    let tradeTime = (DateTime.MinValue.AddTicks(int64 2))
    let tradePrice = 13720.
    let tradeSize = 10
    let tradeLevel =  1
    let trade = Trade {defaultTrade with time = tradeTime; price = tradePrice; size = tradeSize }

    let marketAfterTrade = modifyMarket marketBeforeTrade trade
    
    [<TestMethod>]        
    member this.modifyMarket_with_ask_quote_correctly_modifies_last() = 
        Assert.AreEqual(marketAfterTrade.last, tradePrice)

    [<TestMethod>]        
    member this.modifyMarket_with_ask_quote_correctly_modifies_update_time() = 
        Assert.AreEqual(marketAfterTrade.time, tradeTime)
        
    [<TestMethod>]        
    member this.modifyMarket_with_ask_quote_return_same_bestBid() = 
        Assert.AreEqual(marketAfterTrade.bestBid, marketBeforeTrade.bestBid)
    
    [<TestMethod>]        
    member this.modifyMarket_with_ask_quote_return_same_bestAsk() = 
        Assert.AreEqual(marketAfterTrade.bestAsk, marketBeforeTrade.bestAsk)
                
[<TestClass>]
type modifyPriceNode_with_Bid_quote_tests() = 

    // priceNode test set up
    let updateTime = (DateTime.MinValue.AddTicks(int64 1))
    let nodePrice = 13700.
    let bSize = 20
    let aSize = 10
    let nodeBeforeBidQuote = { price = nodePrice ; bid = bSize; ask = aSize; time = updateTime; }

     // bid quote test set up
    let bidTime = (DateTime.MinValue.AddTicks(int64 2))
    let bidPrice = nodePrice
    let bidSize = 15
    let bidLevel =  1
    let bidQuote = Bid {defaultQuote with time = bidTime; price = bidPrice; size = bidSize; depth = bidLevel}
    let nodeAfterBidQuoteMktOpen, _, _ = priceNodeAfterTick nodeBeforeBidQuote defaultMarket bidQuote 
    let nodeAfterBidQuoteMktClosed, _, _ = priceNodeAfterTick nodeBeforeBidQuote {defaultMarket with isOpen = false} bidQuote 
    
    [<TestMethod>]        
    member this.modifyPriceNode_with_bid_quote_correctly_modifies_bid_size() = 
        Assert.AreEqual(nodeAfterBidQuoteMktOpen.bid, bidSize)

    [<TestMethod>]        
    member this.modifyPriceNode_with_bid_quote_correctly_modifies_update_time() = 
        Assert.AreEqual(nodeAfterBidQuoteMktOpen.time, bidTime)
        
    [<TestMethod>]        
    member this.modifyPriceNode_with_bid_quote_return_same_ask_size_when_mkt_open() = 
        Assert.AreEqual(nodeAfterBidQuoteMktOpen.ask, 0)    
           
    [<TestMethod>]        
    member this.modifyPriceNode_with_bid_quote_return_same_ask_size_when_mkt_closed() = 
        Assert.AreEqual(nodeAfterBidQuoteMktClosed.ask, nodeBeforeBidQuote.ask)       
        
[<TestClass>]
type modifyPriceNode_with_Ask_quote_tests() = 

    // priceNode test set up
    let updateTime = (DateTime.MinValue.AddTicks(int64 1))
    let nodePrice = 13700.
    let bSize = 20
    let aSize = 10
    let nodeBeforeAskQuote = { price = nodePrice ; bid = bSize; ask = aSize; time = updateTime; }

     // ask quote test set up
    let askTime = (DateTime.MinValue.AddTicks(int64 2))
    let askPrice = nodePrice
    let askSize = 15
    let askLevel =  1
    let askQuote = Ask {defaultQuote with time = askTime; price = askPrice; size = askSize; depth = askLevel}
    
    let nodeAfterAskQuoteMktOpen, _, _ = priceNodeAfterTick nodeBeforeAskQuote defaultMarket askQuote 
    let nodeAfterAskQuoteMktClosed, _, _ = priceNodeAfterTick nodeBeforeAskQuote {defaultMarket with isOpen = false} askQuote 
    
    [<TestMethod>]        
    member this.modifyPriceNode_with_ask_quote_correctly_modifies_ask_size() = 
        Assert.AreEqual(nodeAfterAskQuoteMktOpen.ask, askSize)

    [<TestMethod>]        
    member this.modifyPriceNode_with_ask_quote_correctly_modifies_update_time() = 
        Assert.AreEqual(nodeAfterAskQuoteMktOpen.time, askTime)
        
    [<TestMethod>]        
    member this.modifyPriceNode_with_ask_quote_return_same_bid_size_Mkt_Open() = 
        Assert.AreEqual(nodeAfterAskQuoteMktOpen.bid, 0)     

    [<TestMethod>]        
    member this.modifyPriceNode_with_ask_quote_return_same_bid_size_Mkt_Closed() = 
        Assert.AreEqual(nodeAfterAskQuoteMktClosed.bid, nodeBeforeAskQuote.bid)       

[<TestClass>]
type modifyPriceNode_with_Trade_tests() = 

    // priceNode test set up
    let updateTime = (DateTime.MinValue.AddTicks(int64 1))
    let nodePrice = 13700.
    let bSize = 20
    let aSize = 10
    let nodeBeforeTrade = { price = nodePrice ; bid = bSize; ask = aSize; time = updateTime; }

     // trade quote test set up
    let tradeTime = (DateTime.MinValue.AddTicks(int64 2))
    let tradePrice = nodePrice
    let tradeSize = 15
    let tradeLevel =  1
    let bidSizeAfterTrade = max 0 (nodeBeforeTrade.bid - tradeSize)
    let askSizeAfterTrade = max 0 (nodeBeforeTrade.ask - tradeSize)
    let trade = Trade {defaultTrade with time = tradeTime; price = tradePrice; size = tradeSize; }
    
    let nodeAfterTrade, _, _ = priceNodeAfterTick nodeBeforeTrade defaultMarket trade 
    let nodeAfterTradeMktClosed, _, _ = priceNodeAfterTick nodeBeforeTrade {defaultMarket with isOpen = false} trade 


    [<TestMethod>]        
    member this.modifyPriceNode_with_trade_correctly_modifies_update_time() = 
        Assert.AreEqual(nodeAfterTrade.time, tradeTime)
        
    [<TestMethod>]        
    member this.modifyPriceNode_with_trade_quote_return_correct_bid_size_when_mkt_open() = 
        Assert.AreEqual(nodeAfterTrade.bid, bidSizeAfterTrade)  

    [<TestMethod>]        
    member this.modifyPriceNode_with_trade_quote_return_correct_ask_size_when_mkt_open() = 
        Assert.AreEqual(nodeAfterTrade.ask, askSizeAfterTrade)       
        
    [<TestMethod>]        
    member this.modifyPriceNode_with_trade_quote_return_same_bid_size_when_mkt_closed() = 
        Assert.AreEqual(nodeAfterTradeMktClosed.bid, nodeBeforeTrade.bid)  

    [<TestMethod>]        
    member this.modifyPriceNode_with_trade_quote_return_same_ask_size_when_mkt_closed() = 
        Assert.AreEqual(nodeAfterTradeMktClosed.ask, nodeBeforeTrade.ask)       
            
[<TestClass>]
type processTick_plus_Bid_quote_where_bid_size_increases_and_market_is_open_tests() = 

    let lastUpdateTime = (DateTime.MinValue.AddTicks(int64 1))
    let tickTime = (DateTime.MinValue.AddTicks(int64 2))

    // market set up
    let orders = List.empty<Order>
    let bestBidP = 13700.
    let bestAskP = 13700.
    let lastP =  13700.
    let marketBeforeTick = { bestBid = bestBidP; bestAsk = bestAskP; last = lastP; time = lastUpdateTime; isOpen = true;}

    // priceNode test set up
    let nodePrice = 13700.
    let nodeBidSize = 20
    let nodeAskSize = 25
    let nodeBeforeTick = { price = nodePrice ; bid = nodeBidSize; ask = nodeAskSize; time = lastUpdateTime; }
    
    // bid quote with incresing size set up
    let bidPrice = 13700.
    let bidSize = 35
    let bidQuote = Bid {defaultQuote with time = tickTime; price = bidPrice; size = bidSize;}
    let correctIntensity = bidPrice - bestBidP
    let correctOrderSize = bidSize - nodeBidSize 
    let cancelSellSize = -nodeAskSize      
    let (ordersAfterTick, pNodeAfterTick) = processTick orders marketBeforeTick nodeBeforeTick bidQuote

    // Tests using Bid quote (increase in bid size)
    [<TestMethod>]        
    member this.processTick_with_Bid_Quote_correctly_modifies_PriceNode_bid() = 
        Assert.AreEqual(pNodeAfterTick.bid, bidSize)

    [<TestMethod>]        
    member this.processTick_Bid_Quote_generates_correct_intensity_Buy_order() = 
        let orderIntensity = ordersAfterTick |> getFstBuyOrder |> getOrderIntensity
        Assert.AreEqual( orderIntensity , correctIntensity)
        
    [<TestMethod>]        
    member this.processTick_Bid_Quote_with_increase_bid_size_generates_Buy_order() =     
        Assert.IsTrue(ordersAfterTick |> hasBuyOrders)

    [<TestMethod>]       
    member this.processTick_Bid_Quote_does_not_generate_Sell_order() =     
        Assert.IsFalse(ordersAfterTick |> hasSellOrders)
        
    [<TestMethod>]        
    member this.processTick_with_increase_bid_size_Bid_Quote_does_not_generates_CancelBuy_order() =  
        Assert.IsFalse(ordersAfterTick |> hasCancelBuyOrders)

    [<TestMethod>]        
    member this.processTick_Bid_Quote_with_increase_bid_size_generates_correctly_sized_Buy_order() = 
        let orderSize =  ordersAfterTick |> getFstBuyOrder |> getOrderSize
        Assert.AreEqual(orderSize , correctOrderSize)    
        
    [<TestMethod>]        
    member this.processTick_with_Bid_Quote_modifies_PriceNode_askSize_to_zero() = 
        Assert.AreEqual(pNodeAfterTick.ask, 0)

    [<TestMethod>]        
    member this.processTick_with_Bid_Quote_generates_CancelSell_order() =  
        Assert.IsTrue(ordersAfterTick |> hasCancelSellOrders)

    [<TestMethod>]        
    member this.processTick_with_Bid_Quote_generates_correctly_sized_CancelSell_order() =  
        let orderSize = ordersAfterTick |> getFstCancelSellOrder |> getOrderSize
        Assert.AreEqual(orderSize,cancelSellSize) 
        
[<TestClass>]
type processTick_plus_Bid_quote_where_bid_size_decreases_and_market_is_open_tests() = 

    let lastUpdateTime = (DateTime.MinValue.AddTicks(int64 1))
    let tickTime = (DateTime.MinValue.AddTicks(int64 2))

    // market set up
    let orders = List.empty<Order>
    let bestBidP = 13700.
    let bestAskP = 13700.
    let lastP =  13700.
    let marketBeforeTick = { bestBid = bestBidP; bestAsk = bestAskP; last = lastP; time = lastUpdateTime; isOpen = true;}

    // priceNode test set up
    let nodePrice = 13700.
    let nodeBidSize = 20
    let nodeAskSize = 25
    let nodeBeforeTick = { price = nodePrice ; bid = nodeBidSize; ask = nodeAskSize; time = lastUpdateTime; }
    
    // bid quote with decresing size set up
    let bidPrice = 13700.
    let bidSize = 5
    let bidQuote = Bid {defaultQuote with time = tickTime; price = bidPrice; size = bidSize;}
    let correctIntensity = bidPrice - bestBidP
    let correctOrderSize = bidSize - nodeBidSize
    let cancelSellSize = -nodeAskSize       
    let (ordersAfterTick, pNodeAfterTick) = processTick orders marketBeforeTick nodeBeforeTick bidQuote

    // Tests using Bid quote (decrease in bid size)
    [<TestMethod>]        
    member this.processTick_with_Bid_Quote_correctly_modifies_PriceNode_bid() = 
        let size = (
            match bidQuote with
            | Bid q -> q.size
            | _ -> System.Int32.MinValue )
        Assert.AreEqual(pNodeAfterTick.bid, size)

    [<TestMethod>]        
    member this.processTick_with_decrease_bid_size_Bid_Quote_generates_CancelBuy_order() =    
        Assert.IsTrue(ordersAfterTick |> hasCancelBuyOrders)
        
    [<TestMethod>]        
    member this.processTick_with_decrease_bid_size_Bid_Quote_does_not_generate_Buy_order() =    
        Assert.IsFalse(ordersAfterTick |> hasBuyOrders)

    [<TestMethod>]       
    member this.processTick_Bid_Quote_does_not_generate_Sell_order() =     
        Assert.IsFalse(ordersAfterTick |> hasSellOrders)

    [<TestMethod>]        
    member this.processTick_with_Bid_quote_generates_correct_intensity_of_CancelBuy_order() = 
        let orderIntensity = ordersAfterTick |> getFstCancelBuyOrder |> getOrderIntensity
        Assert.AreEqual( orderIntensity , correctIntensity)        

    [<TestMethod>]        
    member this.processTick_with_decrease_bid_size_Bid_Quote_generates_correctly_sized_CancelBuy_order() = 
        let orderSize = ordersAfterTick |> getFstCancelBuyOrder |> getOrderSize
        Assert.AreEqual( orderSize , correctOrderSize)    
        
    [<TestMethod>]        
    member this.processTick_with_Bid_Quote_modifies_PriceNode_askSize_to_zero() = 
        Assert.AreEqual(pNodeAfterTick.ask, 0)

    [<TestMethod>]        
    member this.processTick_with_Bid_Quote_generates_CancelSell_order() =  
        Assert.IsTrue(ordersAfterTick |> hasCancelSellOrders) 

    [<TestMethod>]        
    member this.processTick_with_Bid_Quote_generates_correctly_sized_CancelSell_order() =  
        let orderSize = ordersAfterTick |> getFstCancelSellOrder |> getOrderSize
        Assert.AreEqual(orderSize,cancelSellSize) 

[<TestClass>]
type processTick_plus_Bid_quote_where_bid_size_is_unchanged_and_market_is_open_tests() = 

    let lastUpdateTime = (DateTime.MinValue.AddTicks(int64 1))
    let tickTime = (DateTime.MinValue.AddTicks(int64 2))

    // market set up
    let orders = List.empty<Order>
    let bestBidP = 13700.
    let bestAskP = 13700.
    let lastP =  13700.
    let marketBeforeTick = { bestBid = bestBidP; bestAsk = bestAskP; last = lastP; time = lastUpdateTime; isOpen = true;}

    // priceNode test set up
    let nodePrice = 13700.
    let nodeBidSize = 20
    let nodeAskSize = 25
    let nodeBeforeTick = { price = nodePrice ; bid = nodeBidSize; ask = nodeAskSize; time = lastUpdateTime; }
    
    // bid quote with same bid size set up
    let bidPrice = 13700.
    let bidSize = nodeBidSize
    let bidQuote = Bid {defaultQuote with time = tickTime; price = bidPrice; size = bidSize;}
    let correctIntensity = bidPrice - bestBidP
    let correctOrderSize = bidSize - nodeBidSize    
    let cancelSellSize = -nodeAskSize   
    let (ordersAfterTick, pNodeAfterTick) = processTick orders marketBeforeTick nodeBeforeTick bidQuote

    // Tests using Bid quote (bid size unchanged)
    [<TestMethod>]        
    member this.processTick_with_Bid_Quote_leaves_PriceNode_bid_unchaged() = 
        Assert.AreEqual(pNodeAfterTick.bid, nodeBeforeTick.bid)      
        
    [<TestMethod>]        
    member this.processTick_with_Bid_Quote_modifies_PriceNode_askSize_to_zero() = 
        Assert.AreEqual(pNodeAfterTick.ask, 0)
        
    [<TestMethod>]        
    member this.processTick_with_Bid_quote_does_not_generate_Buy_order() =
        Assert.IsFalse(ordersAfterTick |> hasBuyOrders)

    [<TestMethod>]       
    member this.processTick_Bid_Quote_does_not_generate_Sell_order() =     
        Assert.IsFalse(ordersAfterTick |> hasSellOrders)

    [<TestMethod>]        
    member this.processTick_with_Bid_quote_does_not_generate_CancelBuy_order() =
        Assert.IsFalse( ordersAfterTick |> hasCancelBuyOrders)

    [<TestMethod>]        
    member this.processTick_with_Bid_quote_generates_CancelSell_order() = 
        Assert.IsTrue( ordersAfterTick |> hasCancelSellOrders)

    [<TestMethod>]        
    member this.processTick_with_Bid_Quote_generates_correctly_sized_CancelSell_order() =     
        let orderSize = ordersAfterTick |> getFstCancelSellOrder |> getOrderSize
        Assert.AreEqual(orderSize, cancelSellSize) 

[<TestClass>]
type processTick_plus_Bid_quote_where_market_is_closed_tests() = 

    let lastUpdateTime = (DateTime.MinValue.AddTicks(int64 1))
    let tickTime = (DateTime.MinValue.AddTicks(int64 2))

    // market set up
    let orders = List.empty<Order>
    let bestBidP = 13700.
    let bestAskP = 13700.
    let lastP =  13700.
    let marketBeforeTick = { bestBid = bestBidP; bestAsk = bestAskP; last = lastP; time = lastUpdateTime; isOpen = false;}

    // priceNode test set up
    let nodePrice = 13700.
    let nodeBidSize = 20
    let nodeAskSize = 25
    let nodeBeforeTick = { price = nodePrice ; bid = nodeBidSize; ask = nodeAskSize; time = lastUpdateTime; }
    
    // bid quote with incresing size set up
    let bidPrice = 13700.
    let bidSize = 35
    let bidQuote = Bid {defaultQuote with time = tickTime; price = bidPrice; size = bidSize;}
    let (ordersAfterTick, pNodeAfterTick) = processTick orders marketBeforeTick nodeBeforeTick bidQuote

    // Tests using Bid quote (increase is bid size)        
    [<TestMethod>]        
    member this.processTick_with_Bid_Quote_does_not_modify_PriceNodes_askSize_to_zero() = 
        Assert.AreEqual(pNodeAfterTick.ask, nodeBeforeTick.ask)

    [<TestMethod>]        
    member this.processTick_with_Bid_quote_generates_Buy_order() =
        Assert.IsTrue( ordersAfterTick |> hasBuyOrders)   

    [<TestMethod>]        
    member this.processTick_with_Bid_Quote_does_not_generate_Sell_order() =  
        Assert.IsFalse( ordersAfterTick |> hasSellOrders)

    [<TestMethod>] 
    member this.processTick_with_Bid_quote_does_not_generate_CancelBuy_order() =
        Assert.IsFalse( ordersAfterTick |> hasCancelBuyOrders)   

    [<TestMethod>] 
    member this.processTick_with_Bid_quote_does_not_generate_Sell_order() =
        Assert.IsFalse( ordersAfterTick |> hasCancelSellOrders)

[<TestClass>]
type processTick_plus_Ask_quote_where_ask_size_increases_and_market_is_open_tests() = 

    let lastUpdateTime = (DateTime.MinValue.AddTicks(int64 1))
    let tickTime = (DateTime.MinValue.AddTicks(int64 2))

    // market set up
    let orders = List.empty<Order>
    let bestBidP = 13700.
    let bestAskP = 13700.
    let lastP =  13700.
    let marketBeforeTick = { bestBid = bestBidP; bestAsk = bestAskP; last = lastP; time = lastUpdateTime; isOpen = true;}

    // priceNode test set up
    let nodePrice = 13700.
    let nodeBidSize = 20
    let nodeAskSize = 25
    let nodeBeforeTick = { price = nodePrice ; bid = nodeBidSize; ask = nodeAskSize; time = lastUpdateTime; }
    
    // ask quote with incresing size set up
    let askPrice = 13700.
    let askSize = 35
    let askQuote = Ask {defaultQuote with time = tickTime; price = askPrice; size = askSize;}
    let correctIntensity = bestAskP - askPrice
    let correctOrderSize = askSize - nodeAskSize 
    let cancelBuySize = -nodeBidSize      
    let (ordersAfterTick, pNodeAfterTick) = processTick orders marketBeforeTick nodeBeforeTick askQuote

    // Tests using Bid quote (increase in ask size)
    [<TestMethod>]        
    member this.processTick_with_Ask_Quote_correctly_modifies_PriceNode_ask() = 
        Assert.AreEqual(pNodeAfterTick.ask, askSize)

    [<TestMethod>]        
    member this.processTick_Ask_Quote_generates_correct_intensity_Sell_order() = 
        let orderIntensity = ordersAfterTick |> getFstSellOrder |> getOrderIntensity
        Assert.AreEqual( orderIntensity , correctIntensity)
        
    [<TestMethod>]        
    member this.processTick_Ask_Quote_with_increase_ask_size_generates_Sell_order() =     
        Assert.IsTrue(ordersAfterTick |> hasSellOrders)
        
    [<TestMethod>]        
    member this.processTick_with_increase_ask_size_Ask_Quote_does_not_generates_CancelSell_order() =  
        Assert.IsFalse(ordersAfterTick |> hasCancelSellOrders)

    [<TestMethod>]        
    member this.processTick_with_increase_ask_size_Ask_Quote_does_not_generates_Buy_order() =  
        Assert.IsFalse(ordersAfterTick |> hasBuyOrders)

    [<TestMethod>]        
    member this.processTick_Ask_Quote_with_increase_ask_size__generates_correctly_sized_Sell_order() = 
        let orderSize =  ordersAfterTick |> getFstSellOrder |> getOrderSize
        Assert.AreEqual(orderSize, correctOrderSize)    
        
    [<TestMethod>]        
    member this.processTick_with_Ask_Quote_modifies_PriceNode_bidSize_to_zero() = 
        Assert.AreEqual(pNodeAfterTick.bid, 0)

    [<TestMethod>]        
    member this.processTick_with_Ask_Quote_generates_CancelBuy_order() =  
        Assert.IsTrue(ordersAfterTick |> hasCancelBuyOrders)

    [<TestMethod>]        
    member this.processTick_with_Ask_Quote_generates_correctly_sized_CancelBuy_order() =  
        let orderSize = ordersAfterTick |> getFstCancelBuyOrder |> getOrderSize
        Assert.AreEqual(orderSize, cancelBuySize) 
        
[<TestClass>]
type processTick_plus_Ask_quote_where_ask_size_decreases_and_market_is_open_tests() = 

    let lastUpdateTime = (DateTime.MinValue.AddTicks(int64 1))
    let tickTime = (DateTime.MinValue.AddTicks(int64 2))

    // market set up
    let orders = List.empty<Order>
    let bestBidP = 13700.
    let bestAskP = 13700.
    let lastP =  13700.
    let marketBeforeTick = { bestBid = bestBidP; bestAsk = bestAskP; last = lastP; time = lastUpdateTime; isOpen = true;}

    // priceNode test set up
    let nodePrice = 13700.
    let nodeBidSize = 20
    let nodeAskSize = 25
    let nodeBeforeTick = { price = nodePrice ; bid = nodeBidSize; ask = nodeAskSize; time = lastUpdateTime; }
    
    // ask quote with decresing size set up
    let askPrice = 13700.
    let askSize = 5
    let askQuote = Ask {defaultQuote with time = tickTime; price = askPrice; size = askSize;}
    let correctIntensity = bestAskP - askPrice
    let correctOrderSize = askSize - nodeAskSize 
    let cancelBuySize = -nodeBidSize      
    let (ordersAfterTick, pNodeAfterTick) = processTick orders marketBeforeTick nodeBeforeTick askQuote

    // Tests using Ask quote (decrease in ask size)
    [<TestMethod>]        
    member this.processTick_with_Ask_Quote_correctly_modifies_PriceNode_ask() = 
        Assert.AreEqual(pNodeAfterTick.ask, askSize)

    [<TestMethod>]        
    member this.processTick_with_Ask_Quote_with_decrease_ask_size_generates_CancelSell_order() =    
        Assert.IsTrue(ordersAfterTick |> hasCancelSellOrders)
        
    [<TestMethod>]        
    member this.processTick_with_Ask_Quote_with_decrease_ask_size_does_not_generate_Sell_order() =    
        Assert.IsFalse(ordersAfterTick |> hasSellOrders )

    [<TestMethod>]       
    member this.processTick_with_Ask_Quote_does_not_generate_Buy_order() =     
        Assert.IsFalse(ordersAfterTick |> hasBuyOrders )

    [<TestMethod>]        
    member this.processTick_with_Ask_quote_with_decrease_ask_size_generates_correct_intensity_of_CancelSell_order() = 
        let orderIntensity = ordersAfterTick |> getFstCancelSellOrder |> getOrderIntensity
        Assert.AreEqual( orderIntensity, correctIntensity)        

    [<TestMethod>]        
    member this.processTick_with_Ask_Quote_with_decrease_ask_size_generates_correctly_sized_CancelSell_order() = 
        let orderSize = ordersAfterTick |> getFstCancelSellOrder |> getOrderSize
        Assert.AreEqual( orderSize, correctOrderSize)    
        
    [<TestMethod>]        
    member this.processTick_with_Ask_Quote_modifies_PriceNode_bidSize_to_zero() = 
        Assert.AreEqual(pNodeAfterTick.bid, 0)

    [<TestMethod>]        
    member this.processTick_with_Ask_Quote_generates_CancelBuy_order() =  
        Assert.IsTrue(ordersAfterTick |> hasCancelBuyOrders) 

    [<TestMethod>]        
    member this.processTick_with_Ask_Quote_generates_correctly_sized_CancelBuy_order() =  
        let orderSize = ordersAfterTick |> getFstCancelBuyOrder |> getOrderSize
        Assert.AreEqual(orderSize, cancelBuySize) 

[<TestClass>]
type processTick_plus_Ask_quote_where_Ask_size_is_unchanged_and_market_is_open_tests() = 

    let lastUpdateTime = (DateTime.MinValue.AddTicks(int64 1))
    let tickTime = (DateTime.MinValue.AddTicks(int64 2))

    // market set up
    let orders = List.empty<Order>
    let bestBidP = 13700.
    let bestAskP = 13700.
    let lastP =  13700.
    let marketBeforeTick = { bestBid = bestBidP; bestAsk = bestAskP; last = lastP; time = lastUpdateTime; isOpen = true;}

    // priceNode test set up
    let nodePrice = 13700.
    let nodeBidSize = 20
    let nodeAskSize = 25
    let nodeBeforeTick = { price = nodePrice ; bid = nodeBidSize; ask = nodeAskSize; time = lastUpdateTime; }
    
    // ask quote with same ask size set up
    let askPrice = 13700.
    let askSize = nodeAskSize
    let askQuote = Ask {defaultQuote with time = tickTime; price = askPrice; size = askSize;}
    let correctIntensity = bestAskP - askPrice
    let cancelBuySize = -nodeBidSize      
    let (ordersAfterTick, pNodeAfterTick) = processTick orders marketBeforeTick nodeBeforeTick askQuote

    // Tests using Bid quote (ask size unchanged)
    [<TestMethod>]        
    member this.processTick_with_Ask_Quote_leaves_PriceNode_ask_unchaged() = 
        Assert.AreEqual(pNodeAfterTick.ask, nodeBeforeTick.ask)      
        
    [<TestMethod>]        
    member this.processTick_with_Ask_Quote_correctly_modifies_PriceNode_bidSize_to_zero() = 
        Assert.AreEqual(pNodeAfterTick.bid, 0)
        
    [<TestMethod>]        
    member this.processTick_with_Ask_quote_does_not_generate_Buy_order() =
        Assert.IsFalse(ordersAfterTick |> hasBuyOrders)

    [<TestMethod>]       
    member this.processTick_with_Ask_Quote_does_not_generate_Sell_order() =     
        Assert.IsFalse(ordersAfterTick |> hasSellOrders )

    [<TestMethod>]        
    member this.processTick_with_Ask_quote_does_not_generate_CancelSell_order() =
        Assert.IsFalse( ordersAfterTick |> hasCancelSellOrders )

    [<TestMethod>]        
    member this.processTick_with_Ask_quote_generates_CancelBuy_order() = 
        Assert.IsTrue( ordersAfterTick |> hasCancelBuyOrders )

    [<TestMethod>]        
    member this.processTick_with_Ask_Quote_generates_correctly_sized_CancelBuy_order() =     
        let orderSize = ordersAfterTick |> getFstCancelBuyOrder |> getOrderSize
        Assert.AreEqual(orderSize, cancelBuySize) 
        
[<TestClass>]
type processTick_plus_Ask_quote_where_market_is_closed_tests() = 

    let lastUpdateTime = (DateTime.MinValue.AddTicks(int64 1))
    let tickTime = (DateTime.MinValue.AddTicks(int64 2))

    // market set up
    let orders = List.empty<Order>
    let bestBidP = 13700.
    let bestAskP = 13700.
    let lastP =  13700.
    let marketBeforeTick = { bestBid = bestBidP; bestAsk = bestAskP; last = lastP; time = lastUpdateTime; isOpen = false;}

    // priceNode test set up
    let nodePrice = 13700.
    let nodeBidSize = 20
    let nodeAskSize = 25
    let nodeBeforeTick = { price = nodePrice ; bid = nodeBidSize; ask = nodeAskSize; time = lastUpdateTime; }
    
    // ask quote with incresing size set up
    let askPrice = 13700.
    let askSize = 35
    let askQuote = Ask {defaultQuote with time = tickTime; price = askPrice; size = askSize;}
    let (ordersAfterTick, pNodeAfterTick) = processTick orders marketBeforeTick nodeBeforeTick askQuote

    // Tests using Bid quote (increase is ask size)        
    [<TestMethod>]        
    member this.processTick_with_Ask_Quote_does_not_modify_PriceNodes_bidSize_to_zero() = 
        Assert.AreEqual(pNodeAfterTick.bid, nodeBeforeTick.bid)

    [<TestMethod>]        
    member this.processTick_with_Ask_quote_generates_Sell_order() =
        Assert.IsTrue( ordersAfterTick |> hasSellOrders)  

    [<TestMethod>] 
    member this.processTick_with_Ask_quote_does_not_generate_Buy_order() =
        Assert.IsFalse( ordersAfterTick |> hasBuyOrders) 

    [<TestMethod>]        
    member this.processTick_with_Ask_Quote_does_not_generate_CancelSell_order() =  
        Assert.IsFalse( ordersAfterTick |> hasCancelSellOrders)

    [<TestMethod>] 
    member this.processTick_with_Ask_quote_does_not_generate_CancelBuy_order() =
        Assert.IsFalse( ordersAfterTick |> hasCancelBuyOrders)   
        
[<TestClass>]
type processTick_plus_Trade_where_market_is_open_and_offered_with_more_than_trade_size_tests() = 

    let lastUpdateTime = (DateTime.MinValue.AddTicks(int64 1))
    let tickTime = (DateTime.MinValue.AddTicks(int64 2))

    // market set up
    let orders = List.empty<Order>
    let bestBidP = 13700.
    let bestAskP = 13710.
    let lastP =  13700.
    let marketBeforeTick = { bestBid = bestBidP; bestAsk = bestAskP; last = lastP; time = lastUpdateTime; isOpen = true;}
        
    // priceNode test set up
    let nodePrice = 13700.
    let nodeBidSize = 0
    let nodeAskSize = 20
    let nodeBeforeTick = { price = nodePrice ; bid = nodeBidSize; ask = nodeAskSize; time = lastUpdateTime; }

    // trade
    let tradePrice = 13700.
    let tradeSize = 15
    let nodesAskSizeAfterTrade = max 0 (nodeAskSize - tradeSize)
    let nodesBidSizeAfterTrade = max 0 (nodeBidSize - tradeSize)
    let trade = Trade {defaultTrade with time = tickTime; price = tradePrice; size = tradeSize;}
    let (ordersAfterTick, pNodeAfterTick) = processTick orders marketBeforeTick nodeBeforeTick trade
        
    [<TestMethod>]        
    member this.processTick_with_Trade_correctly_modifies_PriceNodes_ask_size() = 
        Assert.AreEqual(pNodeAfterTick.ask, nodesAskSizeAfterTrade)

    [<TestMethod>]        
    member this.processTick_with_Trade_correctly_modifies_PriceNodes_bid_Size() = 
        Assert.AreEqual(pNodeAfterTick.bid, nodesBidSizeAfterTrade)
        
    [<TestMethod>]        
    member this.processTick_with_Trade_quote_generates_Buy_order() =
        Assert.IsTrue( ordersAfterTick |> hasBuyOrders)  
    
    [<TestMethod>]        
    member this.processTick_with_Trade_Quote_generates_correctly_sized_Buy_order() =     
        let orderSize = ordersAfterTick |> getFstCancelBuyOrder |> getOrderSize
        Assert.AreEqual(orderSize, tradeSize) 

    [<TestMethod>] 
    member this.processTick_with_Trade_quote_does_not_generate_Sell_order() =
        Assert.IsFalse( ordersAfterTick |> hasSellOrders) 

    [<TestMethod>]        
    member this.processTick_with_Trade_Quote_does_not_generate_CancelSell_order() =  
        Assert.IsFalse( ordersAfterTick |> hasCancelSellOrders)

    [<TestMethod>] 
    member this.processTick_with_Trade_quote_does_not_generate_CancelBuy_order() =
        Assert.IsFalse( ordersAfterTick |> hasCancelBuyOrders)   

//    [<TestMethod>]
//    [<ExpectedException(typeof<System.InvalidOperationException>)>]
//    member x.throws_exception_if_market_is_not_initialized() = 
//        mkt2.NewTick(bidTick)
    