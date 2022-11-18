<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Actualizar Usuario</title>
    <link rel="stylesheet" href="estiloregistrar.css">
</head>

<body>
    <?php
    $conexion = mysqli_connect('localhost', 'root');
    mysqli_select_db($conexion, 'banco');
    session_start();
    $DNI = $_SESSION['foo'];

    //Comprobación del ID

    $query =  "SELECT * FROM clientes WHERE DNI = '$DNI'";
    if ($registro = mysqli_query($conexion, $query)) {
        $fila = mysqli_fetch_array($registro);

        print "<form action=\"modificar.php\" method=\"post\">";
        print "<div id=\"div2\">";
        print "<input type=\"hidden\" name=\"id\" value=" . $DNI . "><br>";
        print "<div id=\"divnom\">";
        print "Nombre: <input type=\"text\" name=\"nombre\" value=" . $fila['Nombre'] . "><br>";
        print "Primer apellido: <input type=\"text\" name=\"apellido1\" value=" . $fila['Primer_apellido'] . "><br>";
        print "Segungo apellido: <input type=\"text\" name=\"apellido2\" value=" . $fila['Segundo_apellido'] . "><br>";
        print "</div>";
        print "<div id=\"divnom\">";
        print "Telefono: <input type=\"text\" name=\"telefono\" value=" . $fila['Telefono'] . "><br>";
        print "Correo: <input type=\"mail\" name=\"correo\" value=" . $fila['Correo'] . "><br>";
        print "Direccion: <input type=\"text\" name=\"direccion\" value=" . $fila['Direccion'] . "><br>";
        print "</div>";
        print "<input type=\"submit\" value=\"Actualizar\" id=\"btnr\" /><br>";
        print "</div>";
        print "</form>";
    } else {
        print "<p style = \"colo:red;\"> No se ha podido realizar la petición </p><br>" . mysqli_error($conexion);
    }
    $problema = false;
    if (isset($_POST['id'])) {
        if (!empty($_POST['nombre']) && !empty($_POST['apellido1']) && !empty($_POST['apellido2']) && !empty($_POST['telefono']) && !empty($_POST['direccion']) && !empty($_POST['correo'])) {
            $nombre = mysqli_real_escape_string($conexion, trim($_POST['nombre']));
            $apellido1 = mysqli_real_escape_string($conexion, trim($_POST['apellido1']));
            $apellido2 = mysqli_real_escape_string($conexion, trim($_POST['apellido2']));
            $telefono = mysqli_real_escape_string($conexion, trim($_POST['telefono']));
            $direccion = mysqli_real_escape_string($conexion, $_POST['direccion']);
            $correo = mysqli_real_escape_string($conexion, trim($_POST['correo']));
        } else {
            print "<p style = \"colo:red;\"> No se ha podido realizar la petición </p><br>" . mysqli_error($conexion);
            $problema = true;
        }

        if (!$problema) {
            $query = "UPDATE clientes SET Nombre='$nombre', Primer_apellido='$apellido1', Segundo_apellido='$apellido2',Telefono='$telefono',Direccion='$direccion',Correo='$correo' WHERE DNI = '$DNI'";
            mysqli_query($conexion, $query); 
            if (mysqli_affected_rows($conexion) == 1) {
                echo "<script>alert( '" . addslashes("Cambios realizados") . "' );</script>";
                header('Location: ..\mostrarusuario.php');
            } else {
                print "<p style = \"colo:red;\"> No se ha podido actualizar el usuarios</p><br>" . mysqli_error($conexion);
            }
        }
    }
    mysqli_close($conexion);
    ?>
</body>

</html>