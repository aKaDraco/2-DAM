<?php

class Camion extends Cuatro_ruedas
{

    private $longitud;

    public function setLongitud($longitud) {
        $this->longitud = $longitud;
    }

    public function getLongitud() {
        return $this->longitud;
    }

    public function añadir_remolque($longitud_remolque)
    {
    }
}
