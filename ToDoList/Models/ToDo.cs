using DevExpress.Mvvm;
using Newtonsoft.Json;
using System;

namespace ToDoList.Models
{
    /// <summary>
    /// Task.
    /// </summary>
#pragma warning disable CS0659
    class ToDo : ViewModelBase
#pragma warning restore CS0659
    {
        private bool isCompleted;

        /// <summary>
        /// True - task was completed.
        /// </summary>
        [JsonProperty("iscomp")]
        public bool IsCompleted
        {
            get => isCompleted;
            set
            {
                isCompleted = value;

                if (value)
                    DateEnded = DateTime.Now;
                else DateEnded = null;

                RaisePropertiesChanged(nameof(IsCompleted), nameof(DateAdded), nameof(DateEnded));
            }
        }

        /// <summary>
        /// Task text.
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// Date added.
        /// </summary>
        [JsonProperty("da")]
        public DateTime DateAdded { get; set; }

        /// <summary>
        /// Date ended.
        /// </summary>
        [JsonProperty("de")]
        public DateTime? DateEnded { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is ToDo todo))
                return false;
            return todo.Text == Text && todo.IsCompleted == IsCompleted && todo.DateAdded == DateAdded && todo.DateEnded == DateEnded;
        }
    }
}
