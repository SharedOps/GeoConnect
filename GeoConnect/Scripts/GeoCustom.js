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
         byteData = byteData.split(';')[1].replace("base64,", "");
         var obj = {};
         obj.Data = byteData;
         obj.Name = fileName;
         obj.ContentType = contentType;
         console.log(obj.Data);
     });


 });

