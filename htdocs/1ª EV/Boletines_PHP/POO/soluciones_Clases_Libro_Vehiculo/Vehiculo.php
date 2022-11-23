<?php

require_once 'Coche.php';
require_once 'Dos_ruedas.php';
require_once 'Cuatro_ruedas.php';
require_once 'Camion.php';

 abstract class Vehiculo{
    private $color;
    private $peso;

    
    public static $numero_cambio_color=0; 


    const SALTO_DE_LINEA='<br>';
            
    function __construct($color, $peso) {
        $this->color = $color;
        $this->peso = $peso;
    }

    
   public function getColor() {
        return $this->color;
    }

    public function getPeso() {
        return $this->peso;
    }

    public function setColor($color) {
        $this->color = $color;
        self::$numero_cambio_color++;
    }

   public function setPeso($peso) {
       if ($peso>2100){
           $this->peso=2100;
       }else{
        $this->peso = $peso;
       }
    }
    
   public function Circula(){
        print("El vehículo circula<br/>");
        
    }
   public abstract function añadir_persona($peso_persona);
           
   public function mostrarDatos(){
       print 'El color del vehículo es: '. $this->color .'<br>';
       print 'El peso del vehículo es: '. $this->peso .'<br>';
   }
    
   public static function verAtributo($obj){
    if(get_class($obj)=="Coche")
    {
        print "Los atributos del coche son:<br>";
        print "El atributo número de cadenas de nieve es: ".$obj->getNumero_cadenas_nieve().Vehiculo::SALTO_DE_LINEA;
        print "El atributo número de puertas es: ".$obj->getNumero_puertas().Vehiculo::SALTO_DE_LINEA;
    }elseif(get_class($obj)=="Camion"){
        print "Los atributos del camión son:".Vehiculo::SALTO_DE_LINEA;
        print "El atributo longitud es: ".$obj->getLongitud().Vehiculo::SALTO_DE_LINEA;
        print "El atributo número de puertas es: ".$obj->getNumero_puertas().Vehiculo::SALTO_DE_LINEA;
    }else{
        print "Los atributos de dos ruedas son:".Vehiculo::SALTO_DE_LINEA;
        print "El atributo cilindrada es: ".$obj->getCilindrada().Vehiculo::SALTO_DE_LINEA;
    }
      foreach ($obj as $clave=>$valor){
          if (isset($clave)){
              print 'El atributo '. $clave .' vale '. $valor;
              print Vehiculo::SALTO_DE_LINEA;
          }
        }
        print 'El número de veces que se ha cambiado de color es '. self::$numero_cambio_color;
        print Vehiculo::SALTO_DE_LINEA;
   }
   

}