<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Ejercicio 2</title>
    <?php
    function cade($frase, $letra)
    {
        $cont = 0;
        for ($i = 0; $i < strlen($frase); $i++) {
            if ($frase[$i] == $letra) {
                $cont++;
            }
        }
        echo "La letra \"$letra\" aparece: ", $cont, " veces";
    }
    ?>
</head>

<body>
    <?php
    cade("mamamiaaa", "a");
    ?>
</body>

</html>