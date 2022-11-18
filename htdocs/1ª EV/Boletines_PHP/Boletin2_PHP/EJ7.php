<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Ejercicio 7</title>
    <?php
    function mat()
    {
        $zoo = array(array("Perro", "León", "Cocodrilo"), array("Gato", "Pantera", "Caimán"));
        echo $zoo[1][1];
    }
    ?>
</head>

<body>
    <?php
    mat();
    ?>
</body>

</html>