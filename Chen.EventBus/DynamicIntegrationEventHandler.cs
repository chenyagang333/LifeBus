﻿using Dynamic.Json;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Chen.EventBus
{
    public abstract class DynamicIntegrationEventHandler : IIntegrationEventHandler
    {
        public Task Handle(string eventName, string eventData)
        {
            //https://github.com/dotnet/runtime/issues/53195
            //https://github.com/dotnet/core/issues/6444
            //.NET 6目前不支持把json反序列化为dynamic，本来preview 4支持，但是在preview 7又去掉了
            //所以暂时用Dynamic.Json来实现。
            dynamic dynamicEventData = DJson.Parse(eventData);
            //var responseData = JsonSerializer.Deserialize<dynamic>(responseBody);

            return HandleDynamic(eventName, dynamicEventData);
        }

        public abstract Task HandleDynamic(string eventName, dynamic dynamicEventData);
    }
}
