
var colection = [];
function SendAjax() {
   
    $.ajax({
        url: 'https://localhost:44391/api/produtos',
        crossDomain: true,
        type: "GET",        
        dataType: 'json',
        headers: {
            'Access-Control-Allow-Origin': '*',
            'Access-Control-Allow-Headers': "Origin, X-Requested-With, Content-Type, Accept",
            'Access-Control-Allow-Methods': 'POST, GET, OPTIONS, DELETE'
        },
        complete: function () {
            console.log("finalizou")
        },
        success: function (data) {
            colection =data;
        },
        error: function (data) {
            console.log("Deu Erro: " + data.error)
        }
    });
   
};


