#I @"C:\Users\Markus\.nuget\packages"
#r @"fsharp.data\3.0.0\lib\netstandard2.0\FSharp.Data.dll"
#r @"xplot.googlecharts\1.5.0\lib\net45\XPlot.GoogleCharts.dll"
#r @"google.datatable.net.wrapper\3.1.2\lib\Google.DataTable.Net.Wrapper.dll"
open FSharp.Data
open XPlot.GoogleCharts

type Package = FSharp.Data.HtmlProvider< @"..\data\sample-package.html">
let package = Package.GetSample()
let versionHistory =
    package.Tables.``Version History``

let nunit = Package.Load("https://www.nuget.org/packages/nunit")
let entityframework = Package.Load("https://www.nuget.org/packages/entityframework")
let newtonsoft = Package.Load("https://www.nuget.org/packages/newtonsoft.json")

let versionHistories =
    [nunit.Tables, entityframework.Tables, newtonsoft.Tables]
    |> Seq.collect(fun package -> package.Tables.``Version History``.Rows)
    |> Seq.sortByDescending(fun versionHistory -> versionHistory.Downloads)
    |> Seq.take 10
    |> Seq.map(fun vh -> vh.Version, vh.Downloads)
    |> Chart.Column
    |> Chart.Show
    //|> Seq.collect(fun package -> package.Tables.``Version History``.Rows)
    //|> Seq.sortByDescending(fun row -> row.``Downloads``)
    //|> Seq.take(10)
    //|> Chart.Column
    //|> Chart.Show