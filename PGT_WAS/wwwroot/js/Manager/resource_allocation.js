
var dataTable;


$(document).ready(function () {
    dataTable = $('#tb_resource_allocation').DataTable({

        "processing": true,
        "serverSide": true,
        "filter": true,
        //"bAutoWidth": false,

        "ajax": {
            "url": "/Manager/ResourceAllocation/GetAllResourceAllocation",
            "type": "POST",
            "dataType": "json",
            "data": "json",
            //"traditional": true
        },

        columns: [
            {
                "data": "#",
                "render": function (draw, type, row, data) {
                    return data.row + data.settings._iDisplayStart + 1;
                },
                "width": "1%"
            },
            {
                data: 'pgtJobNumber',
                render: function (draw, type, row, data) {
                    console.log(row);
                    return `<a href="/Manager/Allocation/UpSert?id=${row.projectId}"><b>${row.pgtJobNumber}</b></a>`;
                },
                width: "9%"
            }
        ],
    });
});