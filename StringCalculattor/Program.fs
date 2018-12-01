// Learn more about F# at http://fsharp.org
module StringCalc

open System
open System.Text.RegularExpressions

let defaultDelimiters = [|','; '\n'|]

let (|CustomDelimiters|_|) text =
    let matches = Regex("^//(.+)\n(.*)$").Match text
    if matches.Success
    then Some [matches.Groups.[2].Value; matches.Groups.[1].Value]
    else None

let split' (text : string) =
  match text with
  | "" -> [||]
  | CustomDelimiters [text; delimeters;] -> text.Split delimeters
  | _ -> text.Split defaultDelimiters

let split =
  split' >> List.ofArray >> List.map int

let sum = split >> List.sum