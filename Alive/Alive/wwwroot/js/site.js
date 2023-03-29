
    $(document).ready(function() {
        // Show the modal
        $('#myModal').modal('show');
    });

function registerAdmin() {
    debugger;
    var data = {};
    data.firstName = $('#firstName').val();
    data.lastName = $('#lastName').val();
    data.email = $('#email').val();
    data.PhoneNumber = $('#phoneNumber').val();
    data.password = $('#password').val();
    data.ConfirmPassword = $('#ConfirmPassword').val();
    var userDetails = JSON.stringify(data);
    $.ajax({
        type: 'Post',
        url: '/Account/AdminRegister',
        dataType: 'json',
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

    function registerUser() {
    debugger;
    var data = {};
    data.firstName = $('#firstName').val();
    data.lastName = $('#lastName').val();
    data.email = $('#email').val();
    data.PhoneNumber = $('#phoneNumber').val();
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

//function addRow()
//{
//    var tableRow = document.getElementById("table");
//    var row = document.createElement("tr");
//    var cell1 = document.createElement("td");
//    var cell2 = document.createElement("td");
//    var cell3 = document.createElement("td");
//    var cell3 = document.createElement("td");

//    cell1.innerHTML = "Cell of New Row";
//    cell2.innerHTML = "Cell of New Row";
//    cell3.innerHTML = "Cell of New Row";
//    row.appendChild(cell1);
//    row.appendChild(cell2);
//    row.appendChild(cell3);
//    tableRow.appendChild(row);
//}

//function addCol()
//{
//    var tableRow = document.getElementById("tabe");
//    var row = document.createElement("tr");
//    var cell1 = document.createElement("td");
//    var cell2 = document.createElement("td");
//    var cell3 = document.createElement("td");
//    var cell4 = document.createElement("td");
//    var cell5 = document.createElement("td");

//    cell1.innerHTML = "Cell of New Row";
//    cell2.innerHTML = "Cell of New Row";
//    cell3.innerHTML = "";
//    cell4.innerHTML = "";
//    cell5.innerHTML = "";
   
//    row.appendChild(cell1);
//    row.appendChild(cell2);
//    row.appendChild(cell3);
//    row.appendChild(cell4);
//    row.appendChild(cell5);

//    tableRow.appendChild(row);
//}

//function addCol()
//{
//    var table = document.getElementById("table");
//    var row = table.insertRow(0);
//    var cell1 = row.insertCell(0);
//    var cell2 = row.insertCell(1);
//    var cell3 = row.insertCell(2);
//    var cell4 = row.insertCell(3);
//    var cell5 = row.insertCell(4);

//    cell1.innerHTML = document.getElementById("userID").value;
//    cell2.innerHTML = document.getElementById("firstname").value;
//    cell3.innerHTML = document.getElementById("lastname").value;
//    cell4.innerHTML = document.getElementById("lastname").value;
//    cell5.innerHTML = document.getElementById("lastname").value;

//    return false;
//}
function myDeleteFunction() {
    document.getElementById("myTable").deleteRow(0);
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

$(document).ready(function () {
    $('#example').DataTable();
});
/*Create For Lab test*/
function labtestCreate() {
    debugger;
    var data = {};
    data.LabTestName = $('#testName').val();
    data.TestCategory = $('#testCategory').val();
    data.UnitPrice = $('#unitPrice').val();
    data.DateCreated = $('#dateCreated').val();
    data.ReferenceRange = $('#reference').val();
        let LabTestViewModel = JSON.stringify(data);
        $.ajax({
            type: 'POST',
            dataType: 'Json',
            url: '/Admin/Labtest',
            data:
            {
                deserializedLabTestViewModel: LabTestViewModel,
            },
            success: function (result) {

                if (!result.isError) {
                    $("#loader").fadeOut(3000);
                    var url = '/Admin/Labtest'
                    successAlertWithRedirect(result.msg, url)
                }
                else {
                    $("#loader").fadeOut(3000);
                    errorAlert(result.msg)
                }
            },
            Error: function (ex) {
                $("#loader").fadeOut(3000);
                errorAlert(ex);
            }
        });
    

}
function EditForm(id) {
    debugger;
    $.ajax({
        type: 'GET',
        url: '/Admin/GetEditLabTest', // we are calling json method
        dataType: 'json',
        data:
        {
            id: id
        },
        success: function (result) {
            debugger
            if (!result.isError) {
            debugger
                $("#deleteId").val(result.result.id);
                $("#editId").val(result.result.id);
                $("#edittestName").val(result.result.labTestName);
                $("#edittestCategory").val(result.result.testCategory);
                $("#editunitPrice").val(result.result.unitPrice);
                $("#editdatecreated").val(result.result.dateCreated);
                $("#editreference").val(result.result.referenceRange);
            }        
        },
        error: function (ex) {
            "please fill the form correctly" + errorAlert(ex);
        }
    });
};
///
///*SaveEditStaff*/
function SaveEditLabTest() {
    debugger;
    var data = {};
    data.Id = $('#editId').val();
    data.LabTestName = $('#edittestName').val();
    data.TestCategory = $('#edittestCategory').val();
    data.UnitPrice = $('#editunitPrice').val();
    data.ReferenceRange = $('#editreference').val();
      var now = new Date(dateString);
        var day = ("0" + now.getDate()).slice(-2);
        var month = ("0" + (now.getMonth() + 1)).slice(-2);

    var DateCreated = now.getFullYear() + "-" + (month) + "-" + (day);

    return DateCreated;
    

    if (data.LabTestName != "" && data.TestCategory != "" && data.UnitPrice != "" && data.ReferenceRange != "" && data.DateCreated != "") {
        let Labtest = JSON.stringify(data);
        $.ajax({
            type: 'POST',
            url: '/Admin/SaveEditLabTest', // we are calling json method,
            dataType: 'json',
            data:
            {
                deserializedLabTestViewModel: Labtest,
            },
            success: function (result) {
                if (!result.isError) {
                    var url = "/Admin/LabTest";
                    newSuccessAlert(result.msg, url);
                }
                else {
                    errorAlert(result.msg);
                }
            },
            error: function (ex) {
                "Something went wrong, contact support - " + errorAlert(ex);
            }
        });
    }
    else {
        errorAlert("Incorrect Details");
    }
}

function ConfirmDelete(id)
{
    $("#deleteId").val(id);
        
}
  

function DeleteLab()
{
    debugger;
     var labtestId = $('#deleteId').val();

    $.ajax({
        type: 'POST',
        url: '/Admin/DeleteLabTest', // we are calling json method,
        dataType: 'json',
        data:
        {
            id: labtestId,
        },
        success: function (result) {
            if (!result.isError) {
                var url = "/Admin/LabTest";
                newSuccessAlert(result.msg, url);
            }
            else {
                errorAlert(result.msg);
            }
        },
        error: function (ex) {
            "Something went wrong, contact support - " + errorAlert(ex);
        }
    });
}
/*crud for patientappointment*/
/*Create For Patientappoint */
function dateToInput(dateString) {

    var now = new Date(dateString);
    var day = ("0" + now.getDate()).slice(-2);
    var month = ("0" + (now.getMonth() + 1)).slice(-2);

    var today = now.getFullYear() + "-" + (month) + "-" + (day);

    return today;
}
function AppointmentCreate() {
    debugger;
    var data = {};
    data.Name = $('#patientName').val();
    data.Email = $('#patientEmail').val();
    data.PhoneNumber = $('#patientphone').val();
    data.AppointmentDate = $('#patientdate').val();
    data.Description = $('#description').val();
        let AppointmentViewModel = JSON.stringify(data);
        $.ajax({
            type: 'POST',
            dataType: 'Json',
            url: '/Admin/AppointmentCreate',
            data:
            {
                deserializedAppointmentViewModel: AppointmentViewModel,
            },
            success: function (result) {

                if (!result.isError) {
                    $("#loader").fadeOut(3000);
                    var url = '/Home/IndexLogOut'
                    successAlertWithRedirect(result.msg, url)
                }
                else {
                    $("#loader").fadeOut(3000);
                    errorAlert(result.msg)
                }
            },
            Error: function (ex) {
                $("#loader").fadeOut(3000);
                errorAlert(ex);
            }
        });
    }


function EditAppForm(id) {
    debugger;
    $.ajax({
        type: 'GET',
        url: '/Admin/GetEditAppointment', // we are calling json method
        dataType: 'json',
        data:
        {
            id: id
        },
        success: function (result) {
            debugger
            if (!result.isError) {
                debugger
                $("#pdeleteId").val(result.result.id);
                $("#appointmentId").val(result.result.id);
                $("#patientName").val(result.result.name);
                $("#patientEmail").val(result.result.email);
                $("#patientphone").val(result.result.phoneNumber);
                $("#patientdate").val(dateToInput(result.result.AppointmentDate));
                $("#description").val(result.result.description);
                $("#datecreated").val(dateToInput(result.result.dateCreated));

            }
        },
        error: function (ex) {
            "please fill the form correctly" + errorAlert(ex);
        }
    });
};
///
///*SaveEditStaff*/
function SaveEditAppointment() {
    debugger;
    var data = {};
    data.Id = $('#appointmentId').val();
    data.Name = $('#patientName').val();
    data.Email = $('#patientEmail').val();
    data.PhoneNumber = $('#patientphone').val();
    data.AppointmentDate = $('#patientdate').val();
    data.Description = $('#description').val();
    data.DateCreated = $('#datecreated').val();
    if (data.Name != null) {
        $('#patientName').css('border', 'solid 1px #ccc');
    } else {
        errorAlert('Put patient Name')
        return false;
    }
    if (data.Email != null) {
        $('#patientEmail').css('border', 'solid 1px #ccc');
    } else {
        errorAlert('Put patient Email')
        return false;
    }
    if (data.PhoneNumber != null) {
        $('#patientphone').css('border', 'solid 1px #ccc');
    } else {
        errorAlert('Put patient phone number')
        return false;
    }
    if (data.AppointmentDate != null) {
        $('#patientdate').css('border', 'solid 1px #ccc');
    } else {
        errorAlert('Put Appointment date')
        return false;
    }
    if (data.DateCreated != null) {
        $('#datecreated').css('border', 'solid 1px #ccc');
    } else {
        errorAlert('Put Date Created')
        return false;
    }
    if (data.Description != null) {
        $('#description').css('border', 'solid 1px #ccc');
    } else {
        errorAlert('Put Description Created')
        return false;
    }
    
        let Appointment = JSON.stringify(data);
        $.ajax({
            type: 'POST',
            url: '/Admin/SaveEditAppointment', // we are calling json method,
            dataType: 'json',
            data:
            {
                deserializedAppointmentViewModel: Appointment,
            },
            success: function (result) {
                if (!result.isError) {
                    var url = "/Admin/Appointment";
                    newSuccessAlert(result.msg, url);
                }
                else {
                    errorAlert(result.msg);
                }
            },
            error: function (ex) {
                "Something went wrong, contact support - " + errorAlert(ex);
            }
        });
    }
   

function ConfirmAppDelete(id) {
    $("#deleteId").val(id);

}


function DeleteAppointment() {
    debugger;
    var AppointmentId = $('#deleteId').val();

    $.ajax({
        type: 'POST',
        url: '/Admin/DeleteAppointment', // we are calling json method,
        dataType: 'json',
        data:
        {
            id: AppointmentId,
        },
        success: function (result) {
            if (!result.isError) {
                var url = "/Admin/Appointment";
                newSuccessAlert(result.msg, url);
            }
            else {
                errorAlert(result.msg);
            }
        },
        error: function (ex) {
            "Something went wrong, contact support - " + errorAlert(ex);
        }
    });
}
/*Create For DocInfo*/
function DocCreate() {
    debugger;
    var data = {};
    data.Name = $('#docname').val();
    data.Email = $('#email').val();
    data.PhoneNumber = $('#phonenumber').val();
    data.Category = $('#category').val();
    data.Gender = $('#gender').val();
    data.Country = $('#country').val();

        let DoctorViewModel = JSON.stringify(data);
        $.ajax({
            type: 'POST',
            dataType: 'Json',
            url: '/Admin/DocInfoCreate',
            data:
            {
                deserializedDoctorViewModel: DoctorViewModel,
            },
            success: function (result) {

                if (!result.isError) {
                    $("#loader").fadeOut(3000);
                    var url = '/Admin/DocInfo'
                    successAlertWithRedirect(result.msg, url)
                }
                else {
                    $("#loader").fadeOut(3000);
                    errorAlert(result.msg)
                }
            },
            Error: function (ex) {
                $("#loader").fadeOut(3000);
                errorAlert(ex);
            }
        });
    

}

function EditDoc(id)
{
    debugger;
    $.ajax({
        type: 'GET',
        url: '/Admin/GetEditDoctor', // we are calling json method
        dataType: 'json',
        data:
        {
            id: id
        },
        success: function (result) {
            debugger
            if (!result.isError)
            {
                debugger
                $("#deleteId").val(result.result.id);
                $("#editId").val(result.result.id);
                $("#docnameEdit").val(result.result.name);
                $("#emailEdit").val(result.result.email);
                $("#genderEdit").val(result.result.gender);
                $("#phonenumberEdit").val(result.result.phoneNumber);
                $("#categoryEdit").val(result.result.category);
                $("#countryEdit").val(result.result.country);
               
            }
        },
        error: function (ex) {
            "please fill the form correctly" + errorAlert(ex);
        }
    });
};
///
///*SaveEditStaff*/
function DocEdit() {
    debugger;
    var data = {};
    data.Id = $('#editId').val();
    data.Name = $('#docnameEdit').val();
    data.Email = $('#emailEdit').val();
    data.PhoneNumber = $('#phonenumberEdit').val();
    data.Category = $('#categoryEdit').val();
    data.Gender = $('#genderEdit').val();
    data.Country = $('#countryEdit').val();

        let Doctor = JSON.stringify(data);
        $.ajax({
            type: 'POST',
            url: '/Admin/SaveEditDoctor', // we are calling json method,
            dataType: 'json',
            data:
            {
                deserializedLabTestViewModel: Doctor,
            },
            success: function (result) {
                if (!result.isError) {
                    var url = "/Admin/DocInfo";
                    newSuccessAlert(result.msg, url);
                }
                else {
                    errorAlert(result.msg);
                }
            },
            error: function (ex) {
                "Something went wrong, contact support - " + errorAlert(ex);
            }
        });
    
   
}

function ConfirmDocDelete(Id) {
    $("#deleteId").val(id);

}


function DeleteDoc() {
    debugger;
    var doctorId = $('#deleteId').val();

    $.ajax({
        type: 'POST',
        url: '/Admin/DeleteDoctor', // we are calling json method,
        dataType: 'json',
        data:
        {
            id: doctorId,
        },
        success: function (result) {
            if (!result.isError) {
                var url = "/Admin/DocInfo";
                newSuccessAlert(result.msg, url);
            }
            else {
                errorAlert(result.msg);
            }
        },
        error: function (ex) {
            "Something went wrong, contact support - " + errorAlert(ex);
        }
    });
}
/*NURSE*/
function nurseCreate() {
    debugger;
    var data = {};
    data.Name = $('#nursename').val();
    data.Gender = $('#gender').val();
    data.Email = $('#email').val();
    data.PhoneNumber = $('#phonenumber').val();
    data.Country = $('#country').val();

        let NurseViewModel = JSON.stringify(data);
        $.ajax({
            type: 'POST',
            dataType: 'Json',
            url: '/Admin/InfoCreate',
            data:
            {
                deserializedNurseViewModel: NurseViewModel,
            },
            success: function (result) {

                if (!result.isError) {
                    $("#loader").fadeOut(3000);
                    var url = '/Admin/Info'
                    successAlertWithRedirect(result.msg, url)
                }
                else {
                    $("#loader").fadeOut(3000);
                    errorAlert(result.msg)
                }
            },
            Error: function (ex) {
                $("#loader").fadeOut(3000);
                errorAlert(ex);
            }
        });
   

}

/*edit*/
function EditNurseForm(id)
{
    debugger;
    $.ajax({
        type: 'GET',
        url: '/Admin/GetEditNurse', // we are calling json method
        dataType: 'json',
        data:
        {
            id: id
        },
        success: function (result) {
            debugger
            if (!result.isError) {
                debugger
                $("#deleteId").val(result.result.id);
                $("#editId").val(result.result.id);
                $("#nursenameEdit").val(result.result.name);
                $("#nursegenderEdit").val(result.result.gender);
                $("#nursephonenumberEdit").val(result.result.phoneNumber);
                $("#nursecountryEdit").val(result.result.country);
                $("#nurseemailEdit").val(result.result.email);
            }
        },
        error: function (ex) {
            "please fill the form correctly" + errorAlert(ex);
        }
    });
};
///
///*SaveEditStaff*/
function SaveEditNurse() {
    debugger;
    var data = {};
    data.Id = $('#editId').val();
    data.Name = $('#nursenameEdit').val();
    data.Email = $('#nurseemailEdit').val();
    data.Gender = $('#nursegenderEdit').val();
    data.PhoneNumber = $('#nursephonenumberEdit').val();
    data.Country = $('#nursecountryEdit').val();

    if (data.Name != "" && data.Email != "" && data.Gender != "" && data.PhoneNumber != "" && data.Country != "") {
        let nurse = JSON.stringify(data);
        $.ajax({
            type: 'POST',
            url: '/Admin/SaveEditNurse', // we are calling json method,
            dataType: 'json',
            data:
            {
                deserializedNurseViewModel: nurse,
            },
            success: function (result) {
                if (!result.isError) {
                    var url = "/Admin/Info";
                    newSuccessAlert(result.msg, url);
                }
                else {
                    errorAlert(result.msg);
                }
            },
            error: function (ex) {
                "Something went wrong, contact support - " + errorAlert(ex);
            }
        });
    }
    else {
        errorAlert("Incorrect Details");
    }
}

function ConfirmNurDelete(id) {
    $("#deleteId").val(id);

}


function nurseDoc() {
    debugger;
    var nurseId = $('#deleteId').val();

    $.ajax({
        type: 'POST',
        url: '/Admin/DeleteNurse', // we are calling json method,
        dataType: 'json',
        data:
        {
            id: nurseId,
        },
        success: function (result) {
            if (!result.isError) {
                var url = "/Admin/Info";
                newSuccessAlert(result.msg, url);
            }
            else {
                errorAlert(result.msg);
            }
        },
        error: function (ex) {
            "Something went wrong, contact support - " + errorAlert(ex);
        }
    });
}
/*TREATMENT*/
function MedCreate() {
    debugger;
    var data = {};
    data.MedicineName = $('#medname').val();
    data.MedicineCategory = $('#medcat').val();
    data.Amount = $('#medamout').val();
   
        let TreatmentViewModel = JSON.stringify(data);
        $.ajax({
            type: 'POST',
            dataType: 'Json',
            url: '/Admin/MedicineCreate',
            data:
            {
                deserializedTreatmentViewModel: TreatmentViewModel,
            },
            success: function (result) {

                if (!result.isError) {
                    $("#loader").fadeOut(3000);
                    var url = '/Admin/Medicine'
                    successAlertWithRedirect(result.msg, url)
                }
                else {
                    $("#loader").fadeOut(3000);
                    errorAlert(result.msg)
                }
            },
            Error: function (ex) {
                $("#loader").fadeOut(3000);
                errorAlert(ex);
            }
        });
}


function EditTreatmentForm(id) {
    debugger;
    $.ajax({
        type: 'GET',
        url: '/Admin/GetEditMedicine', // we are calling json method
        dataType: 'json',
        data:
        {
            id: id
        },
        success: function (data) {
            debugger
            if (!data.isError) {
                debugger
                $("#deleteId").val(data.result.id);
                $("#editId").val(data.result.id);
                $("#editmedname").val(data.result.medicineName);
                $("#editmedcat").val(data.result.medicineCategory);
                $("#editmedamout").val(data.result.amount);
                }
        },
        error: function (ex) {
            "please fill the form correctly" + errorAlert(ex);
        }
    });
};
///
///*SaveEditmedicine*/
function medEdit(id) {
    debugger;
    var data = {};
    data.Id = $('#editId').val();
    data.MedicineName = $('#editmedname').val();
    data.MedicineCategory = $('#editmedcat').val();
    data.Amount = $('#editmedamout').val();
    
    if (data.MedicineName != "" && data.MedicineCategory != "" && data.Amount != "" ) {
        let medicine = JSON.stringify(data);
        $.ajax({
            type: 'POST',
            url: '/Admin/SaveEditMedicine', // we are calling json method,
            dataType: 'json',
            data:
            {
                deserializedTreatmentViewModel: medicine,
            },
            success: function (result) {
                if (!result.isError) {
                    var url = "/Admin/GetEditMedicine";
                    newSuccessAlert(result.msg, url);
                }
                else {
                    errorAlert(result.msg);
                }
            },
            error: function (ex) {
                "Something went wrong, contact support - " + errorAlert(ex);
            }
        });
    }
    else {
        errorAlert("Incorrect Details");
    }
}

function ConfirmTreatmentDelete(id) {
    $("#deleteId").val(id);

}


function MedDelete() {
    debugger;
    var medicineId = $('#deleteId').val();

    $.ajax({
        type: 'POST',
        url: '/Admin/DeletMedicine', // we are calling json method,
        dataType: 'json',
        data:
        {
            id: medicineId,
        },
        success: function (result) {
            if (!result.isError) {
                var url = "/Admin/Medicine";
                newSuccessAlert(result.msg, url);
            }
            else {
                errorAlert(result.msg);
            }
        },
        error: function (ex) {
            "Something went wrong, contact support - " + errorAlert(ex);
        }
    });
}
/*PAYMENT*/
function PaymentCreate()
{
    debugger;
    var data = {};
    data.PatientName = $('#patname').val();
    data.ModeOfPay = $('#modofpay').val();
     data.PaymentDate = $('#payday').val();
    data.PaidAmount = $('#paidamount').val();
    var picture = document.getElementById("proof").files;
    data.Email = $('#pEmail').val();
    data.ChargedAmount = $('#amt').val();

    if (data.PatientName != "" && data.ModeOfPay != "" && data.Proof != "" && data.PaymentDate != "" && data.PaidAmount != "" && data.Email != "" && data.ChargedAmount != "") {
         if (picture[0] != null) {
            const reader = new FileReader();
            reader.readAsDataURL(picture[0]);
            reader.onload = function ()
            {
                data.picture = reader.result;
                let PaymentViewModel = JSON.stringify(data);
                $.ajax
                    ({
                        type: 'POST',
                        dataType: 'Json',
                        url: '/Admin/PaymentCreate',
                        data:
                        {
                            deserializedPaymentViewModel: PaymentViewModel,
                        },
                        success: function (result) {

                            if (!result.isError) {
                                $("#loader").fadeOut(3000);
                                var url = '/Admin/payment'
                                successAlertWithRedirect(result.msg, url)
                            }
                            else {
                                $("#loader").fadeOut(3000);
                                errorAlert(result.msg)
                            }
                        },
                        Error: function (ex) {
                            $("#loader").fadeOut(3000);
                            errorAlert(ex);
                        }
                    });
            }
        }

    }
}
function EditpayForm(id) {
    debugger;
    $.ajax({
        type: 'GET',
        url: '/Admin/GetEditPayment', // we are calling json method
        dataType: 'json',
        data:
        {
            id: id
        },
        success: function (result) {
            debugger
            if (!result.isError) {
                debugger
                $("#deleteId").val(result.result.id);
                $("#editId").val(result.result.id);
                $("#editpatname").val(result.result.patientName);
                $("#editmodofpay").val(result.result.modeOfPay);
                $("#editproof").val(result.result.proof);
                $("#editpayday").val(result.result.paymentDate);
                $("#editpaidamount").val(result.result.paidAmount);
                $("#amt").val(result.result.chargedAmount);
                $("#pEmail").val(result.result.Email);
            }
        },
        error: function (ex) {
            "please fill the form correctly" + errorAlert(ex);
        }
    });
};
///
///*SaveEditStaff*/
function SaveEditPayment() {
    debugger;
    var data = {};
    data.Id = $('#editId').val();
    data.PatientName = $('#editpatname').val();
    data.ModeOfPay = $('#editmodofpay').val();
    data.Proof = $('#editproof').val();
    data.PaymentDate = $('#editpayday').val();
    data.PaidAmount = $('#editpaidamount').val();
    data.Email = $('#pEmail').val();
    data.ChargedAmount = $('#amt').val();

    if (data.PatientName != "" && data.ModeOfPay != "" && data.Proof != "" && data.PaymentDate != "" && data.PaidAmount != "" && data.Email != "" && data.Email != "") {
        let Payment = JSON.stringify(data);
        $.ajax({
            type: 'POST',
            url: '/Admin/SaveEditPayment', // we are calling json method,
            dataType: 'json',
            data:
            {
                deserializedPaymentViewModel: Payment,
            },
            success: function (result) {
                if (!result.isError) {
                    var url = "/Admin/Payment";
                    newSuccessAlert(result.msg, url);
                }
                else {
                    errorAlert(result.msg);
                }
            },
            error: function (ex) {
                "Something went wrong, contact support - " + errorAlert(ex);
            }
        });
    }
    else {
        errorAlert("Incorrect Details");
    }
}

function ConfirmpayDelete(id) {
    $("#deleteId").val(id);

}


function DeletePayment() {
    debugger;
    var paymentId = $('#deleteId').val();

    $.ajax({
        type: 'POST',
        url: '/Admin/DeletePayment', // we are calling json method,
        dataType: 'json',
        data:
        {
            id: paymentId,
        },
        success: function (result) {
            if (!result.isError) {
                var url = "/Admin/Payment";
                newSuccessAlert(result.msg, url);
            }
            else {
                errorAlert(result.msg);
            }
        },
        error: function (ex) {
            "Something went wrong, contact support - " + errorAlert(ex);
        }
    });
}
/*checkup*/
function checkupCreate()
{
    debugger;
    var data = {};
    data.FirstName = $('#firstName').val();
    data.Email = $('#email').val();
    data.GenderId = $('#genderId').val();
    data.MaritalStatusId = $('#maritalStatusId').val();
    data.DOB = $('#dob').val();
    data.PatientTypeId = $('#patientTypeId').val();
    data.Address = $('#address').val();
    data.LastName = $('#lastName').val();
    data.Phone = $('#phoneNumber').val();
    data.Nok = $('#nok').val();
    data.NextVisist = $('#nextVisit').val();
    data.DateCreated = $('#dateCreated').val();
    data.Occupation = $('#occupation').val();
    data.NurseName = $('#nurs').val();
    data.GenotypeId = $('#genotypeId').val();

        let CheckupViewModel = JSON.stringify(data);
        $.ajax({
            type: 'POST',
            dataType: 'Json',
            url: '/Admin/CheckupCreate',
            data:
            {
                deserializedCheckupViewModel: CheckupViewModel,
            },
            success: function (result) {

                if (!result.isError) {
                    $("#loader").fadeOut(3000);
                    var url = '/Admin/Checkup'
                    successAlertWithRedirect(result.msg, url)
                }
                else {
                    $("#loader").fadeOut(3000);
                    errorAlert(result.msg)
                }
            },
            Error: function (ex) {
                $("#loader").fadeOut(3000);
                errorAlert(ex);
            }
        });
}


function checkupEdit(Id) {
    debugger;
    $.ajax({
        type: 'GET',
        url: '/Admin/GetEditCheckup', // we are calling json method
        dataType: 'json',
        data:
        {
            Id: Id
        },
        success: function (result) {
            debugger
            if (!result.isError) {
                debugger
                $("#editId").val(result.result.id);
                $('#edit_firstName').val(result.result.firstName);
                $('#edit_email').val(result.result.email);
                $('#edit_genderId').val(result.result.genderId);
                $('#edit_maritalStatusId').val(result.result.maritalStatusId);
                $('#edit_dob').val(dateToInput(result.result.dob));
                $('#edit_patientTypeId').val(result.result.patientTypeId);
                $('#edit_address').val(result.result.address);
                $('#edit_lastName').val(result.result.lastName);
                $('#edit_phoneNumber').val(result.result.phone);
                $('#edit_genotypeId').val(result.result.genotypeId);
                $('#edit_nok').val(result.result.nok);
                $('#edit_nextVisit').val(dateToInput(result.result.nextVisist));
                 $('#edit_dateCreated').val(dateToInput(result.result.dateCreated));
                $('#edit_occupation').val(result.result.occupation);
                 $('#edit_nurs').val(result.result.nurseName);

                $("#bodyTemp").val(result.result.bodyTemperature);
                $("#pulse").val(result.result.pulseRate);
                $('#bodyPress').val(result.result.bloodPressure);
                $('#bodyheight').val(result.result.height);
                $('#bodyweight').val(result.result.bodyWeight);
                $('#chiefComplaints').val(result.result.Complaint);
                $('#complaints').val(result.result.Comment);
                $('#durationOfIllness').val(result.result.durationOfIllness);
                $('#selfMedication').val(result.result.selfmedication);
                $('#doseOfSelfMedication').val(result.result.doseOfSelfmedication);
                $('#drugIntakeDuration').val(result.result.drugIntakeDuration);
                $('#smokingHabit').val(result.result.smokingHabitId);
                $('#anyAddiction').val(result.result.anyAddictionId);
                $('#allergy').val(result.result.allergy);
                $('#occupation').val(result.result.occupation);
                $('#militaryServiceId').val(result.result.militaryServiceId);
                $('#sexuallyActiveId').val(result.result.sexuallyActiveId);

                $("#unprotectedSexId").val(result.result.unprotectedSexId);
                $("#ifYesWhen").val(result.result.ifYesWhen);
                $('#msmId').val(result.result.mSMId);
                $('#amount').val(result.result.amount);
                $('#investigation').val(result.result.investigation);
                $('#result').val(result.result.result);
                $('#Treament').val(result.result.treatment);
                $('#treatAmount').val(result.result.treatAmount);
                $('#howToTake').val(result.result.howToTake);
                $('#history').val(result.result.beforeMeal);
                $('#diagnoses').val(result.result.diagnoses);
                $('#advice').val(result.result.advice);
                $('#consult').val(result.result.consult);
                $('#medicine').val(result.result.medicine);
                $('#docname').val(result.result.painRate);
                $('#Total').val(result.result.total);



            }
        },
        error: function (ex) {
            "please fill the form correctly" + errorAlert(ex);
        }
    });
};
///
///*SaveEditStaff*/
function SaveEditCheckup() {
    debugger;
    var data = {};
    
    data.Id = $("#editId").val();
    data.FirstName = $('#edit_firstName').val();
    data.Email = $('#edit_email').val();
    data.GenderId = $('#edit_genderId').val();
    data.MaritalStatusId = $('#edit_maritalStatusId').val();
    data.DOB = $('#edit_dob').val();
    data.PatientTypeId =  $('#edit_patientTypeId').val();
    data.Address = $('#edit_address').val();
    data.LastName = $('#edit_lastName').val();
    data.Phone = $('#edit_phoneNumber').val();
    data.GenotypeId = $('#edit_genotypeId').val();
    data.Nok = $('#edit_nok').val();
    data.NextVisist = $('#edit_nextVisit').val();
    data.DateCreated = $('#edit_dateCreated').val();
    data.Occupation = $('#edit_occupation').val();
    data.NurseName = $('#edit_nurs').val();

    data.BodyTemperature = $("#bodyTemp").val();
    data.PulseRate = $("#pulse").val();
    data.BloodPressure = $('#bodyPress').val();
    data.Height = $('#bodyheight').val();
    data.BodyWeight =  $('#bodyweight').val();
    data.Comment = $('#complain').val();
    data.Complaint = $('#chiefComplaints').val();
    data.DurationOfIllness = $('#durationOfIllness').val();
    data.Selfmedication = $('#selfMedication').val();
    data.DoseOfSelfmedication = $('#doseOfSelfMedication').val();
    data.DrugIntakeDuration = $('#drugIntakeDuration').val();
    data.Allergy = $('#allergy').val();
    data.MilitaryServiceId = $('#militaryServiceId').val();
    data.SexuallyActiveId = $('#sexuallyActiveId').val();
    data.PainRate = $('#docname').val();

    //data.UnprotectedSexId =  $("#unprotectedSexId").val();
    //data.IfYesWhen = $("#ifYesWhen").val();
    data.MSMId = $('#msmId').val();
    data.Amount = $('#amount').val();
    data.Investigation = $('#investigation').val();
    data.Result = $('#result').val();
    data.Treatment = $('#Treament').val();
    data.TreatAmount = $('#treatAmount').val();
    data.HowToTake = $('#howToTake').val();
    data.BeforeMeal = $('#history').val();
    data.Diagnoses = $('#diagnoses').val();
    data.Advice = $('#advice').val();
    data.Consultation = $('#consult').val();
    data.Medicine =  $('#medicine').val();
    /*data.Others = $('#history').val();*/
    data.Total = $('#Total').val();
    data.Laboratory = $('#lab').val();
    if (data.FirstName != null) {
        $('#edit_firstName').css('border', 'solid 1px #ccc');
    } else {
        errorAlert('Add Total Amount Paid')
        return false;
    }
    if (data.Email != null) {
        $('#edit_email').css('border', 'solid 1px #ccc');
    } else {
        errorAlert('Put patient Email')
        return false;
    }
    if (data.PhoneNumber != "") {
     $('#edit_phoneNumber').css('border', 'solid 1px #ccc');
    } else {
    errorAlert('Put patient phone number')
     return false;
    }
    if (data.LastName != null) {
        $('#edit_lastName').css('border', 'solid 1px #ccc');
    } else {
        errorAlert('Put Last Name')
        return false;
    }
    if (data.DateCreated != null) {
        $('#edit_dateCreated').css('border', 'solid 1px #ccc');
    } else {
        errorAlert('Put Date Created')
        return false;
    }
    if (data.Address != null) {
        $('#edit_address').css('border', 'solid 1px #ccc');
    } else {
        errorAlert('Put Address')
        return false;
    }


    let Checkup = JSON.stringify(data);
        $.ajax({
            type: 'POST',
            url: '/Admin/SaveEditCheckup', // we are calling json method,
            dataType: 'json',
            data:
            {
                deserializedCheckupViewModel: Checkup,
            },
            success: function (result) {
                if (!result.isError) {
                    var url = "/Admin/Checkup";
                    newSuccessAlert(result.msg, url);
                }
                else {
                    errorAlert(result.msg);
                }
            },
            error: function (ex) {
                "Something went wrong, contact support - " + errorAlert(ex);
            }
        });
   
   
}

function confirmCheckDelete(id) {
    $("#deleteId").val(id);

}


function DeleteCheckup() {
    debugger;
    var CheckupId = $('#deleteId').val();

    $.ajax({
        type: 'POST',
        url: '/Admin/DeleteCheckup', // we are calling json method,
        dataType: 'json',
        data:
        {
            id: CheckupId,
        },
        success: function (result) {
            if (!result.isError) {
                var url = "/Admin/Checkup";
                newSuccessAlert(result.msg, url);
            }
            else {
                errorAlert(result.msg);
            }
        },
        error: function (ex) {
            "Something went wrong, contact support - " + errorAlert(ex);
        }
    });
}

$(function () {
    $('#add').click(function () {
         var _name = $('input[name = "name"]').val();
        var _cost = $('input[name = "cost"]').val();
        var _result = $('input[name = "result"]').val();

        var _tr = '<tr><td>' + _name + '</td> <td>' + _cost + '</td> <td>' + _result + '</td> <td><button type = "button" class = "btn btn-success btn-Edit">Edit</button></td></tr>';

        $('tbody').append(_tr)
    });

    var _trEdit = null;
    $(document).on('click', '.btn-edit', function () {
        _trEdit = $(this).closest('tr');
        var _name = (_trEdit).find('td:eq(1)').text();
        var _cost = (_trEdit).find('td:eq(2)').text();
        var _result = (_trEdit).find('td:eq(3)').text();

        $('input[name ="name"]').val(_name);
        $('input[name ="cost"]').val(_cost);
        $('input[name ="result"]').val(_result);
    });
    $('#update').click(function () {

        if (_trEdit) {
            var _name = $('input[name = "name"]').val();
            var _cost = $('input[name = "cost"]').val();
            var _result = $('input[name = "result"]').val();

            (_trEdit).find('td:eq(1)').text(_name);
            (_trEdit).find('td:eq(2)').text(_cost);
            (_trEdit).find('td:eq(3)').text(_result);
            alert('Test has been recorded');
        }

    });
});
function GetMedReport(Id) {
    debugger;
    $.ajax({
        type: 'GET',
        url: '/Admin/GetMedReport/'+ Id ,// we are calling json method,
        dataType: 'json',
        data:
        {
            Id: Id,
        },
        success: function (result) {
            debugger;
            if (!result.isError) {
                var p = result.result;
                $("#print_printId").val(p.id);
                $('#print_firstName').text(p.firstName);
                $('#print_email').text(p.email);
                var genderId = "";
                if (p.genderId = 1) {
                    genderId = "female";
                } else {
                    genderId = "male";
                }
                $('#print_genderId').text(genderId);
                $('#print_maritalStatusId').text(p.maritalStatusId);
                $('#print_dob').text(dateToInput(p.dob));
                var patientTypeId = "";
                if (p.patientTypeId = 18) {
                    patientTypeId = "Antenatal";
                }
                if (p.patientTypeId = 19) {
                    patientTypeId = "Inpatient";
                } else {
                    patientTypeId = "Outpatient";
                }
                $('#print_patientTypeId').text(patientTypeId);
                $('#print_address').text(p.address);
                $('#print_lastName').text(p.lastName);
                $('#print_phoneNumber').text(p.phone);
                var genotypeId = "";
                if (p.genotypeId = 18 ) {
                    genotypeId = "AA";
                }
                if (p.genotypeId = 19) {
                    genotypeId = "AS";
                } else {
                    genotypeId = "SS";
                } 
                $('#print_genotypeId').text(genotypeId);
                $('#print_nok').text(p.nok);
                $('#print_visit').text(dateToInput(p.nextVisist));
                $('#print_dateCreated').text(dateToInput(p.dateCreated));
                $('#print_nurse').text(p.nurseName);

                $("#print_temp").text(p.bodyTemperature);
                $("#print_rate").text(p.pulseRate);
                $('#print_pressure').text(p.bloodPressure);
                $('#print_height').text(p.height);
                $('#print_weight').text(p.bodyWeight);
                $('#print_symptoms').text(p.complaint);
                $('#print_complaints').text(p.comment);
                $('#print_treatment').text(p.medicine);
                $('#print_investigation').text(p.investigation);
                $('#print_history').text(p.beforeMeal);
                $('#print_doctor').text(p.painRate);
                $('#print_diagnoses').text(p.diagnoses);
                $('#print_advice').text(p.advice);
               
                $('#printModal').modal('show');
            }
            else {
                errorAlert(result.msg);
            }
        },
        error: function (ex) {
            "Something went wrong, contact support - " + errorAlert(ex);
        }
    });
}




