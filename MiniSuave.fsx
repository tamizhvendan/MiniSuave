type StatusCode = OK

type HttpResult = {
  Content : string
  StatusCode : StatusCode
}

let OK content = async {
  return {Content = content; StatusCode = OK}
}

let execute app = 
  app
  |> Async.RunSynchronously
  |> printfn "%A"