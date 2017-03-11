﻿/*
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

using Xunit;

namespace GoogleCloudSamples
{
    public class QuickStartTest
    {
        readonly CommandLineRunner _quickStart = new CommandLineRunner()
        {
            VoidMain = QuickStart.Main,
            Command = "QuickStart"
        };

        [Fact]
        public void TestRun()
        {
            var output = _quickStart.Run();
            Assert.Equal(0, output.ExitCode);
            Assert.Contains("Brooklyn", output.Stdout);
        }
    }

    public class RecognizeTest
    {
        readonly CommandLineRunner _recognize = new CommandLineRunner()
        {
            Main = Recognize.Main,
            Command = "Recognize"
        };

        [Fact]
        public void TestSync()
        {
            var output = _recognize.Run("sync", @"resources\audio.raw");
            Assert.Equal(0, output.ExitCode);
            Assert.Contains("Brooklyn", output.Stdout);
        }

        [Fact]
        public void TestAsync()
        {
            var output = _recognize.Run("async", @"resources\audio.raw");
            Assert.Equal(0, output.ExitCode);
            Assert.Contains("Brooklyn", output.Stdout);
        }

        [Fact(Skip = "https://github.com/GoogleCloudPlatform/google-cloud-dotnet/issues/723")]
        public void TestStreaming()
        {
            var output = _recognize.Run("stream", @"resources\audio.raw");
            Assert.Equal(0, output.ExitCode);
            Assert.Contains("Brooklyn", output.Stdout);
        }

        [Fact(Skip = "Unreliable on automated test machines.")]
        public void TestListen()
        {
            var output = _recognize.Run("listen", "3");
            if (0 == output.ExitCode)
                Assert.Contains("Speak now.", output.Stdout);
            else
                Assert.Contains("No microphone.", output.Stdout);
        }

        [Fact]
        public void TestFlac()
        {
            var output = _recognize.Run("rec", "-e", "Flac", @"resources\audio.flac");
            Assert.Equal(0, output.ExitCode);
            Assert.Contains("Brooklyn", output.Stdout);
        }
    }
}
