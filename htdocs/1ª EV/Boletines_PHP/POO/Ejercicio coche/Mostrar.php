<?php
    require_once "Vehiculo.php";"Dos_ruedas.php";"Cuatro_ruedas.php";"Coche.php";"Camion.php";
    // $v1 = new Vehiculo("Negro",1500);
    // $v1->circula();
    $v1Color = new Cuatro_ruedas("Negro",1500);
    $v1ColorDos = new Dos_ruedas("Negro",1500);
    $v1Color->repintar("Rojo");
    $v1ColorDos->poner_gaoslina(1);
?>