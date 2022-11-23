<?php

require_once 'Cuatro_ruedas.php';

class Camion extends Cuatro_ruedas {

    private $longitud;

    public function __construct($color, $peso, $numPuertas, $longitud) {
        parent::__construct($color, $peso, $numPuertas);
        $this->longitud = $longitud;
    }

    public function getLongitud() {
        return $this->longitud;
    }

    public function setLongitud($longitud) {
        $this->longitud = $longitud;
    }

    public function añadir_remolque($longitud_remolque) {
        $this->longitud += $longitud_remolque;
        print "Se ha añadido un remolque de ".$longitud_remolque." metros de longitud<br>";
    }

    public function mostrarCamion() {
        print 'Los datos del camión son: <br>';
        parent::mostrarDatos();
        print 'La longitud es ' . $this->longitud . '<br>';
    }

}
