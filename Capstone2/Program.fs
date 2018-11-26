open Domain
open Auditing
open Operations
open System

[<EntryPoint>]
let main argv =

    let depositWithConsoleAudit = 
        auditedOperation "deposit" consoleAudit deposit

    let withdrawWithConsoleAudit = 
        auditedOperation "withdraw" consoleAudit withdraw

    let createUserAndAccount =
        printfn "Enter your name and press <Enter>:"
        let userName = 
            Console.ReadLine()
        
        let customer = 
            { 
                Name = userName; 
            }   
        
        let account = 
            { 
                Id = new System.Guid(); 
                Owner = customer; 
                Balance = 0M 
            }

        account

    let userAction =
        printfn "Enter desired operation (d_eposit/w_ithdraw/e_xit) and press <Enter>: "
        let operation =
            Console.ReadLine();
        operation
        
    let amount =
        printfn "Enter amount :"
        Decimal.Parse(Console.ReadLine())
        
    
    //printfn "Bank account management system.\n--------------------------\n\n"

    let mutable account = createUserAndAccount

    while true do
            let action = userAction
    
            if action = "e" then Environment.Exit 0

            let amountForOperation = amount            

            account <-
                if userAction = "d" then account |> depositWithConsoleAudit amountForOperation
                elif userAction = "w" then account |> withdrawWithConsoleAudit amountForOperation
                else account

    0