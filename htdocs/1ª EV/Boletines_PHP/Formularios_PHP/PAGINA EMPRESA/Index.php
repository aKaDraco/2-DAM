<?php
$conexion = mysqli_connect('localhost', 'root');
mysqli_select_db($conexion, 'banco');
$query = "SELECT * FROM clientes";
$registros = mysqli_query($conexion, $query);
if ($registros) {
    if (!mysqli_num_rows($registros)) {
        header('Location: Index.html');
        die();
    } else {
        while ($fila = mysqli_fetch_array($registros)) {
            if (($fila['DNI'] != trim($_POST['nif'])) || $fila['PASSW0RD'] != trim($_POST['pass'])) {
                header('Location: Index.html');
                die();
            } else {
                session_start();
                $_SESSION['foo'] = $_POST['nif'];
                $DNI = $_SESSION['foo'];
                header('Location: mostrarusuario.php');
            }
        }
    }
}
?>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>LOG IN</title>
</head>

<body>

</body>

</html>