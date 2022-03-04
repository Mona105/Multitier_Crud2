using System;
using CommanLayer.Models;
using DataLayer;
using System.Collections.Generic;

namespace BussinessAccessLayer
{
    public class BLEmployeeBussiness
    {
        private EmployeeDataAccess employeeData;
        public BLEmployeeBussiness()
        {
            employeeData = new EmployeeDataAccess();
        }
        public List<Employees> GetEmployees()
        {
            return employeeData.GetEmployees();
        }
        public Employees GetEmployeesById(int id)
        {
            return employeeData.GetEmployeesByID(id);
        }
        public bool DeleteEmployees(int id)
        {
            return employeeData.DeleteEmployees(id);
        }
        public bool CreateEmployees(Employees emp)
        {
            return employeeData.CreateEmployees(emp);
        }
        public bool UpdateEmployees(Employees emp)
        {
            return employeeData.UpdateEmployees(emp);
        }
    }
}
