type Order = { OrderId: int }
type Customer = { CustomerId: int; Orders : Order list; Town: string }

let orders1 = [{OrderId = 1};{OrderId = 2};{OrderId = 3};{OrderId = 4}]
let orders2 = [{OrderId = 5};{OrderId = 6}]
let orders3 = [{OrderId = 7};{OrderId = 8};{OrderId = 9}]

let customers : Customer list = 
    [
        {CustomerId = 1; Orders = orders1; Town = "Kassel"};
        {CustomerId = 2; Orders = orders2; Town = "Frankfurt"};
        {CustomerId = 3; Orders = orders3; Town = "Wiesbaden"}
    ]

let orders : Order list = customers |> List.collect(fun c -> c.Orders)