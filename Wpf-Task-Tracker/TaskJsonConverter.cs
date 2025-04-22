//TaskJsonConverter.cs
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace TeamNorthStar_TaskTrackerApp.Models
{
    public class TaskJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(Task).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jsonObject = JObject.Load(reader);
            string taskType = jsonObject["$type"]?.ToString();

            Task task;

            if (taskType == typeof(PersonalTask).FullName)
            {
                task = new PersonalTask("", "", DateTime.Now, "");
            }
            else if (taskType == typeof(WorkTask).FullName)
            {
                task = new WorkTask("", "", DateTime.Now, "");
            }
            else
            {
                throw new InvalidOperationException("Unknown task type!");
            }

            serializer.Populate(jsonObject.CreateReader(), task);
            return task;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JObject jsonObject = JObject.FromObject(value, serializer);
            jsonObject.AddFirst(new JProperty("$type", value.GetType().FullName));
            jsonObject.WriteTo(writer);
        }
    }
}
