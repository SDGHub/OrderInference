namespace tests

open Quantix.OrderInference

module Test_Helper_Functions =

    let getBuyOrders         orders = orders |> List.filter(function | Buy _        -> true | _ -> false)      
    let getCancelBuyOrders   orders = orders |> List.filter(function | CancelBuy _  -> true | _ -> false) 
    let getSellOrders        orders = orders |> List.filter(function | Sell _       -> true | _ -> false)  
    let getCancelSellOrders  orders = orders |> List.filter(function | CancelSell _ -> true | _ -> false) 
    
    let hasBuyOrders         orders = (orders |> getBuyOrders).IsEmpty        |> not
    let hasCancelBuyOrders   orders = (orders |> getCancelBuyOrders).IsEmpty  |> not
    let hasSellOrders        orders = (orders |> getSellOrders).IsEmpty       |> not
    let hasCancelSellOrders  orders = (orders |> getCancelSellOrders).IsEmpty |> not
    
    let getFstBuyOrder orders        = if hasBuyOrders orders        then Some(( getBuyOrders orders        ).[0]) else None
    let getFstCancelBuyOrder orders  = if hasCancelBuyOrders orders  then Some(( getCancelBuyOrders orders  ).[0]) else None
    let getFstSellOrder orders       = if hasSellOrders orders       then Some(( getSellOrders orders       ).[0]) else None
    let getFstCancelSellOrder orders = if hasCancelSellOrders orders then Some(( getCancelSellOrders orders ).[0]) else None
    
    let getOrderSize order =
            match order with
            | None               -> System.Int32.MinValue
            | Some(Buy q)        -> q.size
            | Some(CancelBuy q)  -> q.size
            | Some(Sell q)       -> q.size
            | Some(CancelSell q) -> q.size    
    
    let getOrderPrice order =
            match order with
            | None               -> System.Double.MinValue
            | Some(Buy q)        -> q.price
            | Some(CancelBuy q)  -> q.price
            | Some(Sell q)       -> q.price
            | Some(CancelSell q) -> q.price
    
    let getOrderIntensity order =
            match order with
            | None               -> System.Double.MinValue
            | Some(Buy q)        -> q.intensity
            | Some(CancelBuy q)  -> q.intensity
            | Some(Sell q)       -> q.intensity
            | Some(CancelSell q) -> q.intensity
    
    let getOrderTime order =
            match order with
            | None               -> System.DateTime.MinValue
            | Some(Buy q)        -> q.time
            | Some(CancelBuy q)  -> q.time
            | Some(Sell q)       -> q.time
            | Some(CancelSell q) -> q.time


