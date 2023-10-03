
$(document).ready(function () {
    LoadDepartmentCount();
    LoadDesignationCount();
    LoadLocationCount();
    LoadEmployeeCount();
    LoadHolidayCount();

    LoadEmployeeTable();
    LoadDepartmentTable();
    LoadDesignationTable();
    LoadLocationTable();
    LoadHolidayTable();
});

const LoadEmployeeTable = function () {
    $.ajax({
        "url": "/pgt/api/EmployeeApi/Get",
        "method": "GET",
        success: function (response) {
            console.log(response);
            var rowData = "<tbody>";

            $.each(response, function (index, value) {
                rowData += `<tr >
                                <td>${index + 1}</td>
                                <td >${value.name}</td>
                                <td>${value.gender}</td>
                                <td>${value.employeeId}</td>                             
                                <td>${value.designation.designationName}</td>
                                <td>${value.location.locationName}</td>
                                </tr>`
            });
            rowData += "</tbody>"
            $("#dt_employee_view").append(rowData);
        },
        error: function (error) {
            console.log(error);
        }
    });
}

const LoadDepartmentTable = function () {
    $.ajax({
        "url": "/pgt/api/DepartmentApi/Get",
        "method": "GET",
        success: function (response) {
            var rowData = "<tbody>";

            $.each(response, function (index, value) {
                rowData += `<tr >
                                <td>${index + 1}</td>
                                <td >${value.departmentName}</td>                              
                                </tr>`
            });
            rowData += "</tbody>"
            $("#dt_department_view").append(rowData);
        },
        error: function (error) {
            console.log(error);
        }
    });
}

const LoadDesignationTable = function () {
    $.ajax({
        "url": "/pgt/api/DesignationApi/Get",
        "method": "GET",
        success: function (response) {
            var rowData = "<tbody>";

            $.each(response, function (index, value) {
                rowData += `<tr >
                                <td>${index + 1}</td>
                                <td >${value.designationName}</td>
                                </tr>`
            });
            rowData += "</tbody>"
            $("#dt_designation_view").append(rowData);
        },
        error: function (error) {
            console.log(error);
        }
    });
}

const LoadLocationTable = function () {
    $.ajax({
        "url": "/pgt/api/LocationApi/Get",
        "method": "GET",
        success: function (response) {
            var rowData = "<tbody>";

            $.each(response, function (index, value) {
                rowData += `<tr >
                                <td>${index + 1}</td>
                                <td >${value.locationName}</td>                              
                                </tr>`
            });
            rowData += "</tbody>"
            $("#dt_location_view").append(rowData);
        },
        error: function (error) {
            console.log(error);
        }
    });
}

const LoadHolidayTable = function () {
    $.ajax({
        "url": "/pgt/api/HolidayApi/Get",
        "method": "GET",
        success: function (response) {
            var rowData = "<tbody>";

            $.each(response, function (index, value) {
                rowData += `<tr >
                                <td>${index + 1}</td>
                                <td >${value.holidayName}</td>
                                <td >${value.holidayDate}</td>
                                <td >${value.remarks}</td>
                                </tr>`
            });
            rowData += "</tbody>"
            $("#dt_holiday_view").append(rowData);
        },
        error: function (error) {
            console.log(error);
        }
    });
}

const LoadDepartmentCount = function () {
    var url = "/pgt/api/DepartmentApi/GetCount"

    $.ajax({
        "url": url,
        "method": "GET",
        success: function (response) {
            COM.AddText("#cc_department", response.count)
        },
        error: function (error) {
            console.log(error);
        }
    });

    //var count = COM.AddCount(url);
    //count = COM.IsNanOrNull(count) ? "0" : count;
    //console.log(count);
    //COM.AddText("#cc_department", count);
}

const LoadDesignationCount = function () {
    var url = "/pgt/api/DesignationApi/GetCount"

    $.ajax({
        "url": url,
        "method": "GET",
        success: function (response) {
            COM.AddText("#cc_designation", response.count)
        },
        error: function (error) {
            console.log(error);
        }
    });

    //var count = COM.AddCount(url);
    //count = COM.IsNanOrNull(count) ? "0" : count;
    //COM.AddText("#cc_designation", count);
}

const LoadLocationCount = function () {
    var url = "/pgt/api/LocationApi/GetCount"

    $.ajax({
        "url": url,
        "method": "GET",
        success: function (response) {
            COM.AddText("#cc_location", response.count)
        },
        error: function (error) {
            console.log(error);
        }
    });

    //var count = COM.AddCount(url);
    //count = COM.IsNanOrNull(count) ? "0" : count;
    //COM.AddText("#cc_location", count);
}

const LoadHolidayCount = function () {
    var url = "/pgt/api/HolidayApi/GetCount"

    $.ajax({
        "url": url,
        "method": "GET",
        success: function (response) {
            COM.AddText("#cc_holiday", response.count)
        },
        error: function (error) {
            console.log(error);
        }
    });

    //var count = COM.AddCount(url);
    //count = COM.IsNanOrNull(count) ? "0" : count;
    //COM.AddText("#cc_holiday", count);
}


const LoadEmployeeCount = function () {
    var url = "/pgt/api/EmployeeApi/GetCount"

    $.ajax({
        "url": url,
        "method": "GET",
        success: function (response) {
            COM.AddText("#cc_employee", response.count)
        },
        error: function (error) {
            console.log(error);
        }
    });

    //var count = COM.AddCount(url);
    //count = COM.IsNanOrNull(count) ? "0" : count;
    //COM.AddText("#cc_employee");
}

