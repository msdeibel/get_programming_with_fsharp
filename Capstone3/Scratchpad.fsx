#load "Domain.fs"
#load "Operations.fs"

open Capstone3.Operations
open Capstone3.Domain
open System
open System.Diagnostics

let isValidCommand (command: char) = 
    let validCommands = ['d'; 'w'; 'x']
    if List.contains command validCommands then 
        true
    else
        false

let dOk = isValidCommand 'd'
let wOk = isValidCommand 'w'
let xOk = isValidCommand 'x'
let yNotOk = not (isValidCommand 'z')


let isStopCommand (command: char) =
    command = 'x'

let xStop = isStopCommand 'x'
let uNotStop = not (isStopCommand 'u')

let getAmount (command: char) = 
    match command with
    | 'd' -> ('d', 50M)
    | 'w' -> ('w', 25M)
    | _ -> ('x', 0M)

let dWith50 = getAmount 'd' = ('d', 50M)
let wWith25 = getAmount 'w' = ('w', 25M)
let xWith0 = getAmount 'x' = ('x', 0M)
let otherXWith0 = getAmount 'u' = ('x', 0M)

let processCommand (account: Account) (command: char, amount: decimal) =
    match command with
    | 'd' -> deposit amount account
    | 'w' -> withdraw amount account
    | 'x' -> exit amount account
    | _ ->
        printfn "%c is an invalid command" command
        account
    
let openingAccount = 
    { Owner = {Name = "Isaac"}; Balance = 0M; AccountId = Guid.NewGuid()}

let account = 
    let commands = ['d'; 'w'; 'z'; 'f'; 'd'; 'x'; 'w']

    commands    
    |> Seq.filter isValidCommand
    |> Seq.takeWhile (not << isStopCommand)
    |> Seq.map getAmount
    |> Seq.fold processCommand openingAccount





let loadAccount owner accountId (transactions: Transaction List) =

    let openingAccount = { Owner = owner; Balance = 0M; AccountId = accountId } 
    let sortedTransactions = transactions |> List.sortBy (fun t -> t.Timestamp)
    
    Seq.fold
        (fun account transaction -> 
            let newAccount = 
                processCommand account (transaction.Operation, transaction.Amount)
            newAccount)
        openingAccount
        sortedTransactions            
                    
let testCustomer = { Name = "Tom" }
let testAccountId = Guid.Empty
let testTransactions = 
    [
        {Amount = 100M; Operation = 'd'; Timestamp = DateTime.Now; IsSuccess = true};
        {Amount = 50M; Operation = 'd'; Timestamp = DateTime.Now; IsSuccess = true};
        {Amount = 25M; Operation = 'w'; Timestamp = DateTime.Now; IsSuccess = true};
        {Amount = 150M; Operation = 'w'; Timestamp = DateTime.Now; IsSuccess = false};
    ]

loadAccount testCustomer testAccountId testTransactions