import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import App from "./App.tsx";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import { CustomerIdProvider } from "./customerIdContext.tsx";

const queryClient = new QueryClient();

createRoot(document.getElementById("root")!).render(
  <StrictMode>
    <QueryClientProvider client={queryClient}>
      <CustomerIdProvider>
        <App />
      </CustomerIdProvider>
    </QueryClientProvider>
  </StrictMode>,
);
