// HeaderContext.tsx
import { createContext, useContext, useState } from "react";
import { setCustomerId as setCustomerIdInStore } from "./customeIdStore";

const CustomerIdContext = createContext<{
  customerId: string | null;
  setCustomerId: (val: string | null) => void;
}>({
  customerId: null,
  setCustomerId: () => {},
});

export const CustomerIdProvider = ({
  children,
}: React.PropsWithChildren<{}>) => {
  const [customerId, setCustomerId] = useState<string | null>(null);

  const setCustomerIdValue = (val: string | null) => {
    setCustomerId(val);
    setCustomerIdInStore(val);
  };

  return (
    <CustomerIdContext.Provider
      value={{ customerId, setCustomerId: setCustomerIdValue }}
    >
      {children}
    </CustomerIdContext.Provider>
  );
};

export const useCustomerId = () => useContext(CustomerIdContext);
