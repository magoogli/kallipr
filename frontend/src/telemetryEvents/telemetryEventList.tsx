import { DataGrid, type GridColDef } from "@mui/x-data-grid";
import Paper from "@mui/material/Paper";
import { type TelemetryEventDto } from "../client/api";
import { useListTelemetryEvents } from "../api/devices";

const columns: GridColDef<TelemetryEventDto>[] = [
  { field: "eventId", headerName: "Event Id", width: 100 },
  { field: "recordedAt", headerName: "Recorded At", width: 100 },
  { field: "type", headerName: "Type", width: 100 },
  { field: "value", headerName: "Value", width: 100 },
  { field: "unit", headerName: "Unit", width: 100 },
];

const paginationModel = { page: 0, pageSize: 5 };

export interface TelemetryEventListProps {
  customerId: string;
  deviceId: string;
}

export function TelemetryEventList({
  customerId,
  deviceId,
}: TelemetryEventListProps) {
  const { data: devices, isLoading } = useListTelemetryEvents(
    customerId,
    deviceId,
  );

  return (
    <Paper sx={{ height: 400, width: "100%" }}>
      <DataGrid
        getRowId={(_) => _.eventId ?? ""}
        loading={isLoading}
        rows={devices?.data ?? []}
        columns={columns}
        initialState={{ pagination: { paginationModel } }}
        pageSizeOptions={[5, 10]}
        checkboxSelection
        sx={{ border: 0 }}
      />
    </Paper>
  );
}
