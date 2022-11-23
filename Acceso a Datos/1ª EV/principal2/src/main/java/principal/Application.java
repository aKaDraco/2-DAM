package principal;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Scanner;

public class Application {
  public static void main(String[] args) throws IOException {
    File ficheiro = new File("C:/Prueba/Prueba.txt");
    // LecFicheros(ficheiro);
    // Emu(ficheiro);
    // Carac('a');

    // EJERCICIO 1
    // LecFicheros(ficheiro);

    // EJERCICIO 4
    // ArrayList<Character> c = new ArrayList<>();
    // c = caracMost(new File("C:/xampp/readme_en.txt"));
    // for (Character car : c) {
    // System.out.println(car);
    // }

    // EJERCICIO 5
    // mostrarLinea(ficheiro, "Lorem");

    // EJERCICIO 6
    dividirFichN(ficheiro, 10);
    // dividirFichL(ficheiro, 4);
  }

  // EJERCICIO 1
  public static void LecFicheros(File f) {
    // System.out.println("Nome: " + ficheiro.getName());
    // System.out.println("Existe?: " + ficheiro.exists());
    // System.out.println("Ruta absoluta: " + ficheiro.getAbsolutePath());
    File[] lista = f.listFiles();
    System.out.println("DIRECTORIOS");
    System.out.println("-----------");
    for (int i = 0; i < lista.length; i++) {
      if (lista[i].isDirectory()) {
        System.out.printf("%s\n", lista[i]);
      }
    }
    System.out.println();
    System.out.println("FILES");
    System.out.println("-----");
    for (int x = 0; x < lista.length; x++) {
      if (lista[x].isFile()) {
        System.out.printf("%s\n", lista[x]);
      }
    }
  }

  // EJERCICIO 2
  public static void Emu(File f) {
    File[] lista = f.listFiles();
    for (int i = 0; i < lista.length; i++) {
      System.out.println(lista[i]);
      if (lista[i].isDirectory()) {
        Emu(lista[i]);
      }
    }
  }

  // EJERCICIO 3
  public static int Carac(char c, File f) throws IOException {
    // File f = new File("C:/Prueba/P.txt");
    FileReader fr = null;
    int cont = 0;
    try {
      fr = new FileReader(f);
      int i;
      cont = 0;
      while ((i = fr.read()) != -1) {
        if ((char) i == Character.toLowerCase(c) || (char) i == Character.toUpperCase(c)) {
          cont++;
        }
      }
      System.out.println(cont);
    } finally {
      if (fr != null) {
        fr.close();
      }
    }
    return cont;
  }

  // EJERCICIO 4
  public static ArrayList<Character> caracMost(File f) throws IOException {
    ArrayList<Character> caracSeen = new ArrayList<>();
    ArrayList<Integer> caracContSeen = new ArrayList<>();
    ArrayList<Character> maxCarac = new ArrayList<>();

    if (f.exists() && f.isFile() && f.canRead()) {
      try (Scanner sc = new Scanner(f)) {
        while (sc.hasNextLine()) {
          String linea = sc.nextLine();
          for (int i = 0; i < linea.length(); i++) {
            if (linea.charAt(i) != ' ') {
              if (!caracSeen.contains(linea.charAt(i))) {
                caracSeen.add(linea.charAt(i));
                caracContSeen.add(charCount(f, linea.charAt(i)));
              }
            }
          }
        }
      } catch (IOException e) {
        System.err.println("ERROR");
      }
      int max = Collections.max(caracContSeen);
      for (int i = 0; i < caracContSeen.size(); i++) {
        if (caracContSeen.get(i) == max) {
          maxCarac.add(caracSeen.get(i));
        }
      }
    }
    return maxCarac;
  }

  static int charCount(File f, char carac) {
    int cont = 0;
    if (f.isFile() && f.canRead() && f.exists()) {
      try (Scanner sc = new Scanner(f)) {
        while (sc.hasNextLine()) {
          String car = sc.nextLine();

          for (int i = 0; i < car.length(); i++) {
            if (car.charAt(i) == carac) {
              cont++;
            }
          }
        }
      } catch (FileNotFoundException e) {
        e.printStackTrace();
      }
    }
    return cont;
  }

  // EJERCICIO 5
  public static void mostrarLinea(File f, String cad) {
    int cont = 0;
    if (f.exists() && f.canRead() && f.isFile()) {
      try (Scanner sc = new Scanner(f)) {
        while (sc.hasNextLine()) {
          String texto = sc.nextLine();
          cont++;
          if (texto.contains(cad)) {
            System.out.printf("Linea %d- %s\n", cont, cad);
          }
        }
      } catch (FileNotFoundException e) {
        e.printStackTrace();
      }
    }
  }

  // EJERCICIO 6
  public static void dividirFichN(File f, int n) throws IOException {
    char buffer[] = new char[n];
    File fichero = new File("C:/Prueba/DivisionLineas");
    try (FileReader fichIn = new FileReader(f);) {
      int i;
      int cont = 1;
      String ext = ".txt";
      while ((i = fichIn.read(buffer)) != -1) {
        try (FileWriter fichOut = new FileWriter(fichero.getPath() + cont + ext)) {
          fichOut.write(buffer, 0, i);
          cont++;
        } catch (Exception e) {
          e.printStackTrace();
        }
        // if (fichIn != null)
        // fichIn.close();
      }
    } catch (Exception e) {
      e.printStackTrace();
    }

  }

  public static void dividirFichL(File f, int l) throws IOException {
    File fichero = new File("C:/Prueba/DivisionLineas");
    try (Scanner sc = new Scanner(f)) {
      int contF = 1;
      int contL = 0;
      String ext = ".txt";
      while (sc.hasNextLine()) {
        if (contL == l) {
          try (PrintWriter fichOut = new PrintWriter(fichero.getPath() + contF + ext)) {
            fichOut.println(sc.nextLine());
            // contL = 0;
            contF++;
          } catch (Exception e) {
            e.printStackTrace();
          }
        }
        contL++;
      }
    } catch (Exception e) {
      e.printStackTrace();
    }
  }
}