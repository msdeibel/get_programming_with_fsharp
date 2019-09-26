namespace Capstone4.Domain

open System

type Customer = { Name : string }
type Account = { AccountId : Guid; Owner : Customer; Balance : decimal }
type Transaction = { Timestamp : DateTime; Operation : string; Amount : decimal; Accepted : bool }
type BankOperation = Deposit | Withdraw
type Command = AccountCommand of BankOperation | Exit


module Transactions =
    /// Serializes a transaction
    let serialize transaction =
        sprintf "%O***%s***%M***%b" transaction.Timestamp transaction.Operation transaction.Amount transaction.Accepted
    
    /// Deserializes a transaction
    let deserialize (fileContents:string) =
        let parts = fileContents.Split([|"***"|], StringSplitOptions.None)
        { Timestamp = DateTime.Parse parts.[0]
          Operation = parts.[1]
          Amount = Decimal.Parse parts.[2]
          Accepted = Boolean.Parse parts.[3] }

module Commands =
    let tryParseCommand (c:char) =
        match c with
        | 'd' -> Some (AccountCommand Deposit)
        | 'w' -> Some (AccountCommand Withdraw)
        | 'x' -> Some Command.Exit
        | _ -> None
    
    let tryGetBankOperation cmd =
        match cmd with
        | Exit -> None
        | AccountCommand op -> Some op