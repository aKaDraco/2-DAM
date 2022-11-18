<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>EJ 1</title>
    <?php
    function cadena()
    {
        $texto = 'abordaje';
        $cadena1 = 'abord';
        $cadena2 = 'almir';
        $resultado = str_replace($cadena1, $cadena2, $texto);
        echo "La palabra: $texto, se convirtió en $resultado. </br>";
    }
    ?>
</head>

<body>
    <?php
    cadena();
    ?>
</body>

</html>