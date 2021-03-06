﻿// Copyright 2015 Mårten Rånge
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#load "../src/FsInclude/FsInclude.fs"

open System
open System.IO
open System.Text

let IncludeFiles () =

    use s = File.OpenWrite @"IncludedFiles.fs"
    use sw = new StreamWriter(s, Encoding.UTF8)

    FsInclude.Processor.DownloadWebFilesToStream
        sw
        (Some "Included")
        (Uri "https://raw.githubusercontent.com/mrange/FsInclude/master/src/")
        [|
            "Modules/BasicModule.fs"
            "Common/Disposable.fs"
            "Responsiveness/MultiplexModule.fs"
        |]

do IncludeFiles ()