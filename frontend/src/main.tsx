import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import App from "./App.tsx";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import { CustomerIdProvider } from "./customerIdContext.tsx";
import { BrowserRouter, Routes, Route } from "react-router";
import { DeviceDetails } from "./devices/deviceDetails.tsx";

const queryClient = new QueryClient();

createRoot(document.getElementById("root")!).render(
  <StrictMode>
    <QueryClientProvider client={queryClient}>
      <CustomerIdProvider>
        <BrowserRouter>
          <Routes>
            <Route path="/" element={<App />} />
            <Route path="/device/:deviceId" element={<DeviceDetails />} />
          </Routes>
        </BrowserRouter>
      </CustomerIdProvider>
    </QueryClientProvider>
  </StrictMode>,
);
