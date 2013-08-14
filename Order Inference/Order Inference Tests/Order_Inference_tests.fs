namespace Order_Inference_tests

open System
open Microsoft.VisualStudio.TestTools.UnitTesting
open Quantix.OrderInference
//open DataWrangler.Structures

[<TestClass>]
type Order_Inference_Default_Tick_Data_Structure_Tests() = 

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
type Order_Inference_Default_Order_Data_Structure_Tests() = 

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
type Order_Inference_Default_PriceNode_Data_Structure_Tests() = 

    let updateTime = (DateTime.MinValue.AddTicks(int64 1))
    let price = 13700.
    let bidSize = 10
    let askSize =  5
    let pNode = { defaultPriceNode with price = price; bid = bidSize; ask = askSize; updated = updateTime; }
    
    [<TestMethod>]        
    member this.priceNode_matches_updateTime() = 
        Assert.AreEqual(updateTime, pNode.updated)

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
type Order_Inference_Default_Market_Data_Structure_Tests() = 

    // market record test set up
    let updateTime = (DateTime.MinValue.AddTicks(int64 1))
    let bestBidP = 13700.
    let bestAskP = 13710.
    let lastP =  13720.
    let market = { defaultMarket with bestBid = bestBidP; bestAsk = bestAskP; last = lastP; updated = updateTime; }
    
    [<TestMethod>]        
    member this.market_matches_updateTime() = 
        Assert.AreEqual(updateTime, market.updated)

    [<TestMethod>]        
    member this.market_matches_bestBid() = 
        Assert.AreEqual(bestBidP, market.bestBid)

    [<TestMethod>]        
    member this.market_matches_bestAsk() = 
        Assert.AreEqual(bestAskP, market.bestAsk)
    [<TestMethod>]        
    member this.market_matches_last() = 
        Assert.AreEqual(lastP, market.last)

[<TestClass>]
type Order_Inference_DefaultOrders_Sequence_Tests() = 

    // set up
    let emptyOrdersSeqType = List.empty<Order>.GetType()
    
    [<TestMethod>]        
    member this.defaultOrders_is_of_correct_Type_of_Order_Sequence() = 
        Assert.AreEqual(defaultOrders.GetType(), emptyOrdersSeqType)

    [<TestMethod>]   
    member this.defaultOrders_returns_empty_sequence() = 
        Assert.IsTrue((Seq.isEmpty defaultOrders))
    
[<TestClass>]
type Order_Inference_modifyMarket_with_Bid_quote_Tests() = 

    // market record test set up
    let updateTime = (DateTime.MinValue.AddTicks(int64 1))
    let bestBidP = 13700.
    let bestAskP = 13710.
    let lastP =  13720.
    let marketBeforeBidQuote = { bestBid = bestBidP; bestAsk = bestAskP; last = lastP; updated = updateTime; }

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
        Assert.AreEqual(marketAfterBidQuote.updated, bidTime)
        
    [<TestMethod>]        
    member this.modifyMarket_with_bid_quote_return_same_bestAsk() = 
        Assert.AreEqual(marketAfterBidQuote.bestAsk, marketBeforeBidQuote.bestAsk)

    [<TestMethod>]        
    member this.modifyMarket_with_bid_quote_return_same_last() = 
        Assert.AreEqual(marketAfterBidQuote.last, marketBeforeBidQuote.last)
        
[<TestClass>]
type Order_Inference_modifyMarket_with_Ask_quote_Tests() = 

    // price record test set up
    let updateTime = (DateTime.MinValue.AddTicks(int64 1))
    let bestBidP = 13700.
    let bestAskP = 13710.
    let lastP =  13720.
    let marketBeforeAskQuote = { bestBid = bestBidP; bestAsk = bestAskP; last = lastP; updated = updateTime; }

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
        Assert.AreEqual(marketAfterAskQuote.updated, askTime)
        
    [<TestMethod>]        
    member this.modifyMarket_with_Ask_quote_return_same_bestBid() = 
        Assert.AreEqual(marketBeforeAskQuote.bestBid, marketBeforeAskQuote.bestBid)

    [<TestMethod>]        
    member this.modifyMarket_with_Ask_quote_return_same_last() = 
        Assert.AreEqual(marketBeforeAskQuote.last, marketBeforeAskQuote.last)

[<TestClass>]
type Order_Inference_modifyMarket_with_Trade_Tests() = 

    // price record test set up
    let updateTime = (DateTime.MinValue.AddTicks(int64 1))
    let bestBidP = 13700.
    let bestAskP = 13710.
    let lastP =  13700.
    let marketBeforeTrade = { bestBid = bestBidP; bestAsk = bestAskP; last = lastP; updated = updateTime; }

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
        Assert.AreEqual(marketAfterTrade.updated, tradeTime)
        
    [<TestMethod>]        
    member this.modifyMarket_with_ask_quote_return_same_bestBid() = 
        Assert.AreEqual(marketAfterTrade.bestBid, marketBeforeTrade.bestBid)
    
    [<TestMethod>]        
    member this.modifyMarket_with_ask_quote_return_same_bestAsk() = 
        Assert.AreEqual(marketAfterTrade.bestAsk, marketBeforeTrade.bestAsk)
                
