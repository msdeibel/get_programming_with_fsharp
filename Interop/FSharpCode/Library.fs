namespace Model

type Car = 
    {
        /// Number of wheels on the car
        Wheels : int

        /// Brand of the car
        Brand : string

        /// The x,y dimensions of the car in meters
        Dimensions : float * float
    }

type Vehicle = 
      /// A car is a type of vehicle
    | Motorcar of Car
      /// <summary>A motorbike is another type of vehicle</summary>
    | Motorbike of Name:string * EngineSize:float

module Functions=
    let CreateCar wheels brand x y =
        { Wheels = wheels; Brand = brand; Dimensions = x, y }

    let CreateFourWheelCar = CreateCar 4
