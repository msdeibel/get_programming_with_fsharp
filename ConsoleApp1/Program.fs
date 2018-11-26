// Learn more about F# at http://fsharp.org

open System

[<EntryPoint>]
let main argv =
    let itemCount = argv.Length
    printfn "Passed in %d items: %A" itemCount argv
    Console.ReadLine()
    0 // return an integer exit code
