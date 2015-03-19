-- phpMyAdmin SQL Dump
-- version 4.1.12
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Mar 12, 2015 at 02:45 AM
-- Server version: 5.6.16
-- PHP Version: 5.5.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `maintenance`
--
CREATE DATABASE IF NOT EXISTS `maintenance` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `maintenance`;

-- --------------------------------------------------------

--
-- Table structure for table `__migrationhistory`
--

DROP TABLE IF EXISTS `__migrationhistory`;
CREATE TABLE IF NOT EXISTS `__migrationhistory` (
  `MigrationId` varchar(100) CHARACTER SET utf8 NOT NULL,
  `ContextKey` varchar(200) CHARACTER SET utf8 NOT NULL,
  `Model` longblob NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8 NOT NULL,
  PRIMARY KEY (`MigrationId`,`ContextKey`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `__migrationhistory`
--

INSERT INTO `__migrationhistory` (`MigrationId`, `ContextKey`, `Model`, `ProductVersion`) VALUES
('201503120138227_InitialCreate', 'Application.Data.Migrations.Configuration', 0x1f8b0800000000000400dd5c5b6febb8117e5f60ff83a0c7226be7d21c9c06f62e729ca41b3471823867d1b7035aa21de1489456a2b2098afeb23ef427f52f9494a80b6f1265cbb6b2c84bc2cb37c3e10c391ccde47ffff9efe497b7c0b75e619c78219ada27a363db82c8095d0fada7768a573f7db67ff9f9c71f26d76ef066fd568c3ba3e3c84c944ced178ca38bf138715e60009251e0397198842b3c72c2600cdc707c7a7cfcb7f1c9c91812089b6059d6e42945d80b60f607f973162207463805fe7de8423f61eda46791a15a7310c024020e9cda9751e47b0ec0848fd115c0c0b62e7d0f103e16d05fd9164028c459efc5d7042e701ca2f522220dc07f7e8f2019b7027e0219f717d570d3851c9fd2858cab8905949326380c3a029e9c31c98cc5e91bc9d72e254764774d648cdfe9aa33f94ded87d885b16d89942e667e4c47f1b2cd776294cd39b2e49ea3521b88d2d09f236b96fa388de114c114c7c03fb21ed32599f50ff8fe1c7e87688a52dfaf734878247d5c03697a8cc308c6f8fd09ae18dfb7ae6d8df97963716239ad36275fd42dc267a7b63527c4c1d287a502d404b0c0610cff0e118c0186ee23c018c68862c04c84127581d68d172718915f0b9244ed88fdd8d63d78bb83688d5fa6f63931981bef0dba4503e3e22bf288b59139384ea182cb66ca77e040841f5f42d444f5e4f32ea85e07c0f3f7bed62f3140eedea93ec1b5971033cacf02bda07742fc1e78084304c8b1dc487b27c4672fd0f9ee124b2c4893631e3e7b4177a45bb40ae3a04d84a7861b58a7351957a76be3995b9c214fa10f9b8edefbf258bf4ca239c4a362e22887bc8909dc1f61fc7d54473cb28ce755e7f5a9e9797d76b25c9d7d3eff04dcb34f7f8567e7fb3fbb554a77ba93a365de7c8a9e9e7fea85ea1cbc7aeb6ceb05fac4598913db7a827ed69bbc7851eed270fbfd8d0dbb89c380fecdeb57defb6d11a67166b7a176c83388d7106fa9d214aa7fb52e5087afda945359bd9543e98236b18482c4beada1e077b7748d35aee67d528974746185d91fda99dd9f0ab4f95aa627a20115f2fc5b797100cb557e0989fe01d4dd2b0549420e04f75790bc34b04e7eed81f50574d298e8e9028320da39b5cce19ea7c192aafffe68f5b635cf7f8437c021efac6b44676d8d77173adfc3145f23977a875fb1233b8b8600bdb073e93830496e8832437716a608b7bd3e9be1e83975688f64e6032f50bb24c289faad185ab925ea11926ba219a6724f9a58bd0bd71e3263b518aa67351fd1ca2a1bd695550a66c6291ba967341bd0ca673eaa37872fdba1fe3dbe0c76f82edfd0235187f217b3eda344777e3765947e037eda37a98dac213b04fab7860c76f8d690b1499a5fbd2cae6cf00e2a061378a3f1ea2756bbcd099ceddb1cb865ee9bf87ece009db95c2649e87899152822602c7ec1f34f7c38ab3d9891af460c8890851145f7e895475ac8da6c51a91ed015f42186d6a5937f959981c401ae2c46b220b70363c58daa60ac0a8cf0ccfd45a249341dc67412a08f201aeef51096cdc2438e1701bf554ac24cc32b8caebda421f65cc108224ab0551226c4d57110ca404947d89436094dc6358d6b56448dd7aadbf33617b6da77293cb1179d6cf19d357ac9fcb79d2866b3c4f6a09ccd223161401bd33b8482b2b78aa902880f97a129a8f062d2282873a9f6a2a0bcc40ea0a0bc483e9c82e64f54d3fd17deab43534ffea1bcff6bbd515c07d04d4e1e0353cddcf7247330990163593daf96b413be61c5e38cf0c9de670973754515a1e00b88eb6933896d550e2f530c964f336e9ecee238d26cde8d6d011175b009b0d2d31650f631510292ecb103734528b0913be68474802dc2768db0ecea10606b2a2463d73faad606ea3fbd8aba6df4782957566a836423466f8d1a8e4221c4b38f5fb8815074615d593026ae741767bab630b6190d026a717c35422a16d3bb940ad56c9792ca9febe2d16d2525c1fbd248a9584cef52623ada2e24854fd1c1abd84a44bc07d093b1158192f2b22afb26e33cbb95354cc69a34d8c93d88220fad6b69b1acc55ae439b1b39f16ddd345831c63ec248aacd192db92120e63b086422f214d38cdf21f692eee12d030d1cc0da461caab5973fc1724b9db57dec5e2222886d3df25ddcb5284d9452dfb306cea0d5959401da12cfa5edb77cd3c8be625031fc48a48ff2cf4d300e91d32fdec5a16691da4d66c8e55e585d6a1aa56732496e85987614de6182c95a08ec19acc315812661d83359963f029957528bec71c91cb93ac03721de678b5d4c73a5aadd91c8b4b7ee4d4b2de21e34dc6825948eebc647bd2a38bb764233bd79dfb1dcc9cf3a8bb5b7bf3f4dd18fd5c32d2b9c6400fb42df2d5d7cb16956f94cdb7490fa11376f140ad8b5bf768d5a314316ceefcd0c4b50fb66dbac74a87ad125f81dd77aa15613736d5c77523e6a54960b5be0e9729979fc6dda95c8f39a29084568714ba3a5ef945aa9974f1171d1be16924aa1e614e414e2eaba3cbbd1d1c2939cd8cf3a8e4ee0db0153c8b7de6a88a4cb43ab0a2db1cbb4a4b138fd001df5adad8c486d7561ebcdaeeded260ece63cece7daaba5f870ae69d5dc118b25f14860ac7d90baa48de06ca84b79c4723b5dd260e84f1d2e35863f741af379f4985cbe0b77b037e5fbe8f1ba69ec4ef5420adf88434aea65184708d74c58e8a4bdb4598aa5e4436cab10237957be2f7ef7733dca7e9df91ea4677831e21e206f05139c2779d9e7a34f427df4706a95c749e2fa8ad09354b0cc6fd61ef2343d2ad1d64ccc8e69595291307a05b1f30262a99674cb1ae0be70b9125f25282df2dda6aaa42f4eb902ddbe4055f5b76a2974c75694d76aa0bb634bd5b3f4779c15443cc6d0f1f27fe0d01d57514babe4f99497755fa5b37b3f04d41b72da5de5e74adb94be4adf2217be4ded7f65b32eb22f14f4b7acf9c8ba4dbe22eff794743c13815aff964b41faa9b46b0eae0cb42ed25caab7fffc964f3db2b2bbe5c23a1664b9c90ef3d5929db8c9a76ec1cdc635941fd7a0daef10c120362f445c86a1df4b15a21f12ceb274946e6c298b0c370553d410f600d58fd074f5811b81698b03dbef4293c5ab4b0737e2545b3798f9a05b560d9a9f44c5cc03de368a90c887f5f587753d49c5599b1abd5c7b6586b44569d506faf0c1aa927abb16154547bd611f52a1775e693494e2a22a6ff3b03545fb2c236af80efca7aa1e1a40bebb2201f7f03542fbd635ddc79b81175a74ab041a98b2b1b4ecc3d7fbec5bd9745f7706ae6c9daa7a06a66b87ba3f0fac69c657e8c16b74e47c61715b15c537fada9bfc0b1979d82f43b2edb90f59d4eb189697e45a2111e0bb5574f27fcaa0ce07d711abd4504bb01aa227aa4f4417094b2629d195463493edb656e64a342e968d6926ab29df68a2cd6e9646da6c4c336d4d51c4210a8b946509aa62af9613b2299ff2231512712b69a95b6bf3861b73753e52dd502f42e1ac479374f271ca847a11499fa6d3a12c48ce1f21b772ed1fe813cf20f1d61504fd77fa083adc7d5c8ea19f710bb740e0a818227eac8618b8e4b2be8cb1b7020e26dd34669dfd57992c18483f9e2ca17b8b1e521ca5982c19064b9f0ba551f7a2897e56fbc4f33c7988e85f491f4b206c7a34f4ff80bea49eef967cdf28a24d1a08eab7b00831dd4b9a1800d7ef25d25c2a89d10131f195eed6330c229f80250f68015ee126bc11f5bb836be0bc57b1451d48fb46f0629f5c79601d83206118d57cf227d1613778fbf9ff173f8a0247620000, '6.1.3-40302');

-- --------------------------------------------------------

--
-- Table structure for table `aspnetroles`
--

DROP TABLE IF EXISTS `aspnetroles`;
CREATE TABLE IF NOT EXISTS `aspnetroles` (
  `Id` varchar(128) CHARACTER SET utf8 NOT NULL,
  `Name` varchar(256) CHARACTER SET utf8 NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetuserclaims`
--

DROP TABLE IF EXISTS `aspnetuserclaims`;
CREATE TABLE IF NOT EXISTS `aspnetuserclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` varchar(128) CHARACTER SET utf8 NOT NULL,
  `ClaimType` longtext,
  `ClaimValue` longtext,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id` (`Id`),
  KEY `UserId` (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetuserlogins`
--

DROP TABLE IF EXISTS `aspnetuserlogins`;
CREATE TABLE IF NOT EXISTS `aspnetuserlogins` (
  `LoginProvider` varchar(128) CHARACTER SET utf8 NOT NULL,
  `ProviderKey` varchar(128) CHARACTER SET utf8 NOT NULL,
  `UserId` varchar(128) CHARACTER SET utf8 NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`,`UserId`),
  KEY `ApplicationUser_Logins` (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetuserroles`
--

DROP TABLE IF EXISTS `aspnetuserroles`;
CREATE TABLE IF NOT EXISTS `aspnetuserroles` (
  `UserId` varchar(128) CHARACTER SET utf8 NOT NULL,
  `RoleId` varchar(128) CHARACTER SET utf8 NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IdentityRole_Users` (`RoleId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetusers`
--

DROP TABLE IF EXISTS `aspnetusers`;
CREATE TABLE IF NOT EXISTS `aspnetusers` (
  `Id` varchar(128) CHARACTER SET utf8 NOT NULL,
  `Email` varchar(256) CHARACTER SET utf8 DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext,
  `SecurityStamp` longtext,
  `PhoneNumber` longtext,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEndDateUtc` datetime DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL,
  `UserName` varchar(256) CHARACTER SET utf8 NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `orders`
--

DROP TABLE IF EXISTS `orders`;
CREATE TABLE IF NOT EXISTS `orders` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Firstname` varchar(50) CHARACTER SET utf8 NOT NULL,
  `Lastname` varchar(50) CHARACTER SET utf8 NOT NULL,
  `Phone` varchar(18) CHARACTER SET utf8 NOT NULL,
  `Email` varchar(50) CHARACTER SET utf8 NOT NULL,
  `Brand` varchar(50) CHARACTER SET utf8 NOT NULL,
  `Registration` varchar(10) CHARACTER SET utf8 NOT NULL,
  `Maintenance` varchar(100) CHARACTER SET utf8 NOT NULL,
  `Checkdate` datetime NOT NULL,
  `Information` varchar(250) CHARACTER SET utf8 DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id` (`Id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=5 ;

--
-- Dumping data for table `orders`
--

INSERT INTO `orders` (`Id`, `Firstname`, `Lastname`, `Phone`, `Email`, `Brand`, `Registration`, `Maintenance`, `Checkdate`, `Information`) VALUES
(3, 'Марин', 'Иванов', '+(359) 888 123 123', 'k.ivanov@abv.bg', 'BMW E36', 'CA3446XM', 'Смяна на гуми и масло', '2025-03-10 23:29:50', 'Балансиране на гумите и изправяне на джантите');

--
-- Constraints for dumped tables
--

--
-- Constraints for table `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  ADD CONSTRAINT `ApplicationUser_Claims` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE ON UPDATE NO ACTION;

--
-- Constraints for table `aspnetuserlogins`
--
ALTER TABLE `aspnetuserlogins`
  ADD CONSTRAINT `ApplicationUser_Logins` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE ON UPDATE NO ACTION;

--
-- Constraints for table `aspnetuserroles`
--
ALTER TABLE `aspnetuserroles`
  ADD CONSTRAINT `ApplicationUser_Roles` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE ON UPDATE NO ACTION,
  ADD CONSTRAINT `IdentityRole_Users` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE ON UPDATE NO ACTION;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
