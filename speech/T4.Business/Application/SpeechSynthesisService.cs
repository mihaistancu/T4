﻿using System;
using System.Speech.Synthesis;

namespace T4.Business.Application
{
    public static class SpeechSynthesisService
    {
        public static void Speak(string text)
        {
            Console.WriteLine("Output: " + text);
            using (var synth = new SpeechSynthesizer())
            {
                synth.SetOutputToDefaultAudioDevice();
                synth.Speak(text);
            }
        }
    }
}
