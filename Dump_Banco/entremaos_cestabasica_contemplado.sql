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
-- Table structure for table `cestabasica_contemplado`
--

DROP TABLE IF EXISTS `cestabasica_contemplado`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cestabasica_contemplado` (
  `cestaBasica_Contemplado_id` int NOT NULL AUTO_INCREMENT,
  `contemplado_id` int DEFAULT NULL,
  `cestaBasica_id` int DEFAULT NULL,
  `recebidoPor` varchar(100) DEFAULT NULL,
  `recebido` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`cestaBasica_Contemplado_id`),
  KEY `contemplado_idFK` (`contemplado_id`),
  KEY `cestaBasica_idFK` (`cestaBasica_id`),
  CONSTRAINT `cestaBasica_idFK` FOREIGN KEY (`cestaBasica_id`) REFERENCES `cestabasica` (`cestaBasica_id`),
  CONSTRAINT `contemplado_idFK` FOREIGN KEY (`contemplado_id`) REFERENCES `contemplado` (`contemplado_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cestabasica_contemplado`
--

LOCK TABLES `cestabasica_contemplado` WRITE;
/*!40000 ALTER TABLE `cestabasica_contemplado` DISABLE KEYS */;
INSERT INTO `cestabasica_contemplado` VALUES (1,1,1,'Marcela Freitas Souza',1),(2,1,1,'Marcela Souza',1);
/*!40000 ALTER TABLE `cestabasica_contemplado` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-10-09 15:52:45
