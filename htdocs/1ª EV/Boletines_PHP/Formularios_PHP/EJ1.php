<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Ejercicio 1</title>
</head>

<body>
    <form action="EJ1P.php" method="POST">
        <p>Rellena el siguiente formulario para calcular el coste del envío:</p>
        <p>Precio: <input type="text" name="precio" maxlength="5" size="5"></p>
        <p>Cantidad: <input type="text" name="cantidad" maxlength="5" size="5"></p>
        <p>Descuento: <input type="text" name="descuento" maxlength="5" size="5"></p>
        <p>IVA <input type="text" name="iva" maxlength="3" size="3"> %</p>
        <p>Método de envío: <select name="envio"></p>
        <option value="0">Recoger en tienda</option>
        <option value="5">Correos</option>
        <option value="8">SEUR</option>
        </select>
        <br>
        <br>
        <input type="submit" name="calcular" value="Calcular Precio Total" onclick="calcular();">
    </form>
</body>

</html>