module Auditing

open System
open System.IO
open Domain

let consoleAudit (account:Account) (message:String) =
   Console.WriteLine("Account " + account.Id.ToString() + ": " + message)
    

let fileSystemAudit (account:Account) (message:String) =
    let directoryName = 
        "D:\\temp\\cap2\\" + account.Owner.Name
    let fileName = 
        directoryName + "\\" + account.Id.ToString() + ".txt"

    if(not(Directory.Exists(directoryName)))
    then ignore(Directory.CreateDirectory(directoryName)) 
       
    let auditFileWriter = File.AppendText(fileName)
    auditFileWriter.WriteLine(message)
    ignore(auditFileWriter.Close())