
    $(document).ready(function() {
        // Show the modal
        $('#myModal').modal('show');
  });

    function register() {
    debugger;
    var data = {};
    data.firstName = $('#firstName').val();
    data.lastName = $('#lastName').val();

     data.email = $('#email').val();
    data.PhoneNumber = $('#PhoneNumber').val();
    data.password = $('#password').val();
    data.ConfirmPassword = $('#ConfirmPassword').val();
    var userDetails = JSON.stringify(data);
    $.ajax({
        type: 'Post',
        url: '/Account/RegisterUser',
        dataType:'json',
        data:
        {
            userDetails: userDetails,
        },
        success: function (result) {
            debugger;
            if (!result.isError) {
                var url = "/Account/Login";
                successAlertWithRedirect(result.msg, url);
            }
            else {
                errorAlert(result.msg);
            }
        },
        error: function (ex) {
            errorAlert(ex);
        }
    });

} 
    function login() {
    debugger;
    var data = {};
    data.email = $('#email').val();
    data.password = $('#password').val();
    var userDetails = JSON.stringify(data);
    $.ajax({
        type: 'Post',
        url: '/Account/Login',
        dataType: 'json',
        data:
        {
            userDetails: userDetails,
        },
        success: function (result) {
            debugger;
            if (!result.isError) {
                var url = result.url;
                location.href = url;
            }
            else {
                errorAlert(result.msg);
            }
        },
        error: function (ex) {
            errorAlert(ex);
        }
    });
}



function registerUser() {
    debugger;
    var data = {};
    data.FirstName = $('#firstName').val();
    data.LastName = $('#lastName').val();
    data.PhoneNumber = $('#phoneNumber').val();
    data.Email = $('#email').val();
    data.Password = $('#password').val();
    data.ConfirmPassword = $('#confirmPassword').val();
    if (data.FirstName == "" || data.LastName == "" || data.PhoneNumber == ""  || data.Email == "" || data.Password == "" || data.ConfirmPassword == "") {

        
        if (data.FirstName == "") {
            document.querySelector("#firstNameVDT").style.display = "block";
        }
        else {
            document.querySelector("#firstNameVDT").style.display = "none";
        }
        if (data.LastName == "") {
            document.querySelector("#lastNameVDT").style.display = "block";
        }
        else {
            document.querySelector("#lastNameVDT").style.display = "none";
        }
        if (data.Email == "") {
            document.querySelector("#phoneNumberVDT").style.display = "block";
        }
        else {
            document.querySelector("#phoneNumberVDT").style.display = "none";
        }
           
        if (data.Email == "") {
            document.querySelector("#emailVDT").style.display = "block";
        }
        else {
            document.querySelector("#emailVDT").style.display = "none";
        }
        if (data.Password == "") {
            document.querySelector("#passwordVDT").style.display = "block";
        }
        else {
            document.querySelector("#passwordVDT").style.display = "none";
        }
        if (data.ConfirmPassword == "") {
            document.querySelector("#confirmPasswordVDT").style.display = "block";
        }
        else {
            document.querySelector("#confirmPasswordVDT").style.display = "none";
        }

    }
    else {
        document.querySelector("#firstNameVDT").style.display = "none";
        document.querySelector("#lastNameVDT").style.display = "none";
        document.querySelector("#phoneNumber").style.display = "none";
        document.querySelector("#emailVDT").style.display = "none";
        document.querySelector("#passwordVDT").style.display = "none";
        document.querySelector("#confirmPasswordVDT").style.display = "none";
        let userDetails = JSON.stringify(data);
        reader.onload = function () {
            base64 = reader.result;
            $.ajax({
                type: 'Post',
                dataType: 'Json',
                url: '/Account/Register',
                data:
                {
                    userDetails: userDetails,
                },
                success: function (result) {
                    debugger;
                    if (!result.isError) {
                        var url = '/Account/Login';
                        successAlertWithRedirect(result.msg, url);

                    }
                    else {
                        errorAlert(result.msg);
                    }
                },
                error: function (ex) {
                    errorAlert("Error Occured,try again.");
                }

            });

        }



    }

}


