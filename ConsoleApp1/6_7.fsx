open System.Drawing

let drive(petrol, distance) =
    if distance > 50 then petrol/2.0
    elif distance > 25 then petrol - 10.0
    elif distance > 0 then petrol - 1.0
    else petrol

let petrol = 100.0
let firstState = drive(petrol, 75)
let secondState = drive(firstState, 30)
let thirdState = drive(secondState, 10)
let fourthState = drive(thirdState, 0)


