<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Informacion</title>
    <?php
    include 'funciones.php';
    ?>
</head>
<body>
    <?php
    // phpinfo();
    // phpversion();
    $suma = sumar(3,4);
    $resta = restar(4,3);
    $multiplicacion = multiplicar(3,4);
    $division = dividir(4,2);

    echo "El resultado de la suma es: $suma<br>";
    echo "El resultado de la resta es: $resta<br>";
    echo "El resultado de la suma es: $multiplicacion<br>";
    echo "El resultado de la suma es: $division";
    ?>
</body>
</html>