$("#country").change(function () {
    debugger;
    $("#state").empty();
    var id = $("#country").val();
    $.ajax({
        type: 'GET',
        url: '/Account/LoadState',
        data: { id: id },
        success: function (states) {
            debugger;
            $.each(states, function (i, state) {
                $("#state").append('<option value="' + state.id + ' ">' + state.name + '</option>');
            });
        },
        Error: function (ex) {
            alert('Failed to retreive state .' + ex);
        }
    });

})






//function signup() {
//				var firstname =
//        document.forms.RegForm.FirstName.value;
//    var lastname =
//        document.forms.RegForm.LastName.value;
//    var email =
//    document.forms.RegForm.EMail.value;
//    var phone =
//    document.forms.RegForm.PhoneNumber.value;
//    var password =
//    document.forms.RegForm.Password.value;
//    var password2 =
//        document.forms.RegForm.ConfirmPassword.value;
//    var regEmail=/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2, 3})+$/g;
//    var regPhone=/^\d{10}$/;									 
//    var regName = /\d+$/g;								 

//    if (name == "" || regName.test(name)) {
//        window.alert("Please enter your name properly.");
//        name.focus();
//       return false;
//	}

//    if (address == "") {
//        window.alert("Please enter your address.");
//    address.focus();
//    return false;
//				}

//    if (email == "" || !regEmail.test(email)) {
//        window.alert("Please enter a valid e-mail address.");
//    email.focus();
//    return false;
//				}

//    if (password == "") {
//        alert("Please enter your password");
//    password.focus();
//    return false;
//				}

//    if(password.length <6){
//        alert("Password should be atleast 6 character long");
//    password.focus();
//    return false;

//				}
//    if (phone == "" || !regPhone.test(phone)) {
//        alert("Please enter valid phone number.");
//    phone.focus();
//    return false;
//				}

   

//    return true;
//			}


const form = document.getElementById('form')
const firstname = document.getElementById('firstName')
const lastname = document.getElementById('lastName')
const email = document.getElementById('email')
const password = document.getElementById('password')
const password2 = document.getElementById('confirmpassword')
const phoneNumber = document.getElementById('phoneNumber')

form.addEventListener('submit', e => {
    e.preventDefault();

    validateInputs();
})

const setError = (element, message) => {
    const inputControl = element.parentElement;
    const errorDisplay = inputControl.querySelector('.error');

    errorDisplay.innerText = message;
    inputControl.classList.add('error');
    inputControl.classList.remove('success')
};

const isValidEmail = email => {
    const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
}


const validateInputs = () => {
    const firstnameValue = firstname.value.trim();
    const lastname = lastname.value.trim();

    const usernameValue = username.value.trim();
    const emailValue = email.Value.trim();
    const passwordValue = password.value.trim();
    const password2Value = password2.value.trim();

    if (usernameValue === '') {
        setError(username, 'Username is required');
    } else {
        setSuccess(username);
    }

    if (firstnameValue === '') {
        setError(username, 'First Name is required is required');
    } else {
        setSuccess(firstname);
    }
    if (lastnameValue === '') {
        setError(username, 'lastname is required');
    } else {
        setSuccess(lastname);
    }

    if (emailValue === '') {
        setError(email, 'Email is required');
    } else if (!isValidEmail(emailValue)) {
        setError(email, 'Provide a valid email address');
    } else {
        setSuccess(email);
    }

    if (passwordValue === '') {
        setError(password, 'Password is required');
    } else if (passwordValue.length < 8) {
        setError(password, 'Password must be at least 8 character.')
    } else {
        setSuccess(password);
    }

    if (password2Value === '') {
        setError(password2, 'Please confirm your password');
    } else if (password2Value !== passwordValue) {
        setError(password2, "Passwords doesn't match");
    } else {
        setSuccess(password2);
    }

};

        
