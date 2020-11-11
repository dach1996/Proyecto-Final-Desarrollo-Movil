<?php
include "config.php";
include "utils.php";

$dbConn =  connect($db);

if ($_SERVER['REQUEST_METHOD'] == 'GET')
{
    if (isset($_GET['cod_usuario']))
    {
      //Mostrar un post
      $sql = $dbConn->prepare("SELECT * usuarios  where cod_usuario=:cod_usuario");
      $sql->bindValue(':cod_usuario', $_GET['cod_usuario']);
      $sql->execute();
      header("HTTP/1.1 200 OK");
      echo json_encode(  $sql->fetch(PDO::FETCH_ASSOC)  );
      exit();
	  }

	  else {
      //Mostrar lista de post
      $sql = $dbConn->prepare("SELECT * FROM usuarios");
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
    $sql = "INSERT INTO usuarios
    
(cod_usuario,ced_usuario,nombre_usuario,apellido_usuario,password_usuario,fecha_nacimiento_usuario,foto_usuario,usuario_usuario,correo_usuario)          
          VALUES
          (:cod_usuario, :ced_usuario, :nombre_usuario, :apellido_usuario,:password_usuario,:fecha_nacimiento_usuario,:foto_usuario,:usuario_usuario,:correo_usuario)";
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
	$codigo = $_GET['cod_usuario'];
  $statement = $dbConn->prepare("DELETE FROM  usuarios where cod_usuario=:cod_usuario");
  $statement->bindValue(':cod_usuario', $codigo);
  $statement->execute();
	header("HTTP/1.1 200 OK");
	exit();
}

if ($_SERVER['REQUEST_METHOD'] == 'PUT')
{
    $input = $_GET;
    $postCodigo = $input['cod_usuario'];
    $fields = getParams($input);

    $sql = "
          UPDATE usuarios
          SET $fields
          WHERE cod_usuario='$postCodigo'
           ";

    $statement = $dbConn->prepare($sql);
    bindAllValues($statement, $input);

    $statement->execute();
    header("HTTP/1.1 200 OK");
    exit();
}
//En caso de que ninguna de las opciones anteriores se haya ejecutado


?>
