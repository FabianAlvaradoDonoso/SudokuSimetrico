# Tarea 2 - Análisis de Algoritmos
## Creación de Sudokus con solución única

Este programa se basa en las siguientes ideas:
- Generación desde 0 de un tablero de Sudoku, partiendo desde la generación de grupos de celdas (en este caso de 3x3) en diagonal, para luego implementar un algoritmo de Backtracking para llenar el resto de casillas.
Al generar estos grupos de casillas, el proceso de llenado para el resto del tablero será más simple y con condiciones diferentes, dadas por los grupos de celdas diagonales.

| | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| **1** | **0,0** | **0,1** | **0,2** | 0,3 | 0,4 | 0,5 | 0,6 | 0,7 | 0,8 |
| **2** | **1,0** | **1,1** | **1,2** | 1,3 | 1,4 | 1,5 | 1,6 | 1,7 | 1,8 |
| **3** | **2,0** | **2,1** | **2,2** | 2,3 | 2,4 | 2,5 | 2,6 | 2,7 | 2,8 |
| **4** | 3,0 | 3,1 | 3,2 | **3,3** | **3,4** | **3,5** | 3,6 | 3,7 | 3,8 |
| **5** | 4,0 | 4,1 | 4,2 | **4,3** | **4,4** | **4,5** | 4,6 | 4,7 | 4,8 |
| **6** | 5,0 | 5,1 | 5,2 | **5,3** | **5,4** | **5,5** | 5,6 | 5,7 | 5,8 |
| **7** | 6,0 | 6,1 | 6,2 | 6,3 | 6,4 | 6,5 | **6,6** | **6,7** | **6,8** |
| **8** | 7,0 | 7,1 | 7,2 | 7,3 | 7,4 | 7,5 | **7,6** | **7,7** | **7,8** |
| **9** | 8,0 | 8,1 | 8,2 | 8,3 | 8,4 | 8,5 | **8,6** | **8,7** | **8,8** |

- A partir del tablero generado, **esconder** un número de celdas para generar un tablero disponible para llenar.


| | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| **1** | - | 0,1 | 0,2 | 0,3 | 0,4 | 0,5 | 0,6 | 0,7 | 0,8 |
| **2** | 1,0 | 1,1 | 1,2 | 1,3 | 1,4 | - | 1,6 | 1,7 | 1,8 |
| **3** | 2,0 | 2,1 | 2,2 | 2,3 | 2,4 | 2,5 | 2,6 | 2,7 | 2,8 |
| **4** | 3,0 | 3,1 | 3,2 | 3,3 | 3,4 | 3,5 | 3,6 | - | 3,8 |
| **5** | 4,0 | 4,1 | 4,2 | 4,3 | 4,4 | 4,5 | 4,6 | 4,7 | 4,8 |
| **6** | 5,0 | 5,1 | 5,2 | 5,3 | - | 5,5 | 5,6 | 5,7 | 5,8 |
| **7** | 6,0 | 6,1 | 6,2 | 6,3 | 6,4 | 6,5 | 6,6 | 6,7 | 6,8 |
| **8** | 7,0 | 7,1 | 7,2 | 7,3 | - | - | 7,6 | 7,7 | 7,8 |
| **9** | 8,0 | 8,1 | 8,2 | 8,3 | 8,4 | 8,5 | 8,6 | 8,7 | 8,8 |

- Luego de eso, llenar el tablero, confirmando previamente que tiene solución única.

| | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| **1** | 0,0 | 0,1 | 0,2 | 0,3 | 0,4 | 0,5 | 0,6 | 0,7 | 0,8 |
| **2** | 1,0 | 1,1 | 1,2 | 1,3 | 1,4 | 1,5 | 1,6 | 1,7 | 1,8 |
| **3** | 2,0 | 2,1 | 2,2 | 2,3 | 2,4 | 2,5 | 2,6 | 2,7 | 2,8 |
| **4** | 3,0 | 3,1 | 3,2 | 3,3 | 3,4 | 3,5 | 3,6 | 3,7 | 3,8 |
| **5** | 4,0 | 4,1 | 4,2 | 4,3 | 4,4 | 4,5 | 4,6 | 4,7 | 4,8 |
| **6** | 5,0 | 5,1 | 5,2 | 5,3 | 5,4 | 5,5 | 5,6 | 5,7 | 5,8 |
| **7** | 6,0 | 6,1 | 6,2 | 6,3 | 6,4 | 6,5 | 6,6 | 6,7 | 6,8 |
| **8** | 7,0 | 7,1 | 7,2 | 7,3 | 7,4 | 7,5 | 7,6 | 7,7 | 7,8 |
| **9** | 8,0 | 8,1 | 8,2 | 8,3 | 8,4 | 8,5 | 8,6 | 8,7 | 8,8 |

Las celdas "inversas" se encuentran mediante el siguiente cálculo

<a ><img src="https://latex.codecogs.com/gif.latex?inversoI&space;=&space;8&space;-&space;i" title="inversoI = 8 - i" /></a>

Y de manera similar para el índice j.

La única execpción se encuentra en la celda: **4,4**, la cual no tiene celda inversa.

Entonces, para generar tableros disponibles, se eligen celdas del tablero al azar y se llenan con el número 0, como también su respectiva celda inversa

<sup>Programa creado para ser presentado en la asignatura de Análisis de Algoritmos - Primer Semestre 2018 Universidad Tecnológica Metropolitana</sup>