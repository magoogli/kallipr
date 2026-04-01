import { Configuration } from "../client";
import axios from "axios";
import { getCustomerId } from "../customeIdStore";

export const config = new Configuration({
  basePath: "https://localhost:7264",
});

export const axiosInstance = axios.create({});

axiosInstance.interceptors.request.use((config) => {
  const customerId = getCustomerId();

  if (customerId) {
    config.headers["X-CustomerId"] = customerId;
  }

  return config;
});
