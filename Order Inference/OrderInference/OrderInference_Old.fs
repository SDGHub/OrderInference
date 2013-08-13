namespace Order.Inference
//
//open DataWrangler.Structures
//open System
//open System.Collections.Generic
//
//// enums
//type qteSide = | Bid | Ask
//type ordSide = | Buy | Sell
//
//// record types
//type bidQuote = { time:DateTime; price:float; bidSize:int}
//type askQuote = { time:DateTime; price:float; askSize:int}
//type trade = { time:DateTime; price:float; size:int; }
//
//type Tick = 
//    | Bid of bidQuote
//    | Ask of askQuote
//    | Trade of trade
//
//type qte = { time:DateTime; price:float; size:int; qteSide:qteSide }
//type qoute = { time:DateTime; price:float; size:int; qteSide:qteSide }
//type order = { time:DateTime; price:float; size:int; ordSide:ordSide }
//type priceNode = { price:float; bidSize:int; askSize:int; }
//
//
//    
//module InferenceFunc =
//    
//    let tickToQuote (t:TickData) = 
//         (
//            match t.Type with
//            | Type.Ask ->   Ask {time= t.TimeStamp; price = t.Price; askSize = int t.Size}
//            | Type.Bid ->   Bid {time= t.TimeStamp; price = t.Price; bidSize = int t.Size} 
//            | Type.Trade -> Trade {time= t.TimeStamp; price = t.Price; size = int t.Size}
//         )
//
//
//    let initializeQuote (t:TickData) = 
//        let q = tickToQuote t 
//        (q, q, q)
//
//    let dropOldestAddCurrent (last, sndLast, _) current = (current, last, sndLast)
//
//    let defaultPriceNode = { price = 0.0; bidSize = 0; askSize = 0}
//
//    let newPriceNode (tick:Tick) = 
//        match tick with
//        | Ask tick   -> {defaultPriceNode with price = tick.price; askSize = tick.askSize }
//        | Bid tick   -> {defaultPriceNode with price = tick.price; bidSize = tick.bidSize }
//        | Trade tick -> {defaultPriceNode with price = tick.price }
//
//    let getOrderBook (book : Map<float, priceNode>) = 
//        let update = book
//        update
//
//
//
//type OrderInfer() = 
//
//    let DefaultQuote : qoute = {time = DateTime.MinValue; price = 0.0; size = 0; qteSide = qteSide.Bid}
//    let mutable recentTicksBids = (DefaultQuote, DefaultQuote, DefaultQuote)
//    let mutable recentTicksAsks = (DefaultQuote, DefaultQuote, DefaultQuote)
//    let mutable bid = 0.0
//    let mutable ask = 0.0
//    let mutable initialized = false
//    
//    member this.BidQuotes with get() = recentTicksBids and private set(v) = recentTicksBids <- v
//    member this.AskQuotes with get() = recentTicksAsks and private set(v) = recentTicksAsks <- v
//    member this.BestBid with get() = bid and private set(v) = bid <- v
//    member this.BestAsk with get() = ask and private set(v) = ask <- v
//    member this.Initialized with get() = initialized and private set(v) = initialized <- v
//    
//    member this.Initialize (bidTick:TickData, askTick:TickData) = 
//        this.BestBid <- bidTick.Price 
//        //this.BidQuotes <- InferenceFunc.initializeQuote bidTick
//        this.BestAsk <- askTick.Price
//        //this.AskQuotes <- InferenceFunc.initializeQuote askTick
//        this.Initialized <- true
//        initialized
//
//    member this.NewTick(tick : TickData) =
//        if not initialized then raise (System.InvalidOperationException("Initialize() not called"))
//        match tick.Type with 
//        | Type.Ask -> ()
//        | Type.Bid -> ()
//        | Type.Trade -> ()
//        | _ -> ()