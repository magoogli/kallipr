import { Typography } from "@mui/material";
import { TelemetryEventList } from "../telemetryEvents/telemetryEventList";
import { TelemetryEventWindowInsights } from "../telemetryEvents/telemetryEventWindowInsights";
import { useCustomerId } from "../customerIdContext";
import { useParams } from "react-router";

export function DeviceDetails() {
  const { customerId } = useCustomerId();
  const { deviceId } = useParams();

  if (customerId && deviceId) {
    return (
      <InternalDeviceDetails
        customerId={customerId}
        selectedDeviceId={deviceId}
      />
    );
  }
  return <Typography variant="h4">No device selected</Typography>;
}

interface InternalDeviceDetailsProps {
  customerId: string;
  selectedDeviceId: string;
}

function InternalDeviceDetails(props: InternalDeviceDetailsProps) {
  const { customerId, selectedDeviceId } = props;

  return (
    <>
      <Typography variant="h4">Device Details</Typography>
      <TelemetryEventWindowInsights
        customerId={customerId}
        deviceId={selectedDeviceId}
      />
      <TelemetryEventList customerId={customerId} deviceId={selectedDeviceId} />
    </>
  );
}
