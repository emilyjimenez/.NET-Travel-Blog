

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";



CREATE TABLE `Experiences` (
  `ExperienceId` int(11) NOT NULL,
  `Description` longtext,
  `LocationId` int(11) NOT NULL,
  `Name` longtext
) ENGINE=InnoDB DEFAULT CHARSET=utf8;



INSERT INTO `Experiences` (`ExperienceId`, `Description`, `LocationId`, `Name`) VALUES
(1, 'A thjakdiohasdakjsdh oihad jdkhlhjngksdj;hddjs;gndzk\"SEFsgjnejnghdjgsndhc\r\n', 4, 'Soemthing'),
(4, 'It is a thing to do', 1, 'soemthing');



CREATE TABLE `Locations` (
  `LocationId` int(11) NOT NULL,
  `Name` longtext
) ENGINE=InnoDB DEFAULT CHARSET=utf8;



INSERT INTO `Locations` (`LocationId`, `Name`) VALUES
(1, 'A place'),
(2, 'Somewhere else'),
(3, 'Pairs'),
(4, 'Space');



CREATE TABLE `People` (
  `PersonId` int(11) NOT NULL,
  `LocationId` int(11) NOT NULL,
  `Name` longtext
) ENGINE=InnoDB DEFAULT CHARSET=utf8;



INSERT INTO `People` (`PersonId`, `LocationId`, `Name`) VALUES
(2, 4, 'SpaceKitty'),
(3, 3, 'Bleep'),
(5, 4, 'SPAAAAACE CAT'),
(6, 1, 'Billy'),
(7, 3, 'Bloop'),
(8, 3, 'Buzz'),
(9, 4, 'Marvin The Martian');



CREATE TABLE `__EFMigrationsHistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;



INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`) VALUES
('20180103215331_Initial', '1.1.2');


ALTER TABLE `Experiences`
  ADD PRIMARY KEY (`ExperienceId`),
  ADD KEY `IX_Experiences_LocationId` (`LocationId`);


ALTER TABLE `Locations`
  ADD PRIMARY KEY (`LocationId`);


ALTER TABLE `People`
  ADD PRIMARY KEY (`PersonId`),
  ADD KEY `IX_People_LocationId` (`LocationId`);


ALTER TABLE `__EFMigrationsHistory`
  ADD PRIMARY KEY (`MigrationId`);


ALTER TABLE `Experiences`
  MODIFY `ExperienceId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;


ALTER TABLE `Locations`
  MODIFY `LocationId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;


ALTER TABLE `People`
  MODIFY `PersonId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

ALTER TABLE `Experiences`
  ADD CONSTRAINT `FK_Experiences_Locations_LocationId` FOREIGN KEY (`LocationId`) REFERENCES `Locations` (`LocationId`) ON DELETE CASCADE;


ALTER TABLE `People`
  ADD CONSTRAINT `FK_People_Locations_LocationId` FOREIGN KEY (`LocationId`) REFERENCES `Locations` (`LocationId`) ON DELETE CASCADE;
