#r @"CSharpProject\bin\Debug\netcoreapp3.0\CSharpProject.dll"

open CSharpProject
open System.Collections.Generic

let simon = Person "Simon"
simon.PrintName()

let longhand = 
    ["Tony"; "Fred"; "Samatha"; "Brad"; "Sophie"]
    |> List.map(fun name -> Person(name))

let shorthand = 
    ["Tony"; "Fred"; "Samatha"; "Brad"; "Sophie"]
    |> List.map Person

type PersonComparer()=
    interface IComparer<Person> with
        member this.Compare(x,y) = x.Name.CompareTo(y.Name)

let pComparer = PersonComparer() :> IComparer<Person>
pComparer.Compare(simon, Person "Fred")