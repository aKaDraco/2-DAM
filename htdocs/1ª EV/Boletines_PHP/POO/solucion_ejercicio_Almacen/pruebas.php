<?php

require 'Almacen.php';

$almacen1 = new Almacen(3, 2);

//Declaramos unas cuantas bebidas de prueba
$agua1 = new AguaMineral("Galicia", 1.5, 3, "Sousas");

$azucarada1 = new BebidaAzucarada(5, 0, 2, 10, "CocaCola");
$azucarada2 = new BebidaAzucarada(5, 0, 2, 5, "CocaCola");


$almacen1->agregarBebida($agua1);
$almacen1->agregarBebida($agua1);
$almacen1->agregarBebida($azucarada1);
$almacen1->agregarBebida($azucarada2);
$almacen1->agregarBebida($agua1);

$almacen1->mostrarInformacion();



print('El precio total es '.$almacen1->calcularPrecioBebidas(). '<br>');

print ('El precio de la estantería 1 es '. $almacen1->calcularPrecioEstantería(1).'<br>');

print ('El precio de la marca Cocacola es '. $almacen1->calcularPrecioMarca('CocaCola').'<br>');

print 'Elimino el producto con id=1';
$almacen1->eliminarProducto('1');

$almacen1->mostrarInformacion();

$almacen1->agregarBebida($azucarada2);
$almacen1->agregarBebida($agua1);
$almacen1->agregarBebida($agua1);
$almacen1->mostrarInformacion();

