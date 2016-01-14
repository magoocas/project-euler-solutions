(*
    Problem: 4

    Title: Largest palindrome product

    Description:
        A palindromic number reads the same both ways. The largest palindrome
        made from the product of two 2-digit numbers is 9009 = 91 Ã— 99.
        Find the largest palindrome made from the product of two 3-digit
        numbers.

    Url: https://projecteuler.net/problem=4
*)

namespace ProjectEulerSolutions.FSharp

open System

module Solution004 = 

    let IsPalindrome number =
        let originalNumber = number.ToString()
        originalNumber |> Seq.rev |> String.Concat |> fun reversedNumber -> reversedNumber = originalNumber

    let Answer =
        [for i in 100..1000 do for j in 100..1000 -> i*j]
        |> Seq.sortByDescending (fun a -> a)
        |> Seq.find IsPalindrome

