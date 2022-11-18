<?php

    class CabeceraPagina {

        private $titulo;

        public function cargarTit($titulo) {
            $this->titulo = $titulo;
        }

        public function mostrarTit($donde)
        {
            if($donde == "izq") {
                print "<h1>".$this->titulo."</h1>";
            }
            if($donde == "cen") {
                print "<h1 style = \"text-align: center;\">".$this->titulo."</h1>";
            }
            if($donde == "der") {
                print "<h1 style = \"text-align: right;\">".$this->titulo."</h1>";
            }
        }

        function __construct()
        {
            $this->cargarTit("HOLA");
            $this->mostrarTit("cen");
        }
    }

    $emp = new CabeceraPagina();
?>