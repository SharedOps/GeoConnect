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
         var byteData = reader.result;
         $("#TXTBASE64").val(byteData)
         console.log(byteData);
         byteData = byteData.split(';')[1].replace("base64,", "");
         var obj = {};
         obj.Data = byteData;
         obj.Name = fileName;
         obj.ContentType = contentType;
         console.log(obj.Data);

         $.ajax({
             url: 'http://localhost/geoconnect/api/userRegistration/adduser',
             dataType: 'json',
             type: 'post',
             contentType: 'application/json',
             data: JSON.stringify({ "Name": "string1", "Mobile_no1": "string1", "Email": "string", "Location": "string", "Avatar": byteData, }),
             processData: false,
             success: function (data, textStatus, jQxhr) {
                 $('#success_message').html(JSON.stringify(data));
             },
             error: function (jqXhr, textStatus, errorThrown) {
                 console.log(errorThrown);
             }
         });
     });



 });




