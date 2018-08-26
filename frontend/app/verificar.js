var checkedEncerrado = false;
var checkedConduzido = false;
var checkedApreensao = false;
var checkedRO = false;
var checkedFlagrante = false;
var checkedLacre = false;

var arrayGm2 = new Array();
var envolvidoArray = new Array();

$('#save').click(function () {
    if ($('#data').val() == "" || $('#local').val() == "" || $('#ocorrencia :selected').text == "" || $('#TipoOcorrencia :selected').text == "")
        alert("Preencha todos os campos!");

    else {
        var envelope = {
            "registro": {
                "idOcorrencia": parseInt($('#ocorrencia').val()),
                "idTipoOcorrencia": parseInt($('#TipoOcorrencia').val()),
                "latitude": 0,
                "longitude": 0,
                "inicio": $('#data').val(),
                "endereco": $('#address').val(),
                "historicoOcorrencia": $('#descricao').val(),
                "encerradoNoLocal": true,
                "conduzidoAdp": true,
                "apreensaoMaterial": true,
                "fim": $('#horaterm').val(),
                "ro": 0,
                "flagrante": checkedFlagrante,
                "lacre": 0
            },
            "envolvidos":
                envolvidoArray
            ,
            "matriculas":
                arrayGm2

        };

        console.info(envelope);

        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: 'http://api.guarda.digital/api/RegistroOcorrencia',
            data: JSON.stringify(envelope),
            success: function (data) {
                console.info(data);
                vazioOcorrencia();
            },
            dataType: 'json',           
        });

        checkedEncerrado = false;
        checkedConduzido = false;
        checkedApreensao = false;
        checkedRO = 0;
        checkedFlagrante = false;
        checkedLacre = 0;
    }
});

/*$('#login').click(function()
{
	if($('#login').val() == "" || $('#login-psw').val() == "")
		alert('Preencha todos os campos!');

	else
		login($('#login'.val(), $('#login-psw').val());
});*/

//Capturando data atual
function dataAtual() {
    data = new Date();
    document.getElementById('data').value = data.getDate() + '/' + data.getMonth() + '/' + data.getFullYear();
    document.getElementById('horainicio').value = data.getHours() + ':' + data.getMinutes();
}


$.ajax({
    type: "GET",
    url: 'http://api.guarda.digital/api/Ocorrencia',
    data: 0,
    success: function (data) {
        $('#ocorrencia').append('<option value="0">Selecione a Ocorrência</option>');
        for (var i = 0; i < data.length; i++) {
            $('#ocorrencia').append('<option value="' + data[i].id + '">' + data[i].nome + '</option>');
        }
    },
    dataType: "json"
});

$('#ocorrencia').change(function () {
    pegarId($('#ocorrencia').val());
});

function vazioOcorrencia() {
    data: $('#data').val('');
    local: $('#local').val('');
    nome: $('#name').val('');
    idade: $('#age').val('');
    endereco: $('#address').val('');
    qualidade: $('#qualidade').val('');
    rg: $('#rg').val('');
    descricao: $('#descricao').val('');
    gm2: $('#gm2').val('');
    horaInicio: $('#horainicio').val('');
    horaTermino: $('#horaterm').val('');
    email: $('#email').val('');
}

function vazioEnvolvido() {
    nome: $('#name').val('');
    idade: $('#age').val('');
    qualidade: $('#qualidade').val('');
    rg: $('#rg').val('');
}

function vazioGuarda() {
    guarda: $('#gm2').val('');
}

//Checked Sim ou não
function capturarChecked(valor) {
    if (valor == 1)
        checkedEncerrado = true;

    if (valor == 2)
        checkedConduzido = true;

    if (valor == 3)
        checkedApreensao = true;

    if (valor == 4)
        checkedRO = 0;

    if (valor == 5)
        checkedFlagrante = true;

    if (valor == 6)
        checkedLacre = 0;
}

function pegarId(id) {
    $.ajax({
        type: "GET",
        url: 'http://api.guarda.digital/api/TipoOcorrencia/' + id,
        data: 0,
        beforeSend: function () {
            $('#TipoOcorrencia').html('');
        },
        success: function (data) {
            $('#TipoOcorrencia').append('<option value="0">Selecione o Tipo de Ocorrência</option>');
            for (var i = 0; i < data.length; i++) {
                $('#TipoOcorrencia').append('<option value="' + data[i].id + '">' + data[i].nome + '</option>');
            }
        },
        dataType: "json"
    });
}

function buscarGuarda() {
    if ($('#gm2').val() == "")
        alert("Adicione a matrícula do guarda!");

    else {
        $.ajax({
            type: "GET",
            url: 'http://api.guarda.digital/api/Guarda/' + $('#gm2').val(),
            data: 0,
            success: function (data) {
                $('#receberGuarda').prepend('<div id="' + data.id + '" style="width:100%; text-align:center; margin-top: 10px;">' + data.nome + '</div>');
                arrayGm2.push($('#gm2').val());
                //alert(arrayGm2);
            },
            dataType: "json"
        });
    }
}

function adicionarEnvolvido() {
    if ($('#name').val() == "" || $('#age').val() == "" || $('#address').val() == "" || $('#rg').val() == "" || $('#qualidade :selected').text() == "Qualidade do envolvido (selecione)")
        alert("Preencha todos os campos!");

    else {
        var envolvido = {
            "nome": $('#name').val(),
            "idade": parseInt($('#age').val()),
            "idQualidade": parseInt($('#qualidade').val()),
            "endereco": $('#endereco').val(),
            "rg": $('#rg').val()
        };

        envolvidoArray.push(envolvido);

        $('#receberEnvolvido').prepend('<div style="width:100%; text-align:center; margin-top: 10px; margin-bottom: 20px;"><div><b>Nome:</b> ' + $('#name').val() + '</div><div style="width:100%; text-align:center; margin-top: 10px;"><b>Idade:</b> ' + $('#age').val() + '</div><div style="width:100%; text-align:center; margin-top: 10px;"><b>Envolvido:</b> ' + $('#qualidade :selected').text() + '</div><div style="width:100%; text-align:center; margin-top: 10px;"><b>Endereço:</b> ' + $('#address').val() + '</div><div style="width:100%; text-align:center; margin-top: 10px;"><b>RG:</b> ' + $('#rg').val() + '</div></div>');

        vazioEnvolvido();
    }
}

/*function login(matricula, senha)
{
	$.ajax({
		type: "GET",
		url: 'porcessar',
		data: 0,
		success: function(data)
		{
			if(data.matricula == matricula && data.senha == senha)
			{
				alert("Acesso permitido!");
				window.open('index.html');
			}

			else
				alert("Acesso negato!");
		},
		dataType: 'json'
	});
}*/