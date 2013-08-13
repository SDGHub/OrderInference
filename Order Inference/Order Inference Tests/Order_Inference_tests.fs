namespace Order_Inference_tests

open System
open Microsoft.VisualStudio.TestTools.UnitTesting
open Quantix.OrderInference
//open DataWrangler.Structures

[<TestClass>]
type Order_Inference_Default_Tick_Data_Structure_Tests() = 

    // bid record test set up
    let bidTime = (DateTime.MinValue.AddTicks(int64 1))
    let bidPrice = 13700.0
    let bidSize = 10
    let bidLevel =  1
    let bidQuote = Bid {defaultQuote with time = bidTime; price = bidPrice; size = bidSize; depth = bidLevel}

    // ask record test set up
    let askTime = (DateTime.MinValue.AddTicks(int64 2))
    let askPrice = 13710.0
    let askSize = 20
    let askLevel =  2
    let askQuote = Ask {defaultQuote with time = askTime; price = askPrice; size = askSize; depth = askLevel}

    // trade record test set up
    let tradeTime = (DateTime.MinValue.AddTicks(int64 3))
    let tradePrice = 13720.0
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

    // Buy order record test set up
    let buyTime = (DateTime.MinValue.AddTicks(int64 1))
    let buyPrice = 13700.0
    let buySize = 10
    let buyLevel =  5.0
    let buyQuote = Buy {defaultOrder with time = buyTime; price = buyPrice; size = buySize; level = buyLevel}

    // Sell record test set up
    let sellTime = (DateTime.MinValue.AddTicks(int64 2))
    let sellPrice = 13710.0
    let sellSize = 20
    let sellLevel =  10.0
    let sellQuote = Sell {defaultOrder with time = sellTime; price = sellPrice; size = sellSize; level = sellLevel}
    
    [<TestMethod>]        
    member this.buy_Tick_matches_Tick_DUs_buy_choice() = 
        let isbuyType = (
            match buyQuote with
            | Buy _ -> true
            | _ -> false )
        Assert.IsTrue(isbuyType)

    [<TestMethod>]        
    member this.buy_Tick_matches_buy_Time() = 
        let time = (
            match buyQuote with
            | Buy q -> q.time
            | _ -> System.DateTime.MaxValue)
        Assert.AreEqual(time, buyTime)

    [<TestMethod>]        
    member this.buy_Tick_matches_buy_price() = 
        let price = (
            match buyQuote with
            | Buy q -> q.price
            | _ -> System.Double.MinValue )
        Assert.AreEqual(price, buyPrice)

    [<TestMethod>]        
    member this.buy_Tick_matches_buy_size() = 
        let size = (
            match buyQuote with
            | Buy q -> q.size
            | _ -> System.Int32.MaxValue )
        Assert.AreEqual(size, buySize)        

    [<TestMethod>]        
    member this.buy_Tick_matches_buy_level() = 
        let level = (
            match buyQuote with
            | Buy q -> q.level
            | _ -> System.Double.MaxValue )
        Assert.AreEqual(level, buyLevel)

    [<TestMethod>]        
    member this.sell_Tick_matches_Tick_DUs_sell_choice() = 
        let isSellType = (
            match sellQuote with
            | Sell _ -> true
            | _ -> false )
        Assert.IsTrue(isSellType)

    [<TestMethod>]        
    member this.sell_Tick_matches_sell_Time() = 
        let time = (
            match sellQuote with
            | Sell q -> q.time
            | _ -> System.DateTime.MaxValue)
        Assert.AreEqual(time, sellTime)

    [<TestMethod>]        
    member this.sell_Tick_matches_sell_price() = 
        let price = (
            match sellQuote with
            | Sell q -> q.price
            | _ -> System.Double.MinValue )
        Assert.AreEqual(price, sellPrice)

    [<TestMethod>]        
    member this.sell_Tick_matches_sell_size() = 
        let size = (
            match sellQuote with
            | Sell q -> q.size
            | _ -> System.Int32.MaxValue )
        Assert.AreEqual(size, sellSize)        

    [<TestMethod>]        
    member this.sell_Tick_matches_sell_level() = 
        let level = (
            match sellQuote with
            | Sell q -> q.level
            | _ -> System.Double.MaxValue )
        Assert.AreEqual(level, sellLevel)
        
[<TestClass>]
type Order_Inference_Default_PriceNode_Data_Structure_Tests() = 

    // price record test set up
    let updateTime = (DateTime.MinValue.AddTicks(int64 1))
    let price = 13700.0
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

    // price record test set up
    let updateTime = (DateTime.MinValue.AddTicks(int64 1))
    let bestBidP = 13700.0
    let bestAskP = 13710.0
    let lastP =  13720.0
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
type Order_Inference_modifyMarket_with_Bid_quote_Tests() = 

    // price record test set up
    let updateTime = (DateTime.MinValue.AddTicks(int64 1))
    let bestBidP = 13700.0
    let bestAskP = 13710.0
    let lastP =  13720.0
    let marketBeforeBidQuote = { bestBid = bestBidP; bestAsk = bestAskP; last = lastP; updated = updateTime; }

     // bid record test set up
    let bidTime = (DateTime.MinValue.AddTicks(int64 2))
    let bidPrice = 13690.0
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
    let bestBidP = 13700.0
    let bestAskP = 13710.0
    let lastP =  13720.0
    let marketBeforeAskQuote = { bestBid = bestBidP; bestAsk = bestAskP; last = lastP; updated = updateTime; }

     // ask record test set up
    let askTime = (DateTime.MinValue.AddTicks(int64 2))
    let askPrice = 13720.0
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
    let bestBidP = 13700.0
    let bestAskP = 13710.0
    let lastP =  13700.0
    let marketBeforeTrade = { bestBid = bestBidP; bestAsk = bestAskP; last = lastP; updated = updateTime; }

     // ask record test set up
    let tradeTime = (DateTime.MinValue.AddTicks(int64 2))
    let tradePrice = 13720.0
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
    let nodePrice = 13700.0
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
    let nodePrice = 13700.0
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
    let nodePrice = 13700.0
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