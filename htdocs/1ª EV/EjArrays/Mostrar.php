<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Arrays</title>
</head>
<body>
    <?php
        $bidimensional = array (
            array("David","Garcia",18),
            array("Jesus","Garcia",38),
            array("Maria","Perez",28),
            array("Jorge","Gonzalez",58)
        );
    
        for ($i=0; $i < count($bidimensional); $i++) { 
            for ($j=0; $j < count($bidimensional[i]); $j++) { 
                echo $bidimensional[$i][$j];
            }
        }
    ?>
</body>
</html>