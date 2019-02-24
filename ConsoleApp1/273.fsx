type CustomerId = CustomerId of string
//type Email = Email of string
//type Telephone = Telephone of string
//type Address = Address of string

type ContactDetails =
    |Address of string
    |Telephone of string
    |Email of string

//type Customer =
//    {
//        CustomerId: CustomerId
//        Email: Email
//        Telephone: Telephone
//        Address: Address
//    }

type Customer =
    {
        CustomerId: CustomerId
        PrimaryContact: ContactDetails
        SecondaryContact: ContactDetails option
    }


let  createCustomer customerId primaryContact secondaryContact =
    {
        CustomerId = customerId 
        PrimaryContact = primaryContact
        SecondaryContact = secondaryContact
    }

//createCustomer (CustomerId "C-123") (Email "nicky@myemail.com")  (Telephone "029 293 23") (Address "1 The Street")

//createCustomer (CustomerId "C-123") (Email "nicky@myemail.com")
//createCustomer (CustomerId "C-123") (Telephone "029 293 23")
//createCustomer (CustomerId "C-123") (Address "1 The Street")

createCustomer (CustomerId "C-123") (Email "nicky@myemail.com") (Some (Telephone "029 293 23"))
createCustomer (CustomerId "C-123") (Telephone "029 293 23") (Some (Address "1 The Street"))
createCustomer (CustomerId "C-123") (Address "1 The Street")

type GenuineCustomer = GenuineCustomer of Customer

let validateCustomer customer =
    match customer.PrimaryContact with
    | Email e when e.EndsWith "SuperCorp.com" -> Some (GenuineCustomer customer)
    | Address _ | Telephone _ -> Some (GenuineCustomer customer)
    | Email _ -> None

let sendWelcomeEmail (GenuineCustomer customer) =
    printfn "Hello, %A, and welcome to our site" customer.CustomerId