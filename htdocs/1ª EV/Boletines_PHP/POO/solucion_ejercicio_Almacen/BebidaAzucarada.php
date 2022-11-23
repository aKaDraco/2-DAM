<?php

require_once 'Bebida.php';

class BebidaAzucarada extends Bebida {

//atributos
    private $porcentajeAzucar;
    private $promocion;

//constructor
    public function __construct($porcentajeAzucar, $promocion, $litros, $precio, $marca) {
        parent::__construct($litros, $precio, $marca);
        $this->porcentajeAzucar = $porcentajeAzucar;
        $this->promocion = $promocion;
    }

    //metodos
    public function getPorcentajeAzucar() {
        return $this->porcentajeAzucar;
    }

    public function setPorcentajeAzucar($porcentaje) {
        $this->porcentajeAzucar = $porcentaje;
    }

    public function setPromocion($promo) {
        $this->promocion = $promo;
    }

    public function getPrecio() {
        if ($this->promocion) {
            return Bebida::getPrecio() * 0.9;
        } else {
            return Bebida::getPrecio();
        }
    }

    public function getId() {
        return parent::getId();
    }

    public function visualizar() {
        parent::visualizar();
        print ('porcentaje azúcar ' . $this->porcentajeAzucar . '<br> promoción: ' . $this->promocion . '<br>');
    }

}
