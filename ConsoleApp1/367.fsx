#I @"C:\Users\Markus\.nuget\packages"
#r @"fsharp.data\3.0.0\lib\netstandard2.0\FSharp.Data.dll"
#r @"xplot.googlecharts\1.5.0\lib\net45\XPlot.GoogleCharts.dll"
#r @"google.datatable.net.wrapper\3.1.2\lib\Google.DataTable.Net.Wrapper.dll"
open FSharp.Data
open XPlot.GoogleCharts

type Films = FSharp.Data.HtmlProvider< "https://en.wikipedia.org/wiki/Robert_De_Niro_filmography">
let deNiro = Films.GetSample()
let byYeardata =
    deNiro.Tables.Films.Rows
    |> Array.countBy(fun row -> string row.Year)
    |> Chart.Column
    |> Chart.Show
