open System
open System.IO

type Customer = 
    {
        Name: string
    }

type Account =
    {
        Id: Guid
        Owner: Customer
        Balance: decimal
    }

let consoleAudit (account:Account) (message:String) =
    ignore(printfn "Account %s: %s", account.Id.ToString(),  message)

let fileSystemAudit (account:Account) (message:String) =
    let directoryName = 
        "D:\\temp\\cap2\\" + account.Owner.Name
    let fileName = 
        directoryName + "\\" + account.Id.ToString() + ".txt"

    if(not(Directory.Exists(directoryName)))
    then ignore(Directory.CreateDirectory(directoryName)) 
       
    let auditFileWriter = File.AppendText(fileName)
    auditFileWriter.WriteLine(message)
    ignore(auditFileWriter.Close())

let frank = {Name = "Frank"}

let franksAccount = { Id = Guid.NewGuid(); Owner = frank; Balance = 100M }

let deposit (amount: decimal) (account:Account) : Account =
    let updatedAccount = {
        Id = account.Id; 
        Owner = account.Owner; 
        Balance = account.Balance + amount
    }

//    let auditMessage =
//        "Operation: deposit of " + amount.ToString() + ". Balance is now " + updatedAccount.Balance.ToString()

    updatedAccount

let frankDeposits30 = franksAccount |> deposit 10M |> deposit 20M
let frankHas130 =
    frankDeposits30.Balance = 130M

let withdraw (amount: decimal) (account:Account) : Account =
    if amount > account.Balance
    then account
    else
    {
        Id = account.Id; 
        Owner = account.Owner; 
        Balance = account.Balance - amount
    }

let frankWithdraws30 = franksAccount |> withdraw 10M |> withdraw 20M
let frankHas70 =
    frankWithdraws30.Balance = 70M

let frankWithdraws90And20 = franksAccount |> withdraw 90M |> withdraw 20M
let frankHas10 =
    frankWithdraws90And20.Balance = 10M

consoleAudit franksAccount "Testing console audit"

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


let testAccount = { Id = Guid.NewGuid(); Owner = frank; Balance = 100M }

testAccount
|> deposit 100M
|> withdraw 50M

let withdrawWithConsoleAudit = 
    auditedOperation "withdraw" consoleAudit withdraw

let depositWithConsoleAudit = 
    auditedOperation "deposit" consoleAudit deposit

testAccount
|> depositWithConsoleAudit 100M
|> withdrawWithConsoleAudit 50M
|> withdrawWithConsoleAudit 200M

let withdrawWithFileAudit = 
    auditedOperation "withdraw" fileSystemAudit withdraw

let depositWithFileAudit = 
    auditedOperation "deposit" fileSystemAudit deposit

testAccount
|> depositWithFileAudit 100M
testAccount
|> withdrawWithFileAudit 50M
|> withdrawWithFileAudit 200M
