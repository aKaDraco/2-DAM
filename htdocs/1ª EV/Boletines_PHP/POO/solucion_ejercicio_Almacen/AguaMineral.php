<?php
require_once 'Bebida.php';

class AguaMineral extends Bebida {

//Atributos
    private $manantial;

//Constructores
    public function __construct($manantial, $litros, $precio, $marca) {
        parent::__construct($litros, $precio, $marca);
        $this->manantial = $manantial;
    }

//Metodos
    public function getManatial() {
        return $this->manantial;
    }
  
    public function setManatial($manantial) {
        $this->manantial = $manantial;
    }

      public function getId(){
        return parent::getId();
    }
    
    
    public function visualizar() {
        parent::visualizar();
         print ('manatial '. $this->manantial.'<br>');
    }
}