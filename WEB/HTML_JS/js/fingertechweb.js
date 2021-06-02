/*********************************************
* Nome: Capture
* Descrição: Chama o método "Capture" da aplicação desktop, 
* responsável por chamar a tela de captura de digital para apenas um único dedo.
* Este método é recomendável quando você deseja capturar a impressão digital de um único dedo e 
* não existe a necessidade de identificar qual dedo da mão esta digital pertence. 
* Retorno: Template (String) ou Null
*********************************************/
function Capture() {

	$.ajax({

		url: 'http://localhost:9000/api/public/v1/captura/Capturar/1',
		type: 'GET',
		success: function (data) {
			
			if (data != "" && data != null) {
				$("#inputTemplate").val(data);
				alert("Digital capturada com sucesso!");
			}
			else {
				alert("Digital não pode ser capturada!");
			}
		}
	})
}

/*********************************************
* Nome: Enroll
* Descrição: Chama o método "Enroll" da aplicação desktop, 
* responsável por chamar a tela de captura de impressão digital para mais de um dedo.
* Este método é recomendável quando você deseja capturar a impressão digital de mais de um dedo e
* quando é necessário identificar a qual dedo esta digital pertence. 
* Quando houver a captura de mais de uma impressão digital, elas serão armazenadas de maneira 
* codificada no mesmo "Template" (String), mas durante a comparação qualquer dedo poderá ser 
* comparado.
* Retorno: Template (String) ou "" (Vazio)
*********************************************/
function Enroll() {

	$.ajax({

		url: 'http://localhost:9000/api/public/v1/captura/Enroll/1',
		type: 'GET',
		success: function (data) {
		
			if (data != "" && data != null) {
				$("#inputTemplate").val(data);
				alert("Digitais capturadas com sucesso!");
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
* responsável por chamar a tela de captura de digital para apenas um único dedo e realizar a 
* comparação com um outro template (impressão digital) já cadastrada.
* Este método é recomendável quando você deseja você comparação de 1:1 (Um para Um). 
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

$(function() {
	$("#btn-capture").on("click", function(){
		Capture();
	});
	
	$("#btn-enroll").on("click", function(){
		Enroll();
	});
	
	$("#btn-match").on("click", function(){
		var digital = $("#inputTemplate").val();
		Match(digital);
	});
});