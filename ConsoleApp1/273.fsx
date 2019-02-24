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
        Contact: ContactDetails
    }


let  createCustomer customerId contact =
    {
        CustomerId = customerId 
        Contact = contact
    }

//createCustomer (CustomerId "C-123") (Email "nicky@myemail.com")  (Telephone "029 293 23") (Address "1 The Street")

createCustomer (CustomerId "C-123") (Email "nicky@myemail.com")
createCustomer (CustomerId "C-123") (Telephone "029 293 23")
createCustomer (CustomerId "C-123") (Address "1 The Street")

