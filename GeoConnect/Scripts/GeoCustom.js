function encodeImageFileAsURL(cb) {
    return function(){
        var file = $("GeoAvatarForm").prop('files')[0];
        var reader  = new FileReader();
        reader.onloadend = function () {
            cb(reader.result);
        }
        reader.readAsDataURL(file);
    }
}

var addUser = "#AddUserDetails";

$(addUser).click(function () {
    var imageStream = encodeImageFileAsURL(function (base64Img) {
        alert(base64Img);
    }); 
});