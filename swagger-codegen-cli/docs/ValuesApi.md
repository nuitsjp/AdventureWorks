# AdventureWorks.EmployeeManager.Api.ValuesApi

All URIs are relative to *http://localhost:9000*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ValuesDelete**](ValuesApi.md#valuesdelete) | **DELETE** /api/Values/{id} | 
[**ValuesGet**](ValuesApi.md#valuesget) | **GET** /api/Values | 
[**ValuesGet_0**](ValuesApi.md#valuesget_0) | **GET** /api/Values/{id} | 
[**ValuesPost**](ValuesApi.md#valuespost) | **POST** /api/Values | 
[**ValuesPut**](ValuesApi.md#valuesput) | **PUT** /api/Values/{id} | 


<a name="valuesdelete"></a>
# **ValuesDelete**
> void ValuesDelete (int? id)



### Example
```csharp
using System;
using System.Diagnostics;
using AdventureWorks.EmployeeManager.Api;
using AdventureWorks.EmployeeManager.Client;
using AdventureWorks.EmployeeManager.Model;

namespace Example
{
    public class ValuesDeleteExample
    {
        public void main()
        {
            var apiInstance = new ValuesApi();
            var id = 56;  // int? | 

            try
            {
                apiInstance.ValuesDelete(id);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ValuesApi.ValuesDelete: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **int?**|  | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="valuesget"></a>
# **ValuesGet**
> List<string> ValuesGet ()



### Example
```csharp
using System;
using System.Diagnostics;
using AdventureWorks.EmployeeManager.Api;
using AdventureWorks.EmployeeManager.Client;
using AdventureWorks.EmployeeManager.Model;

namespace Example
{
    public class ValuesGetExample
    {
        public void main()
        {
            var apiInstance = new ValuesApi();

            try
            {
                List&lt;string&gt; result = apiInstance.ValuesGet();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ValuesApi.ValuesGet: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

**List<string>**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="valuesget_0"></a>
# **ValuesGet_0**
> string ValuesGet_0 (int? id)



### Example
```csharp
using System;
using System.Diagnostics;
using AdventureWorks.EmployeeManager.Api;
using AdventureWorks.EmployeeManager.Client;
using AdventureWorks.EmployeeManager.Model;

namespace Example
{
    public class ValuesGet_0Example
    {
        public void main()
        {
            var apiInstance = new ValuesApi();
            var id = 56;  // int? | 

            try
            {
                string result = apiInstance.ValuesGet_0(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ValuesApi.ValuesGet_0: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **int?**|  | 

### Return type

**string**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="valuespost"></a>
# **ValuesPost**
> void ValuesPost (string value)



### Example
```csharp
using System;
using System.Diagnostics;
using AdventureWorks.EmployeeManager.Api;
using AdventureWorks.EmployeeManager.Client;
using AdventureWorks.EmployeeManager.Model;

namespace Example
{
    public class ValuesPostExample
    {
        public void main()
        {
            var apiInstance = new ValuesApi();
            var value = value_example;  // string | 

            try
            {
                apiInstance.ValuesPost(value);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ValuesApi.ValuesPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **value** | **string**|  | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="valuesput"></a>
# **ValuesPut**
> void ValuesPut (int? id, string value)



### Example
```csharp
using System;
using System.Diagnostics;
using AdventureWorks.EmployeeManager.Api;
using AdventureWorks.EmployeeManager.Client;
using AdventureWorks.EmployeeManager.Model;

namespace Example
{
    public class ValuesPutExample
    {
        public void main()
        {
            var apiInstance = new ValuesApi();
            var id = 56;  // int? | 
            var value = value_example;  // string | 

            try
            {
                apiInstance.ValuesPut(id, value);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ValuesApi.ValuesPut: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **int?**|  | 
 **value** | **string**|  | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

