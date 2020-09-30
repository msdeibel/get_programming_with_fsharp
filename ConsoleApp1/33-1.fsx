#I @"C:\Users\Markus\.nuget\packages"
#r @"fsharp.data\3.0.0\lib\netstandard2.0\FSharp.Data.dll"

open FSharp.Data

type Package = 
    FSharp.Data.HtmlProvider< @"..\data\sample-package.html" >

let getPackage packageName =
    packageName 
    |> sprintf "https://www.nuget.org/packages/%s" 
    |> Package.Load

let getDownloadsForPackage packageName =
    let package = getPackage packageName
    package.Tables.``Version History``.Rows
    |> Seq.sumBy(fun p -> p.Downloads)

let getDetailsForVersion packageName version =
    let package = getPackage packageName
    package.Tables.``Version History``.Rows
    |> Seq.tryFind(fun p -> p.Version.Contains version)

getDownloadsForPackage "EntityFramework"
getDetailsForVersion "EntityFramework" "6.1.0"