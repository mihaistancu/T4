/*
 * Copyright (c) 2017 Google Inc.
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

using Google.Cloud.Speech.V1Beta1;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GoogleCloudSamples
{
    public class Recognize
    {
        public static async Task<string> StreamingMicRecognizeAsync(string languageCode)
        {
            string result = string.Empty;

            var manualResetEvent = new ManualResetEvent(false);

            if (NAudio.Wave.WaveIn.DeviceCount < 1)
            {
                throw new Exception("No microphone!");
            }
            var speech = SpeechClient.Create();
            var streamingCall = speech.GrpcClient.StreamingRecognize();
            // Write the initial request with the config.
            await streamingCall.RequestStream.WriteAsync(
                new StreamingRecognizeRequest()
                {
                    StreamingConfig = new StreamingRecognitionConfig()
                    {
                        Config = new RecognitionConfig()
                        {
                            Encoding =
                            RecognitionConfig.Types.AudioEncoding.Linear16,
                            SampleRate = 16000,
                            LanguageCode = languageCode
                        },
                        InterimResults = false,
                    }
                });
            // Print responses as they arrive.
            Task printResponses = Task.Run(async () =>
            {
                while (await streamingCall.ResponseStream.MoveNext(default(CancellationToken)))
                {
                    if (streamingCall.ResponseStream.Current.Results.Count == 1)
                    {
                        result = streamingCall.ResponseStream.Current.Results.Single().Alternatives.Single().Transcript;
                        manualResetEvent.Set();
                    }
                }
            });
            // Read from the microphone and stream to API.
            object writeLock = new object();
            bool writeMore = true;
            var waveIn = new NAudio.Wave.WaveInEvent();
            waveIn.DeviceNumber = 0;
            waveIn.WaveFormat = new NAudio.Wave.WaveFormat(16000, 1);
            waveIn.DataAvailable +=
                (object sender, NAudio.Wave.WaveInEventArgs args) =>
                {
                    lock (writeLock)
                    {
                        if (!writeMore) return;
                        streamingCall.RequestStream.WriteAsync(
                            new StreamingRecognizeRequest()
                            {
                                AudioContent = Google.Protobuf.ByteString
                                .CopyFrom(args.Buffer, 0, args.BytesRecorded)
                            }).Wait();
                    }
                };
            waveIn.StartRecording();
            Console.WriteLine("Speak now.");
            await Task.Run(() => { manualResetEvent.WaitOne(100000); });
            // Stop recording and shut down.
            waveIn.StopRecording();
            lock (writeLock) writeMore = false;
            await streamingCall.RequestStream.CompleteAsync();
            await printResponses;
            return result;
        }

        public static void Main(string[] args)
        {
        //    var result = StreamingMicRecognizeAsync().Result;
        //    Console.WriteLine(result);

        //    result = StreamingMicRecognizeAsync().Result;
        //    Console.WriteLine(result);
        }
    }
}
