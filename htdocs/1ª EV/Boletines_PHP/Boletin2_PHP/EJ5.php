<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Ejercicio 5</title>
    <?php
    function meses()
    {
        $meses = array(
            'enero', 'febrero', 'marzo', 'abril', 'mayo', 'junio', 'julio', 'agosto',
            'septiembre', 'octubre', 'noviemnbre', 'diciembre'
        );
        $mesesM = array();
        for ($i = 0; $i < count($meses); $i++) {
            if (substr($meses[$i], 0, 1) == 'm') {
                array_push($mesesM, $meses[$i]);
            }
        }

        for ($j = 0; $j < count($mesesM); $j++) {
            echo "Mes[$j] = $mesesM[$j]<br/>";
        }
    }
    ?>
</head>

<body>
    <?php
    meses();
    ?>
</body>

</html>