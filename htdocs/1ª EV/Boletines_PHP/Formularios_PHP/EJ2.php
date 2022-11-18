<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>EJ2</title>
</head>

<body>
    <form action="EJ2P.php" method="post">
        <p>Rellena el siguiente formulario</p>
        <p>Nombre: <input type="text" name="nombre"></p>
        <p>Email: <input type="text" name="mail"></p>
        <p>Tel&eacute;fono: <input type="text" name="telefono" maxlength="9"></p>
        <p>Mensaje: <textarea name="mensaje"cols="70" rows="8" placeholder="Escriba aqui su memsaje"></textarea></p>
        <input type="submit" value="Enviar Datos">
    </form>
</body>

</html>