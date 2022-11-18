<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Actualizar Usuario</title>
</head>

<body>
    <?php
    $conexion = mysqli_connect('localhost', 'root');
    mysqli_select_db($conexion, 'usuariosbd');

    //Comprobación del ID

    if (isset($_GET['id'])) {
        $query =  "SELECT Nombre, Apellidos, Correo FROM usuarios WHERE id={$_GET['id']}";
        if ($registro = mysqli_query($conexion, $query)) {
            $fila = mysqli_fetch_array($registro);

            print "<form action=\"actualizarusuarios.php\" method=\"post\">";
            print "<input type=\"text\" name=\"nombre\" value=" . $fila['Nombre'] . "><br>";
            print "<input type=\"text\" name=\"apellidos\" value=" . $fila['Apellidos'] . "><br>";
            print "<input type=\"mail\" name=\"correo\" value=" . $fila['Correo'] . "><br>";
            print "<input type=\"hidden\" name=\"id\" value=" . $_GET['id'] . "><br>";
            print "<input type=\"submit\" value=\"Actualizar\"/><br>";
            print "</form>";
        } else {
            print "<p style = \"colo:red;\"> No se ha podido realizar la petición </p><br>" . mysqli_error($conexion);
        }
    } elseif (isset($_POST['id'])) {
        $problema = false;

        if (!empty($_POST['nombre']) && !empty($_POST['apellidos']) && !empty($_POST['correo'])) {
            $nombre = mysqli_real_escape_string($conexion, trim($_POST['nombre']));
            $apellidos = mysqli_real_escape_string($conexion, trim($_POST['apellidos']));
            $correo = mysqli_real_escape_string($conexion, trim($_POST['correo']));
        } else {
            print "<p style = \"colo:red;\"> No se ha podido realizar la petición </p><br>" . mysqli_error($conexion);
            $problema = true;
        }

        if (!$problema) {
            $query = "UPDATE usuarios SET Nombre='$nombre', Apellidos='$apellidos',Correo='$correo' WHERE id={$_POST['id']}";
            $registro = mysqli_query($conexion, $query);
            if (mysqli_affected_rows($conexion) == 1) {
                print "<p>Cambios realizados en el usuarios</p>";
            } else {
                print "<p style = \"colo:red;\"> No se ha podido actualizar el usuarios</p><br>" . mysqli_error($conexion);
            }
        }
    } else {
        print "<p>No se han recibido datos del formulario</p>";
    }
    mysqli_close($conexion);
    ?>
</body>

</html>