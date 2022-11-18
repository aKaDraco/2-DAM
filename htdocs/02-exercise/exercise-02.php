<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Exercise-02</title>
</head>

<body>
    <style>
        textarea{
            resize: none;
        }
    </style>

    <form action="comprobar.php" method="post">
        <p>Rellena el siguiente formulario:</p>
        <p>Nombre: <input type="text" name="nombre"></p>
        <p>Email: <input type="mail" name="email"></p>
        <p>Teléfono: <input type="text" name="tfno" size="7"></p>
        <p>Mensaje: <textarea name="textA" placeholder="Escriba aquí su mensaje..." cols="50" rows="7"></textarea></p>
        <p><input type="submit" value="Enviar datos"></p>
    </form>
</body>

</html>