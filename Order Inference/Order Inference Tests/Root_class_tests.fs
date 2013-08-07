namespace OrderInference_UnitTest

open System
open Microsoft.VisualStudio.TestTools.UnitTesting
open DataWrangler.Structures
open OrderInference


[<TestClass>]
type OrderInfer_Type_Tests() = 
   
    // setup 1
    let bidTick = new TickData(Price = 13700.0, Type = Type.Bid)
    let askTick = new TickData(Price = 13710.0, Type = Type.Ask)
    let mkt =  OrderInfer()     
    let x = mkt.Initialize(bidTick, askTick)
    
    // setup 2
    let mkt2 =  OrderInfer() 

    [<TestMethod>]    
    member x.On_Market_type_init_BestBid_property_is_set_correctly() = 
        Assert.AreEqual(mkt.BestBid, 13700.0)

    [<TestMethod>]  
    member x.On_Market_type_init_BestAsk_property_is_set_correctly() = 
        Assert.AreEqual(mkt.BestAsk, 13710.0)

    [<TestMethod>]    
    member x.On_Market_type_init_Initialized_property_is_set_correctly() = 
        Assert.IsTrue(mkt.Initialized)
        
    [<TestMethod>]
    [<ExpectedException(typeof<System.InvalidOperationException>)>]
    member x.throws_exception_if_market_is_not_initialized() = 
        mkt2.NewTick(bidTick)
        
[<TestClass>]     
type Inferfunc_Tests_tickToQuote() =  

    // setup 1    
    let tick = new TickData(TimeStamp = DateTime.MaxValue,  Price = 13700.0, Size = uint32 99, Type = Type.Bid)    
    let quote = Inferfunc.tickToQuote tick    
    
    // setup sad path    
    let tickSad = new TickData(TimeStamp = DateTime.MaxValue,  Price = 13700.0, Size = uint32 99, Type = Type.Trade)   

    [<TestMethod>]
    member x.tickToQuote_correctly_sets_price() = 
        Assert.AreEqual(quote.price, 13700.0)

    [<TestMethod>]
    member x.tickToQuote_correctly_sets_size() = 
        Assert.AreEqual(quote.size, 99)
        
    [<TestMethod>]
    member x.tickToQuote_correctly_sets_DateTime() = 
        Assert.AreEqual(quote.time, DateTime.MaxValue)
        
    [<TestMethod>]
    [<ExpectedException(typeof<System.ArgumentException>)>]
    member x.tickToQuote_throws_exception_if_TickData_not_Bid_or_Ask() =   
        Inferfunc.tickToQuote tickSad |> ignore

[<TestClass>]     
type Inferfunc_Tests_initQuote() =  

    // setup 1    
    let tick = new TickData(TimeStamp = DateTime.MaxValue,  Price = 13700.0, Size = uint32 99, Type = Type.Bid)    
    let quoteInit = Inferfunc.initQuote tick    

    [<TestMethod>]
    member x.tickToQuote_sets_all_three_quote_to_same_values() = 
        let quote1, quote2, quote3  = quoteInit
        let allMatch = (quote1 = quote2) && (quote2 = quote3)
        Assert.IsTrue(allMatch)  

[<TestClass>]     
type Inferfunc_Tests_dropOldestAddCurrent() =  

    // setup 1    
    let tick = new TickData(TimeStamp = DateTime.MinValue,  Price = 1.0, Size = uint32 1, Type = Type.Bid)  
    let tick2 = new TickData(TimeStamp = DateTime.MinValue.AddSeconds(1.0),  Price = 2.0, Size = uint32 2, Type = Type.Bid)  
    let tick3 = new TickData(TimeStamp = DateTime.MinValue.AddSeconds(2.0),  Price = 3.0, Size = uint32 3, Type = Type.Bid)   

    let quote1 =  Inferfunc.tickToQuote tick
    let quote2 =  Inferfunc.tickToQuote tick2  
    let quote3 = Inferfunc.tickToQuote tick3  
     
    let quoteInit = Inferfunc.initQuote tick      
    let quoteAddTick2 = Inferfunc.dropOldestAddCurrent quoteInit quote2  
    let quoteAddTick3 = Inferfunc.dropOldestAddCurrent quoteAddTick2  quote3  
    
    let fstQuote, sndQuote, thdQuote  = quoteInit
    let fstQuote2, sndQuote2, thdQuote2  = quoteAddTick2
    let fstQuote3, sndQuote3, thdQuote3  = quoteAddTick3
    
    [<TestMethod>]
    member x.dropOldestAddCurrent_adds_new_value_to_first_in_tuple() = 
        let matches = (fstQuote2 = quote2)
        Assert.IsTrue(matches)  
        
    [<TestMethod>]
    member x.dropOldestAddCurrent_shifts_values_in_first_to_second() = 
        let matches =  (fstQuote = sndQuote2) && (fstQuote2 = sndQuote3)
        Assert.IsTrue(matches) 

    [<TestMethod>]
    member x.dropOldestAddCurrent_shifts_values_in_second_to_third() = 
        let matches =  (sndQuote = thdQuote2) && (sndQuote2 = thdQuote3)
        Assert.IsTrue(matches)  