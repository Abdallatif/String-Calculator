// Learn more about F# at http://fsharp.org
module StringCalc

open System
open System.Text.RegularExpressions

let defaultDelimiters = [|','; '\n'|]

let (|CustomDelimiters|_|) text =
    let matches = Regex("^//(\[.+\])\n(.*)$").Match text
    if matches.Success
    then Some (matches.Groups.[2].Value, matches.Groups.[1].Value)
    else None

let extractDelimeters text =
  let delimeters = Regex("\[(.*?)\]").Matches text
  List.ofSeq delimeters |> List.map (fun (m:Match) -> m.Groups.[1].Value) |> List.toArray

let split' (text : string) =
  match text with
  | "" -> [||]
  | CustomDelimiters (text, delimeters) -> text.Split(extractDelimeters(delimeters), StringSplitOptions.None)
  | _ -> text.Split defaultDelimiters

let split =
  split' >> List.ofArray >> List.map int

let isNegative = (>) 0

let isBigNumber = (>=) 1000

let checkNegatives xs =
  let negatives = List.filter isNegative xs
  if negatives.Length > 0
  then
    let errorMessage = "negative numbers not allowed. " + String.Join(",", negatives) + " was found"
    errorMessage |> System.ArgumentException |> raise
  else xs

let filterBigNumbers = List.filter isBigNumber

let sum = split >> checkNegatives >> filterBigNumbers >> List.sum