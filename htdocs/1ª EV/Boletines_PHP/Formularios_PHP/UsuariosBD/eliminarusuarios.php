<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Borrar Usuario</title>
</head>

<body>
    <?php
    $conexion = mysqli_connect('localhost', 'root');
    mysqli_select_db($conexion, 'usuariosbd');

    //Comprobación

    if (isset($_GET['id'])) {
        print "<form action=\"eliminarusuarios.php\" method=\"post\">";
        print "<h5>ESTA SEGURO DE QUE DESEA BORRAR EL USUARIO?</h5>";
        print "<input type=\"submit\" name=\"confirmar\" value=\"SI\"> ";
        print "<input type=\"submit\" name=\"rechazar\" value=\"NO\">";
        print "<input type=\"hidden\" name=\"id\" value=" . $_GET['id'] . ">";
        print "</form>";
    } elseif (isset($_POST['id'])) {
        if (isset($_POST['confirmar'])) {
            $query =  "DELETE FROM usuarios WHERE id={$_POST['id']} LIMIT 1";
            if (mysqli_query($conexion, $query)) {
                print "<p>Usuario eliminado</p>";
            } else {
                print "<p style = \"colo:red;\"> No se ha podido realizar la petición </p><br>" . mysqli_error($conexion);
            }
        } else if (isset($_POST['rechazar'])) {
            print "<p>Ningún usuario eliminado</p>";
        }
    }
    mysqli_close($conexion);
    ?>
</body>

</html>