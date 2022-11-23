<?php

require_once 'Cuatro_ruedas.php';


class Coche extends Cuatro_ruedas
{

    private $numero_cadenas_nieve;


    public function __construct($color, $peso, $numPuertas, $numero_cadenas_nieve)
    {
        parent::__construct($color, $peso, $numPuertas);
        $this->numero_cadenas_nieve =  $numero_cadenas_nieve;;
    }



    function getNumero_cadenas_nieve()
    {
        return $this->numero_cadenas_nieve;
    }

    function setNumero_cadenas_nieve($numero_cadenas_nieve)
    {
        $this->numero_cadenas_nieve = $numero_cadenas_nieve;
    }

    function añadir_cadenas_nieve($num)
    {
        $this->numero_cadenas_nieve += $num;
    }

    function quitar_cadenas_nieve($num)
    {
        $this->numero_cadenas_nieve -= $num;
    }

    function añadir_persona($peso_persona)
    {
        parent::añadir_persona($peso_persona);
        if ((parent::getPeso() >= 1500) && ($this->numero_cadenas_nieve <= 2)) {
            print('Atención, ponga 4 cadenas para la nieve. </br>');
        }
    }
}
