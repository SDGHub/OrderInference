namespace Quantix

open System
module OrderInference = 
    
    type quote     = { time:DateTime; price:float; size:int; depth:int }
    type trade     = { time:DateTime; price:float; size:int; }
    type order     = { time:DateTime; price:float; size:int; intensity:float }
    type priceNode = { price:float; bid:int; ask:int; updated:DateTime; }
    type market    = { bestBid:float; bestAsk:float; last:float; updated:DateTime; isOpen:bool; }
    
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
    let defaultPriceNode   = { price = 0.; bid = 0; ask = 0; updated = DateTime.MinValue; }
    let defaultMarket      = { bestBid = 0.; bestAsk = 0.; last = 0.; updated = DateTime.MinValue; isOpen = true}
    let defaultOrders      = List.empty<Order>

    let modifyMarket market tick = 
        match tick with
        | Bid quote   -> { market with bestBid = quote.price; updated = quote.time} 
        | Ask quote   -> { market with bestAsk = quote.price; updated = quote.time}  
        | Trade trade -> { market with last = trade.price; updated = trade.time}

    let modifyPriceNode pNode (mktIsOpen:bool) tick  =
        match (tick, mktIsOpen)  with
        | Bid quote, true  -> { pNode with bid = quote.size; ask = 0; updated = quote.time }
        | Bid quote, false -> { pNode with bid = quote.size; updated = quote.time }
        | Ask quote, true  -> { pNode with bid = 0; ask = quote.size; updated = quote.time }
        | Ask quote, false -> { pNode with ask = quote.size; updated = quote.time }
        | Trade trade, _   -> { pNode with updated = trade.time }
    
    let priceNodeAfterTick pNodeBefore market tick = 
        let pNodeAfter, buySize, sellSize = (
            match (market.isOpen, tick, pNodeBefore.bid, pNodeBefore.ask) with
            | true,  Bid q,   bid, ask -> { pNodeBefore with bid = q.size; ask = 0; updated = q.time }, q.size - bid, -ask
            | true,  Ask q,   bid, ask -> { pNodeBefore with bid = 0; ask = q.size; updated = q.time }, -bid, q.size - ask
            | true,  Trade t, bid, ask -> { pNodeBefore with bid = max 0 (bid - t.size); ask = max 0 (ask - t.size); updated = t.time }, t.size - bid, t.size - ask
            | false, Bid q,   bid, ask -> { pNodeBefore with bid = q.size; updated = q.time }, q.size - bid, 0
            | false, Ask q,   bid, ask -> { pNodeBefore with ask = q.size; updated = q.time }, 0, q.size - ask
            | false, Trade t, bid, ask ->   pNodeBefore, 0, 0        
        )
        pNodeAfter, buySize, sellSize

    let processTick (orders:Order list) (market:market) (pNode:priceNode) (tick:Tick) =   
        let (pNodeAfter, buySize, sellSize) = priceNodeAfterTick pNode market tick
        let priceDiffBid = pNodeAfter.price - market.bestBid
        let priceDiffAsk = market.bestAsk - pNodeAfter.price 
        let newOrds = seq {
            match buySize with
            | size when size > 0 -> yield Buy { time = pNodeAfter.updated; price = pNodeAfter.price; size = size; intensity = priceDiffBid }
            | size when size < 0 -> yield CancelBuy { time = pNodeAfter.updated; price = pNodeAfter.price; size = size; intensity = priceDiffBid }
            | _ -> ()
            match sellSize with
            | size when size > 0 -> yield Sell { time = pNodeAfter.updated; price = pNodeAfter.price; size = size; intensity = priceDiffAsk }
            | size when size < 0 -> yield CancelSell { time = pNodeAfter.updated; price = pNodeAfter.price; size = size; intensity = priceDiffAsk }
            | _ -> ()
            } 
        let allOrders = newOrds |> Seq.toList |> List.append orders
        allOrders, pNodeAfter 
                       
              

