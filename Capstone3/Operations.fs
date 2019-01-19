module Capstone3.Operations

open System
open Capstone3.Domain

/// Withdraws an amount of an account (if there are sufficient funds)
let withdraw amount account =
    if amount > account.Balance then account
    else { account with Balance = account.Balance - amount }

/// Deposits an amount into an account
let deposit amount account =
    { account with Balance = account.Balance + amount }

let exit amount account =
     { account with Balance = account.Balance + 0M }

/// Runs some account operation such as withdraw or deposit with auditing.
let auditAs (operationName: string) audit operation amount account =
    //let audit = audit account.AccountId account.Owner.Name
    //audit (transa)
    let updatedAccount = operation amount account
    
    let accountIsUnchanged = (updatedAccount = account)

    let transaction = {Timestamp = DateTime.Now; Operation = operationName.[0]; Amount = amount; IsSuccess = not(accountIsUnchanged)}

    audit account.AccountId account.Owner.Name transaction
    updatedAccount

let processCommand (account: Account) (command: char, amount: decimal) =
    match command with
    | 'd' -> deposit amount account
    | 'w' -> withdraw amount account
    | 'x' -> exit amount account
    | _ ->
        printfn "%c is an invalid command" command
        account

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

    