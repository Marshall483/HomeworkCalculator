open System

type operation =
    | Sum
    | Substract
    | Mult
    | Divide
    | Incorrect

let sum x y = x + y
let dif x y = x - y
let mult x y = x * y

let div x y =
    if Some y = Some(0) then None
    else Some( x / y )
     
let calculate (x:option<int>) operation (y:option<int>) =
    if x.IsNone || y.IsNone then None
    else 
        match operation with
        | Sum -> Some (sum x.Value y.Value) 
        | Substract -> Some (dif x.Value y.Value)
        | Mult -> Some (mult x.Value y.Value)  
        | Divide -> div x.Value y.Value
        | Incorrect -> None
 
let print res = 
    match res with
    | None -> printf "Exception detected"
    | Some res -> printf "%i" res



let tryGetOperation input = 
    match input with
    | "+" -> Sum
    | "-" -> Substract
    | "*" -> Mult
    | "/" -> Divide
    | @"\" -> Divide
    | _ -> Incorrect

type IntOrBool =
    | IsInt of int
    | IsBool of bool

let tryGetValue (input:string) = 
    let result = 0
    let resParse = Int32.TryParse(input, ref result)
    
    if resParse = true then Some (Int32.Parse(input))
       else None


[<EntryPoint>]
let main argv = 

    let x = tryGetValue ( Console.ReadLine() )
    let operation = tryGetOperation ( Console.ReadLine() )
    let y = tryGetValue ( Console.ReadLine() )
    

    let res = calculate x operation y
    print res
    0






