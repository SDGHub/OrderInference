namespace OrderInference

open DataWrangler.Structures
open System
open System.Collections.Generic

type qteSide = 
| Bid = 1
| Ask = -1

type ordSide = 
| Buy = 1
| Sell = -1

type quote = { time:DateTime; price:float; size:int; qteSide:qteSide }
type trade = { time:DateTime; price:float; size:int; }
type order = { time:DateTime; price:float; size:int; ordSide:ordSide }

module Inferfunc =
    
    let tickToQuote (t:TickData) = 
        let side = 
            match t.Type with
            | Type.Ask -> qteSide.Ask
            | Type.Bid -> qteSide.Bid
            | _ -> raise (System.ArgumentException("TickData.Type must be Type.Bid or Type.Ask"))
        {time= t.TimeStamp; price = t.Price; size = int t.Size; qteSide=side}

    let initQuote (t:TickData) =
        let q = tickToQuote t 
        (q, q, q)

    let dropOldestAddCurrent (last, sndLast, _) current = (current, last, sndLast)

    let generateOrdersFromtrade = 0

type OrderInfer() = 

    let DefaultQuote : quote = {time = DateTime.MinValue; price = 0.0; size = 0; qteSide = qteSide.Bid}
    let mutable recentTicksBids = (DefaultQuote, DefaultQuote, DefaultQuote)
    let mutable recentTicksAsks = (DefaultQuote, DefaultQuote, DefaultQuote)
    let mutable bid = 0.0
    let mutable ask = 0.0
    let mutable initialized = false
    
    member this.BidQuotes with get() = recentTicksBids and private set(v) = recentTicksBids <- v
    member this.AskQuotes with get() = recentTicksAsks and private set(v) = recentTicksAsks <- v
    member this.BestBid with get() = bid and private set(v) = bid <- v
    member this.BestAsk with get() = ask and private set(v) = ask <- v
    member this.Initialized with get() = initialized and private set(v) = initialized <- v
    
    member this.Initialize (bidTick:TickData, askTick:TickData) = 
        this.BestBid <- bidTick.Price 
        this.BidQuotes <- Inferfunc.initQuote bidTick
        this.BestAsk <- askTick.Price
        this.AskQuotes <- Inferfunc.initQuote askTick
        this.Initialized <- true
        initialized

    member this.NewTick(tick : TickData) =
        if not initialized then raise (System.InvalidOperationException("Initialize() not called"))
        match tick.Type with 
        | Type.Ask -> ()
        | Type.Bid -> ()
        | Type.Trade -> ()
        | _ -> ()