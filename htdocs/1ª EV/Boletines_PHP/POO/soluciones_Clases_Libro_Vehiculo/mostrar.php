<?php

require_once 'Vehiculo.php';
require_once 'Coche.php';
require_once 'Dos_ruedas.php';
require_once 'Cuatro_ruedas.php';
require_once 'Camion.php';

$coche1=new Coche('amarillo', 1000, 4, 2);
$coche1->añadir_persona(70);
print "Atributos coche1:<br>";
Vehiculo::verAtributo($coche1);

$coche2=new Coche('verde', 1500, 4, 0);
$coche2->añadir_cadenas_nieve(2);
$coche2->añadir_persona(80);
$coche2->repintar('azul');
$coche2->quitar_cadenas_nieve(4);
$coche2->repintar('negro');
print "Atributos coche2:<br>";
Vehiculo::verAtributo($coche2);

$coche3=new Coche('violeta',2000,4,0);
$coche3->repintar("marron");
print "Atributos coche3:<br>";
Vehiculo::verAtributo($coche3);
print $coche3->mostrarDatos();
$coche3->añadir_persona(300);
Vehiculo::verAtributo($coche3);
$coche3->Circula();
$camion1=new Camion('fosforito',5000,2,20);
$camion1->mostrarCamion();
$camion1->añadir_remolque(15);
$camion1->mostrarCamion();
Vehiculo::verAtributo($camion1);

$dosruedas1=new Dos_ruedas('rosa',2000,1000);
$dosruedas1->añadir_persona(200);
$dosruedas1->poner_gasolina(5);
Vehiculo::verAtributo($dosruedas1);

