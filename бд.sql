-- MySQL dump 10.13  Distrib 8.0.31, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: shopcoumpcomplect
-- ------------------------------------------------------
-- Server version	8.0.31

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
-- Table structure for table `manufacture`
--

DROP TABLE IF EXISTS `manufacture`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `manufacture` (
  `id_manufacture` int NOT NULL AUTO_INCREMENT,
  `name_manufacture` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_manufacture`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `manufacture`
--

LOCK TABLES `manufacture` WRITE;
/*!40000 ALTER TABLE `manufacture` DISABLE KEYS */;
INSERT INTO `manufacture` VALUES (1,'MSI'),(2,'Intel'),(3,'AMD'),(4,'Asus'),(5,'Gigabyte'),(6,'Samsung'),(7,'Kingston'),(8,'Be Quiet'),(9,'KCAS '),(10,'DEEPCOOL ');
/*!40000 ALTER TABLE `manufacture` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order`
--

DROP TABLE IF EXISTS `order`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `order` (
  `id_Order` int NOT NULL AUTO_INCREMENT,
  `User_Order` int DEFAULT NULL,
  `Date_Order` date DEFAULT NULL,
  `Pickap_Point_Order` int DEFAULT NULL,
  `codeToGet` int DEFAULT NULL,
  PRIMARY KEY (`id_Order`),
  KEY `Orser_User_FK_idx` (`User_Order`),
  KEY `Order_Pickap_Point_FK_idx` (`Pickap_Point_Order`),
  CONSTRAINT `Order_Pickap_Point_FK` FOREIGN KEY (`Pickap_Point_Order`) REFERENCES `pickap_point` (`id_Pickap_Point`),
  CONSTRAINT `Orser_User_FK` FOREIGN KEY (`User_Order`) REFERENCES `user` (`id_User`)
) ENGINE=InnoDB AUTO_INCREMENT=75 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order`
--

LOCK TABLES `order` WRITE;
/*!40000 ALTER TABLE `order` DISABLE KEYS */;
INSERT INTO `order` VALUES (1,1,'2023-05-21',1,101),(2,5,'2023-06-05',1,102),(3,5,'2023-06-05',1,103),(4,5,'2023-06-05',3,104),(5,5,'2023-06-05',1,105),(6,5,'2023-06-05',1,106),(7,5,'2023-06-05',2,107),(8,5,'2023-06-05',2,108),(9,5,'2023-06-05',1,109),(10,5,'2023-06-05',1,110),(11,5,'2023-06-05',3,111),(12,5,'2023-06-05',1,112),(13,5,'2023-06-05',1,113),(14,5,'2023-06-05',2,114),(15,1,'2023-06-05',3,115),(16,1,'2023-06-05',2,116),(17,5,'2023-06-07',2,117),(18,5,'2023-06-07',1,118),(19,5,'2023-06-07',1,119),(20,5,'2023-06-07',1,120),(21,5,'2023-06-07',1,121),(22,5,'2023-06-07',2,122),(23,5,'2023-06-07',2,123),(24,5,'2023-06-07',2,124),(25,5,'2023-06-07',2,125),(26,5,'2023-06-07',1,126),(27,5,'2023-06-07',3,127),(28,5,'2023-06-07',1,128),(29,5,'2023-06-07',1,129),(30,5,'2023-06-07',3,130),(31,5,'2023-06-07',3,131),(32,5,'2023-06-07',2,132),(33,5,'2023-06-07',1,133),(34,5,'2023-06-07',2,134),(35,5,'2023-06-07',3,135),(36,5,'2023-06-07',2,136),(37,5,'2023-06-07',1,137),(38,5,'2023-06-07',1,138),(39,5,'2023-06-07',2,139),(40,5,'2023-06-07',1,140),(41,5,'2023-06-07',2,141),(42,5,'2023-06-07',2,142),(43,5,'2023-06-07',2,143),(44,5,'2023-06-07',3,144),(45,5,'2023-06-07',2,145),(46,5,'2023-06-07',2,146),(47,5,'2023-06-08',3,147),(48,5,'2023-06-08',1,148),(49,5,'2023-06-10',2,149),(50,5,'2023-06-27',2,150),(51,1,'2023-06-27',1,151),(52,1,'2023-06-27',2,152),(53,1,'2023-06-27',2,153),(54,1,'2023-06-27',1,154),(55,1,'2023-06-27',3,155),(56,1,'2023-06-27',2,156),(57,5,'2023-06-27',1,157),(58,5,'2023-06-27',1,158),(59,5,'2023-06-27',3,159),(60,5,'2023-06-27',1,160),(61,5,'2023-06-27',1,161),(62,5,'2023-06-27',3,162),(63,5,'2023-06-27',3,163),(64,1,'2023-06-27',1,164),(65,5,'2023-06-27',3,165),(66,5,'2023-06-27',2,166),(67,1,'2023-06-28',2,167),(68,5,'2023-06-28',1,168);
/*!40000 ALTER TABLE `order` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orderproduct`
--

DROP TABLE IF EXISTS `orderproduct`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orderproduct` (
  `id_order` int NOT NULL,
  `Id_product` int NOT NULL,
  `count` int DEFAULT NULL,
  PRIMARY KEY (`id_order`,`Id_product`),
  KEY `product_idx` (`Id_product`),
  CONSTRAINT `order` FOREIGN KEY (`id_order`) REFERENCES `order` (`id_Order`),
  CONSTRAINT `product` FOREIGN KEY (`Id_product`) REFERENCES `product` (`id_Product`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orderproduct`
--

LOCK TABLES `orderproduct` WRITE;
/*!40000 ALTER TABLE `orderproduct` DISABLE KEYS */;
INSERT INTO `orderproduct` VALUES (1,1,1),(2,1,1),(2,2,4),(2,3,1),(2,4,1),(2,5,1),(2,6,6),(3,2,1),(4,1,3),(4,2,3),(4,3,4),(5,1,1),(6,1,1),(7,2,2),(7,6,5),(7,7,4),(8,1,1),(8,2,4),(9,5,1),(10,2,1),(11,1,1),(12,2,1),(12,6,1),(12,7,1),(13,11,1),(14,10,1),(15,1,5),(15,3,4),(15,10,1),(15,11,1),(16,2,4),(16,8,4),(16,9,1),(17,7,1),(19,2,5),(22,2,6),(22,5,8),(22,7,7),(23,6,1),(24,10,1),(25,6,1),(26,5,1),(27,11,1),(29,2,3),(31,2,1),(32,5,2),(33,1,1),(34,7,1),(35,1,1),(36,1,1),(37,6,1),(38,6,1),(39,6,1),(40,1,1),(41,6,1),(42,6,1),(43,7,1),(44,11,1),(46,1,4),(46,3,4),(48,1,5),(48,2,3),(48,6,3),(49,1,5),(49,2,1),(49,10,5),(50,2,1),(51,2,1),(52,2,1),(53,2,1),(54,8,1),(55,11,1),(56,7,1),(57,11,1),(58,10,1),(59,9,1),(60,11,1),(61,2,1),(63,1,1),(64,1,1),(66,2,5),(66,3,2),(66,4,3),(66,6,3),(66,10,4),(68,1,1);
/*!40000 ALTER TABLE `orderproduct` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pickap_point`
--

DROP TABLE IF EXISTS `pickap_point`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pickap_point` (
  `id_Pickap_Point` int NOT NULL,
  `index_Pickap_Point` int DEFAULT NULL,
  `Sity_Pickap_Point` varchar(45) DEFAULT NULL,
  `Street_Pickap_Point` varchar(45) DEFAULT NULL,
  `House_Pickap_Point` int DEFAULT NULL,
  PRIMARY KEY (`id_Pickap_Point`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pickap_point`
--

LOCK TABLES `pickap_point` WRITE;
/*!40000 ALTER TABLE `pickap_point` DISABLE KEYS */;
INSERT INTO `pickap_point` VALUES (1,123331,'Уфа','Гагарина',23),(2,124512,'Уфа','Гагарина',63),(3,718211,'Уфа','Жукова',32);
/*!40000 ALTER TABLE `pickap_point` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product`
--

DROP TABLE IF EXISTS `product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `product` (
  `id_Product` int NOT NULL AUTO_INCREMENT,
  `name_Product` varchar(45) DEFAULT NULL,
  `Discription_Product` varchar(500) DEFAULT NULL,
  `Type_Product` int DEFAULT NULL,
  `Manufacture_Product` int DEFAULT NULL,
  `Suppl_Product` int DEFAULT NULL,
  `Count_in_stock_Product` int DEFAULT NULL,
  `Cost_product` decimal(19,2) DEFAULT NULL,
  `Photo_Product` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`id_Product`),
  KEY `type_FK_idx` (`Type_Product`),
  KEY `suppl_FK_idx` (`Suppl_Product`),
  KEY `manufacture_FK_idx` (`Manufacture_Product`),
  CONSTRAINT `manufacture_FK` FOREIGN KEY (`Manufacture_Product`) REFERENCES `manufacture` (`id_manufacture`),
  CONSTRAINT `suppl_FK` FOREIGN KEY (`Suppl_Product`) REFERENCES `supplers` (`id_supplers`),
  CONSTRAINT `type_FK` FOREIGN KEY (`Type_Product`) REFERENCES `type` (`id_type`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product`
--

LOCK TABLES `product` WRITE;
/*!40000 ALTER TABLE `product` DISABLE KEYS */;
INSERT INTO `product` VALUES (1,'GIGABYTE GeForce RTX 4090 GAMING OC','Видеокарта GIGABYTE GeForce RTX 4090 GAMING OC предлагает высокую производительность и широкие графические возможности при поддержке искусственного интеллекта. Модель с архитектурой NVIDIA Ada Lovelace и 24 ГБ памяти стандарта GDDR6X создана для игр и разработки контента. Тактовая частота процессора составляет 2230 МГц.',2,5,2,10,157999.99,'4090.jpg'),(2,'AMD Ryzen 9 7900X OEM','Процессор AMD Ryzen 9 7900X – это мощное решение для игровых систем и рабочих станций. В основе модели используются высококачественные компоненты и передовые технологии, что в связке с большим числом физических ядер и виртуальных потоков может обеспечить непревзойденно высокую вычислительную мощность в любых сценариях использования компьютера.',1,3,1,8,36999.00,'AMD Ryzen 9 7900X OEM.jpg'),(3,'GIGABYTE B650 AORUS PRO AX','Материнская плата GIGABYTE B650 AORUS PRO AX предлагает высокую производительность и широкие возможности для воплощения мощного игрового потенциала. Массивные охлаждающие радиаторы эффективно отводят тепло и поддерживают низкую температуру нагрева. Для создания собственного стиля реализована многоцветная подсветка AORUS с поддержкой синхронизации.',4,5,6,13,22999.00,'GIGABYTE B650 AORUS PRO AX.jpg'),(4,'Kingston FURY Beast Black 32 ГБ','Оперативная память Kingston FURY Beast Black поколения DDR5 разработана для игровых систем и обеспечивает быстродействие при обработке требовательных задач. Она представлена комплектом из двух модулей объемом по 16 ГБ, которые работают с частотой 5200 МГц. ',3,7,4,35,10799.99,'Kingston FURY Beast Black.jpg'),(5,'be quiet! SYSTEM POWER 10 750W','Блок питания be quiet! SYSTEM POWER 10 750W [BN329] с классом энергоэффективности 80 PLUS Bronze и номинальной мощностью 750 Вт способен обеспечить производительность и стабильность в составе высокопроизводительного стационарного ПК. ',5,8,5,15,7099.00,'be quiet! SYSTEM POWER.jpg'),(6,'DEEPCOOL LE500 Marrs','Универсальный жидкостный кулер DEEPCOOL LE500 для ЦП предлагает эффективное охлаждение, яркую светодиодную подсветку и технологию Anti-Leak для долговременной работы.',7,10,1,9,5899.00,'DEEPCOOL LE500 Marrs.jpg'),(7,'2000 ГБ SSD M.2 Samsung 970 EVO Plus','M.2 накопитель Samsung 970 EVO Plus разработан для игровых ПК и профессиональных рабочих станций. Благодаря скорости в пределах 3500 Мбайт/сек он гарантирует повышение производительности системы ПК при разработке контента, рендеринге, запуске игр и выполнении других ресурсоемких задач. Объем 2000 ГБ предоставляет достаточно пространства для хранения большого количества файлов. ',6,6,3,13,15999.99,'2000 ГБ SSD M.2 Samsung 970 EVO Plus.jpg'),(8,'AeroCool KCAS PLUS GOLD 750W','Этот стильный и изысканный блок питания с 12-сантиметровым вентилятором ARGB улучшает внешний вид вашего игрового устройства и служит эффективным источником питания для вашей системы. Оживите свою систему с помощью 13 предустановленных режимов подсветки, которыми можно легко управлять с помощью специальной кнопки. Благодаря адресуемому разъему RGB устройство совместимо с системными платами с адресуемой RGB подсветкой.',5,9,5,15,5999.00,'AeroCool KCAS PLUS GOLD 750W.jpg'),(9,'Кулер для процессора DARK ROCK PRO 4','Кулер для процессора be quiet! DARK ROCK PRO 4 выпущен известным производителем устройств для отвода тепла. Модель универсальна: использовать кулер можно совместно с процессорами Intel и AMD всех широко распространенных в настоящее время сокетов. Устройство имеет башенную конструкцию. 7 тепловых трубок способствуют обеспечению высокого уровня эффективности отвода тепла. Установлены 2 вентилятора: 120-миллиметровый и 135-миллиметровый',7,8,3,16,10499.00,'Кулер для процессора DARK ROCK PRO 4.jpg'),(10,'MSI GeForce RTX 3070 VENTUS 3X OC','Видеокарта MSI GeForce RTX 3070 VENTUS 3X OC (LHR) выделяется минималистским дизайном, за которым скрывается мощный вычислительный потенциал для требовательных программ и игр с высокими графическими настройками. В ее основе содержится процессор на архитектуре Ampere с частотой до 1755 МГц в режиме турбо и 8 ГБ видеопамяти.',2,1,3,7,45999.99,'MSI GeForce RTX 3070 VENTUS 3X OC.jpg'),(11,'Kingston FURY Renegade Pro 128 ГБ','Kingston FURY Renegade Pro DDR5 RDIMM позволяет удовлетворить вычислительные потребности рабочих станций и высокопроизводительных настольных платформ, требующих использования модулей регистровой памяти DIMM DDR5. Эти модули предоставляют инженерам и специалистам по обработке данных высокопроизводительную память с высоким уровнем качества модулей регистровой памяти DIMM, ранее предлагаемую для геймеров.',3,7,1,6,72999.00,'Kingston FURY Renegade Pro.jpg'),(12,'AMD Ryzen 5 5600X OEM','Процессор AMD Ryzen 5 5600X OEM представляет собой производительное решение для игровых систем и рабочих станций. Данная модель выполнена на основе архитектуры Vermeer по техпроцессу 7 нм, что вкупе с 6 физическими ядрами и 12 виртуальными потоками обеспечит высокую вычислительную мощность в самых разных задачах. Диапазон рабочих частот процессора может варьироваться от 3.7 до 4.6 ГГц и при помощи свободного множителя может быть повышен для достижения еще большей производительности.',1,3,2,13,13399.00,'AMD Ryzen 5 5600X OEM.jpg');
/*!40000 ALTER TABLE `product` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `role`
--

DROP TABLE IF EXISTS `role`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `role` (
  `id_role` int NOT NULL AUTO_INCREMENT,
  `name_role` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_role`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `role`
--

LOCK TABLES `role` WRITE;
/*!40000 ALTER TABLE `role` DISABLE KEYS */;
INSERT INTO `role` VALUES (1,'Клиент'),(2,'Менеджер');
/*!40000 ALTER TABLE `role` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `supplers`
--

DROP TABLE IF EXISTS `supplers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `supplers` (
  `id_supplers` int NOT NULL AUTO_INCREMENT,
  `name_supplers` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_supplers`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `supplers`
--

LOCK TABLES `supplers` WRITE;
/*!40000 ALTER TABLE `supplers` DISABLE KEYS */;
INSERT INTO `supplers` VALUES (1,'ООО \"Мегаполис-Телеком регион\"'),(2,'ООО \"КРУТОФ ГРУПП\"'),(3,'ООО \"КОМПЬЮТЕРНЫЕ ТЕХНОЛОГИИ\"'),(4,'М.Видео'),(5,'Эльдорадо'),(6,'DNS');
/*!40000 ALTER TABLE `supplers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `type`
--

DROP TABLE IF EXISTS `type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `type` (
  `id_type` int NOT NULL AUTO_INCREMENT,
  `name_type` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_type`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `type`
--

LOCK TABLES `type` WRITE;
/*!40000 ALTER TABLE `type` DISABLE KEYS */;
INSERT INTO `type` VALUES (1,'Процессор'),(2,'Видеокарта'),(3,'Оперативная память'),(4,'Материнская плата'),(5,'Блок питания'),(6,'Накопитель данных'),(7,'Охлаждение компьютера');
/*!40000 ALTER TABLE `type` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `id_User` int NOT NULL AUTO_INCREMENT,
  `Login_User` varchar(45) NOT NULL,
  `Password_User` varchar(45) NOT NULL,
  `Name_user` varchar(45) NOT NULL,
  `SurName_user` varchar(45) NOT NULL,
  `Patronymic_user` varchar(45) DEFAULT NULL,
  `Role_user` int NOT NULL,
  `NumTelefon_user` varchar(45) NOT NULL,
  PRIMARY KEY (`id_User`),
  UNIQUE KEY `Login_User_UNIQUE` (`Login_User`),
  UNIQUE KEY `NumTelefon_user_UNIQUE` (`NumTelefon_user`),
  KEY `role_FK_idx` (`Role_user`),
  CONSTRAINT `role_FK` FOREIGN KEY (`Role_user`) REFERENCES `role` (`id_role`)
) ENGINE=InnoDB AUTO_INCREMENT=83 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,'qwe','123','Архипов ','Роман ','Георгиевич',2,'+7(641)882-44-972'),(2,'asd','321','Полякова ','София ','Даниловна',2,'+7(707)314-48-353'),(3,'qaz','123ssa','Федоров ','Максим ','Маркович',1,'+7(234) 256-78-90'),(4,'a3d','322','asdf','dsf','fasd',1,'+7(222) 222-22-22'),(5,'q','1','Артем','Захарян','Генадевич',1,'+7(123) 456-78-91'),(6,'erterteert','ertert','rettert','ertert','ertertertert',1,'+7(123) 123-13-12'),(7,'BRFF','8989','Максим','Павлов','Владимирович',1,'+7(898) 989-89-89'),(8,'qweww','123','dfgdfgdfgdfg','erfgdfg','dfgdfgd',1,'+7(332) 423-42-34');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-07-03 20:04:03
