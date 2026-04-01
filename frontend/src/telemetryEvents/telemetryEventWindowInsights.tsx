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
    <Paper sx={{ height: 400, width: "100%" }}>
      {insights && (
        <>
          Latest Value: {insights.data.latestValue}
          Average Value: {insights.data.averageValue}
          Minimum Value: {insights.data.minimumValue}
          Maximum Value: {insights.data.maximumValue}
        </>
      )}
    </Paper>
  );
}
