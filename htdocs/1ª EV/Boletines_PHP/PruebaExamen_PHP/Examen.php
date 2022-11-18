<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>EXAMEN</title>
</head>

<body>
    <h3>Formulario de subscripción a nuestras publicaciones:</h3>
    <br>
    <form action="Examen_PHP.php" method="post">
        <p>Nombre: <input type="text" name="nombre" size="15"></p>
        <p>Primer apellido: <input type="text" name="apellido1" size="15"></p>
        <p>Segundo apellido: <input type="text" name="apellido2" size="15"></p>
        <p>Correo electr&oacute;nico: <input type="text" name="correo" size="15"></p>
        <br>
        <p style="margin-bottom: -0.1%;">¿Desea recibir información sobre las publicaciones?</p>
        <input type="radio" name="radio[]" value="S">Si,estoy interesado<br>
        <input type="radio" name="radio[]" value="N">No, gracias
        <br>
        <p style="margin-bottom: -0.1%;">Publicaiones disponibles:</p>
        <input type="checkbox" name="sub[]" value="National Geographic">National Geographic<br>
        <input type="checkbox" name="sub[]" value="Electronic Letters">Electronic Letters<br>
        <input type="checkbox" name="sub[]" value="Conoces">Conoces<br>
        <input type="checkbox" name="sub[]" value="Science">Science<br>
        <input type="checkbox" name="sub[]" value="Desarrollo Web">Desarrollo Web<br>
        <br>
        <p>Formas de subscripci&oacute;n: <select name="opsub">
            <option value="" selected disabled hidden>-Elegir-</option>
            <option value="S">Semanal</option>
            <option value="M">Mensual</option>
            <option value="A">Anual</option>
        </select></p>
        <input type="submit" value="Subscribirme">
    </form>
</body>

</html>