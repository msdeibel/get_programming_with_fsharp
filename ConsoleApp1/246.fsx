type Disk =
| HardDisk of RPM:int * Platters:int
| SolidState
| MMC of NumberOfPins:int

let hdd250 = HardDisk(250, 7)
let mmc5 = MMC(5)
let ssd = SolidState

let seek disk =
    match disk with
    | HardDisk _ -> "Seeking loudly at a reasonable speed"
    | MMC _ -> "Seeking silently but slowly"
    | SolidState _ -> "Already found it!"

seek ssd
seek mmc5
seek hdd250

let describe disk =
    match disk with 
    | SolidState _ -> "I'm a newfangled SSD."
    | MMC 3 -> "I have only one pin."
    | MMC pins when pins < 5 -> "I'm an MMC with few pins."
    | MMC pins -> sprintf "I'm an MMC with %i pins." pins
    | HardDisk (5400, _) -> "I'm a slow disk"
    | HardDisk (_, 7) -> "I have seven spindles"
    | HardDisk (_, _) -> "I'm a hard disk"

describe ssd
describe mmc5
describe hdd250
