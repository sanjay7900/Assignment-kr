var modal = document.getElementById("myModal");

var btn = document.getElementById("openModalBtn");

var span = document.getElementsByClassName("close")[0];

btn.onclick = function () {
    modal.style.display = "block";
}

span.onclick = function () {
    modal.style.display = "none";
}

window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}


$(document).ready(function() {
    $('.getValuesBtn').on('click', function() {


        const checkboxes = document.querySelectorAll('.getValuesBtn:checked');

        const values = Array.from(checkboxes).map(checkbox => checkbox.value);
        console.log(values);



        $('.hiddenInputsContainerD').empty();
        $('.hiddenInputsContainerU').empty();

        // Create new hidden input elements for each value in the array
        values.forEach(function (value) {
            $('<input>').attr({
                type: 'hidden',
                name: 'id[]',
                value: value
            }).appendTo('.hiddenInputsContainer');
        });
        //values.forEach(function (value) {
        //    $('<input>').attr({
        //        type: 'hidden',
        //        name: 'id[]',
        //        value: value
        //    }).appendTo('.hiddenInputsContainer');
        //});
        //const values = $('.getValuesBtn:checked').map(function() {
        //    return $(this).val();
        //}).get();

        // Set values to the hidden input field
//document.getElementById('updatedata').value = values;
       // $('#updatedata').val(values);
       // console.log($('updatedata').val());
        
        // Optionally, display the values in the console or alert
        //console.log(values);
       // alert('Selected values: ' + values.join(', '));
    });


    $('.pagination a').on('click', function (e) {
        e.preventDefault();
        $('.pagination a').removeClass('active');
        $(this).addClass('active');
        const page = $(this).attr('href').substring(1); 
        $(this).attr('href', '#0')
        if (page>0) {
            GetPageData(10, page);

        }
        console.log(page);
    });

    function GetPageData(pagesize, pagenumber) {

        $.ajax({
            url: "/Products/GetProductPagination?pagenumber="+pagenumber + "&size="+pagesize,
            method: "GET",
            success: function (data) {
                $('.mytable tbody').append(data);
            },
            error: function (xhr, status, error) {
                console.log('Error: ' + error);
            }
            
        })

    }
});






//document.getElementById("productForm").addEventListener("submit", function (event) {
//    event.preventDefault();
//    alert("Form submitted!");
//    modal.style.display = "none";
//});
