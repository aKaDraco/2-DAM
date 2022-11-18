<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>MostrarUsuarios</title>
</head>

<body>
    <?php
    $conexion = mysqli_connect('localhost', 'root');
    mysqli_select_db($conexion, 'usuariosbd');
    
    $query = "SELECT * FROM usuarios";
    $registros = mysqli_query($conexion, $query);
    if ($registros) {
        if (mysqli_num_rows($registros) > 0) {
            while ($fila = mysqli_fetch_array($registros)) {
                print "<h3>Datos del usuario</h3>";
                print "<p>Nombre: " . $fila['Nombre'] . "</p>";
                print "<p>Apellidos: " . $fila['Apellidos'] . "</p>";
                print "<p>Correo: " . $fila['Correo'] . "</p>";
                print "<a href='actualizarusuarios.php?id={$fila['id']}'>" . "Actualizar" . "</a>";
                print "    ";
                print "<a href='eliminarusuarios.php?id={$fila['id']}'>" . "Eliminar" . "</a>";
                print "<br>";
                print "----------------------------------------<br>";
            }
        } else {
            print "<p>No hay usuarios</p>";
        }
    } else {
        print "<p style = \"colo:red;\"> No se ha podido realizar la petición </p><br>" . mysqli_error($conexion);
    }
    ?>
</body>

</html>