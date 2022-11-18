<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>ejercicio10</title>
    <?php
    function fibonacci () {
        $n1 = 0;
        $n2 = 1;
        echo $n1."<br>";
        while ($n2 < 10000) {
            $aux = $n1;
            $n1 = $n2;
            $n2 = $aux + $n1;
            echo $n1."<br>";
        }
    }

    echo fibonacci();
    ?>
</head>
<body>
    
</body>
</html>