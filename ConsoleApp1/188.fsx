type Person =
    {
        Name: string
        Town: string
    }

let inhabitants =
    [
        {Name = "Isaac"; Town = "London"}
        {Name = "Sara"; Town = "Birmingham"}
        {Name = "Tim"; Town = "London"}
        {Name = "Michelle"; Town = "Manchester"}
    ]

let cities = inhabitants |> List.map(fun p -> p.Town)

inhabitants |> List.iter(fun p -> printfn "Hello, %s" p.Town)
