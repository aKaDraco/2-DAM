<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>ejercicico5</title>
    <?php
    function comprobante ($n1, $n2) {
        if($n1%$n2 == 0) {
            return "Son Multiplos";
        } else {
            return "No son Multiplos";
        }
    }

    echo comprobante(3,2);
    ?>
</head>
<body>
    
</body>
</html>