using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Views.Employee;
using QuanLyCuaHangBanh.Services; // Thêm namespace của service
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms; // Để sử dụng DialogResult

namespace QuanLyCuaHangBanh.Presenters
{
    public class EmployeePresenter : PresenterBase<Employee>
    {

        public EmployeePresenter(IEmployeeView view, EmployeeService employeeService)
            : base(view, (IService)employeeService) // Truyền service vào PresenterBase
        {
        }

        public override void LoadData()
        {
            BindingSource.DataSource = ((EmployeeService)Service).GetAllEmployees();
            // View.SetBindingSource(BindingSource); // Dòng này có thể không cần thiết nếu đã được gọi trong PresenterBase
        }

        public override void OnExport(object? sender, EventArgs e)
        {
            // Triển khai logic export tại đây, có thể gọi _employeeService.Export...
            throw new NotImplementedException();
        }

        public override void OnImport(object? sender, EventArgs e)
        {
            // Triển khai logic import tại đây, có thể gọi _employeeService.Import...
            throw new NotImplementedException();
        }

        public override void OnAddNew(object? sender, EventArgs e)
        {
            EmployeeInputView inputView = new EmployeeInputView();
            if (inputView.ShowDialog() == DialogResult.OK)
            {
                Employee newEmployee = inputView.Tag as Employee;
                if (newEmployee != null)
                {
                    ((EmployeeService)Service).AddEmployee(newEmployee);
                    View.Message = "Thêm nhân viên thành công!";
                    LoadData();
                }
            }
        }

        public override void OnDelete(object? sender, EventArgs e)
        {
            if (View.SelectedItem is Employee employeeToDelete)
            {
                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    ((EmployeeService)Service).DeleteEmployee(employeeToDelete);
                    View.Message = "Xóa nhân viên thành công!";
                    LoadData(); // Load lại dữ liệu sau khi xóa
                }
            }
            else
            {
                View.Message = "Vui lòng chọn một nhân viên để xóa.";
            }
        }

        public override void OnEdit(object? sender, EventArgs e)
        {
            if (View.SelectedItem is Employee selectedEmployee)
            {
                EmployeeInputView inputView = new EmployeeInputView(selectedEmployee);
                if (inputView.ShowDialog() == DialogResult.OK)
                {
                    Employee updatedEmployee = inputView.Tag as Employee;
                    if (updatedEmployee != null)
                    {
                        // updatedEmployee.ID = ((Employee)View.SelectedItem).ID; // ID đã được gán qua constructor của inputView
                        ((EmployeeService)Service).UpdateEmployee(updatedEmployee);
                        View.Message = "Cập nhật nhân viên thành công!";
                        LoadData();
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
            // Triển khai logic search tại đây, có thể gọi _employeeService.Search...
            // Ví dụ: BindingSource.DataSource = _employeeService.SearchEmployees(View.SearchValue);
            throw new NotImplementedException();
        }
    }
}