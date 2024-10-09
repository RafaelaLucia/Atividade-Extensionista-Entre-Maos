CREATE DATABASE  IF NOT EXISTS `entremaos` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `entremaos`;
-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: localhost    Database: entremaos
-- ------------------------------------------------------
-- Server version	8.0.37

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `contemplado`
--

DROP TABLE IF EXISTS `contemplado`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `contemplado` (
  `contemplado_id` int NOT NULL AUTO_INCREMENT,
  `estadoCivil_id` int DEFAULT NULL,
  `postoConvenio_id` int DEFAULT NULL,
  `moraCom_id` int DEFAULT NULL,
  `residencia_id` int DEFAULT NULL,
  `nomeContemplado` varchar(300) NOT NULL,
  `dataNascimento` date NOT NULL,
  `RG` varchar(15) DEFAULT NULL,
  `CPF` varchar(15) DEFAULT NULL,
  `escolaridade` varchar(100) DEFAULT NULL,
  `endereco` varchar(200) DEFAULT NULL,
  `naturalidade` varchar(100) DEFAULT NULL,
  `telefone` varchar(20) DEFAULT NULL,
  `bairro` varchar(200) DEFAULT NULL,
  `ajudaGoverno` varchar(100) DEFAULT NULL,
  `gastoComMedicamento` varchar(100) DEFAULT NULL,
  `dívida` varchar(100) DEFAULT NULL,
  `rendaFamiliar` varchar(100) DEFAULT NULL,
  `temVeiculo` tinyint(1) DEFAULT NULL,
  `necessidadeDeLeite` tinyint(1) DEFAULT NULL,
  `necessidadeDeFralda` tinyint(1) DEFAULT NULL,
  `problemaComCigarroOuDrogas` varchar(50) DEFAULT NULL,
  `problemaComBebida` varchar(50) DEFAULT NULL,
  `deficiencia` varchar(100) DEFAULT NULL,
  `responsavelFamilia` varchar(50) DEFAULT NULL,
  `tamanhoFamilia` int DEFAULT NULL,
  `anotacoesGerais` varchar(500) DEFAULT NULL,
  `cadastro` date DEFAULT NULL,
  `desligamento` tinyint(1) DEFAULT NULL,
  `indicacao` varchar(100) DEFAULT NULL,
  `nomePosto` varchar(100) DEFAULT NULL,
  `aluguel` varchar(100) DEFAULT NULL,
  `fotoContemplado` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`contemplado_id`),
  KEY `estadoCivil_idFK` (`estadoCivil_id`),
  KEY `postoConvenio_idFK` (`postoConvenio_id`),
  KEY `moraCom_idFK` (`moraCom_id`),
  KEY `residencia_idFK` (`residencia_id`),
  CONSTRAINT `estadoCivil_idFK` FOREIGN KEY (`estadoCivil_id`) REFERENCES `estadocivil` (`estadoCivil_id`),
  CONSTRAINT `moraCom_idFK` FOREIGN KEY (`moraCom_id`) REFERENCES `moracom` (`moraCom_id`),
  CONSTRAINT `postoConvenio_idFK` FOREIGN KEY (`postoConvenio_id`) REFERENCES `convenio` (`postoConvenio_id`),
  CONSTRAINT `residencia_idFK` FOREIGN KEY (`residencia_id`) REFERENCES `residencia` (`residencia_id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contemplado`
--

LOCK TABLES `contemplado` WRITE;
/*!40000 ALTER TABLE `contemplado` DISABLE KEYS */;
INSERT INTO `contemplado` VALUES (1,1,1,1,3,'Marcela Freitas Souza','1993-03-17','26.088.968-4','353.687.428-27','Ensino Médio Completo','Rua Ilha da Trindade, 500','São Paulo/SP','(11) 99137-3669','Parque Santa Madalena','Bolsa Família - R$750','Não','Não','Até 1500,00',0,0,0,'Não','Não','Não','O próprio entrevistado(a)',2,'Mora com a filha, a Casa foi herança, filha é intolerante a lactose e tem dermatite. Trabalha como diarista - valor R$150 quando aparece','2023-07-24',0,'Portão','Pastoral','Não','C:\\Users\\rafae\\Downloads\\grupo.jpg'),(7,2,1,1,2,'Ana Paula Alves Pereira','1980-12-02','55.487.653-2','','Ensino Médio Completo','AV. Dom Frederico Carvalho','São Paulo / SP','(11) 955487-4521','Parque Santa Madalena','Sim, R$600','Não','','1000',0,0,0,'Não','Não','Não','Cônjuge',3,'Filho tem Artrite Joelho','2022-11-30',0,'Creusa','Iguaçu','R$500,00','');
/*!40000 ALTER TABLE `contemplado` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-10-09 15:52:44
