﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace todo_list_enh.Server.Models.DTO.Task
{
    public class TaskDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsStrict { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsTemplate { get; set; }
        public TimeSpan? StartTime { get; set; } = TimeSpan.Zero;
        public TimeSpan? EndTime { get; set; } = TimeSpan.Zero;
    }
}
