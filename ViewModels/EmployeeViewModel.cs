using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using EmployeeWPF.Models;
using EmployeeWPF.Commands;
using System.Collections.ObjectModel;
namespace EmployeeWPF.ViewModels
{
    class EmployeeViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged_Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        EmployeeService objEmployeeService;
        public EmployeeViewModel()
        {
            objEmployeeService = new EmployeeService();
            LoadData();
            CurrentEmployee = new Employee();
            saveCommand = new RelayCommand(Save);
            searchCommand = new RelayCommand(Search);
            updateCommand = new RelayCommand(Update);
            deleteCommand = new RelayCommand(Delete);
        }

        private Employee currentEmployee;
        public Employee CurrentEmployee
        {
            get { return currentEmployee; }
            set { currentEmployee = value; OnPropertyChanged("CurrentEmployee"); }
        }

        private string message;
        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }

        #region DisplayOperation

        private ObservableCollection<Employee> employeesList;
        public ObservableCollection<Employee> EmployeesList
        {
            get { return employeesList; }
            set { employeesList = value; OnPropertyChanged("EmployeesList"); }
        }
        private void LoadData()
        {
            EmployeesList = new ObservableCollection<Employee>(objEmployeeService.GetAll());
        }
        #endregion

        #region SaveOperation
        private RelayCommand saveCommand;

        public RelayCommand SaveCommand
        {
            get { return saveCommand; }
        }

        public void Save()
        {
            try
            {
                var isSaved = objEmployeeService.Add(currentEmployee);
                LoadData();
                CurrentEmployee = new Employee();
                if (isSaved)
                {
                    Message = "Employee saved";
                }
                else
                {
                    Message = "Save operation failed";
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }

        #endregion

        #region SearchOperation
        private RelayCommand searchCommand;

        public RelayCommand SearchCommand
        {
            get { return searchCommand; }
        }

        public void Search()
        {
            try
            {
                var objEmployee = objEmployeeService.Search(CurrentEmployee.Id);
                if(objEmployee != null)
                {
                    CurrentEmployee = objEmployee;
                    Message = "Employee found.";

                }
                else
                {
                    Message = "Employee not found.";
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region updateOperation
        private RelayCommand updateCommand;

        public RelayCommand UpdateCommand
        {
            get { return updateCommand; }
        }

        public void Update()
        {
            try
            {
                var isUpdated = objEmployeeService.Update(CurrentEmployee);
                if (isUpdated)
                {
                    Message = "Employee Updated";
                    LoadData();
                }
                else
                {
                    Message = "Update operation failed.";
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region deleteOperation
        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get { return deleteCommand; }
        }

        public void Delete()
        {
            try
            {
                var isUpdated = objEmployeeService.Delete(CurrentEmployee.Id);
                if (isUpdated)
                {
                    Message = "Employee Deleted";
                    LoadData();
                }
                else
                {
                    Message = "Update operation failed.";
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
    }
}
