﻿module Capstone3.FileRepository

open Capstone3.Domain
open System.IO
open System

let private accountsPath =
    let path = @"accounts"
    Directory.CreateDirectory path |> ignore
    path

let private findAccountFolder owner =    
    let folders = Directory.EnumerateDirectories(accountsPath, sprintf "%s_*" owner)
    if Seq.isEmpty folders then ""
    else
        let folder = Seq.head folders
        DirectoryInfo(folder).Name

let private buildPath(owner, accountId:Guid) = sprintf @"%s\%s_%O" accountsPath owner accountId

/// Logs to the file system
//let writeTransaction accountId owner message =
//    let path = buildPath(owner, accountId)    
//    path |> Directory.CreateDirectory |> ignore
//    let filePath = sprintf "%s/%d.txt" path (DateTime.UtcNow.ToFileTimeUtc())
//    File.WriteAllText(filePath, message)

let writeTransaction accountId owner transaction =
    let path = buildPath(owner, accountId)    
    path |> Directory.CreateDirectory |> ignore
    let filePath = sprintf "%s/%d.txt" path (DateTime.UtcNow.ToFileTimeUtc())
    
    File.WriteAllText(filePath, (Transactions.serialize transaction))

let findTransactionsOnDisk owner =
    let accountFolder = findAccountFolder owner

    if accountFolder = "" then
        (Guid.NewGuid(), List.empty)
    else
        let accountId = Guid.Parse(accountFolder.Split('_').[1].Split('.').[0])
        let transactions = 
            Directory.GetFiles(buildPath (owner, accountId))
            |> Seq.map (fun f -> Transactions.deserialize(File.ReadAllText(f)))
            |> Seq.toList

        (accountId, transactions)
     