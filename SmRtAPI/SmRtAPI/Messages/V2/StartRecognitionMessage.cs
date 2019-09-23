﻿namespace Speechmatics.Realtime.Client.Messages.V2
{
    internal class StartRecognitionMessage : BaseMessage
    {
        public StartRecognitionMessage(AudioFormatSubMessage audioFormatSubMessage, string model)
        {
            audio_format = audioFormatSubMessage;
            transcription_config = new { language = model };
        }

        public override string message => "StartRecognition";
        public AudioFormatSubMessage audio_format { get; }
        public object transcription_config { get; }
    }
}