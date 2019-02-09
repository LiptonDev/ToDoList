using MaterialDesignXaml.DialogsHelper;
using System.Windows.Controls;
using ToDoList.ViewModels;

namespace ToDoList.Views
{
    /// <summary>
    /// Логика взаимодействия для NewTask.xaml
    /// </summary>
    public partial class NewTask : UserControl
    {
        public NewTask(IDialogIdentifier identifier)
        {
            InitializeComponent();

            DataContext = new NewTaskVM(identifier);
        }
    }
}
