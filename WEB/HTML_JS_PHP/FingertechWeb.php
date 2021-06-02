<?php
require_once("Controller.php");

$obj = new Controller();
$table = $obj->selectDB();
?>
<!DOCTYPE html>
<html lang="pt-BR">
	<head>
		<meta charset="utf-8" />
		<title>Fingertech WEB - Sample HTML + JS + PHP</title>
		<link rel="stylesheet" href="css/bootstrap.css" />
		<link rel="stylesheet" href="css/fingertechweb.css" />
	</head>
	
	<body>
		<main role="main" class="container">
			<div style="text-align: center;">
				<img src="img/LogoFingertech.png" width="60%" />
				<h1>Serviço Fingertech Web</h1>
				<h2 style="color: #AAA;">Exemplo para Captura de Impressão Digital - SDK Nitgen</h2>
			</div>
			
			<br />
			<div class="form-group row justify-content-center">
				<label for="inputName" class="col-1 col-form-label"><b>Nome:</b></label>
				<div class="col-6">
				  <input type="text" class="form-control" id="inputName" placeholder="Digite seu nome...">
				</div>
				
				<div class="col-1">
					<button class="btn btn-primary" id="btn-capture">Cadastrar</button>
				</div>
			</div>
			
			
			<div class="row" style="padding-left: 150px; padding-right: 150px; margin-bottom: 20px;">
				<table class="table table-condensed">
					<thead class="thead-light">
						<tr>
							<th scope="col" class="col-1">ID</th>
							<th scope="col" class="col-2">Nome</th>
							<th scope="col" class="col-8">Template</th>
							<th scope="col" class="col-1">Ação</th>
						</tr>
					</thead>
					<tbody>
						<?php echo $table; ?>
					</tbody>
				</table>
			</div>
			
		</main>
		
		<footer class="footer py-3">
			<div style="text-align: center;">
				<span class="text-muted">
					<b>Fingertech 2019</b> <br /> 
					<a href="http://www.fingertech.com.br" target="_blank">www.fingertech.com.br</a>
				</span>
			</div>
		</footer>
	</body>
	
	<script type="text/javascript" src="js/jquery-3.3.1.js"></script>
	<script type="text/javascript" src="js/bootstrap.js"></script>
	<script type="text/javascript" src="js/fingertechweb.js"></script>
</html>

