var dataTable;

$(document).ready(function () {

    dataTable = $('#designationTable').DataTable({

        "processing": true,
        "serverSide": false,
        "filter": true,
        "bAutoWidth": false,
        "rowHeight": 'auto',

        "ajax": {
            "url": "/Admin/Designation/GetAllDesignation",
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
                "width": "1%"
            },
            {
                "data": "designationName",

                "render": function (draw, type, row, data) {
                    return `<span class="">${row.designationName}</span>
                           
                            `
                },

                "width": "10%"
            },
            {
                "data": "department.departmentName",

                "render": function (draw, type, row, data) {
                    return ` <span class="badge rounded-pill bg-info">${row.department.departmentName}</span>
                            `
                },

                "width": "15%"
            },
            {
                "data": "designationId",
                "render": function (draw, type, row, data) {
                    return `
                          <div class="text-end">

                         <a href="/Admin/Designation/UpSert?id=${row.designationId}" class="mx-2"> <i class="bi bi-pencil-square"></i></a>
                           <a href="/" onClick = Delete('/Admin/Designation/Delete/${row.designationId}')  class="mx-2"> <i class="bi bi-trash"></i></a>

                          </div>                             
                           `
                },

                "width": "2%"
            }
        ]
    });
});


//<a href="/Admin/Designation/UpSert?id=${row.designationId}" class="mx-2"> <i class="bi bi-pencil-square"></i></a>
