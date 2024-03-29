﻿using Fuel.Station.Model;
using FuelStation.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuel.Station.Blazor.Shared.Validator
{
        public class Validator : IValidator
        {
            public readonly MinMax CashiersLimits;
            public readonly MinMax ManagersLimits;
            public readonly MinMax StaffLimits;
            public readonly MinMax WaitersLimits;

            public Validator()
            {
                CashiersLimits = new MinMax() { Min = 0, Max = 4 };
                ManagersLimits = new MinMax() { Min = 0, Max = 3 };
                StaffLimits = new MinMax() { Min = 0, Max = 10 };
            }

            //TODO MAKE METHODS SMALLER
            public bool ValidateAddEmployee(EmployeeType type, List<Employee> employees, out string errorMessage, Employee employee)
            {
                errorMessage = "Succeed ";
                bool ret = true;
                var cashiers = employees.Where(e => e.employeeType == EmployeeType.Cashier && e.HireDateEnd == null);
                var managers = employees.Where(e => e.employeeType == EmployeeType.Manager && e.HireDateEnd == null) ;
                var staff = employees.Where(e => e.employeeType == EmployeeType.Staff && e.HireDateEnd == null);
                if (type == EmployeeType.Manager && managers.Count() == ManagersLimits.Max)
                {
                    ret = false;
                    errorMessage = $"You already have {ManagersLimits.Max} Managers. Max number of Managers is {ManagersLimits.Max}";
                }
                if (type == EmployeeType.Cashier && cashiers.Count() >= CashiersLimits.Max)
                {
                    ret = false;
                    errorMessage = $"You already have {CashiersLimits.Max} Cashiers. Max number of Cashiers is {CashiersLimits.Max}";
                }
                if (type == EmployeeType.Staff && staff.Count() >= StaffLimits.Max)
                {
                    ret = false;
                    errorMessage = $"You already have {StaffLimits.Max} Staff. Max number of Staff is {StaffLimits.Max}";
                }
                if (ret){
                if (employee.HireDateStart > employee.HireDateEnd)
                    {
                       ret = false;
                       errorMessage = $"Hire End Date must be greater than Start Date.";
                     }
                else if (employee.HireDateStart <= employee.HireDateEnd)
                     {
                        ret = true;
                        errorMessage = "Succeed ";
                     }
                 }
            return ret;
        }

            public bool ValidateUpdateEmployee(EmployeeType NewType, Employee dbEmployee, List<Employee> employees, out string errorMessage)
            {
                errorMessage = "Succeed ";
                bool ret = true;
                if (dbEmployee == null)
                {
                    ret = false;
                }
                else
                {
                    var cashiers = employees.Where(e => e.employeeType == EmployeeType.Cashier && e.HireDateEnd == null);
                    var staff = employees.Where(e => e.employeeType == EmployeeType.Staff && e.HireDateEnd == null);
                    var managers = employees.Where(e => e.employeeType == EmployeeType.Manager && e.HireDateEnd == null);

                    if (NewType == EmployeeType.Manager && managers.Count() >= ManagersLimits.Max)
                    {
                        errorMessage = $"You already have {ManagersLimits.Max} Managers. Max number of managers is {ManagersLimits.Max}";
                        ret = false;
                    }
                    if (NewType == EmployeeType.Cashier && cashiers.Count() >= CashiersLimits.Max)
                    {
                        errorMessage = $"You already have {CashiersLimits.Max} cashiers. Max number of cashiers is {CashiersLimits.Max}";
                        ret = false;
                    }
                    if (NewType == EmployeeType.Staff && staff.Count() >= StaffLimits.Max)
                    {
                        errorMessage = $"You already have {StaffLimits.Max} Staff. Max number of Staff is {StaffLimits.Max}";
                        ret = false;
                    }
                    if (ret)
                    {
                        if (dbEmployee.HireDateStart > dbEmployee.HireDateEnd)
                        {
                            ret = false;
                        errorMessage = $"Hire End Date must be greater than Start Date.";                    }
                    else if (dbEmployee.HireDateStart < dbEmployee.HireDateEnd)
                        {
                            ret = true;
                            errorMessage = "Succeed ";
                        }
                    }
                }
                return ret;
            }

            public bool ValidateDeleteEmployee(EmployeeType type, List<Employee> employees, out string errorMessage)
            {
                bool ret = true;
                errorMessage = "Succeed ";
                var cashiers = employees.Where(e => e.employeeType == EmployeeType.Cashier && e.HireDateEnd == null);
                var staff = employees.Where(e => e.employeeType == EmployeeType.Staff && e.HireDateEnd == null);
                var managers = employees.Where(e => e.employeeType == EmployeeType.Manager && e.HireDateEnd == null);
                if (type == EmployeeType.Manager && managers.Count() <= ManagersLimits.Min  )
                {
                    errorMessage = $"You only have {ManagersLimits.Min} Manager. Min number of Managers is {ManagersLimits.Min}.";
                    ret = false;
                }
                if (type == EmployeeType.Cashier && cashiers.Count() <= CashiersLimits.Min)
                {
                    errorMessage = $"You only have {CashiersLimits.Min} Cashier. Min number of Cashiers is {CashiersLimits.Min}.";
                    ret = false;
                }
                if (type == EmployeeType.Staff && staff.Count() <= StaffLimits.Min)
                {
                    errorMessage = $"You only have {StaffLimits.Min} Staff. Min number of Staff is {StaffLimits.Min}.";
                    ret = false;
                }

                return ret;
            }

            public bool ValidateTransaction(Transaction transaction, out string errorMessage)
            {
                errorMessage = "Succeed";
                throw new NotImplementedException();
            }

        public bool ValidateAddCustomer(List<Customer> customers, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public bool ValidateDeleteCustomer(List<Customer> customers, out string errorMessage)
        {
            throw new NotImplementedException();
        }
    }

        public struct MinMax
        {
            public int Min;
            public int Max;
        }
    }
