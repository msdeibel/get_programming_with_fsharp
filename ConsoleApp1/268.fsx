let tryLoadCustomer customerId =
    match customerId with
    | customerId 
        when customerId >= 2 && customerId <=7 -> Some (sprintf "Customer %i" customerId)
    | _ -> None

let customers = [0..10]

List.choose tryLoadCustomer customers