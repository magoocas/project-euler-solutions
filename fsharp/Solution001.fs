(*
    Problem: 1

    Title: Multiples of 3 and 5

    Description:
        If we list all the natural numbers below 10 that are multiples of 3 or
        5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
        Find the sum of all the multiples of 3 or 5 below 1000.

    Url: https://projecteuler.net/problem=1
*)

module ProjectEulerSolutions.FSharp.Solution001

let Answer =
    [0..1000-1]
        |> List.filter (fun x -> (x % 3 = 0) || (x % 5 = 0))
        |> List.sum

