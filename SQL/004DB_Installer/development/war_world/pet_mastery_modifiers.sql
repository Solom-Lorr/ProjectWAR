-- MySQL dump 10.13  Distrib 5.5.37, for Win32 (AMD64)
--
-- Host: 127.0.0.1    Database: war_world
-- ------------------------------------------------------
-- Server version	8.0.18

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
-- Table structure for table `pet_mastery_modifiers`
--

DROP TABLE IF EXISTS `pet_mastery_modifiers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pet_mastery_modifiers` (
  `CareerLine` tinyint(3) unsigned NOT NULL,
  `PrimaryValue` tinyint(3) unsigned NOT NULL,
  `MasteryTree` tinyint(3) unsigned NOT NULL,
  `PointStart` tinyint(3) unsigned NOT NULL,
  `PointEnd` tinyint(3) unsigned NOT NULL,
  `MasteryModifierPercent` float DEFAULT NULL,
  `MasteryModifierAddition` int(5) DEFAULT '0',
  `Active` tinyint(1) DEFAULT '0',
  `UUID` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  PRIMARY KEY (`UUID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pet_mastery_modifiers`
--

LOCK TABLES `pet_mastery_modifiers` WRITE;
/*!40000 ALTER TABLE `pet_mastery_modifiers` DISABLE KEYS */;
INSERT INTO `pet_mastery_modifiers` VALUES (25,1,2,1,6,1,0,1,'854b9afe-6e7d-11e7-9033-000c29d63948'),
(25,1,2,7,12,2,0,1,'856d6e51-6e7d-11e7-9033-000c29d63948'),
(25,1,2,13,15,5,0,1,'858f2f82-6e7d-11e7-9033-000c29d63948');
/*!40000 ALTER TABLE `pet_mastery_modifiers` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-01-07 15:42:08