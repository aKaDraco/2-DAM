<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Formualrio</title>
</head>

<body>
    <form action="registrousuario.php" method="post">
        Nombre: <input type="text" name="nombre"></br>
        Apellidos: <input type="text" name="apellido"></br>
        Correo: <input type="mail" name="correo"></br>
        <input type="submit" value="Registrar"></br>
    </form>
    <form action="mostrarusuarios.php" method="post">
        <input type="submit" value="Ver usuarios registrados">
    </form>
</body>

</html>