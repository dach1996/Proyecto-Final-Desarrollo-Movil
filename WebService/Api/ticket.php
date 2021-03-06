<?php

include "../config.php";
include "../utils.php";
$dbConn =  connect($db);
$tablaTicket="tickets";
if ($_SERVER['REQUEST_METHOD'] == 'GET')
{
  $var = $_GET;
    if (isset($_GET['cod_ticket']))
    {
      //Mostrar un post
      $sql = $dbConn->prepare("SELECT * from  $tablaTicket  where cod_ticket=:cod_ticket");
      $sql->bindValue(':cod_ticket', $_GET['cod_ticket']);
      $sql->execute();
      header("HTTP/1.1 200 OK");
      echo json_encode(  $sql->fetch(PDO::FETCH_ASSOC)  );
      exit();
	  }
	  else {
      //Mostrar lista de post
      $sql = $dbConn->prepare("SELECT * FROM $tablaTicket");
      $sql->execute();
      $sql->setFetchMode(PDO::FETCH_ASSOC);
      header("HTTP/1.1 200 OK");
      echo json_encode( $sql->fetchAll()  );
      exit();
	}
}

if ($_SERVER['REQUEST_METHOD'] == 'POST')
{
    $input = $_POST;
    $sql = "INSERT INTO $tablaTicket
          (cod_local, titulo_ticket, fecha_inicio_ticket, fecha_fin_ticket,estado_ticket,prioridad_ticket,completador_ticket,cod_usuario,cod_cliente,cod_categoria)
          VALUES
          (:cod_local, :titulo_ticket, :fecha_inicio_ticket, :fecha_fin_ticket,:estado_ticket,:prioridad_ticket,:completador_ticket,:cod_usuario,:cod_cliente,:cod_categoria)";
    $statement = $dbConn->prepare($sql);
    bindAllValues($statement, $input);
    $statement->execute();

    $postCodigo = $dbConn->lastInsertId();
    if($postCodigo)
    {      
      $input['cod_local'] = $postCodigo;
      header("HTTP/1.1 200 OK");
      echo json_encode($input);
      exit();
	 }
}

if ($_SERVER['REQUEST_METHOD'] == 'DELETE')
{
	$codigo = $_GET['cod_ticket'];
  $statement = $dbConn->prepare("DELETE FROM  $tablaTicket where cod_ticket=:cod_ticket");
  $statement->bindValue(':cod_ticket', $codigo);
  $statement->execute();
	header("HTTP/1.1 200 OK");
	exit();
}

if ($_SERVER['REQUEST_METHOD'] == 'PUT')
{
    $input = $_GET;
    $postCodigo = $input['cod_ticket'];
    $fields = getParams($input);

    $sql = "
          UPDATE $tablaTicket
          SET $fields
          WHERE cod_ticket='$postCodigo'
           ";

    $statement = $dbConn->prepare($sql);
    bindAllValues($statement, $input);

    $statement->execute();
    header("HTTP/1.1 200 OK");
    exit();
}
?>
