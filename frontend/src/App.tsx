import { useListCustomers } from "./api/customers";

function App() {
  const { data: customers, isLoading } = useListCustomers();

  return (
    <>
      {customers?.data?.map((customer) => (
        <div key={customer.id}>{customer.name}</div>
      ))}
    </>
  );
}

export default App;
