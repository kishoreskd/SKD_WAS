var dataTable;

function format(d) {

    var items = "";

    $.each(d.activity, (index, act) => {
        items += TableCreation(act, index);
    });

    items = `<dl>
                <table  class="table table" style="width:100%">
                         <thead style="display:none;">
                            <tr>    
                                <th class="text-left"></th>
                                <th class="text-center"></th>
                                <th class="text-right"></th>
                            </tr>
                         </thead>
                   <tbody>
                      ${items}
                   </tbody>
             </table>
           </dl>`

    //< th ></th >
    //    <th width="10%"></th>
    return (items);
}


const TableCreation = function (act, index) {

    var percent = COM.CaculatePercent(act.startDate, act.endDate)
    var progressLabel = COM.GetStautsLabel(percent.status);

    //<td><div class="progress">
    //                        <div  class="progress-bar bg-${progressLabel}" role="progressbar" style="width: ${percent.percent};font-size: 10px" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100">${percent.percent}</div>
    //                       </div></td>

    //                   <td><span class="badge rounded-pill bg-${progressLabel}">${percent.status}</span></td>

    var items = `<tr  class="table-light child-row">              
                        <td class="text-left"> <span class="badge rounded-pill bg-info"><i class="bi bi-calendar"></i>&nbsp ${act.startDate}</span> - <span class="badge rounded-pill bg-danger"><i class="bi bi-calendar"></i>&nbsp ${act.endDate}</span></td>
                        
                        <td  class="text-right"><span class="badge rounded-pill bg-secondary">${COM.ObjIsNull(act.userTaskStatus) ? " " : act.userTaskStatus.status} ${COM.IsNullOrEmpty(act.description) ? " " : "(" + act.description + ")"}</span></td>
                        <td class="text-right"><span class="badge bg-success"><i class="bi bi-briefcase"></i>&nbsp ${COM.ObjIsNull(act.project) ? " " : act.project.pgtJobNumber}</span></td >
                      </tr>              
                    `
    return items;
}




$(document).ready(function () {
    dataTable = $('#dt_team_tasks').DataTable({

        "processing": false,
        "serverSide": true,
        "filter": false,
        "iDisplayLength": 100,
        "searching": false,
        "info": false,
        "lengthChange": false,
        'paging': false,
        "ajax": {
     
            "url": "/TeamLead/TeamPlan/GetAllTasks",
            "type": "POST",
            "dataType": "json",         
        },

        columns: [
            {
                className: 'dt-control',
                orderable: false,
                data: null,
                defaultContent: '',
                width: "0%",
            },
            {
                "data": "#",
                "render": function (draw, type, row, data) {
                    return data.row + data.settings._iDisplayStart + 1;
                },
                "width": "0%",
                'orderable': false,
                "className": "text-center",
            },         

            {
                "data": "label",
                "render": function (draw, type, row, data) {
                    return `<span class="btn  btn-outline-primary btn-sm">${row.label}</span>
                            <span class="badge rounded-pill bg-warning">${row.designation}</span>`;
                },
                "width": "20%",
                "orderable": false,
                "className": "text-left",
            },

        ],
        createdRow: function (row, data, dataIndex) {
            $(row).addClass('primary-row');
        },
    });


    dataTable.on('click', 'td.dt-control', function (e) {
        let tr = e.target.closest('tr');
        let row = dataTable.row(tr);

        if (row.child.isShown()) {
            // This row is already open - close it
            row.child.hide();
        }
        else {
            // Open this row
            row.child(format(row.data())).show();
        }
    });

});



