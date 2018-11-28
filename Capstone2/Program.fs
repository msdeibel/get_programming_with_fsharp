open Domain
open Auditing
open Operations
open System

[<EntryPoint>]
let main argv =

    let depositWithConsoleAudit = 
        deposit |> auditedOperation "deposit" consoleAudit

    let withdrawWithConsoleAudit = 
        withdraw |> auditedOperation "withdraw" consoleAudit

    let depositWithFileAudit = 
        deposit |> auditedOperation "deposit" fileSystemAudit

    let withdrawWithFileAudit = 
        withdraw |> auditedOperation "withdraw" fileSystemAudit

    let createUserAndAccount =
        let customer = 
            printfn "Enter your name and press <Enter>:"
            let customerName = Console.ReadLine()
            { 
                Name = customerName; 
            }   
        
        let account = 
            { 
                Id = System.Guid.NewGuid(); 
                Owner = customer; 
                Balance = 0M 
            }

        account

    let mutable account = createUserAndAccount

    while true do
        let action = 
            printfn ""
            printfn "Current balance is %M" account.Balance
            printfn "Enter desired operation (d_eposit/w_ithdraw/e_xit) and press <Enter>: "
            Console.ReadLine();
    
        if action = "e" then Environment.Exit 0

        let amountForOperation = 
            printfn "Enter amount :"
            Console.ReadLine() |> Decimal.Parse

        account <-
            if action = "d" then account |> depositWithConsoleAudit amountForOperation
            elif action = "w" then account |> withdrawWithConsoleAudit amountForOperation
            else account

    0