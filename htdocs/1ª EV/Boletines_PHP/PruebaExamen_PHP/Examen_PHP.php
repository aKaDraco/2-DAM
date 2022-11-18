<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>EXAMEN2</title>
</head>

<body>
    <h3>Datos del subscriptor:</h3>
    <br>
    <?php
    $radio = $_POST['radio'];
    $subs;
    $pub = $_POST['sub'];
    if (isset($_POST['nombre']) && !empty($_POST['nombre'])) {
        $nombre = $_POST['nombre'];
    }

    echo "Nombre: " . $nombre . "<br>";

    if (isset($_POST['apellido1']) && !empty($_POST['apellido1'])) {
        $apellido1 = $_POST['apellido1'];
    }

    echo "Primer apellido: " . $apellido1 . "<br>";

    if (isset($_POST['apellido2']) && !empty($_POST['apellido2'])) {
        $apellido2 = $_POST['apellido2'];
    }

    echo "Segundo apellido: " . $apellido2 . "<br>";
    echo "<br>";

    if (isset($_POST['correo']) && !empty($_POST['correo'])) {
        $correo = $_POST['correo'];
    }

    foreach ($radio as $value) {
        if (isset($value)) {
            if ($value == "S") {
                $subs = "Le enviaremos informacion relacionada con nuestras publicaiones al correo " . $correo . "<br>";
            } else {
                $subs = "No le enviaremos informacion relacionada con nuestras publicaiones al correo " . $correo . "<br>";
            }
        }
    }

    echo $subs . "<br>";
    echo "<h3>Datos de la subscripción</h3>";
    echo "<br>";
    echo "Señor/a " . $apellido1 . ". Estas son las publicaiones a las que se ha subscrito: <br>";
    foreach ($pub as $value) {
        if (isset($value)) {
            echo "<b>" . $value . "</b> <br>";
        }
    }
    ?>
</body>

</html>