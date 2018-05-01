using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BorsaBekya.Models.ViewModel
{
    public class CategoryVm
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Title
        {
            get
            {
                if (Id != 0)
                {
                    return "تعديل بيانات دوله";
                }
                return "اضافه دوله جديدة";
            }
        }
    }
}