<?php

require_once 'Vehiculo.php';

class Dos_ruedas extends Vehiculo{
    private $cilindrada;
    
   public function __construct($color, $peso, $cilindrada) {
        parent::__construct($color, $peso);
        $this->cilindrada = $cilindrada;
    }

     public   function getCilindrada() {
        return $this->cilindrada;
    }

   public function setCilindrada($cilindrada) {
        $this->cilindrada = $cilindrada;
    }

        
    public function poner_gasolina($litros){
       /* parent::añadir_persona($litros);*/
        $peso=parent::getPeso()+$litros;
        parent::setPeso($peso);
    }
    
  public function añadir_persona($peso_persona) {
        $peso=parent::getPeso()+$peso_persona+2;
        parent::setPeso($peso);
    }

}