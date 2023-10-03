var dataTable;

$(document).ready(function () {
    dataTable = $('#departmentTable').DataTable({

        "processing": true,
        "serverSide": true,
        "filter": true,
        //"bAutoWidth": false,
        responsive: true,
        select: true,
        "ajax": {
            "url": "/Admin/Department/GetAllDepartment",
            "type": "POST",
            "dataType": "json",
            "data": "json",
            //"traditional": true
        },

        "columnDefs": [
            {
                "targets": [0, 1, 2], //selecting the edit and delete column
                "searchable": false,
                "bSortable": false
            },
        ],

        "columns": [

            {
                "data": "#",
                "render": function (draw, type, row, data) {
                    return data.row + data.settings._iDisplayStart + 1;
                },
                "width": "10%"
            },
            {
                "data": "departmentName",

                "render": function (draw, type, row, data) {
                    return `${row.departmentName}`
                },

                "width": "25%"
            },
            {
                "data": "departmentId",
                "render": function (draw, type, row, data) {
                    return `
                            <div  class="text-end">
                                <a " href="/Admin/Department/UpSert?id=${row.departmentId}"> <i class="bi bi-pencil-square"></i></a>
                                <a  " onClick = Delete('/Admin/Department/Delete/${row.departmentId}')  class="mx-2"> <i class="bi bi-trash"></i></a>
                            </div>`
                },

                "width": "6%"
            }
        ]
    });
});


