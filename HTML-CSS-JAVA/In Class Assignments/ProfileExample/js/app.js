var arrEmployees;
$.getJSON("https://www.swollenhippo.com/getEmployeesByAPIKey.php?APIKey=Mickey2021!", function(result){
    console.log(result);
    arrEmployees = result;
    buildEmployeeCard();
    $.each(result,function(i,person){
        console.log(person.FirstName);
        console.log(person.FirstName + ' ' + person.LastName);
        $('#txtEmail').val(person.Email);
    })
})

function buildEmployeeCard(){
    $.each(arrEmployees,function(i,person){
        if(person.FirstName != 'John'){
            let strHTML = '<div class="card col-6 offset-3 mt-5">';
            strHTML += '<h3 class="text-center"><a href="mailto:' + person.Email + '">' + person.FirstName + ' ' + person.LastName + '</a></h3>';
            strHTML += '<h4 class="text-center">' + person.Postion +'</h4>';
            strHTML += '<h4 class="mt-3">Profile Details</h4>';
            strHTML += '<p>Hourly Rate: ' + person.HourlyRate + '</p>';
            strHTML += '<p>Address:  586 Southern Lane, Cookeville, TN 38506</p>';
            strHTML += '<p>Assignment:  Clement Hall</p>';
            strHTML += '<div class="form-group">';
            strHTML += '<label for="txtPayRate">Pay Rate</label>';
            strHTML += '<input id="txtPayRate">';
            strHTML += '</div>';
            strHTML += '</div>';
            $('body').append(strHTML);
        }
        
    });
}
$('#btnTest').click(function() {
    const decTaxRate = .0925;
    let decHours = $('#txtHours').val();
    let decRate = $('#txtPayRate').val();
    console.log(decHours * decRate);
});
$('#cboEmployeeType').change(function() {
    if($('#cboEmployeeType').val()== 'FULL'){
        //$('divHours').slideup();
        //$('divHours').css('display','none')
        $('divHours').addClass('b-none')
    }else {
        $('divHours').slideDown();
    }
})                        
