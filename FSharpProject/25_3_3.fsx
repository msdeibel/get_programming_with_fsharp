open System

let blank:string = null
let name = "Vera"
let number = Nullable 10

let blankAsOption = blank |> Option.ofObj
let nameAsOption = name |> Option.ofObj
let numberAsOption = number|> Option.ofNullable

let unsafeName = Some "Fred" |> Option.ofObj
