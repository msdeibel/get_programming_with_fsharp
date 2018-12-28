open System

type FootballResult =
    { 
        HomeTeam: string
        AwayTeam: string
        HomeGoals: int
        AwayGoals: int 
    }

let create (ht, hg) (at, ag) =
    { HomeTeam=ht; AwayTeam=at; HomeGoals=hg; AwayGoals=ag }

let results =
    [
        create("MV", 1) ("RC", 2)
        create("MV", 1) ("BT", 3)
        create("BT", 3) ("RC", 1)
        create("BT", 2) ("MV", 1)
        create("RC", 4) ("MV", 2)
        create("RC", 1) ("BT", 2)
    ]

results |> List.filter(fun r -> r.AwayGoals > r.HomeGoals) 
    |> List.groupBy (fun r -> r.AwayTeam)
        |> List.sortByDescending (fun r -> (snd r).Length)
            |> List.map (fun r -> Console.WriteLine(fst r + " " + (snd r).Length.ToString()))

// Book solution
results |> List.filter(fun r -> r.AwayGoals > r.HomeGoals) 
|> List.countBy (fun r -> r.AwayTeam)
    |> List.sortByDescending (fun (_, awayWins) -> awayWins)
        |> List.map (fun r -> Console.WriteLine(fst r + " " + (snd r).ToString()))