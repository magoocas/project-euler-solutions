(*
    Problem: 3

    Title: Largest prime factor

    Description:
        The prime factors of 13195 are 5, 7, 13 and 29.
        What is the largest prime factor of the number 600851475143 ?

    Url: https://projecteuler.net/problem=3
*)

namespace ProjectEulerSolutions.FSharp

open System

module Solution003 =
    let rec GetPrimeFactors potentialPrime primes (numberToFactor:int64) = 
        let quotient, remainder = Math.DivRem(numberToFactor, potentialPrime)
        match remainder with
            
        //Confirmed prime, so add to list and call again with quotient as the new number to factor
        | 0L -> GetPrimeFactors potentialPrime (potentialPrime::primes) quotient
            
        // Prime number is now too large to be divided into the numberToFactor which means the numberToFactor
        // is actually the last prime, so we can just add it to the list
        | _ when potentialPrime*2L > numberToFactor -> numberToFactor::primes 

        // This will handle the case when the original number to be factored is odd, which means we 
        // know we can skip all remaining even numbers since they cannot be primes
        | _ when potentialPrime = 2L -> GetPrimeFactors 3L primes numberToFactor

        // Once we fall to this case we know because of the previous match, we will always have an odd
        // potential prime. Since it failed to test as a factor we should increase by 2 and try again
        | _ -> GetPrimeFactors (potentialPrime + 2L) primes numberToFactor

    let Answer =
        // Now we finally set answer with a call to GetPrimeFactor with the problem specifics
        GetPrimeFactors 2L [] 600851475143L |> Seq.max