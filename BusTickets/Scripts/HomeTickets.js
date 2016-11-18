$(document).ready(function () {
    $('#inputStopDep').focus(function () {
        $(this).keyup(function (event) {
            if (event.keyCode > 64 & event.keyCode < 91)
                stop.getStopDep($(this).val());
        });
    });
    $('#inputStopArr').focus(function () {
        $(this).keyup(function (event) {
            if (event.keyCode > 64 & event.keyCode < 91)
                stop.getStopArrive($(this).val());
        });
    });
    $('#btnSearchVoyage').click(function () {
        voyage.search();
    });
});
stop = {
    getStopDep: function (name) {
        $.ajax({
            type: 'GET',
            url: '/api/Stop?name=' + name,
            asynch: true,
            success: function (output) {
                stop.renderStopDep(output);
            }
        });
    },
    renderStopDep: function (output) {
        $('#selectStopDep').empty();
        $('#addStopNameTmpl').tmpl(output).appendTo('#selectStopDep');
        $('.tdStopSelect').click(function () {
            $('#inputStopDep').val($(this).attr('stopName'));
            $('#inputStopDep').attr('stopId', $(this).attr('id'));
            $('#selectStopDep').empty();
        })
    },
    getStopArrive: function (name) {
        $.ajax({
            type: 'GET',
            url: '/api/Stop?name=' + name,
            asynch: true,
            success: function (output) {
                stop.renderStopArrive(output);
            }
        });
    },
    renderStopArrive: function (output) {
        $('#selectStopArr').empty();
        $('#addStopNameArriveTmpl').tmpl(output).appendTo('#selectStopArr');
        $('.tdStopSelectArr').click(function () {
            $('#inputStopArr').val($(this).attr('stopName'));
            $('#inputStopArr').attr('stopId', $(this).attr('id'));
            $('#selectStopArr').empty();
        })
    }
}
voyage = {
    search: function () {
        var idDep = $('#inputStopDep').attr('stopId');
        var idArr = $('#inputStopArr').attr('stopId');
        var date = $('#inputDateDep').val();
        
        $.ajax({
            type: 'GET',
            url: '/api/voyage?DepId='+idDep+'&ArrId='+idArr+'&Date='+date,
            asynch: true,
            success: function (output, status, xhr) {
               voyage.render(output)
            },
            error: function () {
                alert('Error');
            }
        });
    },
    render: function (output) {
        $('#trVoyageTable').empty();
        $('#addVoyageTmpl').tmpl(output).appendTo('#tableResultSearch');        
    }
}