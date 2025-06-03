using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCuaHangBanh.Base;

namespace QuanLyCuaHangBanh.DTO
{
    public class WarehouseReleaseNoteDTO : ISearchable
    {
        public int ID { get; set; }
        public string CreatedBy { get; set; }
        public DateOnly CreatedDate { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }

        public bool MatchesSearch(string searchValue)
        {
            return ID.ToString().Contains(searchValue, StringComparison.OrdinalIgnoreCase) ||
                   CreatedDate.ToString().Contains(searchValue, StringComparison.OrdinalIgnoreCase) ||
                   Status.Contains(searchValue, StringComparison.OrdinalIgnoreCase) ||
                   Note.Contains(searchValue, StringComparison.OrdinalIgnoreCase);
        }
    }
}
