<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>TablaDeNumeros</title>
    <?php
    include 'Funciones.php';
    ?>
    <style>
        table,
        th,
        td {
            border: 1px solid black;
            border-collapse: collapse;
        }
    </style>
</head>

<body>
    <table>
        <tr>
            <th>Numero</th>
            <th>Cuadrado</th>
            <th>Cubo</th>
        </tr>
        <?php
        operaciones(15);
        ?>
    </table>
</body>

</html>