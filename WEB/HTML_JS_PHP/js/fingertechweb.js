/*********************************************
* Nome: Capture
* Descrição: Chama o método "Capture" da aplicação desktop, 
* 	responsável por chamar a tela de captura de digital para apenas um único dedo.
* 	Este método é recomendável quando você deseja capturar a impressão digital de um único dedo e 
* 	não existe a necessidade de identificar qual dedo da mão esta digital pertence. 
* Retorno: Template (String) ou Null
*********************************************/
function Capture() {

	$.ajax({

		url: 'http://localhost:9000/api/public/v1/captura/Capturar/1',
		type: 'GET',
		success: function (data) {
			
			if (data != "" && data != null) {
				
				var name = $("#inputName").val();
				insertDB(name, data);
			}
			else {
				alert("Digital não pode ser capturada!");
			}
		}
	})
}

/*********************************************
* Nome: Match
* Descrição: Chama o método "VerifyMatch" da aplicação desktop, 
* 	responsável por chamar a tela de captura de digital para apenas um único dedo e realizar a 
* 	comparação com um outro template (impressão digital) já cadastrada.
* 	Este método é recomendável quando você deseja você comparação de 1:1 (Um para Um). 
* Retorno: Template (String) ou Null
*********************************************/
function Match(digital) {
		
	if (digital != "") {
	
		$.ajax({
			url: 'http://localhost:9000/api/public/v1/captura/Comparar?Digital=' + digital,
			type: 'GET',
			success: function (data) {
			
				if (data != "") {
					alert("Digital encontrada com sucesso!");
				}
				else {
					alert("Digitais não conferem.");
				}
			}
		});
	}
	else {
		alert("Por favor, registre a impressão digital.");
	}
}

/*********************************************
* Nome: insertDB
* Descrição: Realizar uma requisação AJAX para a página Controller.php, 
* 	enviando os dados do novo usuário cadastrado, para que sejam gravado 
* 	no banco de dados.
* Retorno: String
*********************************************/
function insertDB(name, template) {
	
	$.ajax({
		url: 'Controller.php',
		method: 'POST',
		dataType: 'json',
		data: {
			method: "insertDB",
			name: name,
			template: template
		},
		success: function (data) {
			
			$("#inputName").val("");
			alert(data.msg);
			window.location.reload();
		}
	});
}

$(function() {
	$("#btn-capture").on("click", function(){
		
		if($("#inputName").val() != "") {
			Capture();
		}
		else {
			alert("Por favor, preencha o nome.");
		}
	});
	
	$(".btn-match").on("click", function(){
		var digital = $(this).parent().parent().find(".td-template").html();
		Match(digital);
	});
});