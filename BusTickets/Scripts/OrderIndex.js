$(document).ready(function () {
    main.newOrder();
    $('#btnOneStep').click(function () {
        main.EnterPassengers();
    })
})
main = {
    EnterPassengers: function () {
        $('#divOrderList').css('display', 'grid');
        $('#divTickets').show();
        $('#addPassengerInfo').tmpl().appendTo('#divAddPassenger');
        $('#btnBookTicket').click(function () {
            ticket.GetTicket();
        })
    },
    newOrder: function () {
        var id = $('#orderName').attr('voyageId');
        $.ajax({
            type: 'GET',
            url: '/api/order/'+id,
            asynch: true,
           // data:({voyageId:id}),
            success: function (output) {
                $('#orderName').append(output);
                main.idOrder = output;
            }
        });
    },
    idOrder:0
}
ticket = {
    GetTicket: function () {
        var name = $('#inputFirstName').val() + ' ' + $('#inputLastName').val();        
        var numb = $('#inputDocumentNumber').val();
       
        $.ajax({
            type: 'POST',
            url: '/api/ticket/',
            data: ({ PassengerName: name, OrderId: main.idOrder, DocumentNumber: numb, NumberSeet:3,status:'reserved' }),
            asynch: true,            
            success: function (output) {
               // 
                ticket.GetTicketInfo(output);
            }
        });
    },
    GetTicketInfo: function (id) {
        $.ajax({
            type: 'GET',
            url: '/api/ticket/'+id,            
            asynch: true,
            success: function (output) {
                ticket.renderTicketInfo(output);
            }
        });
    },
    UpdateStatus: function (id) {
        $.ajax({
            type: 'PUT',
            url: '/api/order/' + id,
            data: ({ status:"reserved" }),
            asynch: true,
            success: function () { 
            }
        });
    },
    renderTicketInfo: function (output) {
        $('#containerResult').show();
        $('#addTicketInfoTmpl').tmpl(output).appendTo('#containerTicketInfo');
        ticket.UpdateStatus(main.idOrder);
    }
}