$(document).ready(function () {
    $('#btnAddStop').click(function () {
        main.addStop();
    })
});
main = {
    addStop: function () {
        var name = $('#inputStopName').val();
        var descr = $('#inputDescriptionStop').val();
        var status = $('#inputStatusStop').val();

        $.ajax({
            type: 'POST',
            url: '/api/Stop',
            data: ({Name:name, Description:descr, Status:status}),
            //asynch: true,
            success: function (output, status, xhr) {
                $('#resultAddStop').text('Success');
            },
            error: function () {
                alert('Error adding the stop');
            }
        });
    }
}