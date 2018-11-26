module _154

open System

type Customer = {Age:int}

let where filter customers =
    seq {
        for customer in customers do
            if filter customer then
                yield customer 
    }

let customers = [{Age=21};{Age=35};{Age=36}]
let isOver35 customer = customer.Age >35

customers |> where isOver35
 
let printCustomerAge writer customer =
    if customer.Age < 13 then writer "Child"//Console.WriteLine("Child")
    else if customer.Age < 20 then writer "Teenager"//Console.WriteLine("Teenager")
    else writer "Adult"//Console.WriteLine("Adult")

printCustomerAge Console.WriteLine {Age=12}
printCustomerAge Console.WriteLine {Age=18}
printCustomerAge Console.WriteLine {Age=25}

let printCustomerAgeToConsole = printCustomerAge Console.WriteLine

printCustomerAgeToConsole {Age=12}
printCustomerAgeToConsole {Age=18}
printCustomerAgeToConsole {Age=25}

open System.IO

let writeToFile text = File.WriteAllText(@"D:\temp\output.txt", text)

let printCustomerAgeToFile = printCustomerAge writeToFile

printCustomerAgeToFile {Age = 21}

File.ReadAllText(@"D:\temp\output.txt") = "Adult"