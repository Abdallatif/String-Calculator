module Tests

open Expecto

[<Tests>]
let numbers =
  testList "numbers" [
    testCase "should return 0 for empty string" <| fun _ ->
      let expected = 0
      let actual = StringCalc.sum ""
      Expect.equal actual expected "Should return 0 for empty string"

    testCase "should return the number in brackets" <| fun _ ->
      let expected = 1
      let actual = StringCalc.sum "1"
      Expect.equal actual expected "Should return 1 as it is"

    testCase "should return the sum of two numbers" <| fun _ ->
      let expected = 3
      let actual = StringCalc.sum "1,2"
      Expect.equal actual expected "Should return 3 for the sum of 1,2"

    testCase "should return the sum of for multiple numbers" <| fun _ ->
      let expected = 25
      let actual = StringCalc.sum "10,2,3,10"
      Expect.equal actual expected "Should return 20 for the sum of '10,2,3,10'"
    
    testCase "should ignore numbers bigger than 1000" <| fun _ ->
      let expected = 2
      let actual = StringCalc.sum "2,1001"
      Expect.equal actual expected "Should return 3 for the sum of 1,2"
  ]

[<Tests>]
let delimiters =
  testList "delimiters" [
    testCase "should split numbers by ','" <| fun _ ->
      let expected = 3
      let actual = StringCalc.sum "1,2"
      Expect.equal actual expected "should split numbers by ','"

    testCase "should split numbers by '\\n'" <| fun _ ->
      let expected = 3
      let actual = StringCalc.sum "1\n2"
      Expect.equal actual expected "should split numbers by '\n'"

    testCase "should split numbers by different delimeters" <| fun _ ->
      let expected = 10
      let actual = StringCalc.sum "1\n2,3,4"
      Expect.equal actual expected "split numbers by different delimeters"

    testCase "should split by a custom delimeter" <| fun _ ->
      let expected = 3
      let actual = StringCalc.sum "//[;]\n1;2"
      Expect.equal actual expected "split by a custom delimeter"

    testCase "delimeters could be of any length" <| fun _ ->
      let expected = 6
      let actual = StringCalc.sum "//[***]\n1***2***3"
      Expect.equal actual expected "delimeters could be of any length"

    testCase "should split by multiple custom delimeters" <| fun _ ->
      let expected = 6
      let actual = StringCalc.sum "//[*][%]\n1*2%3"
      Expect.equal actual expected "split by multiple custom delimeters"

    testCase "should split by multiple custom delimeters of any length" <| fun _ ->
      let expected = 11
      let actual = StringCalc.sum "//[*][###][%]\n1*2%3###5"
      Expect.equal actual expected "split by multiple custom delimeters of any length"
  ]

let sumWrapper text = fun _ -> StringCalc.sum text |> ignore

[<Tests>]
let exceptions =
  testList "exceptions" [
    testCase "should raise an exception" <| fun _ ->
      let wrappedSum = fun _ -> StringCalc.sum "-2" |> ignore
      Expect.throws (sumWrapper "-1") "negative numbers shouldn't be allowed"
  ]