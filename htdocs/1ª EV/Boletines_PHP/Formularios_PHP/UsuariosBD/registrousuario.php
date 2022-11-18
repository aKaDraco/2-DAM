<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Registro</title>
</head>

<body>
    <?php
    $conexion = mysqli_connect('localhost', 'root');
    mysqli_select_db($conexion, 'usuariosbd');

    $comp = false;

    if (!empty($_POST['nombre']) && !empty($_POST['apellido']) && !empty($_POST['correo'])) {
        $nombre = trim($_POST['nombre']);
        $apellido = trim($_POST['apellido']);
        $correo = trim($_POST['correo']);
    } else {
        print "<p style = \"colo:red;\">Debe introducir un nombre, un apellido y un correo </p>";
        $comp = true;
    }

    // CONTROL DE USUARO REGISTRADO
    $query = "SELECT * FROM usuarios";
    $registros = mysqli_query($conexion, $query);
    if ($registros) {
        if (empty($registros)) {
            print "<p>No hay usuarios registrados</p>";
        } else {
            while ($fila = mysqli_fetch_array($registros)) {
                if (($fila['Nombre'] == $nombre) && ($fila['Apellidos'] == $apellido)) {
                    print "<p>Ya existe un usuario con ese nombre y apellido</p>";
                    $comp = true;
                    break;
                } else if ($fila['Correo'] == $correo) {
                    print "<p>Ya existe un usuario con ese correo</p>";
                    $comp = true;
                    break;
                }
            }
        }
    } else {
        print "<p style = \"colo:red;\"> No se ha podido realizar la petición </p><br>" . mysqli_error($conexion);
    }

    if (!$comp) {
        $peticion = "INSERT INTO usuarios (id,Nombre,Apellidos,Correo) VALUES (0,'$nombre','$apellido','$correo')";
        if (mysqli_query($conexion, $peticion)) {
            print "<p> Usuario Registrado </p>";
        } else {
            print "<p style = \"colo:red;\"> Error en el registro </p><br>" . mysqli_error($conexion);
        }
    }
    ?>

</body>

</html>