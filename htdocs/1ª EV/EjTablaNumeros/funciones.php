<?php
function operaciones ($n){
    for ($i=1; $i <= $n; $i++) { 
        $cuadrado = $i * $i;
        $cubo = $i * $i * $i;
        echo "<tr>";
        echo "<td>";
        echo $i;
        echo "</td>";
        echo "<td>";
        echo $cuadrado;
        echo "</td>";
        echo "<td>";
        echo $cubo;
        echo "</td>";
        echo "</tr>";
    }
}
?>