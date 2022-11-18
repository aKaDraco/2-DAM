<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Eliminar</title>
    <link rel="stylesheet" href="estiloeliminar.css">
</head>

<body>
    <?php
    session_start();
    $DNI = $_SESSION['foo'];
    $conexion = mysqli_connect('localhost', 'root');
    mysqli_select_db($conexion, 'banco');
    $query = "DELETE FROM clientes WHERE DNI = '$DNI'";
    if (mysqli_query($conexion, $query)) {
        echo "<h1>Cliente eliminado</h1>";
    }
    ?>

    <form action="Index.html" method="post">
        <div id="div1">
            <input type="submit" value="Volver" id="btn">
        </div>
    </form>
</body>

</html>