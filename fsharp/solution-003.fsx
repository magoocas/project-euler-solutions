(*
  Problem: 3

  Title: Largest prime factor

  Description: 

   The prime factors of 13195 are 5, 7, 13 and 29.

   What is the largest prime factor of the number 600851475143 ?

  Url: https://projecteuler.net/problem=3
*)

    //Code submitted for review: http://codereview.stackexchange.com/questions/114228/prime-factorization-in-f

    open System
    open System.Collections.Generic

    let number = 600851475143L
    let limit = Convert.ToInt32(sqrt (float number))

    let sieve = Array.create (limit+1) true
    sieve.SetValue(false,0)
    sieve.SetValue(false,1)

    let rec markNotPrime prime multiple =
        if multiple > limit then prime
        else
            sieve.SetValue(false, multiple)
            markNotPrime prime (prime+multiple)

    let smallPrimes = 
        Seq.unfold(fun a -> Some(a, (a+1))) 2
        |> Seq.takeWhile(fun a -> a <= limit)
        |> Seq.filter( fun a -> sieve.[a])
        |> Seq.map( fun a -> 
            let b = a+a
            markNotPrime a b)
        |> Seq.filter( fun a -> number % (int64 a) = 0L)
        
    let bigPrimes = new List<int>()

    let rec addBigPrime potentialPrime = 
        match potentialPrime with
        | p when bigPrimes.Contains(potentialPrime) -> 
            ignore()
        | p when smallPrimes |> Seq.forall(fun a -> (potentialPrime % a) <> 0) -> 
            bigPrimes.Add(p)
        | _ -> 
            smallPrimes 
                |> Seq.filter(fun a -> 
                    (potentialPrime % a) = 0) 
                |> Seq.iter(fun a -> 
                    addBigPrime (potentialPrime / a))

    smallPrimes 
        |> Seq.map(fun a -> (int (number/(int64 a))))
        |> Seq.iter(addBigPrime)

    let answer = smallPrimes |> Seq.append(bigPrimes) |> Seq.max

    printfn "smallPrimes: %A" smallPrimes
    printfn "bigPrimes: %A" bigPrimes
    printfn "answer: %d" answer