$(document).ready(function () {
    $('#btnSearchStop').click(function () {
        main.searchStop();
    });
    $('#btnShowAllhStop').click(function () {
        stop.getAllStop();
    });

});
main = {
    searchStop: function () {
        var name = $('#inputSearshStop').val();
        if (name == '') {
            $('#resultSearchStop').text('Enter the stop name!');
            return false;
        }
        
        $.ajax({
            type: 'GET',
            url: '/api/Stop?name='+name,
            asynch: true,
            success: function (output, status, xhr) {
                if (output == null || output == '') {                    
                    $('#resultSearchStop').text('The stop not found');
                }
                else
                stop.renderStop(output)
            },
            error: function () {
                alert('Error adding the stop');
            }
        });
    }
}
stop = {
    renderStop: function (output) {
        $('#resultSearchStop').text('');
        $('#tableStop').empty();
        $('#addStopTmpl').tmpl(output).appendTo('#tableStop');
        $('.tdStopTable').click(function () {
            $('#stopName').text($(this).attr('stopName'));
            timeTable.show($(this).attr('id'));
        });

    },
    getAllStop: function () {
        $.ajax({
            type: 'GET',
            url: '/api/Stop',
            asynch: true,
            success: function (output, status, xhr) {                             
                  stop.renderStop(output)
            },
            error: function () {
                alert('Error adding the stop');
            }
        });
    }
}
timeTable = {
    show: function (id) {
        
        $.ajax({
            type: 'GET',
            url: '/api/stopinfo/' + id,
            asynch: true,
            success: function (output, status, xhr) {
                timeTable.renderTimeTable(output)
            },
            error: function () {
                alert('Error adding the stop');
            }
        });
    },
    renderTimeTable: function (output) {
        $('#divTimeTable').show();
        $('.trTimeTable').empty();
        $('#addTimeTableTmpl').tmpl(output).appendTo('#tableTimeTable');
    }
}