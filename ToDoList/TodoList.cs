using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;
using ToDoList.Models;

namespace ToDoList
{
    static class TodoList
    {
        static string ListPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "todo.json");

        /// <summary>
        /// Load list of tasks.
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<ToDo> Load()
        {
            if (File.Exists(ListPath))
                return JsonConvert.DeserializeObject<ObservableCollection<ToDo>>(File.ReadAllText(ListPath));
            else return new ObservableCollection<ToDo>();
        }

        /// <summary>
        /// Save list of tasks.
        /// </summary>
        /// <param name="list"></param>
        public static void Save(ObservableCollection<ToDo> list)
        {
            File.WriteAllText(ListPath, JsonConvert.SerializeObject(list, Formatting.Indented));
        }
    }
}
