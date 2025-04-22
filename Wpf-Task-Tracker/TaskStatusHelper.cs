//TaskStatusHelper.cs
using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamNorthStar_TaskTrackerApp.Models
{
    public static class TaskStatusHelper
    {
        public static IEnumerable<TaskStatus> Values => Enum.GetValues(typeof(TaskStatus)).Cast<TaskStatus>();
    }
}

