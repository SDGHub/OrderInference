namespace Quantix

open System

module OrderInference = 
    
    type quote = { time:DateTime; price:float; size:int; depth:int }
    type trade = { time:DateTime; price:float; size:int; }
    type order = { time:DateTime; price:float; size:int; level:float }
    type priceNode = { price:float; bid:int; ask:int; updated:DateTime; }
    type market = { bestBid:float; bestAsk:float; last:float; updated:DateTime; }
    
    type Tick = 
        | Bid of quote
        | Ask of quote
        | Trade of trade

    type Order = 
        | Buy of order
        | Sell of order
        
    let defaultQuote:quote = { time = DateTime.MinValue; price = 0.0; size = 0; depth = 0 }
    let defaultTrade:trade = { time = DateTime.MinValue; price = 0.0; size = 0; }
    let defaultOrder       = { time = DateTime.MinValue; price = 0.0; size = 0; level = 0.0 }
    let defaultPriceNode   = { price = 0.0; bid = 0; ask = 0; updated = DateTime.MinValue; }
    let defaultMarket      = { bestBid = 0.0; bestAsk = 0.0; last = 0.0; updated = DateTime.MinValue; }

    let modifyMarket market tick = 
        match tick with
        | Bid quote   -> { market with bestBid = quote.price; updated = quote.time} 
        | Ask quote   -> { market with bestAsk = quote.price; updated = quote.time}  
        | Trade trade -> { market with last = trade.price; updated = trade.time}

    let modifyPriceNode pNode tick =
        match tick with
        | Bid quote   ->  { pNode with bid = quote.size; updated = quote.time }
        | Ask quote   ->  { pNode with ask = quote.size; updated = quote.time }
        | Trade trade ->  { pNode with updated = trade.time }

        
    let evalutePriceNode pNode tick =
        let diff = (
            match tick with
            | Bid quote   ->  pNode.bid - quote.size 
            | Ask quote   ->  pNode.ask - quote.size 
            | Trade trade ->  0  )
        ()

