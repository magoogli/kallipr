import { useQuery } from "@tanstack/react-query";
import { axiosInstance, config } from "./axiosInstance";
import { DeviceApi } from "../client/api";

//https://tkdodo.eu/blog/effective-react-query-keys
export const Keys = {
  all: ["devices"] as const,
  list: (customerId: string) => [...Keys.all, "list", customerId] as const,
  telemetryEvents: (query: { customerId: string; deviceId: string }) =>
    [...Keys.all, "telemetryEvents", query] as const,
  telemetryEventsWindowInsights: (query: {
    customerId: string;
    deviceId: string;
  }) => [...Keys.all, "telemetryEventsWindowInsights", query] as const,
};

export const deviceApi = new DeviceApi(config, undefined, axiosInstance);

export const useListDevices = (customerId: string) =>
  useQuery({
    queryKey: Keys.list(customerId),
    queryFn: () => deviceApi.listDevices(),
  });

export const useListTelemetryEvents = (customerId: string, deviceId: string) =>
  useQuery({
    queryKey: Keys.telemetryEvents({ customerId, deviceId }),
    queryFn: () => deviceApi.listTelemetryEvents({ deviceId }),
  });

export const useGetTelemetryEventsWindowInsights = (
  customerId: string,
  deviceId: string,
) =>
  useQuery({
    queryKey: Keys.telemetryEventsWindowInsights({ customerId, deviceId }),
    queryFn: () => deviceApi.getTelemetryEventsWindowInsights({ deviceId }),
  });
