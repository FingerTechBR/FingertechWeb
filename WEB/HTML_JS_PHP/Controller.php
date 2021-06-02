<?php
require_once("Connection.php");

/******************************************
 Verifica se houve uma solicitação AJAX, 
 verificando se o parâmetro "method" existe.
******************************************/
if(isset($_REQUEST['method'])) {
	$name = $_REQUEST['name'];
	$template = $_REQUEST['template'];
	$method = $_REQUEST['method'];

	$obj = new Controller();
	$obj->insertDB($name, $template);
}

class Controller {
	
	private $con;
	
	public function __construct() {
		
		// Cria uma instância para realizar a conexão com o banco.
		$this->con = new Connection();
	}
	
	/************************************************
	* Nome: insertDB
	* Descrição: Realiza a inserção das informação do 
	* 	usuário Nome e Template no banco de Dados.
	* 	Também foi definida o comando SQL de inserção.
	* Retorno: JSON
	************************************************/
	public function insertDB($name, $template) {
		
		$json;
		$sql = "INSERT INTO client(name, template) VALUES ('". $name ."','". $template ."')";
		if($this->con->execute($sql)) {
			
			$json = array(
				'error' => 'false',
				'msg' => 'Usuário Inserido com Sucesso!'
			);
		}
		else {
			$json = array(
				'error' => 'true',
				'msg' => 'Usuário Não Pode ser Cadastrado!'
			);
		}
		
		echo json_encode($json);
	}
	
	/************************************************
	* Nome: selectDB
	* Descrição: Seleciona as informações de todos os
	* 	dados dos usuários cadastrados no banco.
	* 	Também monta o html das linhas da tabela contendo
	* 	as informações do usuário.
	* Retorno: String (html)
	************************************************/
	public function selectDB() {
		
		$sql = "SELECT * FROM client";
		
		$result = $this->con->execute($sql);
		
		$tr = "";
		if ($result->num_rows > 0) {
			
			while($row = $result->fetch_assoc()) {
				
				$tr .= "
					<tr>
					  <th scope='row'>". $row['id'] ."</th>
					  <td>". $row['name'] ."</td>
					  <td class='td-template' style='word-break:break-all'>". $row['template'] ."</td>
					  <td class='align-middle'><button class='btn btn-secondary btn-match'>Comparar</button></td>
					</tr>";
			}
		} 
		else {
			
			$tr = "
				<tr>
					<th scope='row' colspan='4' style='text-align:center'>Nenhum usuário encontrado!</th>
				</tr>";
		}
		
		return $tr;
	}
}
?>