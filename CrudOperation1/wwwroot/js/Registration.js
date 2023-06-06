    $(document).ready(function () {

        $("#myRegistrationFormBtn").prop("disabled", true);
    $("#exampleCheck1").change(function () {
            if ($(this).is(":checked")) {
        $("#myRegistrationFormBtn").prop("disabled", false); // Enable the button
            } else {
        $("#myRegistrationFormBtn").prop("disabled", true); // Disable the button
            }
        });
    $.ajax({
        url: '/UserRegistration/StateName',
    type: 'GET',
    dataType: 'json',
    success: function (data) {
        console.log(data)
                // Iterate over the data and append options to the dropdown
                $.each(data, function (index, item) {
        $('#statedropdownList').append($('<option></option>').val(item.stateId).text(item.stateName));
                });
            }
        });
    $('#statedropdownList').change(function () {
            var selectedValue = $(this).val();
    // Clear the child dropdown
    $('#citydropdownList').empty();

    // Make an AJAX call to retrieve the data for the child dropdown
    $.ajax({
        url: '/UserRegistration/CityName',
    type: 'GET',
    dataType: 'json',
    data: {parentValue: selectedValue},
    success: function (data) {
        // Iterate over the data and append options to the child dropdown
        $.each(data, function (index, item) {
            $('#citydropdownList').append($('<option></option>').val(item.cityId).text(item.cityName));
        });
                }
            });
        });

    $('#myRegistrationFormBtn').click(function () {
        var res = validate();
        if (res == false) {
            return false;
        } 
            //function myRegistrationFormBtn()
            //{
            //e.preventDefault(); // Prevent default form submission

            //var formData = $(this).serialize(); // Serialize form data
            
            
            var name = $('#Name').val();
    var email = $('#Email').val();
    var phone = $('#Phone').val();
    var address = $('#Address').val();
    var stateId = $('#statedropdownList').val();
    var cityId = $('#citydropdownList').val();
    var dataObj = {
        Name: name,
    Email: email,
    Phone:phone,
    Address:address,
    StateId: stateId,
    CityId: cityId
            };

    $.ajax({
        url: '/UserRegistration/Add', // Replace with your route or action method URL
    type: 'POST',
    contentType: 'application/json',
    data: JSON.stringify(dataObj),
    dataType: 'json',
    success: function (response) {
                    if (response == "success") {
        window.location.href = '/UserRegistration/GetUserRegistrationList';
                        // Handle success, e.g., display a success message
                    } else {
        // Handle failure, e.g., display an error message
    }
                },
    error: function () {
        // Handle error, e.g., display an error message
    }
            });
           // }
        });

    //For update code

    $('#myUpdateFormBtn').click(function () {
       
            //var formData = $(this).serialize(); // Serialize form data
    var id = $('#Id').val();
    var name = $('#Name').val();
    var email = $('#Email').val();
    var phone = $('#Phone').val();
    var address = $('#Address').val();
    var stateId = $('#statedropdownList').val();
    var cityId = $('#citydropdownList').val();
    var dataObj = {
        Id:id,
    Name: name,
    Email: email,
    Phone: phone,
    Address: address,
    StateId: stateId,
    CityId: cityId
            };

    $.ajax({
        url: '/UserRegistration/Update', // Replace with your route or action method URL
    type: 'POST',
    contentType: 'application/json',
    data: JSON.stringify(dataObj),
    dataType: 'json',
    success: function (response) {
                    if (response==true) {
        window.location.href = '/UserRegistration/GetUserRegistrationList';
                        // Handle success, e.g., display a success message
                    } else {
        // Handle failure, e.g., display an error message
    }
                },
    error: function () {
        // Handle error, e.g., display an error message
    }
            });
            // }
        });

       
       
    });
    //Edit form call
function getById(id) {
    $('#Name').css('border-color', 'lightgrey');
    $('#Email').css('border-color', 'lightgrey');
    $('#Address').css('border-color', 'lightgrey');
    $('#Phone').css('border-color', 'lightgrey');
    $('#State').css('border-color', 'lightgrey');
    $('#City').css('border-color', 'lightgrey');
    $.ajax({
        url: "/UserRegistration/getbyID/" + id,
    typr: "GET",
    contentType: "application/json;charset=UTF-8",
    dataType: "json",
    success: function (result) {
        
    $('#Id').val(result.id);
    $('#Name').val(result.name);
    $('#Email').val(result.email);
    $('#Address').val(result.address);
    $('#Phone').val(result.phone);
    $('#State').val(result.stateId);
    $('#City').val(result.cityId);

    $('#exampleModal').modal('show');
    $('#myUpdateFormBtn').show();
    $('#myRegistrationFormBtn').hide();
            },
    error: function (errormessage) {
        alert(errormessage.responseText);
            }
        });

    }

    //delete
    function Delete(id) {
    $.ajax({
        url: "/UserRegistration/Delete/" + id,
    typr: "GET",
    contentType: "application/json;charset=UTF-8",
    dataType: "json",
    success: function (result) {
                if(result)
    {
        window.location.href = '/UserRegistration/GetUserRegistrationList';
                }
            },
    error: function (errormessage) {
        alert(errormessage.responseText);
            }
        });

}
    //Validate 
function validate() {
    var isValid = true;
    if ($('#Name').val().trim() == "") {
        $('#Name').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Name').css('border-color', 'lightgrey');
    }
    if ($('#Email').val().trim() == "") {
        $('#Email').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Email').css('border-color', 'lightgrey');
    }
    if ($('#Address').val().trim() == "") {
        $('#Address').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Address').css('border-color', 'lightgrey');
    }
    if ($('#Phone').val().trim() == "") {
        $('#Phone').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Phone').css('border-color', 'lightgrey');
    }
    if ($('#State').val().trim() == "") {
        $('#State').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#State').css('border-color', 'lightgrey');
    }

    if ($('#City').val().trim() == "") {
        $('#City').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#City').css('border-color', 'lightgrey');
    }
    return isValid;
}  
