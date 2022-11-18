<?php

class Dos_ruedas extends Vehiculo
{

    private $cilindrada;

    public function setCilindrada($cilindrada) {
        $this->cilindrada = $cilindrada;
    }

    public function getCilindrada() {
        return $this->cilindrada;
    }

    public function poner_gaoslina($litros)
    {
        parent::setPeso(parent::getPeso() + $litros);
    }
}
