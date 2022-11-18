<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Registro</title>
    <link rel="stylesheet" href="estiloregistrar.css">
</head>

<body>
    <nav>
        <h1>REGISTRO</h1>
    </nav>
    <section>
        <form action="registrarusuario.php" method="POST">
            <div id="div1">
                <div id="divnom">
                    <label>NOMBRE:</label>
                    <input type="text" name="nombre" id="nombr" minlength="2" maxlength="20" required>
                    <label>PRIMER APELLIDO:</label>
                    <input type="text" name="apellido1" id="apellid1" minlength="2" maxlength="20" required>
                    <label>SEGUNDO APELLIDO:</label>
                    <input type="text" name="apellido2" id="apellid2" minlength="2" maxlength="20" required>
                </div>
                <div id="divnom">
                    <label>DNI:</label>
                    <input type="text" name="dni" id="dn" minlength="9" maxlength="9" required>
                    <label>TELEFONO:</label>
                    <input type="tel" name="telefono" id="telefon" minlength="6" maxlength="20" required>
                    <label>CORREO:</label>
                    <input type="mail" name="correo" id="corre" minlength="6" required>
                </div>
                <div id="divnom">
                    <label>DIRECCION:</label>
                    <input type="text" name="direccion" id="direcc" minlength="5" maxlength="30" required>
                    <label>DINERO:</label>
                    <input type="text" name="dinero" id="diner" minlength="2" maxlength="40" required>
                    <label>PIN:</label>
                    <input type="password" name="password" id="pass" minlength="4" maxlength="4" required>
                </div>
                *Todos los campos obligatorios*<input type="submit" value="REGISTRAR" id="btnr">
            </div>
        </form>
    </section>
    <?php
    $conexion = mysqli_connect('localhost', 'root');
    mysqli_select_db($conexion, 'banco');
    session_start();
    $DNI = $_SESSION['foo'];

    $comp = false;

    if (empty($_POST['nombre']) || empty($_POST['apellido1']) || empty($_POST['apellido2']) || empty($_POST['dni']) || empty($_POST['telefono']) || empty($_POST['correo']) || empty($_POST['direccion']) || empty($_POST['dinero']) || empty($_POST['password'])) {
        $comp = true;
    } else {
        // session_start();
        // $DNI = $_SESSION['foo'];
        // if (!empty($_POST['nombre']) && !empty($_POST['apellido1']) && !empty($_POST['apellido2']) && !empty($_POST['dni']) && !empty($_POST['telefono']) && !empty($_POST['correo']) && !empty($_POST['direccion']) && !empty($_POST['dinero'])) {
        $nombre = trim($_POST['nombre']);
        $apellido1 = trim($_POST['apellido1']);
        $apellido2 = trim($_POST['apellido2']);
        $dni = trim($_POST['dni']);
        $telefono = trim($_POST['telefono']);
        $correo = trim($_POST['correo']);
        $direccion = $_POST['direccion'];
        $dinero = trim($_POST['dinero']);
        $pass = trim($_POST['password']);
    }

    // CONTROL DE USUARO REGISTRADO
    $query = "SELECT * FROM clientes";
    $registros = mysqli_query($conexion, $query);

    $numero_de_cuenta = rand(1, 999);

    if ($registros) {
        if (empty($registros)) {
            print "<p>No hay usuarios registrados</p>";
        } else {
            while ($fila = mysqli_fetch_array($registros)) {
                if (($fila['DNI'] == $DNI)) {
                    // print "<p>Ya existe un usuario con ese DNI</p>";
                    $comp = true;
                    break;
                }
            }
        }
    } else {
        print "<p style = \"colo:red;\"> No se ha podido realizar la petición </p><br>" . mysqli_error($conexion);
    }

    if (!$comp) {
        $peticion = "INSERT INTO clientes (Nombre,Primer_apellido,Segundo_apellido,DNI,Telefono,Correo,Direccion,numero_cuenta,dinero_cuenta,PASSW0RD) VALUES ('$nombre','$apellido1','$apellido2','$dni','$telefono','$correo','$direccion','$numero_de_cuenta','$dinero','$pass')";
        if (mysqli_query($conexion, $peticion)) {
            echo "<script>alert( '" . addslashes("Usuario Registrado") . "' );</script>";
            header('Location: ..\Index.php');
        } else {
            print "<p style = \"colo:red;\"> Error en el registro </p><br>" . mysqli_error($conexion);
        }
    }
    ?>
</body>

</html>