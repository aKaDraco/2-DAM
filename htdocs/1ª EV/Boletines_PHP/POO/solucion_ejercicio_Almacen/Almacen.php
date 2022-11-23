<?php

require 'BebidaAzucarada.php';
require 'AguaMineral.php';

class Almacen {

    private $estanteria = [];

    public function __construct($filas, $columnas) {
        for ($i = 0; $i < $filas; $i++) {
            for ($j = 0; $j < $columnas; $j++) {
                $this->estanteria[$i][$j] = 0;
            }
        }
    }

    public function agregarBebida($nuevaBebida) {
        $i = 0;
        $j = 0;
        $encontrado = 0;
        //count($this->estanteria) devuelve el numero de filas
        while (($i < count($this->estanteria))and ( $encontrado == 0)) {
            $j = 0;
            while (($j < count($this->estanteria[$i]))and ( $encontrado == 0)) {
                if (!is_object($this->estanteria[$i][$j])) {
                    print('Hay sitio para la bebida <br>');

                    $this->estanteria[$i][$j] = $nuevaBebida;
                    $encontrado = 1;
                }
                $j++;
            }
            $i++;
        }
        if ($encontrado == 0) {
            print('No hay sitio para la bebida <br>');
        }
    }

    public function calcularPrecioBebidas() {
        $precioTotal = 0;
        for ($i = 0; $i < count($this->estanteria); $i++) {
            for ($j = 0; $j < count($this->estanteria[$i]); $j++) {
                if (is_object($this->estanteria[$i][$j])) {
                    if ($this->estanteria[$i][$j]->getPrecio() != 0) {
                        $precioTotal += $this->estanteria[$i][$j]->getPrecio(); //acumulo el precio
                    }
                }
            }
        }
        return $precioTotal;
    }

    public function calcularPrecioMarca($marca) {
        $precioTotal = 0;
        for ($i = 0; $i < count($this->estanteria); $i++) {
            for ($j = 0; $j < count($this->estanteria[$i]); $j++) {
                if (is_object($this->estanteria[$i][$j])) {
                    if ($this->estanteria[$i][$j]->getMarca() == $marca) {
                        $precioTotal += $this->estanteria[$i][$j]->getPrecio(); //acumulo el precio
                    }
                }
            }
        }
        if ($precioTotal == 0) {
            print 'No existen productos en el almacen de la marca ' . $marca . '<br>';
        }
        return $precioTotal;
    }

    public function calcularPrecioEstantería($num) {
        $precioTotal = 0;
        for ($i = 0; $i < count($this->estanteria); $i++) {
            if ($num >= count($this->estanteria)) {
                print ('No existe la estantería indicada <br>');
            } else {
                if (is_object($this->estanteria[$i][$num])) {
                    $precioTotal += $this->estanteria[$i][$num]->getPrecio();
                }
            }
        }
        return $precioTotal;
    }

    function eliminarProducto($id) {
        for ($i = 0; $i < count($this->estanteria); $i++) {
            for ($j = 0; $j < count($this->estanteria[$i]); $j++) {
                if (is_object($this->estanteria[$i][$j])) {
                if ($this->estanteria[$i][$j]->getId() == $id) {
                    $this->estanteria[$i][$j] = 0;
                    print 'Producto borrado <br>';
                }
                } else {
                    print 'Producto no encontrado <br> ';
                }
            }
        }
    }

    function mostrarInformacion() {
        for ($i = 0; $i < count($this->estanteria); $i++) {
            for ($j = 0; $j < count($this->estanteria[$i]); $j++) {
                if (!empty($this->estanteria[$i][$j])) {
                    $this->estanteria[$i][$j]->visualizar();
                } else {
                    print'Falta producto <br>';
                }
            }
        }
    }

}
