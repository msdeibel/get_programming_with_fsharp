open System

let directoryDates =
    System.IO.Directory.EnumerateDirectories "C:\\"
    |> Seq.map(fun d -> System.IO.DirectoryInfo(d))
    |> Seq.map(fun di -> (di.Name, di.CreationTimeUtc))
    |> Map.ofSeq
    |> Map.map (fun k v -> printfn "%s - %s" k (DateTime.UtcNow.Subtract(v).ToString()))