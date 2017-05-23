
// assuming you're using jQuery

$(document).ready(function () {
    $("#createajax").change(function () {

        alert("I'm here!");

        //Update typeDropDown
        $.ajax({
            url: '/Buildings/Create',
            type: 'POST',
            datatype: 'json',
            data: {
                title: $("#Categories").val()
            },
            success: function (data) {
                $('#typeDropDown option[value!="0"]').remove()
                $.each(data, function (i, item) {
                    $('#typeDropDown').append('<option value="' + item.DescriptorID + '">' + item.pplType + '</option>');
                });
            },
            error: function(jqXHR, textStatus, errorThrown){
                alert(errorThrown);
            }
        });



        //Update Data Grid
        $.ajax({
            url: '/Part/updateGrid',
            type: 'POST',
            datatype: 'json',
            data: { id: $("#Categories").val() },
            success: function (data) {
                alert("Got it!");
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert(errorThrown);
            }
        });




    });
});

/*
$(function () {
    $('form').submit(function () {
        if ($(this).valid()) {
            $.ajax({
                url: this.action,
                type: this.method,
                data: $(this).serialize(),
                success: function (result) {
                    $('#result').html(result);
                }
            });
        }
        return false;
    });
});

*/