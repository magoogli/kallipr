# DeviceApi

All URIs are relative to *http://localhost*

|Method | HTTP request | Description|
|------------- | ------------- | -------------|
|[**getTelemetryEventsWindowInsights**](#gettelemetryeventswindowinsights) | **GET** /Device/{deviceId}/TelemetryEventsWindowInsights | |
|[**listDevices**](#listdevices) | **GET** /Device | |
|[**listTelemetryEvents**](#listtelemetryevents) | **GET** /Device/{deviceId}/TelemetryEvents | |

# **getTelemetryEventsWindowInsights**
> TelemetryEventsWindowInsightsDto getTelemetryEventsWindowInsights()


### Example

```typescript
import {
    DeviceApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new DeviceApi(configuration);

let deviceId: string; // (default to undefined)

const { status, data } = await apiInstance.getTelemetryEventsWindowInsights(
    deviceId
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **deviceId** | [**string**] |  | defaults to undefined|


### Return type

**TelemetryEventsWindowInsightsDto**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
|**200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **listDevices**
> Array<DeviceDto> listDevices()


### Example

```typescript
import {
    DeviceApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new DeviceApi(configuration);

const { status, data } = await apiInstance.listDevices();
```

### Parameters
This endpoint does not have any parameters.


### Return type

**Array<DeviceDto>**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
|**200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **listTelemetryEvents**
> Array<TelemetryEventDto> listTelemetryEvents()


### Example

```typescript
import {
    DeviceApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new DeviceApi(configuration);

let deviceId: string; // (default to undefined)

const { status, data } = await apiInstance.listTelemetryEvents(
    deviceId
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **deviceId** | [**string**] |  | defaults to undefined|


### Return type

**Array<TelemetryEventDto>**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
|**200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

