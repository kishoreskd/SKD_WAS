class COM {

    //VALIDATION
    static IsValidCount(x) {
        return x > 0;
    };

    static IsNanOrNull(x) {

        if (x == null || isNaN(x) || x == undefined) {
            return true;
        } else {
            return false;
        }
    }

    static ObjIsNull(obj) {
        if (obj === null) {
            return true;
        } else {
            return false;
        }
    }

    static IsNullOrEmpty(x) {

        if (x === null || x.trim().length === "") {
            return true;
        } else {
            return false;
        }
    }

    static IsValidId(x) {
        return parseInt(x) > 0;
    }

    static OnSetRangeHandler(input) {

        if (input.value < 0) input.value = 0;
        if (input.value > 100) input.value = 0;
    }

    static IsNumber(evt) {
        evt = (evt) ? evt : window.event;
        var charCode = (evt.which) ? evt.which : evt.keyCode;
        if (charCode > 31 && (charCode < 48 || charCode > 57)) {
            return false;
        }
        return true;
    }

    static IsNanOrInfinity(x) {
        if (isNaN(x) || !isFinite(x)) {
            return true
        }
        else { return false };
    }

    //CONVERSION
    static ConvertFloat(x) {
        return parseFloat(x);
    }


    static GetPercent(percent, val) {
        return val * percent / 100;
    }

    ////string
    static ParseDate(input) {


        var parts = input.match(/(\d+)/g);
        // new Date(year, month [, date [, hours[, minutes[, seconds[, ms]]]]])
        return new Date(parts[2], parts[1] - 1, parts[0]); // months are 0-based
    }

    static StringToDate(input) {

        var parts = input.split("-");
        // new Date(year, month [, date [, hours[, minutes[, seconds[, ms]]]]])

        return new Date(parseInt(parts[0]), parseInt(parts[1]) - 1, parseInt(parts[2])); // months are 0-based
    }

    static GetFormatedDateObject(input) {

        var date = new Date(input);

        var year = date.getFullYear();
        var month = '' + (date.getMonth() + 1);
        var day = '' + date.getDate();

        if (month.length < 2) {
            month = "0" + month;
        }
        if (day.length < 2) {
            day = "0" + day;
        }


        var d = new Date(year, parseInt(month) - 1, parseInt(day));

        return new Date(year, parseInt(month) - 1, parseInt(day));
    }

    //new Date();
    static ParseDateOfObject(input) {


        return `${input.getDate().toString()}/${input.getMonth() + 1}/${input.getFullYear()}`;
    }

    //ADD
    static AddText(id, text) {
        $(id).text(text);
    }


    //Log
    static _L(val) {
        console.log(val);
    }




    static GetStautsLabel(status) {
        var label = "primary";

        switch (status) {
            case SD.Completed:
                label = "success";
                break;
            case SD.InProgress:
                label = "warning";
                break;
        }

        return label;
    }


    static CaculatePercent(startDate, endDate) {

        var result = {};

        var today = COM.GetFormatedDateObject(new Date());

        var start = COM.StringToDate(startDate);
        var end = COM.StringToDate(endDate);

        var p = Math.max(0, Math.round(((today - start) / (end - start)) * 100));
        p = p >= 100 ? 100 : p;

        result.percent = p + "%";

        switch (p) {
            case 100:
                result.status = SD.Completed;
                break;
            case 0:
                result.status = SD.NotStartYet;
                break;
            default:
                result.status = SD.InProgress;
                break;
        }

        return result;
    }


}

class SD {


    static InProgress = "In progress."
    static Planed = "Planned."
    static Completed = "Completed."


    static Leave = "Leave";
    static Training = "Training";
    static NoticePeriod = "NoticePeriod";
    static NotStartYet = "Not start yet.";


}