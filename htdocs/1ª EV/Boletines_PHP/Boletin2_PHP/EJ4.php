<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Ejercicio 4</title>
    <?php
    function pares()
    {
        $pares = array();
        for ($i = 1; $i <= 10; $i++) {
            if ($i % 2 == 0) {
                array_push($pares, $i);
            }
        }
        for ($j = 0; $j < count($pares); $j++) {
            echo "Numero[$j] = $pares[$j]<br/>";
        }
    }
    ?>
</head>

<body>
    <?php
    pares();
    ?>
</body>

</html>