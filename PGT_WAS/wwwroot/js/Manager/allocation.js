var dataTable;

function format(d) {

    var na = "N/A";

    var mainStart = COM.IsNullOrEmpty(d.mainStartDt) ? na : d.mainStartDt;
    var miscStartDate = COM.IsNullOrEmpty(d.miscStartDate) ? na : d.miscStartDate;
    var mainSubmissionDt = COM.IsNullOrEmpty(d.projectEstimation.mainSubmissionDt) ? na : d.projectEstimation.mainSubmissionDt;
    var miscSubmissionDt = COM.IsNullOrEmpty(d.projectEstimation.miscSubmissionDt) ? na : d.projectEstimation.miscSubmissionDt;



    return (
        `<dl>
           <table class="table table-hover" style="width:100%">

                    <thead style="font-size:11px">
                        <tr>
                            <th>Allocation</th>
                            <th >Main (Input)</th>
                            <th >Misc (Input)</th>
                            <th >Main (Result)</th>
                            <th >Misc (Result)</th>

                        </tr>
                    </thead>

                    <tbody class="table-light">
                        <tr>
                            <td>Hours</td>
                            <td >${d.mainAllocation.hours}</td>
                            <td >${d.miscAllocation.hours}</td>
                            <td >${d.mainAllocation.hours}</td>
                            <td >${d.miscAllocation.hours}</td>
                        </tr>
                        <tr>
                            <td>Submission Date</td>
                            <td id="td_mainsubmission">${d.mainAllocation.startDate}</td>
                            <td id="td_miscSubmission">${d.miscAllocation.startDate}</td>
                            <td id="td_mainsubmission">${d.mainAllocation.submissionDate}</td>
                            <td id="td_miscSubmission">${d.miscAllocation.submissionDate}</td>
                        </tr>
                        <tr>
                            <td>Ratio</td>
                            <td id="td_main_ratio">${d.ratio}</td>
                            <td id="td_misc_raio">${d.ratio}</td>
                            <td id="td_main_ratio">${d.projectEstimation.ifAr1r2}</td>
                            <td id="td_misc_raio">${d.projectEstimation.ifFr1r2}</td>
                                          
                        </tr>
                        <tr>
                            <td>Resource</td>
                            <td id="td_resourceMain">IFA: ${d.projectEstimation.ifAr1r2.split(" ")[0]} / (Production hours: ${d.whPerday} x Schedule days ${d.mainSDt})</td>
                              <td id="td_resourceMisc">IFA: ${d.projectEstimation.ifFr1r2.split(" ")[0]} / (Production hours: ${d.whPerday} x Schedule days ${d.miscSDt})</td>
                            <td id="td_resourceMain">${d.projectEstimation.resourcesMain}</td>
                            <td id="td_resourceMisc">${d.projectEstimation.resourcesMisc}</td>
                        </tr>
                        <tr>
                            <td>Resource need of modelers</td>
                            <td id="td_mainMnd">${d.mainModelersNdPercent}%</td>
                            <td id="td_miscMnd">${d.miscModelersNdPercent}%</td>
                            <td id="td_mainMnd">${d.projectEstimation.mainMNd}</td>
                            <td id="td_miscMnd">${d.projectEstimation.miscMNd}</td>
                        </tr>
                        <tr>
                            <td>Resource need of detailers</td>
                            <td id="td_mainDnd">${d.mainDetilersNdPercent}%</td>
                            <td id="td_miscDnd">${d.miscDetilersNdPercent}%</td>
                            <td id="td_mainDnd">${d.projectEstimation.mainDNd}</td>
                            <td id="td_miscDnd">${d.projectEstimation.miscDNd}</td>
                        </tr>
                        <tr>
                            <td>Resource need of checkers</td>
                            <td id="td_mainCnd">${d.mainCheckersNdPercent}%</td>
                            <td id="td_miscCnd">${d.miscCheckersNdPercent}%</td>
                            <td id="td_mainCnd">${d.projectEstimation.mainCNd}</td>
                            <td id="td_miscCnd">${d.projectEstimation.miscCNd}</td>
                        </tr>
                    </tbody>

                </table>
        </dl>`
    );
}


$(document).ready(function () {
    dataTable = $('#projectAllocationTable').DataTable({

        "processing": true,
        "serverSide": true,
        "filter": true,
        //"bAutoWidth": false,
        pagingType: 'full_numbers',
        "ajax": {
            "url": "/Manager/ProjectAllocation/GetAllProjectAllocation",
            "type": "POST",
            "dataType": "json",
            "data": "json",
            //"traditional": true
        },

        columns: [
            //{
            //    className: 'dt-control',
            //    orderable: false,
            //    data: null,
            //    defaultContent: '',
            //    width: "1%"
            //},
            {
                "data": "#",
                "render": function (draw, type, row, data) {
                    return data.row + data.settings._iDisplayStart + 1;
                },
                "width": "1%"
            },
            {
                data: 'pgtJobNumber',
                width: "9%",
                className: "text-center",
            },
            {
                data: 'clientName',
                className: "text-center",

            },
            {
                data: 'projectName',
                className: "text-center",

            },
            {
                data: 'clientJobNumber',
                className: "text-center",

            },
            {
                "data": "projectId",
                "render": function (draw, type, row, data) {
                    return `
                            <div  class="text-end">
                                <a " href="/Manager/ProjectAllocation/UpSert?id=${row.projectAllocationId}"> <i class="bi bi-pencil-square"></i></a>
                                <a  " onClick = Delete('/Manager/ProjectAllocation/Delete/${row.projectAllocationId}')  class="mx-2"> <i class="bi bi-trash"></i></a>
                            </div>`
                },

                "width": "7%"
            }
        ],
    });

    //dataTable.on('click', 'td.dt-control', function (e) {
    //    let tr = e.target.closest('tr');
    //    let row = dataTable.row(tr);

    //    if (row.child.isShown()) {
    //        // This row is already open - close it
    //        row.child.hide();
    //    }
    //    else {
    //        // Open this row
    //        console.log(row.data());
    //        row.child(format(row.data())).show();
    //    }
    //});
});



