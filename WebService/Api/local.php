<?php
include "../config.php";
include "../utils.php";


$dbConn =  connect($db);

if ($_SERVER['REQUEST_METHOD'] == 'GET')
{
    if (isset($_GET['cod_local']))
    {
      //Mostrar un post
      $sql = $dbConn->prepare("SELECT * locales  where cod_local=:cod_local");
      $sql->bindValue(':cod_local', $_GET['cod_local']);
      $sql->execute();
      header("HTTP/1.1 200 OK");
      echo json_encode(  $sql->fetch(PDO::FETCH_ASSOC)  );
      exit();
	  }

	  else {
      //Mostrar lista de post
      $sql = $dbConn->prepare("SELECT * FROM locales");
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
    $sql = "INSERT INTO locales
          (cod_local, nomb_local)
          VALUES
          (:cod_local, :nomb_local)";
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
	$codigo = $_GET['cod_local'];
  $statement = $dbConn->prepare("DELETE FROM  locales where cod_local=:cod_local");
  $statement->bindValue(':cod_local', $codigo);
  $statement->execute();
	header("HTTP/1.1 200 OK");
	exit();
}

if ($_SERVER['REQUEST_METHOD'] == 'PUT')
{
    $input = $_GET;
    $postCodigo = $input['cod_local'];
    $fields = getParams($input);

    $sql = "
          UPDATE locales
          SET $fields
          WHERE cod_local='$postCodigo'
           ";

    $statement = $dbConn->prepare($sql);
    bindAllValues($statement, $input);

    $statement->execute();
    header("HTTP/1.1 200 OK");
    exit();
}
//En caso de que ninguna de las opciones anteriores se haya ejecutado


?>
