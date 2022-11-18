<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>ejercicio8</title>
    <?php
    function premio ($edad) {
        if ($edad >= 75 && $edad <= 80) {
            return $edad * 0.05;
        } else {
            return "Edad no permitida";
        }
    }

    echo premio(76);
    ?>
</head>
<body>
    
</body>
</html>