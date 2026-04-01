import { useQuery } from "@tanstack/react-query";
import { axiosInstance, config } from "./axiosInstance";
import { CustomerApi } from "../client/api";

//https://tkdodo.eu/blog/effective-react-query-keys
export const Keys = {
  all: ["customers"] as const,
  list: () => [...Keys.all, "list"] as const,
};

export const customerApi = new CustomerApi(config, undefined, axiosInstance);

export const useListCustomers = () =>
  useQuery({
    queryKey: Keys.list(),
    queryFn: () => customerApi.listCustomers(),
  });
