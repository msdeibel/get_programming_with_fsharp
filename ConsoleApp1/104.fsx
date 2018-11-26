module _104

open System

    let parse (person: string) =
        let splitPerson = person.Split(' ')
        let score = Convert.ToInt32(splitPerson.[2])
        splitPerson.[0], splitPerson.[1], score

    let goGoGo = 
        parse("Mary Asteroids 2500")

    let n, g, s = 
        parse("Mary Asteroids 2500") 
