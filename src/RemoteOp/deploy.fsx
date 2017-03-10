// #I @"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.6"
// #I @"..\..\packages\FAKE\tools"
#r @".\lib\FakeLib.dll"
open System
open Fake

let LogLevelParam = getBuildParamOrDefault "loglevel" "Trace"
let AppRootPath = getBuildParamOrDefault "path" @"S:\Program Files\APL\PRICEXPERT\"

let configPath = System.IO.Path.Combine [|AppRootPath ; "APLPX.exe.config" |]

updateAppSetting "LogLevel" LogLevelParam configPath


// TEST
// let path = System.IO.Path.Combine [|__SOURCE_DIRECTORY__ ; "app.config" |]

// updateAppSetting "LogLevel" "Trace" path


