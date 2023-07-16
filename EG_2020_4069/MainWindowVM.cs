using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EG_2020_4069.Model;
using EG_2020_4069.View;
using EG_2020_4069;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace EG_2020_4069
{
    public partial class MainWindowVM : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<User> users;

        [ObservableProperty]
        public User selectedUser = null;

        public void CloseMainWindow()
        {
            Application.Current.MainWindow.Close();
        }

        [RelayCommand]
        public void messeag()
        {

            MessageBox.Show($"{selectedUser.FirstName} GPA value must be between 0 and 4.", "Error");
        }

        [RelayCommand]
        public void AddStudent()
        {
            var vm = new AddUserVM();
            vm.title = "ADD USER";
            AddUserWindow window = new AddUserWindow(vm);
            window.ShowDialog();

            if (vm.Student.FirstName != null)
            {
                users.Add(vm.Student);
            }
        }

        [RelayCommand]
        public void Delete()
        {
            if (selectedUser != null)
            {
                string name = selectedUser.FirstName;
                users.Remove(selectedUser);
                MessageBox.Show($"{name} Deleted.", "DELETED \a ");
            }
            else
            {
                MessageBox.Show("Select a Student.", "Error");
            }
        }

        [RelayCommand]
        public void ExecuteEditStudentCommand()
        {
            if (selectedUser != null)
            {
                var vm = new AddUserVM(selectedUser);
                vm.title = "EDIT USER";
                var window = new AddUserWindow(vm);

                window.ShowDialog();

                int index = users.IndexOf(selectedUser);
                users.RemoveAt(index);
                users.Insert(index, vm.Student);
            }
            else
            {
                MessageBox.Show("Select a student", "Warning!");
            }
        }

        [RelayCommand]
        public void Exit()
        {
            CloseMainWindow();
        }

        public MainWindowVM()
        {
            users = new ObservableCollection<User>();
            string image1 = "/Model/Images/2.png";
            users.Add(new User(23, "Jonathon", "Snowild", "2/1/2000", image1, 2.35));
            string image2 = "/Model/Images/1.png";
            users.Add(new User(24, "Timmothy", "Griffin", "12/11/1999", image2, 3.24));
            string image3 = "/Model/Images/3.png";
            users.Add(new User(22, "Alexandra", "Dadario", "18/8/2001", image3, 3.21));
            string image4 = "/Model/Images/2.png";
            users.Add(new User(23, "Emilia", "Clark", "24/5/2000", image4, 2.53));
        }
    }
}
