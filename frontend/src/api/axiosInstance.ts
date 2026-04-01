import { Configuration } from "../client";
import axios from "axios";

export const config = new Configuration({
  basePath: "https://localhost:7264",
});

export const axiosInstance = axios.create({});

// Add an interceptor to inject the Bearer token in the header for all requests.
// This is very useful as the token will periodically be refreshed by the user manager when needed, and
// Adding this interceptor rather than some static config ensure the token is always up to date.
axiosInstance.interceptors.response.use(
  function (response) {
    // Any status code that lie within the range of 2xx cause this function to trigger
    // Do something with response data
    return response;
  },

  function (error) {
    //alert("An Error Occured");
    //store.dispatch()
    // Any status codes that falls outside the range of 2xx cause this function to trigger
    // Do something with response error
    return Promise.reject(error);
  },
);
