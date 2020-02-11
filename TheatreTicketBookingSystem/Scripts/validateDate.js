function validateForm() {
    var date = document.forms[0]["date"].value;
    var element = document.getElementById("error");

    if (date === "") {
        SetInnerHtml(element, "Date is a required field");
        AddToClassList(element, "text-danger");
        return false;
    }

    if (new Date(date).toString() === "Invalid Date") {
        SetInnerHtml(element, "You Entered Invalid date.An example of correct date is 2020-10-28");
        AddToClassList(element, "text-danger");
        return false;
    }
    else
        return true;

    function AddToClassList(element, className) {
        element.classList.add(className);
    }

    function SetInnerHtml(element, value) {
        element.innerHTML = value;
    }
}