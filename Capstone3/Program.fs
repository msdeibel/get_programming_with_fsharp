module Capstone3.Program

open System
open Capstone3.Domain
open Capstone3.Operations

let isValidCommand (command: char) = 
    let validCommands = ['d'; 'w'; 'x']
    if List.contains command validCommands then 
        true
    else
        false

let isStopCommand (command: char) =
    command = 'x'

let getAmount (command: char) = 
    match command with
    | 'd' -> ('d', 50M)
    | 'w' -> ('w', 25M)
    | _ -> ('x', 0M)

let getAmountConsole (command: char) =
    Console.Write "Enter the amount: "
    let amount = Decimal.Parse(Console.ReadLine());
    (command, amount)

let processCommand (account: Account) (command: char, amount: decimal) =
    match command with
    | 'd' -> deposit amount account
    | 'w' -> withdraw amount account
    | 'x' -> exit amount account
    | _ ->
        printfn "%c is an invalid command" command
        account

[<EntryPoint>]
let main _ =
    let name =
        Console.Write "Please enter your name: "
        Console.ReadLine()

    let withdrawWithAudit = auditAs "withdraw" Auditing.composedLogger withdraw
    let depositWithAudit = auditAs "deposit" Auditing.composedLogger deposit

    let openingAccount = { Owner = { Name = name }; Balance = 0M; AccountId = Guid.Empty } 

    let closingAccount =
        // Fill in the main loop here...
        //openingAccount

            //let commands = ['d'; 'w'; 'z'; 'f'; 'd'; 'x'; 'w']

            let consoleCommands = seq {
                while true do
                    Console.Write "(d)eposit, (w)ithdraw or e(x)it: "
                    yield Console.ReadKey().KeyChar }

            consoleCommands    
            |> Seq.filter isValidCommand
            |> Seq.takeWhile (not << isStopCommand)
            |> Seq.map getAmountConsole
            |> Seq.fold processCommand openingAccount

    Console.Clear()
    printfn "Closing Balance:\r\n %A" closingAccount
    Console.ReadKey() |> ignore

    0