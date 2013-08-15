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
        let (pNodeAfter, bidChg, askChg) = (
            match (market.isOpen, tick, pNodeBefore.bid, pNodeBefore.ask) with
            | true, Bid q, bid, ask -> {pNodeBefore with bid = q.size; ask = 0; updated = q.time}, bid - q.size, ask
            | true, Ask q, bid, ask -> {pNodeBefore with bid = 0; ask = q.size; updated = q.time}, bid, ask - q.size
            | true, Trade t, bid, ask -> defaultPriceNode,0,0
            | false, Bid q, bid, ask -> {pNodeBefore with bid = q.size; updated = q.time}, bid - q.size, 0
            | false, Ask q, bid, ask -> {pNodeBefore with ask = q.size; updated = q.time}, 0, ask - q.size
            | false, Trade t, bid, ask -> defaultPriceNode,0,0
            //| _ -> defaultPriceNode,0,0
        
        )
        (pNodeAfter, bidChg, askChg)
        
    let processTick (ords:Order list) (mkt:market) (pNode:priceNode) (tick:Tick) =         
        let newOrds = seq {
            match tick with
            | Bid q -> 
                let priceDiff = q.price - mkt.bestBid
                match (q.size - pNode.bid) with
                | diff when diff > 0 -> yield Buy { time = q.time; price = q.price; size = diff; intensity = priceDiff } 
                | diff when diff < 0 -> yield CancelBuy { time = q.time; price = q.price; size = diff; intensity = priceDiff } 
                | _ -> ()
                let priceDiffAsk = mkt.bestAsk - q.price
                match (pNode.ask, mkt.isOpen) with
                | diff, true when diff > 0 -> yield CancelSell { time = q.time; price = q.price; size = diff; intensity = priceDiffAsk }                
                | _ -> ()  
            | Ask q ->
                let priceDiff = mkt.bestAsk - q.price 
                match (q.size - pNode.ask) with
                | diff when diff > 0 -> yield Sell { time = q.time; price = q.price; size = diff; intensity = priceDiff } 
                | diff when diff < 0 -> yield CancelSell { time = q.time; price = q.price; size = diff; intensity = priceDiff } 
                | _ -> ()                  
                let priceDiffBid = mkt.bestAsk - q.price
                match (pNode.bid, mkt.isOpen) with
                | diff, true when diff > 0 -> yield CancelBuy { time = q.time; price = q.price; size = diff; intensity = priceDiffBid }                
                | _ -> ()  
            | Trade t -> 
                let bidDiff = pNode.bid - t.size
                let askDiff = pNode.ask - t.size
                () }
        let allOrders = newOrds |> Seq.toList |> List.append ords
        let newPNode = (
            match tick with
            | Bid q -> modifyPriceNode pNode (mkt.isOpen) tick            
            | Ask q -> modifyPriceNode pNode (mkt.isOpen) tick  
            | Trade t -> pNode )        
        (allOrders, newPNode) 
              

