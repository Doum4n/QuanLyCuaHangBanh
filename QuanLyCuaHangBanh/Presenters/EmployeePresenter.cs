using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Views.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Presenters
{
    public class EmployeePresenter(IEmployeeView view, IRepositoryProvider provider) : PresenterBase<Employee>(view, provider)
    {
        public override void LoadData()
        {
            BindingSource.DataSource = Provider.GetRepository<Employee>().GetAll();
            View.SetBindingSource(BindingSource);
        }

        public override void OnExport(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void OnImport(object? sender, EventArgs e)
        {
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
                    Provider.GetRepository<Employee>().Add(newEmployee);
                    View.Message = "Thêm nhân viên thành công!";
                    LoadData();
                }
            }
        }

        public override void OnDelete(object? sender, EventArgs e)
        {
            Provider.GetRepository<Employee>().Delete(View.SelectedItem as Employee);
            View.Message = "Xóa nhân viên thành công!";
        }

        public override void OnEdit(object? sender, EventArgs e)
        {
            EmployeeInputView inputView = new EmployeeInputView(View.SelectedItem as Employee);
            if (inputView.ShowDialog() == DialogResult.OK)
            {
                Employee updatedEmployee = inputView.Tag as Employee;
                if (updatedEmployee != null)
                {
                    updatedEmployee.ID = ((Employee)View.SelectedItem).ID;
                    Provider.GetRepository<Employee>().Update(updatedEmployee);
                    View.Message = "Cập nhật nhân viên thành công!";
                    LoadData();
                }
            }
        }

        public override void OnSearch(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
