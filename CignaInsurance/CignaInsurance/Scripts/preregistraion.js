$(function () {
    $("#sr1").hide();
    $("#sr2").hide();
    $("#sr3").hide();
   

    $("#x1").blur(function () {
        checkusername("#x1", "#xx1", "UserName can not be empty!");
   
    });

    $("#x2").blur(function () {
        
        checkusername("#x2", "#xx2", "password can not be empty!");

    });

    $("#x3").blur(function () {

        var sq = $("#x3");
        if(sq.val()=="")
            checkusername("#x3", "#xx3", "password can not be empty!");
        else equalpassword("#x3", "#x2", "#xx3", "password dont match!")

      
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
function equalpassword (x,xx, s, m) { // txt 3 txt2 sp 3 mess
    var user = $(x);// txt3
    var user2 = $(xx);// txt2
    if (user.val() != user2.val()) {
        $(s).html(m);
        $(s).show();
        err1 = true;

    }
    else {
        $(s).hide();
    }
};


