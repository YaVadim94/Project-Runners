using System;
using System.IO;
using System.Threading.Tasks;
using Google.Protobuf;
using ProjectRunners.Common.Models.Dto;
using ProjectRunners.Common.Protos;
using ProjectRunners.Runner.APIs.Grpc;

namespace ProjectRunners.Runner.EventHandlers
{
    /// <summary>
    /// Обрабочтик для отправки скиншотов
    /// </summary>
    public class ScreenshotHandler : IEventHandler
    {
        private readonly IRunnersApi _runnersApi;

        public ScreenshotHandler(IRunnersApi runnersApi)
        {
            _runnersApi = runnersApi;
        }

        /// <summary>
        /// Отправить скиншот рабочего стола
        /// </summary>
        public async Task Handle(RunnerCommandDto dto)
        {
            var stream = File.OpenRead(Path.Combine("Pictures", GetPictureName()));

            var contract = new ScreenshotContract
            {
                RunnerId = 1,
                Payload = await ByteString.FromStreamAsync(stream)
            };
            
            await _runnersApi.SendScreenshot(contract);
        }

        private string GetPictureName() =>
            (DateTime.Now.Ticks % 5) switch
            {
                0 => "It is boring.jpg",
                1 => "Manutd.jpg",
                2 => "Matrix.jpg",
                3 => "Python interview.jpg",
                4 => "Timbaland.jpeg",
                _ => throw new ArgumentOutOfRangeException("Could not return picture name")
            };
    }
}