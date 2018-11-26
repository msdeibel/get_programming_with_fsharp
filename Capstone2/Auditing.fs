module Auditing

open System
open System.IO
open Domain

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

