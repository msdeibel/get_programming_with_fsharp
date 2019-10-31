#I @"C:\Users\Markus\.nuget\packages"
#r @"newtonsoft.json\12.0.2\lib\netstandard2.0\Newtonsoft.Json.dll"
#r @"humanizer.core\2.7.9\lib\netstandard2.0\Humanizer.dll"

open Humanizer

"ScriptsAreAGreatWayToExplorePackages".Humanize()

"ScriptsAreAGreatWayToExplorePackages".Humanize(LetterCasing.LowerCase)



#load "Library1.fs"
Library1.getPerson()

