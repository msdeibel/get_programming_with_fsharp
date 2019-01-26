type Customer =
    {
        Name: string
        Balance: int
    }

let handleCustomers customers =
    match customers with
    | [] -> failwith "No customers supplied!"
    | [customer] -> printfn "Single customer, name is %s" customer.Name
    | [first; second] -> printfn "Two customers, balance = %d" (first.Balance + second.Balance)
    | customers -> printfn "Customers supplied: %d" customers.Length


handleCustomers [{Balance = 10; Name= "Joe"}]
//handleCustomers []