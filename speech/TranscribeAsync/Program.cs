﻿/*
 * Copyright (c) 2015 Google Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not
 * use this file except in compliance with the License. You may obtain a copy of
 * the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
 * License for the specific language governing permissions and limitations under
 * the License.
 */
// [START import_libraries]

using System;
using System.Linq;
using Google.Apis.CloudSpeechAPI.v1beta1;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using System.IO;
using System.Threading;
//[END import_libraries]

namespace GoogleCloudSamples
{
    public class TranscribeAsync
    {
        // [START authenticating]
        static public CloudSpeechAPIService CreateAuthorizedClient()
        {
            GoogleCredential credential =
                GoogleCredential.GetApplicationDefaultAsync().Result;
            // Inject the Cloud Storage scope if required.
            if (credential.IsCreateScopedRequired)
            {
                credential = credential.CreateScoped(new[]
                {
                    CloudSpeechAPIService.Scope.CloudPlatform
                });
            }
            return new CloudSpeechAPIService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "DotNet Google Cloud Platform Speech Sample",
            });
        }
        // [END authenticating]

        // [START run_application]
        static public void Main(string[] args)
        {
            if (args.Count() < 1)
            {
                Console.WriteLine("Usage:\nTranscribe audio_file");
                return;
            }
            var service = CreateAuthorizedClient();
            string audio_file_path = args[0];
            // [END run_application]
            // [START construct_request]
            var request = new Google.Apis.CloudSpeechAPI.v1beta1.Data.AsyncRecognizeRequest()
            {
                Config = new Google.Apis.CloudSpeechAPI.v1beta1.Data.RecognitionConfig()
                {
                    Encoding = "LINEAR16",
                    SampleRate = 16000,
                    LanguageCode = "en-US"
                },
                Audio = new Google.Apis.CloudSpeechAPI.v1beta1.Data.RecognitionAudio()
                {
                    Content = Convert.ToBase64String(File.ReadAllBytes(audio_file_path))
                }
            };
            // [END construct_request]
            // [START send_request]
            var asyncResponse = service.Speech.Asyncrecognize(request).Execute();
            var name = asyncResponse.Name;
            Google.Apis.CloudSpeechAPI.v1beta1.Data.Operation op;
            do
            {
                Console.WriteLine("Waiting for server processing...");
                Thread.Sleep(1000);
                op = service.Operations.Get(name).Execute();
            } while (!(op.Done.HasValue && op.Done.Value));
            dynamic results = op.Response["results"];
            foreach (var result in results)
            {
                foreach (var alternative in result.alternatives)
                    Console.WriteLine(alternative.transcript);
            }
            // [END send_request]
        }
    }
}
