type StatusCode = OK | NotFound | InternalError

type HttpResult = {
  Content : string
  StatusCode : StatusCode
}

let response statusCode content = async {
  return {Content = content; StatusCode = statusCode}
}

let OK = response OK

let NOT_FOUND = response NotFound

let INTERNAL_ERROR = response InternalError

let execute app = 
  app
  |> Async.RunSynchronously
  |> printfn "%A"