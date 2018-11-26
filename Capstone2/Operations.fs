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