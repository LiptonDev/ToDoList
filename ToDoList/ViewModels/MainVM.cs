using DevExpress.Mvvm;
using MaterialDesignXaml.DialogsHelper;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ToDoList.Models;
using ToDoList.Views;

namespace ToDoList.ViewModels
{
    class MainVM : ViewModelBase, IDialogIdentifier
    {
        /// <summary>
        /// For dialogs.
        /// </summary>
        public string Identifier => "MainIdentifier";

        /// <summary>
        /// Tasks.
        /// </summary>
        public ObservableCollection<ToDo> ToDoList { get; private set; }

        /// <summary>
        /// Costructor.
        /// </summary>
        public MainVM()
        {
            RemoveTaskCommand = new DelegateCommand<ToDo>(RemoveTask);
            RemoveAllTasksCommand = new DelegateCommand(RemoveAllTasks);
            AddNewTaskCommand = new DelegateCommand(AddNewTask);
            OnClosingCommand = new DelegateCommand(OnClosing);
            OnLoadedCommand = new DelegateCommand(OnLoaded);
        }

        /// <summary>
        /// Remove task.
        /// </summary>
        public ICommand<ToDo> RemoveTaskCommand { get; }

        /// <summary>
        /// Remove all tasks.
        /// </summary>
        public ICommand RemoveAllTasksCommand { get; }

        /// <summary>
        /// Add new task to list of tasks.
        /// </summary>
        public ICommand AddNewTaskCommand { get; }

        /// <summary>
        /// Raised when window closing.
        /// </summary>
        public ICommand OnClosingCommand { get; }

        /// <summary>
        /// Raised when window loaded.
        /// </summary>
        public ICommand OnLoadedCommand { get; }

        /// <summary>
        /// Remove task from list of tasks.
        /// </summary>
        private void RemoveTask(ToDo todo)
        {
            if (todo == null)
                return;

            ToDoList.Remove(todo);
        }

        /// <summary>
        /// Remove all tasks.
        /// </summary>
        private void RemoveAllTasks()
        {
            ToDoList.Clear();
        }

        /// <summary>
        /// Add new task to list of tasks.
        /// </summary>
        private async void AddNewTask()
        {
            var res = await this.Show<ToDo>(new NewTask(this));

            if (res == null) //clicked "Cancel"
                return;

            ToDoList.Add(res);
        }

        /// <summary>
        /// Raised when window loaded.
        /// </summary>
        private void OnLoaded()
        {
            ToDoList = TodoList.Load();
        }

        /// <summary>
        /// Raised when window closing.
        /// </summary>
        private void OnClosing()
        {
            TodoList.Save(ToDoList);
        }
    }
}
