namespace Capstone3.Domain

open System

type Customer = { Name : string }
type Account = { AccountId : Guid; Owner : Customer; Balance : decimal }
type Transaction = {Amount: decimal; Operation: char; Timestamp: DateTime; IsSuccess: bool}

module Transactions =
    let serialize transaction=
        sprintf "%O***%c***%M***%b"
            transaction.Timestamp
            transaction.Operation
            transaction.Amount
            transaction.IsSuccess

    let deserialize (serializedTransaction: string) =
        let transactionParts = serializedTransaction.Split(List.toArray ["***"], StringSplitOptions.None)
        let transaction = 
            {
                Amount = Decimal.Parse(transactionParts.[2]);
                Operation = Char.Parse(transactionParts.[1]);
                Timestamp = DateTime.Parse(transactionParts.[0]);
                IsSuccess = bool.Parse(transactionParts.[3]);
            }

        transaction