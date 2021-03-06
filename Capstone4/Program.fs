module Capstone4.Program

open System
open Capstone4.Domain
open Capstone4.Operations

let withdrawWithAudit = auditAs "withdraw" Auditing.composedLogger withdraw
let depositWithAudit = auditAs "deposit" Auditing.composedLogger deposit

let loadAccountOptional = Option.map Operations.loadAccount
let tryLoadAccountFromDisk = FileRepository.tryFindTransactionsOnDisk >> loadAccountOptional

[<AutoOpen>]
module CommandParsing =
    //let isValidCommand cmd = [ 'd'; 'w'; 'x' ] |> List.choose tryParseCommand
    let isStopCommand = (=) Command.Exit

[<AutoOpen>]
module UserInput =
    let commands = seq {
        while true do
            Console.Write "(d)eposit, (w)ithdraw or e(x)it: "
            yield Console.ReadKey().KeyChar
            Console.WriteLine() }

    let tryGetAmount command = 
        Console.WriteLine()
        Console.Write "Enter Amount: "
        let amount = Console.ReadLine() |> Decimal.TryParse
        match amount with
        | true, amount -> Some(command, amount)
        | false, _ -> None

[<EntryPoint>]
let main _ =
    let openingAccount =
        Console.Write "Please enter your name: "
        let owner  = Console.ReadLine()
        //Console.ReadLine() |> tryLoadAccountFromDisk

        match (tryLoadAccountFromDisk owner) with
        | Some account -> account
        | None ->
            InCredit (CreditAccount { 
                                        Balance = 0M
                                        AccountId = Guid.NewGuid()
                                        Owner = { Name = owner}
            })
    
    printfn "Current balance is £%M" (openingAccount.GetField(fun a -> a.Balance))

    let processCommand account (command, amount) =
        printfn ""
        let account =
            match command with
            | BankOperation.Deposit -> account |> depositWithAudit amount
            | BankOperation.Withdraw -> account |> withdrawWithAudit amount
        printfn "Current balance is £%M" account.Balance
        account

    let closingAccount =
        commands
        |> Seq.choose Commands.tryParseCommand
        |> Seq.takeWhile ((<>) Command.Exit)
        |> Seq.choose Commands.tryGetBankOperation
        |> Seq.choose tryGetAmount
        |> Seq.fold processCommand openingAccount
    
    printfn ""
    printfn "Closing Balance:\r\n %A" closingAccount
    Console.ReadKey() |> ignore

    0