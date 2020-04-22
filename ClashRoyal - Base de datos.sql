CREATE DATABASE ClashRoyal;
USE ClashRoyal;

CREATE TABLE Jugador(id_jugador INT PRIMARY KEY IDENTITY(0,1) NOT NULL,
					 usuario VARCHAR(45) NOT NULL,
					 clave VARCHAR(45) NOT NULL,
					 nombre VARCHAR(45) NOT NULL,
					 apepat VARCHAR(45) NOT NULL,
					 apemat VARCHAR(45) NOT NULL);

CREATE TABLE Partida(id_partida INT PRIMARY KEY IDENTITY(0,1) NOT NULL,
					 id_jugador INT NOT NULL FOREIGN KEY REFERENCES Jugador(id_jugador),
					 ganador INT NOT NULL)



CREATE TABLE Estadistica(id_estadistica INT PRIMARY KEY IDENTITY(0,1) NOT NULL,
						 id_jugador INT NOT NULL FOREIGN KEY REFERENCES Jugador(id_jugador),
						 danio INT NOT NULL,
						 tiempo INT NOT NULL,
						 elixir INT NOT NULL,
						 personaje VARCHAR(45) NOT NULL);

