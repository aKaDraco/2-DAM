<?php

class Bebida {

    //atributos
    private static $idActual = 0;
    private $id;
    private $litros;
    private $precio;
    private $marca;

    //constructor
    public function __construct($litros, $precio, $marca) {
        $this->litros = $litros;
        $this->precio = $precio;
        $this->marca = $marca;
        $this->id = self::$idActual + 1;
        self::$idActual++;
    }
    
 //metodos
    public function getId() {
        return $this->id;
    }

    public function setId($id) {
        $this->id = $id;
    }

    public function getCantidad() {
        return $this->litros;
    }

    public function setCantidad($litros) {
        $this->litros = $litros;
    }

    public function getPrecio() {
        return $this->precio;
    }

    public function setPrecio($precio) {
        $this->precio = $precio;
    }

    public function getMarca() {
        return $this->marca;
    }

    public function setMarca($marca) {
        $this->marca = $marca;
    }
    
    public function visualizar(){
        print ('id: '. $this->id . '<br> litros: '. $this->litros.'<br> precio: '. $this->precio.'<br> marca: '. $this->marca .'<br>');
        
    }

}