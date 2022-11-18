<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>ejercicio6</title>
    <?php
    function precio ($edad) {
        switch($edad) {
            case $edad <= 8:
                return "Entrada gratis";
                break;
            case $edad >8 && $edad <= 16:
                return "La entrada cuesta 5€";
                break;
            case $edad > 16 && $edad <= 25:
                return "La entrada cuesta 8€";
                break;
            case $edad > 25 && $edad <= 55:
                return "La entrada cuesta 10€";
                break;
            case $edad > 55 && $edad <= 65:
                return "La entrada cuesta 5€";
                break;
            case $edad > 65:
                return "Entrada gratis";
                break;
        }
    }

    echo precio(45);
    ?>
</head>
<body>
    
</body>
</html>