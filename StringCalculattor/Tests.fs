module Tests

open Expecto

[<Tests>]
let tests =
  testList "samples" [
    testCase "universe exists" <| fun _ ->
      let subject = true
      Expect.equal subject StringCalc.returnsTrue "I compute, therefore I am."

    testCase "should fail foo" <| fun _ ->
      let subject = false
      Expect.isTrue subject "I should fail because the subject is false."
  ]