import { DataGrid, type GridColDef } from "@mui/x-data-grid";
import Paper from "@mui/material/Paper";
import { type TelemetryEventDto } from "../client/api";
import { useGetTelemetryEventsWindowInsights } from "../api/devices";

export interface TelemetryEventWindowInsightsProps {
  customerId: string;
  deviceId: string;
}

export function TelemetryEventWindowInsights({
  customerId,
  deviceId,
}: TelemetryEventWindowInsightsProps) {
  const { data: insights, isLoading } = useGetTelemetryEventsWindowInsights(
    customerId,
    deviceId,
  );

  return (
    <Paper>
      {insights && (
        <>
          Latest Value: {insights.data.latestValue}
          <br />
          Average Value: {insights.data.averageValue}
          <br />
          Minimum Value: {insights.data.minimumValue}
          <br />
          Maximum Value: {insights.data.maximumValue}
          <br />
        </>
      )}
    </Paper>
  );
}
