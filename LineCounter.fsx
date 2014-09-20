#r "System.Xml.Linq"

open System
open System.IO
open System.Xml.Linq
open System.Text.RegularExpressions

printf "Enter solution path: "
let solutionPath = Console.ReadLine()
let solutionDirPath = Path.GetDirectoryName(solutionPath)

let solutionText = File.ReadAllText(solutionPath)
let projectPaths  = 
    Regex.Matches(solutionText, "([^\"]*csproj)")
    |> Seq.cast<Match>
    |> Seq.map (fun m -> Path.Combine(solutionDirPath, m.Groups.[1].Value))

let codeFilePaths = 
    projectPaths
    |> Seq.map (fun projPath -> 
        let projectDirPath = Path.GetDirectoryName(projPath)
        let document = XDocument.Load(projPath)
        document.Descendants()
            |> Seq.where (fun desc -> desc.Name.LocalName = "Compile")
            |> Seq.map (fun desc -> Path.Combine(projectDirPath, desc.FirstAttribute.Value)))
        |> Seq.concat

let locIsSignificant (loc : string) =
    let sanitizedLoc = loc.Trim()
    match sanitizedLoc with
    | ""  -> false
    | "{" -> false
    | "}" -> false
    | _   -> true

let totalLoc = 
    codeFilePaths
    |> Seq.sumBy (fun path ->
        File.ReadLines(path)
        |> Seq.where locIsSignificant
        |> Seq.length)

printfn "Total Loc: %i" totalLoc
Console.ReadKey() |> ignore