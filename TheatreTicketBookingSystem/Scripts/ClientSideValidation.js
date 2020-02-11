
// Check if name is valid
$.validator.unobtrusive.adapters.addBool("isnamevalid");
$.validator.addMethod('isnamevalid',
    function (value) {
        var specialCharacters = "~!@#$%^&*()_+<>?\":;\\{}|\'[]=";
        for (var i = 0; i < value.length; i++) {
            for (var c = 0; c < specialCharacters.length; c++) {
                if (value.charAt(i) == specialCharacters.charAt(c)) {
                    return false;
                }
            }
        }
        return true;
    });

// Check if date is valid
$.validator.unobtrusive.adapters.addBool("isdatevalid");
$.validator.addMethod('isdatevalid',
    function (value) {
        if (new Date(value).toString() === "Invalid Date") {
            return false;
        }
        return true;
    });

// Check if email is valid
$.validator.unobtrusive.adapters.addBool("isemailvalid");
$.validator.addMethod('isemailvalid',
    function (value) {
        return /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(value);
    });