<?php

require_once 'Vehiculo.php';

class Cuatro_ruedas extends Vehiculo {

    private $numeroPuertas;

    public function __construct($color, $peso, $numPuertas) {
        parent::__construct($color, $peso);
        $this->numeroPuertas = $numPuertas;
    }

    public function getNumero_puertas() {
        return $this->numeroPuertas;
    }

    public function setNumero_puertas($numero_puertas) {
        $this->numeroPuertas = $numero_puertas;
    }

    public function repintar($color) {
        parent::setColor($color);
    }
    public function añadir_persona($peso_persona) {
        $peso=parent::getPeso()+$peso_persona;
        parent::setPeso($peso);
    }
    public function mostrarDatos() {
        parent::mostrarDatos();
        print 'El número de puertas es ' . $this->numeroPuertas . '<br>';
    }

}
