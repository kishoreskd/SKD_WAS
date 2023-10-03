var dataTable;

$(document).ready(function () {
    dataTable = $('#holidayTable').DataTable({

        "processing": true,
        "serverSide": true,
        "filter": true,
        //"bAutoWidth": false,

        "ajax": {
            "url": "/Admin/Holiday/GetAllHolidays",
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
                "data": "holidayName",

                "render": function (draw, type, row, data) {
                    return `${row.holidayName}`
                },

                "width": "25%"
            },
            {
                "data": "holidayDate",

                "render": function (draw, type, row, data) {
                    return `${row.holidayDate}`
                },

                "width": "25%"
            },
            {
                "data": "description",

                "render": function (draw, type, row, data) {
                    return COM.IsNullOrEmpty(row.remarks) ? " " : row.remarks;
                },

                "width": "25%"
            },
            {
                "data": "holidayId",
                "render": function (draw, type, row, data) {
                    return `
                            <div  class="text-end">
                                <a href="/Admin/Holiday/UpSert?id=${row.holidayId}"> <i class="bi bi-pencil-square"></i></a>
                                <a onClick = Delete('/Admin/Holiday/Delete/${row.holidayId}')  class="mx-2"> <i class="bi bi-trash"></i></a>
                            </div>`
                },

                "width": "6%"
            }
        ]
    });
});


