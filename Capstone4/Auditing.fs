module Capstone4.Auditing

open Capstone4.Operations
open Capstone4.Domain

/// Logs to the console
let printTransaction _ accountId transaction =
    ignore (printfn "Account %O: %s of %M (approved: %b)" accountId transaction.Operation transaction.Amount)
    

// Logs to both console and file system
let composedLogger = 
    let loggers =
        [ FileRepository.writeTransaction
          printTransaction ]
    fun accountId owner transaction ->
        loggers
        |> List.iter(fun logger -> logger accountId owner transaction)