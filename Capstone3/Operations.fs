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



    