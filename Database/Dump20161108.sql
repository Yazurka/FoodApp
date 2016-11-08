CREATE DATABASE  IF NOT EXISTS `app` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `app`;
-- MySQL dump 10.13  Distrib 5.6.24, for Win64 (x86_64)
--
-- Host: localhost    Database: app
-- ------------------------------------------------------
-- Server version	5.6.26-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `dish`
--

DROP TABLE IF EXISTS `dish`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `dish` (
  `Id` int(11) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `Recipe` varchar(255) DEFAULT NULL,
  `Difficulty` int(11) DEFAULT NULL,
  `Duration` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dish`
--

LOCK TABLES `dish` WRITE;
/*!40000 ALTER TABLE `dish` DISABLE KEYS */;
INSERT INTO `dish` VALUES (1,'Rømmegrøt','grøtrett',NULL,NULL,NULL),(1791711019,'Pølse i brød','kjøttrett',NULL,NULL,NULL);
/*!40000 ALTER TABLE `dish` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dish_ingredient`
--

DROP TABLE IF EXISTS `dish_ingredient`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `dish_ingredient` (
  `Id` int(11) NOT NULL,
  `Amount` int(11) DEFAULT NULL,
  `Unit` varchar(255) DEFAULT NULL,
  `Ingredient_id_fk` int(11) NOT NULL,
  `Dish_id_fk` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `Ingredient_id_fk_idx` (`Ingredient_id_fk`),
  KEY `Disht_id_fk_idx` (`Dish_id_fk`),
  CONSTRAINT `Disht_id_fk` FOREIGN KEY (`Dish_id_fk`) REFERENCES `dish` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `Ingredient_id_fk` FOREIGN KEY (`Ingredient_id_fk`) REFERENCES `ingredient` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dish_ingredient`
--

LOCK TABLES `dish_ingredient` WRITE;
/*!40000 ALTER TABLE `dish_ingredient` DISABLE KEYS */;
INSERT INTO `dish_ingredient` VALUES (1757351271,2,'Liter',2,1);
/*!40000 ALTER TABLE `dish_ingredient` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dish_tag`
--

DROP TABLE IF EXISTS `dish_tag`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `dish_tag` (
  `Id` int(11) NOT NULL,
  `Dish_id_fk` int(11) NOT NULL,
  `Tag_id_fk` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `Dish_id_fk_idx` (`Dish_id_fk`),
  KEY `TagId _fk_idx` (`Tag_id_fk`),
  CONSTRAINT `DishInTag_id_fk` FOREIGN KEY (`Dish_id_fk`) REFERENCES `dish` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `TagId _fk` FOREIGN KEY (`Tag_id_fk`) REFERENCES `tag` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dish_tag`
--

LOCK TABLES `dish_tag` WRITE;
/*!40000 ALTER TABLE `dish_tag` DISABLE KEYS */;
INSERT INTO `dish_tag` VALUES (1,1,899627983),(2,1791711019,928694354),(3,1791711019,843741084),(4,1791711019,297681079),(1333945632,1791711019,805764724);
/*!40000 ALTER TABLE `dish_tag` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ingredient`
--

DROP TABLE IF EXISTS `ingredient`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ingredient` (
  `Id` int(11) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Description` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ingredient`
--

LOCK TABLES `ingredient` WRITE;
/*!40000 ALTER TABLE `ingredient` DISABLE KEYS */;
INSERT INTO `ingredient` VALUES (1,'Melk','Melkeprodukt'),(2,'Smør','Meieriprodukt'),(3,'Rømme','Melkeprodukt'),(4,'Fløte','Melkeprodukt'),(5,'Bacon','Kjøttprodukt');
/*!40000 ALTER TABLE `ingredient` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tag`
--

DROP TABLE IF EXISTS `tag`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tag` (
  `Id` int(11) NOT NULL,
  `Name` varchar(255) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tag`
--

LOCK TABLES `tag` WRITE;
/*!40000 ALTER TABLE `tag` DISABLE KEYS */;
INSERT INTO `tag` VALUES (151698370,'Mexico'),(297681079,'Fest'),(805764724,'Spicy'),(843741084,'Rask'),(899627983,'Tradisjonell'),(928694354,'Grille'),(1107510883,'Hverdag'),(1444907797,'Norsk'),(1921483138,'Kosemat');
/*!40000 ALTER TABLE `tag` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-11-08 20:57:12
