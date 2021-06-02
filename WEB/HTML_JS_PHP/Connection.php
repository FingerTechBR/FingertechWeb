<?php
class Connection {
	
	// DADOS DE ACESSO.
	private $con;
	private $host = "localhost";
	private $dbname = "clients";
	private $username = "root";
	private $password = "";
	
	public function __construct() {
        
		$this->getInstance();
    }
	
	/************************************************
	* Nome: getInstance
	* Descrição: Cria uma conexão com o banco de dados.
	************************************************/
    public function getInstance() {
		
		$this->con = mysqli_connect($this->host, $this->username, $this->password, $this->dbname) or die (mysqli_error());
    }
	
	/************************************************
	* Nome: execute
	* Descrição: Executa um comando SQL.
	* Retorno: ResultSet
	************************************************/
	public function execute($sql) {
		return $this->con->query($sql);
	}
}
?>