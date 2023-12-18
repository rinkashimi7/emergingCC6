using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWPF.Models
{
    class EmployeeService
    {
        private static List<Employee> ObjEmployeesList;

        public EmployeeService()
        {
            ObjEmployeesList = new List<Employee>() { 
                new Employee{Id=100,Name="Syed",Age=25}
            };
        }

        public List<Employee> GetAll()
        {
            return ObjEmployeesList;
        }

        public bool Add(Employee objNewEmployee)
        {
            if (objNewEmployee.Age < 21 && objNewEmployee.Age > 58)
                throw new ArgumentException("Invalid age limit for employee");
            ObjEmployeesList.Add(objNewEmployee);
            return true;
        }

        public bool Update(Employee objUpdateEmployee)
        {
            bool isUpdated = false;
            for(int index = 0;index<ObjEmployeesList.Count;index++)
            {
                if (ObjEmployeesList[index].Id == objUpdateEmployee.Id)
                {
                    ObjEmployeesList[index].Name = objUpdateEmployee.Name;
                    ObjEmployeesList[index].Age = objUpdateEmployee.Age;
                    isUpdated = true;
                    break;
                }
            }
            return isUpdated;
        }

        public bool Delete(int id)
        {
            bool isDeleted = false;
            for(int index=0;index<ObjEmployeesList.Count;index++)
            {
                if (ObjEmployeesList[index].Id == id)
                {
                    ObjEmployeesList.RemoveAt(index);
                    isDeleted = true;
                    break;
                }
            }
            return isDeleted;
        }

        public Employee Search(int id)
        {
            return ObjEmployeesList.FirstOrDefault(e => e.Id == id);
        }


    }
}
