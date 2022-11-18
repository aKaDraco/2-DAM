<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Usuario</title>
    <link rel="stylesheet" href="estilomostrar.css">
</head>

<body>

    <?php
    session_start();
    $DNI = $_SESSION['foo'];
    echo "<form action=\"mostrarusuario.php\" method=\"POST\">";
    echo "<input type=\"hidden\" name=\"nif\" value =" . $DNI . ">";
    echo "</form>";
    ?>
    <nav>
        <h1>OPCIONES</h1>
        <div id="div1">
            <form action="registrarusuario.php" method="post">
                <input type="submit" value="Añadir nuevo cliente" id="btn">
            </form>
            <form action="mostrar.php" method="post">
                <input type="submit" value="Mostrar datos" id="btn">
            </form>
            <form action="eliminar.php" method="post">
                <input type="submit" value="Eliminar cliente" id="btn">
            </form>
            <form action="modificar.php" method="post">
                <input type="submit" value="Modificar datos" id="btn">
            </form>
            <form action="ingreso.php" method="post">
                <input type="submit" value="Realizar ingreso" id="btn">
            </form>
            <form action="retirar.php" method="post">
                <input type="submit" value="Retirar dinero" id="btna">
            </form>
        </div>
        <p id="lnk"><a href="Index.php">Log out</a></p>
    </nav>
</body>

</html>