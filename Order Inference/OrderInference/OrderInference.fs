namespace Quantix

open System
module OrderInference = 
    
    type trade     = { time:DateTime; price:float; size:int; }
    type quote     = { time:DateTime; price:float; size:int; depth:int }
    type order     = { time:DateTime; price:float; size:int; intensity:float }
    type priceNode = { time:DateTime; price:float; bid:int; ask:int; }
    type market    = { time:DateTime; last :float; bestBid:float; bestAsk:float; isOpen:bool; }
    
    type Tick = 
        | Bid   of quote
        | Ask   of quote
        | Trade of trade

    type Order = 
        | Buy        of order
        | CancelBuy  of order
        | Sell       of order
        | CancelSell of order
        
    let defaultTrade:trade = { time = DateTime.MinValue; price = 0.; size = 0; }
    let defaultQuote       = { time = DateTime.MinValue; price = 0.; size = 0; depth = 0 }
    let defaultOrder       = { time = DateTime.MinValue; price = 0.; size = 0; intensity = 0. }
    let defaultPriceNode   = { price = 0.; bid = 0; ask = 0; time = DateTime.MinValue; }
    let defaultMarket      = { bestBid = 0.; bestAsk = 0.; last = 0.; time = DateTime.MinValue; isOpen = true}
    let defaultOrders      = List.empty<Order>

    let modifyMarket market tick = 
        match tick with
        | Bid quote   -> { market with bestBid = quote.price; time = quote.time} 
        | Ask quote   -> { market with bestAsk = quote.price; time = quote.time}  
        | Trade trade -> { market with last = trade.price; time = trade.time}
            
    let priceNodeAfterTick pNodeBefore market tick = 
        let pNodeAfter, buySize, sellSize = (
            match (market.isOpen, tick, pNodeBefore.bid, pNodeBefore.ask) with
            | true,  Bid q,   bid, ask -> { pNodeBefore with bid = q.size; ask = 0; time = q.time }, q.size - bid, -ask
            | true,  Ask q,   bid, ask -> { pNodeBefore with bid = 0; ask = q.size; time = q.time }, -bid, q.size - ask
            | true,  Trade t, bid, ask -> { pNodeBefore with bid = max 0 (bid - t.size); ask = max 0 (ask - t.size); time = t.time }, max 0 (t.size - bid), max 0 (t.size - ask)
            | false, Bid q,   bid, ask -> { pNodeBefore with bid = q.size; time = q.time }, q.size - bid, 0
            | false, Ask q,   bid, ask -> { pNodeBefore with ask = q.size; time = q.time }, 0, q.size - ask
            | false, Trade t, bid, ask ->   pNodeBefore, 0, 0        
        )
        pNodeAfter, buySize, sellSize

    let processTick (orders:Order list) (m:market) (p:priceNode) (t:Tick) =   
        let (pAfter, buysize, sellSize) = priceNodeAfterTick p m t
        let orderBase = {defaultOrder with time = pAfter.time; price = p.price} 
        let newOrds = seq {
            match buysize with
            | size when size > 0 -> yield Buy { orderBase with size = size; intensity = p.price - m.bestBid }
            | size when size < 0 -> yield CancelBuy { orderBase with size = size; intensity = p.price - m.bestBid }
            | _ -> ()
            match sellSize with
            | size when size > 0 -> yield Sell { orderBase with size = size; intensity = m.bestAsk - p.price }
            | size when size < 0 -> yield CancelSell { orderBase with size = size; intensity = m.bestAsk - p.price }
            | _ -> ()
            } 
        let allOrders = newOrds |> Seq.toList |> List.append orders
        allOrders, pAfter 
                       
              

