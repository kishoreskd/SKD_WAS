var dataTable;
var i;

$(document).ready(function () {
    dataTable = $('#employeeTable').DataTable({

        "processing": true,
        "serverSide": true,
        "filter": true,
        "bAutoWidth": false,
        //"rowHeight": 'auto',
        "pagingType": "full_numbers",

        "ajax": {
            "url": "/Admin/Employee/GetAllEmployee",
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
                "data": "name",
                "render": function (draw, type, row, data) {
                    console.log(row);
                    return `
                            <span >${row.name}</span>
                            <div class="pl-0">
                            <span class="text-end badge bg-primary">${row.employeeId}</span>
                            <span class="badge bg-secondary">${row.designation.designationName}</span>
                            <span class="badge bg-info">Reporting To:${COM.ObjIsNull(row.reportingTo) ? "N/A" : row.reportingTo.name}</span>
                            </div>                          
                            `
                },
                "width": "15%"
            },
            {
                "data": "dob",
                "width": "0%"

            },
            { "data": "emailID" },
            {
                "data": "gender",
            },
            { "data": "mobileNumber" },
            { "data": "bloodGroup" },
            {
                "data": "address",
                "width": "10%"
            },
            { "data": "dateOfJoining" },
            { "data": "totalExperiance" },
            {
                "data": "location",
                "render": function (draw, type, row, data) {
                    return `<span>${row.location.locationName}</span> `
                },
            },
            {
                "data": "id",
                "render": function (draw, type, row, data) {

                    return `
                        <div class="text-end">
                        <a  href="/Admin/Employee/UpSert?id=${row.id}" class="mx-2"> <i class="bi bi-pencil-square"></i></a>
                        <a   onClick = Delete('/Admin/Employee/Delete/${row.id}')  class="mx-2"> <i class="bi bi-trash"></i></a>
                        </div>`
                },

            }
        ]
    });

    $("#accordion").accordion();
});