[<TestClass>]
type Order_Inference_modifyPriceNode_with_Bid_quote_Tests() = 

    // priceNode test set up
    let updateTime = (DateTime.MinValue.AddTicks(int64 1))
    let nodePrice = 13700.
    let bSize = 20
    let aSize = 10
    let nodeBeforeBidQuote = { price = nodePrice ; bid = bSize; ask = aSize; updated = updateTime; }

     // bid quote test set up
    let bidTime = (DateTime.MinValue.AddTicks(int64 2))
    let bidPrice = nodePrice
    let bidSize = 15
    let bidLevel =  1
    let bidQuote = Bid {defaultQuote with time = bidTime; price = bidPrice; size = bidSize; depth = bidLevel}

    let nodeAfterBidQuote = modifyPriceNode nodeBeforeBidQuote bidQuote
    
    [<TestMethod>]        
    member this.modifyPriceNode_with_bid_quote_correctly_modifies_bid_size() = 
        Assert.AreEqual(nodeAfterBidQuote.bid, bidSize)

    [<TestMethod>]        
    member this.modifyPriceNode_with_bid_quote_correctly_modifies_update_time() = 
        Assert.AreEqual(nodeAfterBidQuote.updated, bidTime)
        
    [<TestMethod>]        
    member this.modifyPriceNode_with_bid_quote_return_same_ask_size() = 
        Assert.AreEqual(nodeAfterBidQuote.ask, nodeBeforeBidQuote.ask)       
        
[<TestClass>]
type Order_Inference_modifyPriceNode_with_Ask_quote_Tests() = 

    // priceNode test set up
    let updateTime = (DateTime.MinValue.AddTicks(int64 1))
    let nodePrice = 13700.
    let bSize = 20
    let aSize = 10
    let nodeBeforeAskQuote = { price = nodePrice ; bid = bSize; ask = aSize; updated = updateTime; }

     // ask quote test set up
    let askTime = (DateTime.MinValue.AddTicks(int64 2))
    let askPrice = nodePrice
    let askSize = 15
    let askLevel =  1
    let askQuote = Ask {defaultQuote with time = askTime; price = askPrice; size = askSize; depth = askLevel}

    let nodeAfterAskQuote = modifyPriceNode nodeBeforeAskQuote askQuote
    
    [<TestMethod>]        
    member this.modifyPriceNode_with_ask_quote_correctly_modifies_ask_size() = 
        Assert.AreEqual(nodeAfterAskQuote.ask, askSize)

    [<TestMethod>]        
    member this.modifyPriceNode_with_ask_quote_correctly_modifies_update_time() = 
        Assert.AreEqual(nodeAfterAskQuote.updated, askTime)
        
    [<TestMethod>]        
    member this.modifyPriceNode_with_ask_quote_return_same_bid_size() = 
        Assert.AreEqual(nodeAfterAskQuote.bid, nodeBeforeAskQuote.bid)       

[<TestClass>]
type Order_Inference_modifyPriceNode_with_Trade_Tests() = 

    // priceNode test set up
    let updateTime = (DateTime.MinValue.AddTicks(int64 1))
    let nodePrice = 13700.
    let bSize = 20
    let aSize = 10
    let nodeBeforeTrade = { price = nodePrice ; bid = bSize; ask = aSize; updated = updateTime; }

     // trade quote test set up
    let tradeTime = (DateTime.MinValue.AddTicks(int64 2))
    let tradePrice = nodePrice
    let tradeSize = 15
    let tradeLevel =  1
    let tradeQuote = Trade {defaultTrade with time = tradeTime; price = tradePrice; size = tradeSize; }

    let nodeAfterTrade = modifyPriceNode nodeBeforeTrade tradeQuote    

    [<TestMethod>]        
    member this.modifyPriceNode_with_trade_correctly_modifies_update_time() = 
        Assert.AreEqual(nodeAfterTrade.updated, tradeTime)
        
    [<TestMethod>]        
    member this.modifyPriceNode_with_trade_quote_return_same_bid_size() = 
        Assert.AreEqual(nodeAfterTrade.bid, nodeBeforeTrade.bid)  

    [<TestMethod>]        
    member this.modifyPriceNode_with_trade_quote_return_same_ask_size() = 
        Assert.AreEqual(nodeAfterTrade.ask, nodeBeforeTrade.ask)       

[<TestClass>]
type Order_Inference_orderIntensity_with_Buy_order_Tests() = 
    
    // price record test set up
    let updateTime = (DateTime.MinValue.AddTicks(int64 1))
    let bestBidP = 13700.
    let bestAskP = 13710.
    let lastP =  13700.
    let marketBeforeOrder = { bestBid = bestBidP; bestAsk = bestAskP; last = lastP; updated = updateTime; }

    // Buy order test set up 1
    let buyTime1 = (DateTime.MinValue.AddTicks(int64 2))
    let buyPrice1 = 13700.
    let buySize1 = 10
    let buyIntensity1 =  0.
    let buyOrderAtBid = Buy {defaultOrder with time = buyTime1; price = buyPrice1; size = buySize1; intensity = buyIntensity1}

