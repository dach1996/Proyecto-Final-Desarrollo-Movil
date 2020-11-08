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
      $sql = $dbConn->prepare("SELECT * from  $tablaTicket t join categorias c on t.cod_categoria=c.cod_categoria  where cod_ticket=:cod_ticket");
      $sql->bindValue(':cod_ticket', $_GET['cod_ticket']);
      $sql->execute();
      header("HTTP/1.1 200 OK");
      $prueba= $sql->fetch(PDO::FETCH_ASSOC);
      echo json_encode(  $sql->fetch(PDO::FETCH_ASSOC)  );
      exit();
	  }
	  else {
      //Mostrar lista de post
      $sql = $dbConn->prepare("SELECT  json_array(
        json_object(
        'ticket',t.cod_ticket,
        'detalles', json_arrayagg(json_object(
                      'codigo',d.cod_detalle,'nombre',d.texto_detalle)
                                    )
        ) 
        )as dato
        FROM tickets t join detalles_ticket d on t.cod_ticket=d.cod_ticket
        group by t.cod_ticket
        ");
      $sql->execute();
      $sql->setFetchMode(PDO::FETCH_ASSOC);
      header("HTTP/1.1 200 OK");
      $str="";
      $prueba =  $sql->fetchAll()  ;
      foreach($prueba as $item){
        $str=$str.implode("",$item);
      }
      echo $str;
      exit();
	}
}

if ($_SERVER['REQUEST_METHOD'] == 'POST')
{
    $input = $_POST;
    $sql = "INSERT INTO $tablaTicket
          (cod_local, titulo_ticket, fecha_inicio_ticket, fecha_fin_ticket,estado_ticket,prioridad_ticket,completador_ticket,cod_usuario,cod_cliente,cod_categoria)
          VALUES
          (:codigo, :nombre, :apellido, :edad)";
    $statement = $dbConn->prepare($sql);
    bindAllValues($statement, $input);
    $statement->execute();

    $postCodigo = $dbConn->lastInsertId();
    if($postCodigo)
    {      
      $input['codigo'] = $postCodigo;
      header("HTTP/1.1 200 OK");
      echo json_encode($input);
      exit();
	 }
}

if ($_SERVER['REQUEST_METHOD'] == 'DELETE')
{
	$codigo = $_GET['codigo'];
  $statement = $dbConn->prepare("DELETE FROM  $tablaTicket where codigo=:codigo");
  $statement->bindValue(':codigo', $codigo);
  $statement->execute();
	header("HTTP/1.1 200 OK");
	exit();
}

if ($_SERVER['REQUEST_METHOD'] == 'PUT')
{
    $input = $_GET;
    $postCodigo = $input['codigo'];
    $fields = getParams($input);

    $sql = "
          UPDATE $tablaTicket
          SET $fields
          WHERE codigo='$postCodigo'
           ";

    $statement = $dbConn->prepare($sql);
    bindAllValues($statement, $input);

    $statement->execute();
    header("HTTP/1.1 200 OK");
    exit();
}
?>
