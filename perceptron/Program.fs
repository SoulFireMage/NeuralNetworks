
//Quite possibly the most beginner understanding of the decades old idea of a perceptron written to make sure I understand chapter 1 from neuralnetworksanddeeplearning.com !
open System
//basic factor type - the weight is how important is this factor in making the decision, the factor itself should be 0 or 1
type input = { weight : int
               factor : int
               }

//Here sigma is a function to be passed in as a parameter to decide how to evaluate inputs.
//In this version, we are still summing a vector of weight and decision (0 or 1) - this is likely to also be abstracted slightly.
let decision (threshold:int,  
              inputList : input list, 
              vectorFunction: input -> int )  = 
    let total =  List.sumBy (vectorFunction) inputList
//are we going to fire or what?
    match total with
    | n when total > threshold || total = threshold -> 1
    | _ -> 0

//populate from a list of tuples into a nice list of input types.
let BuildList (inputs : (int * int) list) = 
     inputs |> List.map (fun (w,x) -> {weight = w; factor = x})
//arbitrary test
let test = BuildList [(4, 1);(3,0);(2,1)]  
//NAND gate
let nand = BuildList [(-2, 1); (-2,0)] 
let inputVectorResult = fun x -> x.weight * x.factor
 
let result  = decision(5, test, inputVectorResult)
let resultNand = decision (3, nand,inputVectorResult)

printfn "%A" result
printfn "%A" resultNand
Console.ReadLine() |> ignore


