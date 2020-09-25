#I @"C:\Users\Markus\.nuget\packages"
#r @"fsharp.data\3.0.0\lib\netstandard2.0\FSharp.Data.dll"

open FSharp.Data

type TvListing = 
    FSharp.Data.JsonProvider<"http://www.bbc.co.uk/programmes/genres/comedy/schedules/all.json">

let tvListing = TvListing.GetSample()
let title = tvListing.Broadcasts.[0].Programme.DisplayTitles.Title