#load "Domain.fs"
#load "Operations.fs"

#r @"C:\Users\Markus\Desktop\learn_fsharp_2\lesson-29\packages\Newtonsoft.Json.12.0.3\lib\net45\Newtonsoft.Json.dll"

open Newtonsoft.Json
open Capstone5.Operations
open Capstone5.Domain
open System

let txn =
    { 
        Transaction.Amount = 100M
        Timestamp = DateTime.UtcNow
        Operation = "withdraw"
    }

let serialized = txn |> JsonConvert.SerializeObject
let deserialzed = JsonConvert.DeserializeObject<Transaction>(serialized)