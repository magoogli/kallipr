# TelemetryEventApi

All URIs are relative to *http://localhost*

|Method | HTTP request | Description|
|------------- | ------------- | -------------|
|[**createTelemetryEvent**](#createtelemetryevent) | **POST** /TelemetryEvent | |
|[**listTelemetryEventsByDeviceId**](#listtelemetryeventsbydeviceid) | **GET** /TelemetryEvent | |

# **createTelemetryEvent**
> createTelemetryEvent()


### Example

```typescript
import {
    TelemetryEventApi,
    Configuration,
    TelemetryEventDto
} from './api';

const configuration = new Configuration();
const apiInstance = new TelemetryEventApi(configuration);

let telemetryEventDto: TelemetryEventDto; // (optional)

const { status, data } = await apiInstance.createTelemetryEvent(
    telemetryEventDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **telemetryEventDto** | **TelemetryEventDto**|  | |


### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/*+json
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
|**200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **listTelemetryEventsByDeviceId**
> Array<TelemetryEventDto> listTelemetryEventsByDeviceId()


### Example

```typescript
import {
    TelemetryEventApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new TelemetryEventApi(configuration);

let deviceId: string; // (optional) (default to undefined)

const { status, data } = await apiInstance.listTelemetryEventsByDeviceId(
    deviceId
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **deviceId** | [**string**] |  | (optional) defaults to undefined|


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

