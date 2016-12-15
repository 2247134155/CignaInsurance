


/////////////////////////////////////////////////////////////////////////////////////////////////
$(function () {

    //logring span
    $("#fs1").hide();
    $("#fs2").hide();
    // preregister span
    $("#fs3").hide();
  

    $("#f1").blur(function () {

        checkusername("#f1", "#fs1", " Name can not be empty!");


    });
    $("#f2").blur(function () {
        
        checkusername("#f2", "#fs2", "Last Name can not be empty!");


    });


    $("#f3").blur(function () {


        checkusername("#f3", "#fs3", "Date can not be empty!");

    });





});

function checkusername(x, s, m) {
    var user = $(x);
    if (user.val() == "") {
        $(s).html(m);
        $(s).show();
        err1 = true;

    }
    else {
        $(s).hide();
    }
};








