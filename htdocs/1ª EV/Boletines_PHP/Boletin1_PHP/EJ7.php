<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>ejercicio7</title>
    <?php
    function precio ($mascota){
        $masc = strtolower($mascota);
        switch($masc) {
            case $masc == "gato" || $masc == "huron":
                return "El precio de la entrada es 1€";
                break;
            case $masc == "perro":
                return "El precio de la entrada es 1.5€";
                break;
            case $masc == "loro":
                return "El precio de la entrada es 2€";
                break;
            default:
                return "Mascota no permitida";
                break;
        }
    }

    echo precio("perro");
    ?>
</head>
<body>
    
</body>
</html>