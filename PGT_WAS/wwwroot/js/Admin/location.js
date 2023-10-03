var dataTable;

$(document).ready(function () {
    dataTable = $('#locationTable').DataTable({

        "processing": true,
        "serverSide": true,
        "filter": true,
        "bAutoWidth": false,

        "rowHeight": 'auto',

        "ajax": {
            "url": "/Admin/Location/GetAllLocation",
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
                "data": "locationName",

                "render": function (draw, type, row, data) {
                    return `${row.locationName}`
                },

                "width": "25%"
            },
            {
                "data": "locationId",
                "render": function (draw, type, row, data) {
                    return `
                        <div class="text-end">
                          <a  href="/Admin/Location/UpSert?id=${row.locationId}" class="mx-2"> <i class="bi bi-pencil-square"></i></a>
                          <a  onClick = Delete('/Admin/Location/Delete/${row.locationId}')  class="mx-2"> <i class="bi bi-trash"></i></a>
                        </div>                             
                            `
                    
                },
                "width": "4%"
            }
        ]
    });
});




//function Delete(url) {
//    Swal.fire({

//        title: 'Are you sure?',
//        text: "You won't be able to revert this!",
//        icon: 'warning',
//        showCancelButton: true,
//        confirmButtonColor: '#3085d6',
//        cancelButtonColor: '#d33',
//        confirmButtonText: 'Yes, delete it!'

//    }).then((result) => {
//        if (result.isConfirmed) {
//            $.ajax({
//                url: url,
//                type: 'Delete',
//                success: function (data) {
//                    if (data.success) {
//                        dataTable.ajax.reload();
//                        toastr.success(data.msg);
//                    } else {
//                        toastr.error(data.msg);
//                    }
//                }
//            })
//        }
//    })
//}