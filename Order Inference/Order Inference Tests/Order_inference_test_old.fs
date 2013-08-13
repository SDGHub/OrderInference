namespace OrderInference_UnitTest
//
//open System
//open Microsoft.VisualStudio.TestTools.UnitTesting
//open DataWrangler.Structures
//open OrderInference
//open OrderInference.InferenceFunc
//
//
//[<TestClass>]
//type OrderInfer_Type_Tests() = 
//   
//    // setup 1
//    let bidTick = new TickData(Price = 13700.0, Type = Type.Bid)
//    let askTick = new TickData(Price = 13710.0, Type = Type.Ask)
//    let mkt =  OrderInfer()     
//    let x = mkt.Initialize(bidTick, askTick)
//    
//    // setup 2
//    let mkt2 =  OrderInfer() 
//
//    [<TestMethod>]    
//    member x.On_Market_type_init_BestBid_property_is_set_correctly() = 
//        Assert.AreEqual(mkt.BestBid, 13700.0)
//
//    [<TestMethod>]  
//    member x.On_Market_type_init_BestAsk_property_is_set_correctly() = 
//        Assert.AreEqual(mkt.BestAsk, 13710.0)
//
//    [<TestMethod>]    
//    member x.On_Market_type_init_Initialized_property_is_set_correctly() = 
//        Assert.IsTrue(mkt.Initialized)
//        
//    [<TestMethod>]
//    [<ExpectedException(typeof<System.InvalidOperationException>)>]
//    member x.throws_exception_if_market_is_not_initialized() = 
//        mkt2.NewTick(bidTick)
//        
//[<TestClass>]     
//type InferFunc_Tests_tickToQuote() =  
//
//    // setup 1    
//    let tick = new TickData(TimeStamp = DateTime.MaxValue,  Price = 13700.0, Size = uint32 99, Type = Type.Bid)    
//    let bidQuote =  InferenceFunc.tickToQuote tick    
//    
//    // setup sad path    
//    let tickSad = new TickData(TimeStamp = DateTime.MaxValue,  Price = 13700.0, Size = uint32 99, Type = Type.Trade)   
//
//    [<TestMethod>]
//    member x.tickToQuote_correctly_sets_price() = 
//        let price  = (match bidQuote with  | Ask a -> a.price | Bid b -> b.price | Trade t -> t.price)
//        Assert.AreEqual(price, 13700.0)
////
//    [<TestMethod>]
//    member x.tickToQuote_correctly_sets_size() = 
//        let size  = (match bidQuote with  | Ask a -> a.askSize | Bid b -> b.bidSize | Trade t -> t.size)
//        Assert.AreEqual(size, 99)
//        
//    [<TestMethod>]
//    member x.tickToQuote_correctly_sets_DateTime() = 
//        let time  = (match bidQuote with  | Ask a -> a.time | Bid b -> b.time | Trade t -> t.time)
//        Assert.AreEqual(time, DateTime.MaxValue)
//        
//    [<TestMethod>]
//    [<ExpectedException(typeof<System.ArgumentException>)>]
//    member x.tickToQuote_throws_exception_if_TickData_not_Bid_or_Ask() =   
//        InferenceFunc.tickToQuote tickSad |> ignore
//
//[<TestClass>]     
//type InferFunc_Tests_initQuote() =  
//
//    // setup 1    
//    let tick = new TickData(TimeStamp = DateTime.MaxValue,  Price = 13700.0, Size = uint32 99, Type = Type.Bid)    
//    let quoteInit = InferenceFunc.initializeQuote tick    
//
//    [<TestMethod>]
//    member x.tickToQuote_sets_all_three_quote_to_same_values() = 
//        let quote1, quote2, quote3  = quoteInit
//        let allMatch = (quote1 = quote2) && (quote2 = quote3)
//        Assert.IsTrue(allMatch)  
//
//[<TestClass>]     
//type InferFunc_Tests_dropOldestAddCurrent() =  
//
//    // setup 1    
//    let tick = new TickData(TimeStamp = DateTime.MinValue,  Price = 1.0, Size = uint32 1, Type = Type.Bid)  
//    let tick2 = new TickData(TimeStamp = DateTime.MinValue.AddSeconds(1.0),  Price = 2.0, Size = uint32 2, Type = Type.Bid)  
//    let tick3 = new TickData(TimeStamp = DateTime.MinValue.AddSeconds(2.0),  Price = 3.0, Size = uint32 3, Type = Type.Bid)   
//
//    let quote1 =  InferenceFunc.tickToQuote tick
//    let quote2 =  InferenceFunc.tickToQuote tick2  
//    let quote3 = InferenceFunc.tickToQuote tick3  
//     
//    let quoteInit = InferenceFunc.initializeQuote tick      
//    let quoteAddTick2 = InferenceFunc.dropOldestAddCurrent quoteInit quote2  
//    let quoteAddTick3 = InferenceFunc.dropOldestAddCurrent quoteAddTick2  quote3  
//    
//    let fstQuote, sndQuote, thdQuote  = quoteInit
//    let fstQuote2, sndQuote2, thdQuote2  = quoteAddTick2
//    let fstQuote3, sndQuote3, thdQuote3  = quoteAddTick3
//    
//    [<TestMethod>]
//    member x.dropOldestAddCurrent_adds_new_value_to_first_in_tuple() = 
//        let matches = (fstQuote2 = quote2)
//        Assert.IsTrue(matches)  
//        
//    [<TestMethod>]
//    member x.dropOldestAddCurrent_shifts_values_in_first_to_second() = 
//        let matches =  (fstQuote = sndQuote2) && (fstQuote2 = sndQuote3)
//        Assert.IsTrue(matches) 
//
//    [<TestMethod>]
//    member x.dropOldestAddCurrent_shifts_values_in_second_to_third() = 
//        let matches =  (sndQuote = thdQuote2) && (sndQuote2 = thdQuote3)
//        Assert.IsTrue(matches)  
//
//[<TestClass>]         
//type InferFunc_defaultPriceNode() = 
//
//    [<TestMethod>]
//    member x.defaultPriceNode_returns_with_price_set_to_zero() =
//        let pNode = defaultPriceNode
//        Assert.AreEqual(0.0,pNode.price)
//
//    [<TestMethod>]
//    member x.defaultPriceNode_returns_with_bidSize_set_to_zero() =
//        let pNode = defaultPriceNode
//        Assert.AreEqual(0,pNode.bidSize)
//
//    [<TestMethod>]
//    member x.defaultPriceNode_returns_with_askSize_set_to_zero() =
//        let pNode = defaultPriceNode
//        Assert.AreEqual(0,pNode.askSize)
//
//type InferFunc_newPriceNode() = 
//
//    let p = 13700.0
//    let s = 15
//    let askQuote = Ask { time = DateTime(2013,7,1,0,0,0); price = p ; askSize = s}
//
//    [<TestMethod>]
//    member x.given_askQuote_newPriceNode_returns_priceNode_with_price_equal_askQuote_price() =
//        let pNode = newPriceNode askQuote
//        Assert.AreEqual(0.0,pNode.price)
//
//
//type InferFunc_Tests_PriceBook() = 
//
//    let p = 13700.0
//    let pNode = {price = p; bidSize = 0; askSize = 0 }
