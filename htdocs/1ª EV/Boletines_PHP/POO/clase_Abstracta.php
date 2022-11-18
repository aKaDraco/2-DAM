<?php

abstract class clase_Abstracta
{
    protected $valor1;
    protected $valor2;
    protected $resultado;

    public function cargar1($valor)
    {
        $this->valor1 = $valor;
    }

    public function cargar2($valor)
    {
        $this->valor2 = $valor;
    }

    public function mostrar()
    {
        print "El resultado de la suma es: " .  $this->resultado . "<br>";
    }

    abstract public function operar();
}
class Suma extends clase_Abstracta
{
    public function operar()
    {
        $this->resultado = $this->valor1 + $this->valor2;
    }
}

$suma = new Suma();
$suma->cargar1(10);
$suma->cargar2(20);
$suma->operar();
$suma->mostrar();

?>