USE projetoquadra;

-- MySQL dump 10.13  Distrib 8.0.16, for Linux (x86_64)
--
-- Host: 172.18.0.3    Database: projetoquadra
-- ------------------------------------------------------
-- Server version	8.0.16

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table Agendamento
--

DROP TABLE IF EXISTS Agendamento;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE Agendamento (
  Id int(11) NOT NULL AUTO_INCREMENT,
  IdQuadra int(11) NOT NULL,
  IdGrupo int(11) NOT NULL,
  DataInicio datetime NOT NULL,
  DataFim datetime NOT NULL,
  PRIMARY KEY (Id,IdQuadra,IdGrupo),
  KEY fk_Agendamento_quadra_idx (IdQuadra),
  CONSTRAINT fk_Agendamento_quadra FOREIGN KEY (IdQuadra) REFERENCES Quadra (Id)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table Agendamento
--

LOCK TABLES Agendamento WRITE;
/*!40000 ALTER TABLE Agendamento DISABLE KEYS */;
INSERT INTO Agendamento VALUES (2,2,1,'2019-05-12 10:00:00','2019-05-12 11:00:00'),(3,2,1,'2019-05-12 08:00:00','2019-05-12 09:30:00');
/*!40000 ALTER TABLE Agendamento ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table Grupo
--

DROP TABLE IF EXISTS Grupo;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE Grupo (
  Id int(11) NOT NULL,
  Nome varchar(45) NOT NULL,
  PRIMARY KEY (Id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table Grupo
--

LOCK TABLES Grupo WRITE;
/*!40000 ALTER TABLE Grupo DISABLE KEYS */;
INSERT INTO Grupo VALUES (1,'Grupo 1'),(2,'Grupo 2');
/*!40000 ALTER TABLE Grupo ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table GrupoJogador
--

DROP TABLE IF EXISTS GrupoJogador;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE GrupoJogador (
  idJogador int(11) NOT NULL,
  IdGrupo int(11) NOT NULL,
  PRIMARY KEY (IdGrupo,idJogador)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table GrupoJogador
--

LOCK TABLES GrupoJogador WRITE;
/*!40000 ALTER TABLE GrupoJogador DISABLE KEYS */;
INSERT INTO GrupoJogador VALUES (1,1),(2,1),(3,1),(4,1),(5,1),(6,2),(7,2),(8,2),(9,2),(10,2);
/*!40000 ALTER TABLE GrupoJogador ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table Jogador
--

DROP TABLE IF EXISTS Jogador;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE Jogador (
  Id int(11) NOT NULL AUTO_INCREMENT,
  Nome varchar(100) NOT NULL,
  Sobrenome varchar(100) NOT NULL,
  PRIMARY KEY (Id)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table Jogador
--

LOCK TABLES Jogador WRITE;
/*!40000 ALTER TABLE Jogador DISABLE KEYS */;
INSERT INTO Jogador VALUES (1,'Jogador 1','Sobrenome Jogador 1'),(2,'Jogador 2','Sobrenome Jogador 2'),(3,'Jogador 3','Sobrenome Jogador 3'),(4,'Jogador 4','Sobrenome Jogador 4'),(5,'Jogador 5','Sobrenome Jogador 5'),(6,'Jogador 6','Sobrenome Jogador 6'),(7,'Jogador 7','Sobrenome Jogador 7'),(8,'Jogador 8','Sobrenome Jogador 8'),(9,'Jogador 9','Sobrenome Jogador 9'),(10,'Jogador 10','Sobrenome Jogador 10');
/*!40000 ALTER TABLE Jogador ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table Quadra
--

DROP TABLE IF EXISTS Quadra;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE Quadra (
  Id int(11) NOT NULL AUTO_INCREMENT,
  Nome varchar(100) NOT NULL,
  Endereco varchar(255) NOT NULL,
  PRIMARY KEY (Id)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table Quadra
--

LOCK TABLES Quadra WRITE;
/*!40000 ALTER TABLE Quadra DISABLE KEYS */;
INSERT INTO Quadra VALUES (1,'Quadra 1','Rua 1'),(2,'Quadra 2','Rua 2');
/*!40000 ALTER TABLE Quadra ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-05-12 15:33:20


/********************************************************
    Registros iniciais
/********************************************************/

INSERT INTO Jogador(Nome, Sobrenome) VALUES('Jogador 1', 'Sobrenome Jogador 1');
INSERT INTO Jogador(Nome, Sobrenome) VALUES('Jogador 2', 'Sobrenome Jogador 2');
INSERT INTO Jogador(Nome, Sobrenome) VALUES('Jogador 3', 'Sobrenome Jogador 3');
INSERT INTO Jogador(Nome, Sobrenome) VALUES('Jogador 4', 'Sobrenome Jogador 4');
INSERT INTO Jogador(Nome, Sobrenome) VALUES('Jogador 5', 'Sobrenome Jogador 5');
INSERT INTO Jogador(Nome, Sobrenome) VALUES('Jogador 6', 'Sobrenome Jogador 6');
INSERT INTO Jogador(Nome, Sobrenome) VALUES('Jogador 7', 'Sobrenome Jogador 7');
INSERT INTO Jogador(Nome, Sobrenome) VALUES('Jogador 8', 'Sobrenome Jogador 8');
INSERT INTO Jogador(Nome, Sobrenome) VALUES('Jogador 9', 'Sobrenome Jogador 9');
INSERT INTO Jogador(Nome, Sobrenome) VALUES('Jogador 10','Sobrenome Jogador 10');

INSERT INTO Quadra(Nome, Endereco) VALUES('Quadra 1', 'Endereco 1');
INSERT INTO Quadra(Nome, Endereco) VALUES('Quadra 2', 'Endereco 2');
INSERT INTO Quadra(Nome, Endereco) VALUES('Quadra 3', 'Endereco 3');
INSERT INTO Quadra(Nome, Endereco) VALUES('Quadra 4', 'Endereco 4');
INSERT INTO Quadra(Nome, Endereco) VALUES('Quadra 5', 'Endereco 5');
INSERT INTO Quadra(Nome, Endereco) VALUES('Quadra 6', 'Endereco 6');
INSERT INTO Quadra(Nome, Endereco) VALUES('Quadra 7', 'Endereco 7');
INSERT INTO Quadra(Nome, Endereco) VALUES('Quadra 8', 'Endereco 8');
INSERT INTO Quadra(Nome, Endereco) VALUES('Quadra 9', 'Endereco 9');
INSERT INTO Quadra(Nome, Endereco) VALUES('Quadra 10','Endereco 10');