<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Retirar</title>
    <link rel="stylesheet" href="estiloregistrar.css">
</head>

<body>
    <form action="retirar.php" method="POST">
        <div id="div3">
            Importe a retirar: <input type="text" name="retirar" id="ing"><br>
            <input type="submit" value="RETIRAR" id="btnING">
        </div>
    </form>
    <?php
    $conexion = mysqli_connect('localhost', 'root');
    mysqli_select_db($conexion, 'banco');
    session_start();
    $DNI = $_SESSION['foo'];

    $comp = false;

    if (empty($_POST['retirar'])) {
        $comp = true;
    } else {
        // if (!empty($_POST['nombre']) && !empty($_POST['apellido1']) && !empty($_POST['apellido2']) && !empty($_POST['dni']) && !empty($_POST['telefono']) && !empty($_POST['correo']) && !empty($_POST['direccion']) && !empty($_POST['dinero'])) {
        $retirar = trim($_POST['retirar']);
    }

    $query = "SELECT dinero_cuenta FROM clientes";
    $registro = mysqli_query($conexion, $query);
    $fila = mysqli_fetch_assoc($registro);
    $dinero = $fila['dinero_cuenta'];

    if (!$comp) {
        if ($dinero > 0) {
            $peticion = "UPDATE clientes SET dinero_cuenta = dinero_cuenta - '$retirar' WHERE DNI = '$DNI'";
            if (mysqli_query($conexion, $peticion)) {
                echo "<script>alert( '" . addslashes("Dinero retirado") . "' );</script>";
                header('Location: ..\mostrarusuario.php');
            } else {
                print "<p style = \"colo:red;\"> Error al realizar la peticion </p><br>" . mysqli_error($conexion);
            }
        } else {
            echo "<script>alert( '" . addslashes("Operación no realizada") . "' );</script>";
        }
    }
    ?>
</body>

</html>