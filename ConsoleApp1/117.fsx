module _117

type Car =
    { 
        Manufacturer : string
        EngineSize : uint32
        NumberOfDoors : uint32
        NumberOfSeats : uint32 
    }

let seatStFr = 
    {
        Manufacturer = "Seat"
        EngineSize = 1800u
        NumberOfDoors = 5u
        NumberOfSeats = 5u
    }

let  stFr2 = 
    {
        Car.Manufacturer = "Seat"
        Car.EngineSize = 1800u
        NumberOfDoors = 5u
        NumberOfSeats = 5u
    }

let eq = 
    seatStFr = stFr2

let equal =
    seatStFr.Equals(stFr2)

let refEqual = 
    System.Object.ReferenceEquals(seatStFr,stFr2)

let tuneIt (car : Car, engineSize : uint32, seatCount : uint32) =
    let tunedCar =
        {
            car with
                EngineSize = engineSize
                NumberOfSeats = seatCount
        }
    
    printfn "Original: %iccm, %i seats" car.EngineSize car.NumberOfSeats

    printfn "Modified: %iccm, %i seats" tunedCar.EngineSize tunedCar.NumberOfSeats

    tunedCar

let rx8 =
    {
        Manufacturer = "Mazda"
    }




    

