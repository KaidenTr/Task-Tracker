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
            // Check if the object type is assignable to the Task base class
            return typeof(Task).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Parse the JSON into a JObject
            JObject jsonObject = JObject.Load(reader);

            // Get the type information from the "$type" property
            string taskType = jsonObject["$type"]?.ToString();

            Task task;

            // Remove assembly information from the type name
            string cleanedTaskType = taskType?.Split(',')[0]?.Trim();

            // Instantiate the correct derived class based on the cleaned type name
            if (cleanedTaskType == typeof(PersonalTask).FullName)
            {
                task = new PersonalTask("", "", DateTime.Now, "");
            }
            else if (cleanedTaskType == typeof(WorkTask).FullName)
            {
                task = new WorkTask("", "", DateTime.Now, "");
            }
            else
            {
                throw new InvalidOperationException($"Unknown task type: {taskType}");
            }

            // Populate the properties of the task object from the JSON
            serializer.Populate(jsonObject.CreateReader(), task);
            return task;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // Convert the task object into a JObject
            JObject jsonObject = JObject.FromObject(value, serializer);

            // Add the "$type" property with the type's full name
            jsonObject.AddFirst(new JProperty("$type", value.GetType().FullName));

            // Write the JSON object to the output
            jsonObject.WriteTo(writer);
        }
    }
}


