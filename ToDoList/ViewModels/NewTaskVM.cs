using DevExpress.Mvvm;
using MaterialDesignXaml.DialogsHelper;
using System;
using System.Windows.Input;
using ToDoList.Models;

namespace ToDoList.ViewModels
{
    /// <summary>
    /// View model for NewTask dialog.
    /// </summary>
    class NewTaskVM : IClosableDialog
    {
        /// <summary>
        /// Dialog identifier.
        /// </summary>
        public IDialogIdentifier Identifier { get; set; }

        public NewTaskVM(IDialogIdentifier identifier)
        {
            Identifier = identifier;

            CloseDialogCommand = new DelegateCommand(CloseDialog);
            AddTaskCommand = new DelegateCommand(AddTask);
        }

        /// <summary>
        /// Task text.
        /// </summary>
        public string TaskText { get; set; }

        /// <summary>
        /// Close dialog.
        /// </summary>
        public ICommand CloseDialogCommand { get; }

        /// <summary>
        /// Close dialog and return new task.
        /// </summary>
        public ICommand AddTaskCommand { get; }

        /// <summary>
        /// Close dialog.
        /// </summary>
        private void CloseDialog()
        {
            this.Close(null);
        }

        /// <summary>
        /// Close dialog and return new task.
        /// </summary>
        private void AddTask()
        {
            this.Close(new ToDo { DateAdded = DateTime.Now, Text = TaskText });
        }
    }
}
