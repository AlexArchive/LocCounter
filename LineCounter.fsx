open System
open System.IO
open System.Text.RegularExpressions

Console.Write "Enter solution path: "
let solutionPath = Console.ReadLine()
let solutionDirPath = Path.GetDirectoryName(solutionPath)

let solutionText = File.ReadAllText(solutionPath)
let projectPaths  = 
    Regex.Matches(solutionText, "Project.+?, \"(.+?\.csproj)")
    |> Seq.cast<Match>
    |> Seq.map (fun m -> Path.Combine(solutionDirPath, m.Groups.[1].Value))

projectPaths
|> Seq.iter (printfn "%s")
Console.ReadKey() |> ignore