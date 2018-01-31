
$(document).ready(function () {
            $('.validateNumber').on('keydown', function (e) {

-1 !== $.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) || /65|67|86|88/.test(e.keyCode) && (!0 === e.ctrlKey || !0 === e.metaKey) || 35 <= e.keyCode && 40 >= e.keyCode || (e.shiftKey || 48 > e.keyCode || 57 < e.keyCode) && (96 > e.keyCode || 105 < e.keyCode) && e.preventDefault()
            });


    $('.validateDate').change(function () {
        
        debugger;
        var result = true;
        var dateformat = /^(19|20)\d\d-(0\d|1[012])-(0\d|1\d|2\d|3[012])$/;
        var Val_date = $(this).val();
        $(this).css("border-color", "");
        if (Val_date.match(dateformat)) {
            var seperator1 = Val_date.split('/');
            var seperator2 = Val_date.split('-');

            if (seperator1.length > 1) {
                var splitdate = Val_date.split('/');
            }
            else if (seperator2.length > 1) {
                var splitdate = Val_date.split('-');
            }
            var yy = parseInt(splitdate[0]);
            var mm = parseInt(splitdate[1]);
            var dd = parseInt(splitdate[2]);

            var ListofDays = [32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32];
            if (mm == 1 || mm > 2) {
                if (dd > ListofDays[mm - 1]) {
                    $(this).css("border-color", "red");
                    //$(this).val('');
                    alert('Invalid date format1!');
                    result = false;
                }
            }
            if (mm == 2) {
                var lyear = false;
                if ((!(yy % 4) && yy % 100) || !(yy % 400)) {
                    lyear = true;
                }
                if ((lyear == false) && (dd >= 32)) {
                    $(this).css("border-color", "red");
                    //$(this).val('');
                    alert('Invalid date format2!');

                    result = false;
                }
                if ((lyear == true) && (dd > 32)) {
                    $(this).css("border-color", "red");
                   // $(this).val('');
                    alert('Invalid date format3!');

                    result = false;
                }
            }
        }
        else {
            $(this).css("border-color", "red");
           // $(this).val('');
            alert("Invalid date format4!");

            result = false;
        }
        $(this).focus();
        return result;
    });
});
function validateDate(name) {
    
        debugger;
        var result = true;
        var dateformat = /^(19|20)\d\d-(0\d|1[012])-(0\d|1\d|2\d|3[012])$/;
        var Val_date = $('#'+name).val();
      
        if (Val_date.match(dateformat)) {
            var seperator1 = Val_date.split('/');
            var seperator2 = Val_date.split('-');

            if (seperator1.length > 1) {
                var splitdate = Val_date.split('/');
            }
            else if (seperator2.length > 1) {
                var splitdate = Val_date.split('-');
            }
            var yy = parseInt(splitdate[0]);
            var mm = parseInt(splitdate[1]);
            var dd = parseInt(splitdate[2]);

            var ListofDays = [32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32];
            if (mm == 1 || mm > 2) {
                if (dd > ListofDays[mm - 1]) {

                    alert('Invalid date format!');
                    result = false;
                }
            }
            if (mm == 2) {
                var lyear = false;
                if ((!(yy % 4) && yy % 100) || !(yy % 400)) {
                    lyear = true;
                }
                if ((lyear == false) && (dd >= 32)) {

                    alert('Invalid date format!');

                    result = false;
                }
                if ((lyear == true) && (dd > 32)) {

                    alert('Invalid date format!');

                    result = false;
                }
            }
        }
        else {

            alert("Invalid date format!");

            result = false;
        }
       
        return result;
    
}

function unicodeToEngNumber(field) {
    debugger;
    var unicodeVal = field.value;
 
    var leng = unicodeVal.length;
    var i = 0;
    var result = '';
    var str = '';
    for (i = 0; i < leng; i++) {
        str = unicodeVal.substr(i, 1);
        
        if (str == '०') {
            str = '0';
        }
        else if (str == '१') {
            str = '1';
        }
        else if (str == '२') {
            str = '2';
        }
        else if (str == '३') {
            str = '3';
        }
        else if (str == '४') {
            str = '4';
        }
        else if (str == '५') {
            str = '5';
        }
        else if (str == '६') {
            str = '6';
        }
        else if (str == '७') {
            str = '7';
        }
        else if (str == '८') {
            str = '8';
        }
        else if (str == '९') {
            str = '9';
        }
        
        result = result + str;
    }
    field.value = result;
}