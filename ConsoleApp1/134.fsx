module _134

let driveCurried distance petrol =
    if distance = "far" then petrol/2.0
    elif distance = "medium" then petrol - 10.0
    elif distance = "short" then petrol - 1.0
    else petrol

let startPetrol = 100.0

startPetrol
|> driveCurried "far"
|> driveCurried "medium"
|> driveCurried "short"
