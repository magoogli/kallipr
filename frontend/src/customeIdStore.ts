let customerId: string | null = null;

export const setCustomerId = (value: string | null) => {
  customerId = value;
};

export const getCustomerId = () => customerId;
