import "@fontsource/roboto/300.css";
import "@fontsource/roboto/400.css";
import "@fontsource/roboto/500.css";
import "@fontsource/roboto/700.css";

import { CustomerSelect } from "./customers/customerSelect";
import { useCustomerId } from "./customerIdContext";
import { DeviceList } from "./devices/deviceList";

function App() {
  const { customerId } = useCustomerId();

  return (
    <>
      <CustomerSelect />
      {customerId && <DeviceList customerId={customerId} />}
    </>
  );
}

export default App;
