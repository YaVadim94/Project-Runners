using System.Buffers.Text;
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
        public async Task Handle(MessageDto dto)
        {
            var stream = File.OpenRead(Path.Combine("Pictures", "It is boring.jpg"));

            var contract = new ScreenshotContract
            {
                RunnerId = 1,
                Payload = await ByteString.FromStreamAsync(stream)
            };
            
            await _runnersApi.SendScreenshot(contract);
        }
    }
}