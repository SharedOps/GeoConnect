 $(function () {
    var reader = new FileReader();
    var fileName;
    var contentType;
     $('[id*=GeoAvatarForm]').change(function () {
        if (typeof (FileReader) != "undefined") {
            var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.jpg|.jpeg|.gif|.png|.bmp)$/;
            $($(this)[0].files).each(function () {
                var file = $(this);
                if (regex.test(file[0].name.toLowerCase())) {
                    fileName = file[0].name;
                    contentType = file[0].type;
                    reader.readAsDataURL(file[0]);
                    $("#TXTBASE64").val(reader.result)
                } else {
                    alert(file[0].name + " is not a valid image file.");
                    return false;
                }
            });
        } else {
            alert("This browser does not support HTML5 FileReader.");
        }
     });

     var addUser = "#AddUserDetails";

     $(addUser).click(function () {
         var x = reader.result;
         $.ajax({
             url: 'http://localhost/geoconnect/api/userRegistration',
             dataType: 'json',
             type: 'post',
             contentType: 'application/json',
             data: JSON.stringify({ "Name": "string1", "Mobile_no": "string1", "Email": "string", "Location": "string", "Avatar": x}),
             processData: false,
             success: function (data, textStatus, jQxhr) {
                 $('#success_message').html(JSON.stringify(data));
                 console.log(xhr.status);
             },
             error: function (jqXhr, textStatus, errorThrown) {
                 console.log(errorThrown);
             }
         });
     });



 });




