open System
open System.Net

let address = "https://localhost:44344/calculate?"

type AsyncMaybeBuilder () =
    member this.Bind(x, f) =
        async {
            let! x' = x
            match x' with
            | Some s -> return! f s
            | None -> return None
            }
        member this.Return x =
            async{return x}

let asyncMaybe = AsyncMaybeBuilder()

let createRequest (buildedUrl:string) =
    async { return HttpWebRequest.Create(buildedUrl) |> Some} 
   
let getResponce (request:WebRequest)  = 
    async { return request.GetResponseAsync() |> Some}
              
let getAnswerAsync (responce: WebResponse) = 
        match responce.Headers.["result"] with
        | "Fail" -> None
        | _ ->  Some (responce.Headers.["result"]) 

let buildRequestUrl (first, second, action) = 
    let str = String.Format("first={0}&second={1}&action={2}", first, second, action)
    address + str

let formateOperator (op:string) = 
    op.Replace("+", "%2B").
       Replace("*", "%2A").
       Replace("/", "%2F")

let showResult result:string = 
    match result with
    | Some result -> result 
    | None -> "Some error"

let calculate (first:string, second:string, operator:string) =
    Async.RunSynchronously (asyncMaybe{
        let action = formateOperator operator
        let url = buildRequestUrl (first, second, action)
        let! request = createRequest url
        let! responce = getResponce request
        let result = getAnswerAsync responce.Result
        return result
    })

[<EntryPoint>]
let main argv =

    let first = Console.ReadLine()
    let action = Console.ReadLine()
    let second = Console.ReadLine()

    let result = calculate (first, second, action)
    Console.WriteLine( showResult result )
    Console.ReadLine() |> ignore
    0