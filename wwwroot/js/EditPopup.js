function Edit(Id) {
    debugger;
    //  var id = $("#MId").html();
    $.get("/Employee/EditEmployee/" + Id,

        function (res) {
            debugger;
            if (res) {
                $('#editModalBody').html(res);
            } else {
                alert("Unsuccessful");
            }

        });

    $('#EditProdModal').modal("show");
};

function updateProd() {
    var Id = $("#Id").val();
    var Name = $("#Name").val();
    var Position = $("#Position").val();
    var office = $("#office").val();
    var Email = $("#Email").val();
    var Password = $("#Password").val();


    var data = {
        "Id" : Id , "Name": Name, "Password": Password, "Position": Position, "office": office,"Email": Email
    }

    $.post("/Employee/EditEmployee", data,
        function (res) {
            debugger;
            if (res) {

                $("#editmsg").html("Data Updated successfully");

            }
        }
    );
}

function CloseEdit() {
    debugger;
    $('#EditexampleModalCenter').modal("hide");
}


function Delete(id) {
    debugger;
    var result = confirm("Are you sure to want to Delete the Record")
    if (result == true) {
        debugger;
        //var Minid = $("#MId").html();
        $.get("/Employee/DeleteEmployee/" + id,
            function (res) {
                if (res == true) {
                    $("#DelMsg").html("Data Deleted Successfully")
                }

            });
    }

}

function View(Id)
{
    debugger;
    //  var id = $("#MId").html();
    $.get("/Employee/ViewEmployee/" + Id,

        function (res)
        {
            debugger;
            if (res)
            {
                $('#viewModalBody').html(res);
            }
            else
            {
                alert("Unsuccessful");
            }

        });

    $('#viewProdModal').modal("show");
};
