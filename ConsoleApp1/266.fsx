type Driver = 
    {
        Name: string;
        SafetyScore: int option
        YearPassed: int;
    }

let drivers = 
    [
        {Name = "Fred Smith"; SafetyScore = Some 550; YearPassed = 1965; };
        {Name = "Tina Johnson"; SafetyScore = None; YearPassed = 1970; }
    ]

let tryFindCustomer cId = if cId = 10 then Some drivers.[0] else None
let getSafetyScore customer = customer.SafetyScore
let score = tryFindCustomer 10 |> Option.map getSafetyScore


