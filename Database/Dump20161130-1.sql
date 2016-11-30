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
  `Recipe` longtext,
  `Difficulty` int(11) DEFAULT NULL,
  `Duration` int(11) DEFAULT NULL,
  `Author` varchar(255) DEFAULT NULL,
  `TimeAdded` date DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dish`
--

LOCK TABLES `dish` WRITE;
/*!40000 ALTER TABLE `dish` DISABLE KEYS */;
INSERT INTO `dish` VALUES (789269301,'Fransk kyllinggryte','Digg','[{\"Value\":\"Stek kylling i smør. Skjær soppen i skiver.\"},{\"Value\":\"Hell oppi matfløte og kyllingbuljong. Småkok på svak varme i 5 min. \"},{\"Value\":\"Serveres med ris\"}]',2,40,'Therese Ryen','2016-11-28'),(1907347186,'Omelett','En rett som passer til rester','[{\"Value\":\"Visp romtemperert egg, melk/fløte og krydder\"},{\"Value\":\"Surr finhakket chili, hvitløk og sjarlottløk i smør \"},{\"Value\":\"Hell blandingen i en liten stekepanne, tilsett de siste ingrediensene og sett på lokk \"},{\"Value\":\"Stek på lav varme til blandingen er stivnet\"},{\"Value\":\"Serveres med ristet brød og evt en salat til\"},{\"Value\":\"Velbekomme, kos deg på kjøkkenet du også :-)\"}]',2,30,'Winnie Lian','2016-11-29');
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
  `Amount` double DEFAULT NULL,
  `Unit` varchar(255) DEFAULT NULL,
  `Ingredient_id_fk` int(11) NOT NULL,
  `Dish_id_fk` int(11) NOT NULL,
  `Comment` varchar(255) DEFAULT NULL,
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
INSERT INTO `dish_ingredient` VALUES (165369802,0.5,'ts',1718571757,1907347186,NULL),(260076771,0.5,'stk',1173031059,1907347186,NULL),(556899818,0.25,'ts',1758041746,1907347186,NULL),(708628643,3,'ss',1658025047,1907347186,NULL),(789269301,300,'gr',697367444,789269301,NULL),(838219319,3,'dl',1658025047,789269301,NULL),(1237114879,150,'gr',161659272,789269301,NULL),(1275734250,1,'ts',1257281188,1907347186,NULL),(1366958302,1,'ts',769216489,789269301,NULL),(1626592044,2,'skiver',2120804335,1907347186,NULL),(1666915949,1,'ss',604879288,1907347186,NULL),(1865194668,3,'ss',1837046267,1907347186,NULL),(1907347186,3,'stk',237467699,1907347186,NULL),(1932406151,0.5,'stk',1390785261,1907347186,NULL),(2102682307,1,'skive',695832841,1907347186,NULL);
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
INSERT INTO `dish_tag` VALUES (99105974,789269301,843741084),(286025836,1907347186,1107510883),(708628643,1907347186,1703283771),(789269301,789269301,1107510883),(1757987696,789269301,1237877467);
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
INSERT INTO `ingredient` VALUES (161659272,'Sjampinjong','sopp'),(237467699,'Egg',NULL),(604879288,'Gressløk','Urt'),(695832841,'Paprika','Grønt'),(697367444,'Kylling','Lyst kjøtt'),(769216489,'Timian','Krydder'),(1173031059,'Chili','Krydder'),(1257281188,'Smør',''),(1380862174,'Tomat','Frukt/Grønt'),(1390785261,'Sjarlottløk','Løk'),(1652100118,'Melk',''),(1658025047,'Matfløte','Melkeprodukt'),(1718571757,'Pepper',''),(1758041746,'Salt',''),(1837046267,'Tacokjøttdeig','Kjøttdeig'),(2120804335,'Ost','Ost'),(2134727527,'Hvitløk','Løk');
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
INSERT INTO `tag` VALUES (490143748,'Kvelds'),(508289655,'Billig'),(843741084,'Rask'),(1092345305,'Kyllingmiddag'),(1107510883,'Hverdag'),(1237877467,'Fransk'),(1317703471,'Forrett'),(1606552294,'Hovedrett'),(1703283771,'Allround'),(1882113309,'Lunch');
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

-- Dump completed on 2016-11-30  8:57:04
