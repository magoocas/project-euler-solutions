(*
    Problem: 5

    Title: Smallest multiple

    Description:
        
        
        2520 is the smallest number that can be divided by each of the numbers
        from 1 to 10 without any remainder.
        
        What is the smallest positive number that is evenly divisible by all of
        he numbers from 1 to 20?

    Url: https://projecteuler.net/problem=5
*)

namespace ProjectEulerSolutions.FSharp

open System

module Solution005 = 
    let Answer = 
        [2L..20L]
        |> Seq.map (Solution003.GetPrimeFactors 2L [])
        |> Seq.map(fun factors -> 
        factors
            |> Seq.groupBy(fun factor -> factor) 
            |> Seq.map(fun (factor, factorGroup) -> (factor, factorGroup |> Seq.length)))
        |> Seq.collect (fun factorGrouping -> factorGrouping)
        |> Seq.groupBy (fun (factor, countOfFactor) -> factor)
        |> Seq.map (fun (factor, factorGroup) -> (factor, factorGroup |> Seq.max))
        |> Seq.fold (fun acc (factor, (factor2, maxCountOfFactor)) -> acc * (pown factor maxCountOfFactor)) 1L



