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

//******************************************************

let numbers = [1..10]
let timesTwo n = n * 2

let outputImperative = ResizeArray()

for number in numbers do
    outputImperative.Add (number |> timesTwo)

System.Console.WriteLine(outputImperative.[0])

let outputFunctional = numbers |> List.map timesTwo

