#I @"C:\Users\Markus\.nuget\packages"
#r @"fsharp.data\3.0.0\lib\netstandard2.0\FSharp.Data.dll"
#r @"xplot.googlecharts\1.5.0\lib\net45\XPlot.GoogleCharts.dll"
#r @"google.datatable.net.wrapper\3.1.2\lib\Google.DataTable.Net.Wrapper.dll"
open FSharp.Data
open XPlot.GoogleCharts

type Football = FSharp.Data.CsvProvider< @".\data\FootballResults.csv">
let data = Football.GetSample().Rows |> Seq.toArray

data
|> Seq.filter(fun row ->
    row.``Full Time Home Goals`` > row.``Full Time Away Goals``)
|> Seq.countBy(fun row -> row.``Home Team``)
|> Seq.sortByDescending snd
|> Seq.take 10
|> Chart.Column
|> Chart.Show