[<TestClass>]
type Order_Inference_process_order_with_Bid_quote_Tests() = 

    let lastUpdateTime = (DateTime.MinValue.AddTicks(int64 1))
    let tickTime = (DateTime.MinValue.AddTicks(int64 2))

    // market set up
    let orders = List.empty<Order>
    let bestBidP = 13700.
    let bestAskP = 13700.
    let lastP =  13700.
    let marketBeforeTick = { bestBid = bestBidP; bestAsk = bestAskP; last = lastP; updated = lastUpdateTime; }

    // priceNode test set up
    let nodePrice = 13700.
    let nodeBidSize = 20
    let nodeAskSize = 25
    let nodeBeforeTick = { price = nodePrice ; bid = nodeBidSize; ask = nodeAskSize; updated = lastUpdateTime; }
    
    // bid quote with incresing size set up
    let bidPrice1 = 13700.
    let bidSize1 = 35
    let bidQuote1 = Bid {defaultQuote with time = tickTime; price = bidPrice1; size = bidSize1;}
    let correctIntensity1 = bidPrice1 - bestBidP
    let correctSize1 = bidSize1 - nodeBidSize    
    let (ordersAfterTick1, pNodeAfterTick1) = processTick orders marketBeforeTick nodeBeforeTick bidQuote1
    let order1 =  ordersAfterTick1.[0] 
    let orderNext1 =  if ordersAfterTick1.Length >  1 then ordersAfterTick1.[1] else Buy defaultOrder

    // bid quote with decresing size set up
    let bidPrice2 = 13700.
    let bidSize2 = 10
    let bidQuote2 = Bid {defaultQuote with time = tickTime; price = bidPrice2; size = bidSize2;}
    let correctIntensity2 = bidPrice2 - bestBidP
    let correctSize2 = bidSize2 - nodeBidSize    
    let (ordersAfterTick2, pNodeAfterTick2) = processTick orders marketBeforeTick nodeBeforeTick bidQuote2
    let order2 =  ordersAfterTick2.[0]
    //let orderNext2 =  ordersAfterTick2.[1]
    
    // Tests on Bid quote 1
    [<TestMethod>]        
    member this.processTick_with_Bid_Quote_correctly_modifies_PriceNode_bid() = 
        let size = (
            match bidQuote1 with
            | Bid q -> q.size
            | _ -> System.Int32.MinValue )
        Assert.AreEqual(pNodeAfterTick1.bid, size)

    [<TestMethod>]        
    member this.processTick_with_Bid_Quote_correctly_modifies_PriceNode_askSize_to_zero() = 
        Assert.AreEqual(pNodeAfterTick1.ask, 0)

    [<TestMethod>]        
    member this.processTick_with_Bid_quote_gererates_correct_intensity_of_Buy_order() = 
        let orderIntensity = (
            match order1 with
            | Buy quote -> quote.intensity
            | _ -> System.Double.MinValue) 
        Assert.AreEqual( orderIntensity , correctIntensity1)
        
    [<TestMethod>]        
    member this.processTick_with_increase_bid_size_Bid_Quote_gererates_Buy_order() = 
        let aBuyOrder = Buy defaultOrder 
        Assert.AreEqual(order1.GetType(), aBuyOrder.GetType())

    [<TestMethod>]        
    member this.processTick_with_increase_bid_size_Bid_Quote_gererates_correctly_sized_Buy_order() = 
        let orderSize = (
            match order1 with
            | Buy quote -> quote.size
            | _ -> System.Int32.MinValue) 
        Assert.AreEqual( orderSize , correctSize1)


// Tests on Bid quote 2
    [<TestMethod>]        
    member this.processTick_with_Bid_Quote2_correctly_modifies_PriceNode_bid() = 
        let size2 = (
            match bidQuote2 with
            | Bid q -> q.size
            | _ -> System.Int32.MinValue )
        Assert.AreEqual(pNodeAfterTick2.bid, size2)

    [<TestMethod>]        
    member this.processTick_with_Bid_quote2_gererates_correct_intensity_of_Buy_order() = 
        let orderIntensity2 = (
            match order2 with
            | CancelBuy quote -> quote.intensity
            | _ -> System.Double.MinValue) 
        Assert.AreEqual( orderIntensity2 , correctIntensity2, 1E-6)
        
    [<TestMethod>]        
    member this.processTick_with_decrease_bid_size_Bid_Quote2_gererates_Buy_order() = 
        let aBuyOrder2 = CancelBuy defaultOrder 
        Assert.AreEqual(order2.GetType(), aBuyOrder2.GetType())

    [<TestMethod>]        
    member this.processTick_with_decrease_bid_size_Bid_Quote2_gererates_correctly_sized_Buy_order() = 
        let orderSize2 = (
            match order2 with
            | CancelBuy quote -> quote.size
            | _ -> System.Int32.MinValue) 
        Assert.AreEqual( orderSize2 , correctSize2)



    