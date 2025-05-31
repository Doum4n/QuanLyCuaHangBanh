using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Views.Employee;
using QuanLyCuaHangBanh.Services; // Thêm namespace của service
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using QuanLyCuaHangBanh.DTO; // Để sử dụng DialogResult

namespace QuanLyCuaHangBanh.Presenters
{
    public class EmployeePresenter(IEmployeeView view, EmployeeService service) :PresenterBase<Employee>(view, service)
    {
        private IList<EmployeeDTO> employees = new List<EmployeeDTO>();

        public override async Task InitializeAsync()
        {
            employees = await ((EmployeeService)Service).GetAllEmployees();
            BindingSource.DataSource = employees;
        }

        public override async void OnExport(object? sender, EventArgs e)
        {
            if (BindingSource.List is IList<Employee> employees)
            {
                await ((EmployeeService)Service).ExportEmployees(employees);
            }
        }

        public override void OnImport(object? sender, EventArgs e)
        {
            ((EmployeeService)Service).ImportEmployees();
            InitializeAsync(); // Reload data after import
        }

        public override async void OnAddNew(object? sender, EventArgs e)
        {
            EmployeeInputView inputView = new EmployeeInputView();
            if (inputView.ShowDialog() == DialogResult.OK)
            {
                if (inputView.Tag is Employee newEmployeeDTO)
                {
                    if (newEmployeeDTO != null)
                    {
                        ((EmployeeService)Service).AddEmployee(newEmployeeDTO);
                        View.Message = "Thêm nhân viên thành công!";
                        await InitializeAsync();
                    }
                }
            }
        }

        public override async void OnDelete(object? sender, EventArgs e)
        {
            if (View.SelectedItem is EmployeeDTO employeeToDelete)
            {
                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    ((EmployeeService)Service).DeleteEmployee(employeeToDelete.ToEntity());
                    View.Message = "Xóa nhân viên thành công!";
                    await InitializeAsync(); // Load lại dữ liệu sau khi xóa
                }
            }
            else
            {
                View.Message = "Vui lòng chọn một nhân viên để xóa.";
            }
        }

        public override async void OnEdit(object? sender, EventArgs e)
        {
            if (View.SelectedItem is EmployeeDTO selectedEmployee)
            {
                EmployeeInputView inputView = new EmployeeInputView(selectedEmployee);
                if (inputView.ShowDialog() == DialogResult.OK)
                {
                    if (inputView.Tag is Employee updatedEmployee)
                    {
                        ((EmployeeService)Service).UpdateEmployee(updatedEmployee);
                        View.Message = "Cập nhật nhân viên thành công!";
                        await InitializeAsync();
                    }
                }
            }
            else
            {
                View.Message = "Vui lòng chọn một nhân viên để chỉnh sửa.";
            }
        }

        public override void OnSearch(object? sender, EventArgs e)
        {
            if(employees.Count > 0)
            {
                var filteredEmployees = employees.Where(e => e.MatchesSearch(View.SearchValue)).ToList();
                BindingSource.DataSource = filteredEmployees;
                BindingSource.ResetBindings(false);
            }
        }
    }
}