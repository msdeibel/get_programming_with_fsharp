#load "Domain.fs"
#load "Operations.fs"

open Capstone4.Operations
open Capstone4.Domain
open System

type Command =
    | Deposit
    | Withdraw
    | Exit
    
let tryParseCommand (c:char) =
    match c with
    | 'd' -> Some Command.Deposit
    | 'w' -> Some Command.Withdraw
    | 'x' -> Some Command.Exit
    | _ -> None

tryParseCommand 'd' = Some Command.Deposit

tryParseCommand 'w' = Some Command.Withdraw

tryParseCommand 'x' = Some Command.Exit

tryParseCommand 'g' = None