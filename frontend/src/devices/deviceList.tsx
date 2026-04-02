import { DataGrid, type GridColDef } from "@mui/x-data-grid";
import Paper from "@mui/material/Paper";
import { type DeviceDto } from "../client/api";
import { useListDevices } from "../api/devices";
import { useNavigate } from "react-router";

const columns: GridColDef<DeviceDto>[] = [
  { field: "deviceId", headerName: "Device Id", width: 100 },
  { field: "label", headerName: "Label", width: 100 },
  { field: "location", headerName: "Location", width: 100 },
];

const paginationModel = { page: 0, pageSize: 10 };

export interface DeviceListProps {
  customerId: string;
}

export function DeviceList({ customerId }: DeviceListProps) {
  const navigate = useNavigate();
  const { data: devices, isLoading } = useListDevices(customerId);

  return (
    <Paper sx={{ height: 400, width: "100%" }}>
      <DataGrid
        onRowClick={(_) => {
          navigate(`/device/${_.row.deviceId}`);
        }}
        getRowId={(_) => _.deviceId ?? ""}
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
