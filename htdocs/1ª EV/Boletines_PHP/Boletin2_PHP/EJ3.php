<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Ejercicio 3</title>
    <?php
    function comp($contra)
    {
        // $nums = array(0, 1, 2, 3, 4, 5, 6, 7, 8, 9);
        if (strlen($contra) >= 8 && strlen($contra) <= 12) {
            if (is_numeric($contra[0])) {
                echo "CONTRASEÑA NO VÁLIDA, EMPIEZA POR NUMERO";
            } else {
                echo "CONTRASEÑA VÁLIDA";
            }
        } else {
            echo "CONTRASEÑA NO VÁLIDA, LONGITUD INADECUADA";
        }
    }
    ?>
</head>

<body>
    <?php
    comp("e2345678");
    ?>
</body>

</html>