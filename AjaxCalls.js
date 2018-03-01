//---------------------------------------------------------------------------
// 
//---------------------------------------------------------------------------
function GetUserByIdFromDb(request, successCB, failureCB) {

    dataString = JSON.stringify(request);
    $.ajax({ // ajax call starts
        url: 'AjaxServices.asmx/GetUserById',   // JQuery call to the server side method
        data: dataString,    // the parameters sent to the server
        type: 'POST',        // can be post or get
        dataType: 'json',    // Choosing a JSON datatype
        contentType: 'application/json; charset = utf-8', // of the data received
        timeout: 5000, // timeout in miliseconds
        success: successCB, // 
        error: failureCB 
        })// end of ajax call
}