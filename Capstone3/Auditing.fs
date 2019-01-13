module Capstone3.Auditing

open Capstone3.Operations
open Capstone3.Domain

/// Logs to the console
let printTransaction _ accountId transaction = 
    let message = sprintf "Transaction %c on %O for amount %M. Accepted: %b"
                    transaction.Operation
                    transaction.Timestamp
                    transaction.Amount
                    transaction.IsSuccess

    printfn "Account %O: %s" accountId message

// Logs to both console and file system
let composedLogger = 
    let loggers =
        [ FileRepository.writeTransaction
          printTransaction ]
    fun accountId owner transaction ->
        loggers
        |> List.iter(fun logger -> logger accountId owner transaction)