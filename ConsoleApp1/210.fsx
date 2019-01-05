let sum inputs =
    Seq.fold   
        (fun state input ->
            let newState = state + input
            printfn 
                "Current state is %d, input is %d, new state value is %d"
                state
                input
                newState
            newState)
        0
        inputs

sum [1..5]

let length inputs =
    Seq.fold   
        (fun state input ->
            let newState = state + 1
            printfn 
                "Current state is %d, input has one more item, new state value is %d"
                state
                newState
            newState)
        0
        inputs

length [1..5]

let max inputs =
    Seq.fold   
        (fun state input ->
            let newState = 
                if input > state then
                    input
                else
                    state    
            printfn 
                "Current state is %d, input is %d, new state value is %d"
                state
                input
                newState
            newState)
        0
        inputs

max [1;5;2;4;7;6;9]

let inputs = [1..9]

Seq.fold (fun state input -> state + input) 0 inputs
inputs |> Seq.fold (fun state input -> state + input) 0
(0, inputs) ||> Seq.fold (fun state input -> state + input)