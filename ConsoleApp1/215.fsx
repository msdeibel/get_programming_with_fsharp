open System
type Rule = string -> bool * string

let rules : Rule list =
    [   
        fun text -> 
            printfn "Three word rule"
            (text.Split ' ').Length = 3, "Must be three words"
        fun text -> 
            printfn "30 character rule"
            text.Length <= 30, "Max length is 30 characters"
        fun text -> 
            printfn "All caps rule"        
            text
            |> Seq.filter Char.IsLetter
            |> Seq.forall Char.IsUpper, "All letters must be caps" 
        fun text -> 
            printfn "No numbers rule"
            text
            |> Seq.filter Char.IsNumber
            |> Seq.length = 0, "Must not contain numbers" 
    ]

let validateManual (rules: Rule list) word =
    let passed, error = rules.[0] word
    if not passed then false, error
    else    
        let passed, error = rules.[1] word
        if not passed then false, error
        else    
            let passed, error = rules.[2] word
            if not passed then false, error
            else
                true,""

let buildValidator (rules: Rule list) =
    rules
    |> List.reduce(fun firstRule secondRule ->
        fun word ->
            let passed, error = firstRule word
            if passed then  
                let passed, error = secondRule word
                if passed then true, ""
                else false, error
            else false, error)

let validate = buildValidator rules
let word = "HELLO FROM FSHARP4"

validate word
