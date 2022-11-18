<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>ejercicio11</title>
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
        $n2 = 1;
        for ($i = 1; $i <= 10; $i++) {
            echo "<tr>";
            echo  "<th>";
            echo $i;
            echo  "</th>";
            for ($j = 1; $j <= 10; $j++) {
                echo  "<td>";
                echo $j * $n2;
                echo "</td>";
            }
            $n2++;
            echo "</tr>";
        }
    }
    ?>
</head>

<body>
    <table>
        <tr>
            <th></th>
            <th>1</th>
            <th>2</th>
            <th>3</th>
            <th>4</th>
            <th>5</th>
            <th>6</th>
            <th>7</th>
            <th>8</th>
            <th>9</th>
            <th>10</th>
        </tr>
        <?php
        tabla();
        ?>
    </table>
</body>

</html>