<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Ejercicio 8</title>
    <style>
        table,
        td,
        th,
        tr {
            border: 1px solid black;
            border-collapse: collapse;
        }
    </style>
    <?php
    function tabla()
    {
        $nombres = array("Carlos Álvarez", "Laura López", "Rosa Márquez", "Jorge Tiras");
        $materias = array("Lengua", "Historia", "Inglés", "Matemáticas");
        echo "<tr><td></td>";
        for ($i = 0; $i < count($materias); $i++) {
            echo "<th>";
            echo $materias[$i];
            echo "</th>";
        }
        echo "</tr>";
        for ($j = 0; $j < count($nombres); $j++) {
            echo "<tr>";
            echo "<th>";
            echo $nombres[$j];
            echo "</th>";
            for ($k = 0; $k < count($materias); $k++) {
                echo "<td>";
                echo $numRand = rand(1, 10);
                echo "</td>";
            }
            echo "</tr>";
        }
    }
    ?>
</head>

<body>
    <table>
        <?php
        tabla();
        ?>
    </table>
</body>

</html>