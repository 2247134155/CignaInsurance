


/////////////////////////////////////////////////////////////////////////////////////////////////
           $(function () {
             
               //logring span
               $("#sp1").hide();
               $("sp2").hide();
                // preregister span
               $("sr1").hide();
               $("sr2").hide();
               $("sr3").hide();
               // forget password span
               $("#f1").hide();
              
               
               
               $("#usernameid").blur(function ()
               {
                   
                   checkusername("#usernameid", "#sp1", " UserName can not be empty!");

                   
               });
               $("#usn2").blur(function () {

                   checkusername("#usn2", "#f1", "UserName can not be empty!");


               });


               $("#passwordid").blur(function () {

                 
                   checkusername("#passwordid", "#sp2", "password can not be empty!");

               });
        
              
               $("#pr1").blur(function () {
                  
                   checkusername("#pr1", "#sr1", "UserName can not be empty!");

               });








           });

           function checkusername(x,s,m)
           {
               var user = $(x);
               if(user.val()=="" )
               {
                   $(s).html(m);
                   $(s).show();
                   err1 = true;
                   
               }
               else
               {
                   $(s).hide();
               }
           };
           function checkpassword() {
               var user = $("#passwordid");
               if (user.val() == "") {
                   $("#sp2").html('password can not be empty');
                   $("#sp2").show();
                   err1 = true;

               }
               else {
                   $("#sp2").hide();
               }
           };






 

