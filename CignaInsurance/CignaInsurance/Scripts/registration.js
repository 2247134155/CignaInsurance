$(function () {
    $("#p1").hide();
    $("#p2").hide();
    $("#p3").hide();
    $("#p4").hide();
    $("#p5").hide();
    $("#p6").hide();
    $("#p7").hide();
    $("#p8").hide();
    $("#p9").hide();
    $("#p10").hide();
    $("#p11").hide();


    $("#r1").blur(function () {
        checkusername("#r1", "#p1", "Name can not be empty!");

    });
    $("#r2").blur(function () {
        checkusername("#r2", "#p2", "Last Name can not be empty!");

    });

    $("#r3").blur(function () {
        checkusername("#r3", "#p3", "DOB can not be empty!");

    });

    $("#r4").blur(function () {
        checkusername("#r4", "#p4", "Address can not be empty!");

    });

    $("#r5").blur(function () {
        checkusername("#r5", "#p5", "Phone can not be empty!");

    });

    $("#r6").blur(function () {
        checkusername("#r6", "#p6", "City can not be empty!");

    });

    $("#r7").blur(function () {
        checkusername("#r7", "#p7", "State can not be empty!");

    });

    $("#r8").blur(function () {
        checkusername("#r8", "#p8", "Zipcode can not be empty!");

    });


    $("#r9").blur(function () {
        checkusername("#r9", "#p9", "Email can not be empty!");

    });

    $("#r10").blur(function () {
        checkusername("#r10", "#p10", "Gender can not be empty!");

    });

    $("#r11").blur(function () {
        checkusername("#r11", "#p11", "SSN can not be empty!");

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
function equalpassword(x, xx, s, m) {
    var user = $(x);
    var user2 = $(xx);
    if (user.val() != user2.val()) {
        $(s).html(m);
        $(s).show();
        err1 = true;

    }
    else {
        $(s).hide();
    }
};


