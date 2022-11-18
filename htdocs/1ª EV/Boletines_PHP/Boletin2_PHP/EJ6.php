<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Ejercicio 6</title>
    <?php
    function colorinchos()
    {
        $colores = array('rojo', 'verde', 'amarillo', 'azul', 'rosa');
        for ($i = 0; $i < count($colores); $i++) {
            if ($colores[$i] == 'azul') {
                unset($colores[$i]);
            }
        }
        print_r($colores);
    }
    ?>
</head>

<body>
    <?php
    colorinchos();
    ?>
</body>

</html>