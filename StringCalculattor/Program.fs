// Learn more about F# at http://fsharp.org
module StringCalc

open System

let delimiters = [|','; '\n'|]

let split' (text : string) =
  match text with
  | "" -> [||]
  | _ -> text.Split delimiters

let split =
  split' >> List.ofArray >> List.map int

let sum = split >> List.sum