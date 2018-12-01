module Tests

open Expecto

[<Tests>]
let tests =
  testList "sum" [
    testCase "should return 0 for empty string" <| fun _ ->
      let expected = 0
      let actual = StringCalc.sum ""
      Expect.equal actual expected "add should return 0 for empty string"

    testCase "should return the number in brackets" <| fun _ ->
      let expected = 1
      let actual = StringCalc.sum "1"
      Expect.equal actual expected "Should return 1"

    testCase "should return the sum of two numbers" <| fun _ ->
      let expected = 3
      let actual = StringCalc.sum "1,2"
      Expect.equal actual expected "Should return 3 for the sum of 1,2"
  ]