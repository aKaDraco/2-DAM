<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>DATOS</title>
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

        print "<h1 id=\"datos\">DATOS</h1>";
        print "<form action=\"Index.html\" method=\"post\">";
        print "<div id=\"div4\">";
        print "DNI: <input type=\"text\" name=\"id\" readonly value=" . $DNI . "><br>";
        print "<div id=\"divnom\">";
        print "Nombre: <input type=\"text\" name=\"nombre\" readonly value=" . $fila['Nombre'] . "><br>";
        print "Primer apellido: <input type=\"text\" name=\"apellido1\" readonly value=" . $fila['Primer_apellido'] . "><br>";
        print "Segungo apellido: <input type=\"text\" name=\"apellido2\" readonly value=" . $fila['Segundo_apellido'] . "><br>";
        print "</div>";
        print "<div id=\"divnom\">";
        print "Telefono: <input type=\"text\" name=\"telefono\" readonly value=" . $fila['Telefono'] . "><br>";
        print "Correo: <input type=\"mail\" name=\"correo\" readonly value=" . $fila['Correo'] . "><br>";
        print "Direccion: <input type=\"text\" name=\"direccion\" readonly value=" . $fila['Direccion'] . "><br>";
        print "</div>";
        print "<div id=\"divnom\">";
        print "Numero de cuenta: <input type=\"text\" name=\"telefono\" readonly value=" . $fila['numero_cuenta'] . "><br>";
        print "Dinero en la cuenta: <input type=\"mail\" name=\"correo\" readonly value=" . $fila['dinero_cuenta'] . "><br>";
        print "</div>";
        print "<input type=\"submit\" value=\"VOLVER\" id=\"btnr2\" /><br>";
        print "</div>";
        print "</form>";
    } else {
        print "<p style = \"colo:red;\"> No se ha podido realizar la petición </p><br>" . mysqli_error($conexion);
    }
    mysqli_close($conexion);
    ?>
</body>

</html>