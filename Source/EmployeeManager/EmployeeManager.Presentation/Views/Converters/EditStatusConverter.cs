using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using AdventureWorks.EmployeeManager.Presentation.ViewModels;

namespace AdventureWorks.EmployeeManager.Presentation.Views.Converters
{
    public class EditStatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is EditStatus editStatus)
            {
                switch (editStatus)
                {
                    case EditStatus.UnModified:
                        return string.Empty;
                    case EditStatus.Modified:
                        return "M";
                    case EditStatus.New:
                        return "N";
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // ignore
            return value;
        }
    }
}
