module _129

open System

let writeToFile (date:System.DateTime) filename text =
    let diskFilename = sprintf "%s-%s.txt" (date.ToString("yyyyMMdd")) filename
    System.IO.File.WriteAllText(diskFilename, text)

let writeToToday = writeToFile DateTime.UtcNow.Date
let writeToTomorrow = writeToFile (DateTime.UtcNow.Date.AddDays(1.))
let writeToTodayHelloWorld = writeToToday "hello-world"

writeToToday "first-file" "The quick brown fox jumps over the lazy dog."
writeToTomorrow "second-file" "The quick brown fox jumps over the lazy dog."
writeToTodayHelloWorld "The quick brown fox jumps over the lazy dog."



    