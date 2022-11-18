<?php
function calcular()
{
    if (isset($_POST['precio']) && !empty($_POST['precio']) && is_int($_POST['precio'])) {
        $precio = intval($_POST['precio']);
    }
    if (isset($_POST['cantidad']) && !empty($_POST['cantidad']) && is_int($_POST['cantidad'])) {
        $cantidad = intval($_POST['cantidad']);
    }
    if (isset($_POST['descuento']) && !empty($_POST['descuento']) && is_double($_POST['descuento'])) {
        $descuento = doubleval($_POST['descuento']);
    }
    if (isset($_POST['iva']) && !empty($_POST['iva']) && is_double($_POST['iva'])) {
        $iva = doubleval($_POST['iva'] / 100);
    }
    if (isset($_POST['envio']) && !empty($_POST['envio'])) {
        $envio = $_POST['envio'];
    }

    print (($precio + ($precio * $iva)) - $descuento) * $cantidad + $envio + "€";
}
