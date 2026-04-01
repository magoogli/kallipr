import { useEffect } from "react";
import Box from "@mui/material/Box";
import InputLabel from "@mui/material/InputLabel";
import MenuItem from "@mui/material/MenuItem";
import FormControl from "@mui/material/FormControl";
import Select, { type SelectChangeEvent } from "@mui/material/Select";

import { useListCustomers } from "../api/customers";
import { useCustomerId } from "../customerIdContext";
import type { CustomerDto } from "../client";

export function CustomerSelect() {
  const { data: customers, isLoading } = useListCustomers();
  if (isLoading) {
    return <div>Loading...</div>;
  }

  if (!customers?.data?.length) {
    return <div>No customers found</div>;
  }

  return <CustomerSelectMenu customers={customers.data} />;
}

interface CustomerSelectMenuProps {
  customers: CustomerDto[];
}

function CustomerSelectMenu(props: CustomerSelectMenuProps) {
  const { customerId, setCustomerId } = useCustomerId();
  const { customers } = props;

  useEffect(() => {
    if (!customerId && customers.length > 0) {
      setCustomerId(customers[0]?.id ?? null);
    }
  }, [customers, customerId, setCustomerId]);

  const handleChange = (event: SelectChangeEvent) => {
    const selectedId = event.target.value as string;
    const customer = customers.find((item) => item.id === selectedId) ?? null;
    setCustomerId(customer?.id ?? null);
  };

  return (
    <Box sx={{ minWidth: 120 }}>
      <FormControl fullWidth>
        <InputLabel id="customer-select-label">Customer</InputLabel>
        <Select
          labelId="customer-select-label"
          id="customer-select"
          label="Customer"
          onChange={handleChange}
          value={customerId ?? ""}
        >
          {customers.map((customer) => (
            <MenuItem key={customer.id} value={customer.id ?? ""}>
              {customer.name}
            </MenuItem>
          ))}
        </Select>
      </FormControl>
    </Box>
  );
}
