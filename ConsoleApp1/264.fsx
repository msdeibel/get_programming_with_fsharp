type Driver = 
    {
        Name: string;
        SafetyScore: int option
        YearPassed: int;
    }

let customers = 
    [
        {Name = "Fred Smith"; SafetyScore = Some 550; YearPassed = 1965; };
        {Name = "Tina Johnson"; SafetyScore = None; YearPassed = 1970; }
    ]

let calculateAnnualPremiumUsd customer =
    match customer.SafetyScore with
    | Some 0 -> 250
    | Some score when score < 0 -> 400
    | Some score when score > 0 -> 150
    | None ->
        printfn "No score supplied! Using temporary premium."
        300
        
calculateAnnualPremiumUsd customers.[0]    
calculateAnnualPremiumUsd customers.[1]