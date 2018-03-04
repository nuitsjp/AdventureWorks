using System;
using Cauldron.Interception;

namespace AdventureWorks.EmployeeManager.Presentation.ViewModels
{
    public class MonitorPropertiesAttribute: Attribute, IPropertySetterInterceptor
    {
        public void OnException(Exception e)
        {
        }

        public void OnExit()
        {
        }

        public bool OnSet(PropertyInterceptionInfo propertyInterceptionInfo, object oldValue, object newValue)
        {
            if (Equals(oldValue, newValue))
                return true;

            var monitorPropertyUpdated = propertyInterceptionInfo.Instance as IMonitorPropertyUpdated;

            monitorPropertyUpdated?.OnUpdateProperty();

            return false;
        }
    }
}