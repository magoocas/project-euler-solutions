(*
    Problem: 6

    Title: Sum square difference

    Description:
        
        
        The sum of the squares of the first ten natural numbers is,
        1^2 + 2^2 + ... + 10^2 = 385
        
        The square of the sum of the first ten natural numbers is,
        (1 + 2 + ... + 10)^2 = 55^2 = 3025
        
        Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.

        Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.

    Url: https://projecteuler.net/problem=6
*)

namespace ProjectEulerSolutions.FSharp

open System

type Solution006() =
    static member Answer() =
        let sumOfSquares = [1L..100L] |> List.fold (fun acc x -> acc + x*x) 0L
        let squareOfSum = [1L..100L] |> List.fold (fun acc x -> acc + x) 0L |> fun x -> x*x
        Math.Abs(sumOfSquares - squareOfSum)

