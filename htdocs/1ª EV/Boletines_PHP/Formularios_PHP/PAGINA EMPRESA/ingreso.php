<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>INGRESO</title>
    <link rel="stylesheet" href="estiloregistrar.css">
</head>

<body>
    <form action="ingreso.php" method="POST">
        <div id="div3">
            Ingreso: <input type="text" name="ingreso" id="ing"><br>
            <input type="submit" value="INGRESAR" id="btnING">
        </div>
    </form>
    <?php
    $conexion = mysqli_connect('localhost', 'root');
    mysqli_select_db($conexion, 'banco');
    session_start();
    $DNI = $_SESSION['foo'];

    $comp = false;

    if (empty($_POST['ingreso'])) {
        $comp = true;
    } else {
        // if (!empty($_POST['nombre']) && !empty($_POST['apellido1']) && !empty($_POST['apellido2']) && !empty($_POST['dni']) && !empty($_POST['telefono']) && !empty($_POST['correo']) && !empty($_POST['direccion']) && !empty($_POST['dinero'])) {
        $ingreso = trim($_POST['ingreso']);
    }

    $query = "SELECT dinero_cuenta FROM clientes";
    $registro = mysqli_query($conexion, $query);

    if (!$comp) {
        $peticion = "UPDATE clientes SET dinero_cuenta = dinero_cuenta + '$ingreso' WHERE DNI = '$DNI'";
        if (mysqli_query($conexion, $peticion)) {
            echo "<script>alert( '" . addslashes("Ingreso realizado") . "' );</script>";
            header('Location: ..\mostrarusuario.php');
        } else {
            print "<p style = \"colo:red;\"> Error en el ingreso </p><br>" . mysqli_error($conexion);
        }
    }
    ?>
</body>

</html>