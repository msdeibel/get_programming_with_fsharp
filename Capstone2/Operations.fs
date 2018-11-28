module Operations

open Domain

let deposit (amount: decimal) (account:Account) : Account =
    let updatedAccount = {
        Id = account.Id; 
        Owner = account.Owner; 
        Balance = account.Balance + amount
    }

    updatedAccount

let withdraw (amount: decimal) (account:Account) : Account =
    if amount > account.Balance
    then account
    else
    {
        Id = account.Id; 
        Owner = account.Owner; 
        Balance = account.Balance - amount
    }

let auditedOperation operationName auditor operation amount account =
    let updatedAccount = operation (amount:decimal) (account:Account)

    let operationResult =
        if account.Balance = updatedAccount.Balance
        then "Operation rejected"
        else "Balance is now " + updatedAccount.Balance.ToString()

    let auditMessage =
        "Account " + account.Id.ToString() + ": Operation " + operationName + " with amount " + amount.ToString() + ". " + operationResult

    auditor account auditMessage

    updatedAccount