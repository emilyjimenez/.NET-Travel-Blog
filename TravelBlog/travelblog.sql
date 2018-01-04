-- phpMyAdmin SQL Dump
-- version 4.6.5.2
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Jan 04, 2018 at 10:07 PM
-- Server version: 5.6.35
-- PHP Version: 7.0.15

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";

--
-- Database: `travelblog`
--

-- --------------------------------------------------------

--
-- Table structure for table `Experiences`
--

CREATE TABLE `Experiences` (
  `ExperienceId` int(11) NOT NULL,
  `Description` longtext,
  `LocationId` int(11) NOT NULL,
  `Name` longtext
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `Experiences`
--

INSERT INTO `Experiences` (`ExperienceId`, `Description`, `LocationId`, `Name`) VALUES
(1, 'A thjakdiohasdakjsdh oihad jdkhlhjngksdj;hddjs;gndzk\"SEFsgjnejnghdjgsndhc\r\n', 4, 'Soemthing'),
(4, 'It is a thing to do', 1, 'soemthing');

-- --------------------------------------------------------

--
-- Table structure for table `Locations`
--

CREATE TABLE `Locations` (
  `LocationId` int(11) NOT NULL,
  `Name` longtext
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `Locations`
--

INSERT INTO `Locations` (`LocationId`, `Name`) VALUES
(1, 'A place'),
(2, 'Somewhere else'),
(3, 'Pairs'),
(4, 'Space');

-- --------------------------------------------------------

--
-- Table structure for table `People`
--

CREATE TABLE `People` (
  `PersonId` int(11) NOT NULL,
  `LocationId` int(11) NOT NULL,
  `Name` longtext
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `People`
--

INSERT INTO `People` (`PersonId`, `LocationId`, `Name`) VALUES
(2, 4, 'SpaceKitty'),
(3, 3, 'Bleep'),
(5, 4, 'SPAAAAACE CAT'),
(6, 1, 'Billy'),
(7, 3, 'Bloop'),
(8, 3, 'Buzz'),
(9, 4, 'Marvin The Martian');

-- --------------------------------------------------------

--
-- Table structure for table `__EFMigrationsHistory`
--

CREATE TABLE `__EFMigrationsHistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `__EFMigrationsHistory`
--

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`) VALUES
('20180103215331_Initial', '1.1.2');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `Experiences`
--
ALTER TABLE `Experiences`
  ADD PRIMARY KEY (`ExperienceId`),
  ADD KEY `IX_Experiences_LocationId` (`LocationId`);

--
-- Indexes for table `Locations`
--
ALTER TABLE `Locations`
  ADD PRIMARY KEY (`LocationId`);

--
-- Indexes for table `People`
--
ALTER TABLE `People`
  ADD PRIMARY KEY (`PersonId`),
  ADD KEY `IX_People_LocationId` (`LocationId`);

--
-- Indexes for table `__EFMigrationsHistory`
--
ALTER TABLE `__EFMigrationsHistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `Experiences`
--
ALTER TABLE `Experiences`
  MODIFY `ExperienceId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT for table `Locations`
--
ALTER TABLE `Locations`
  MODIFY `LocationId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT for table `People`
--
ALTER TABLE `People`
  MODIFY `PersonId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;
--
-- Constraints for dumped tables
--

--
-- Constraints for table `Experiences`
--
ALTER TABLE `Experiences`
  ADD CONSTRAINT `FK_Experiences_Locations_LocationId` FOREIGN KEY (`LocationId`) REFERENCES `Locations` (`LocationId`) ON DELETE CASCADE;

--
-- Constraints for table `People`
--
ALTER TABLE `People`
  ADD CONSTRAINT `FK_People_Locations_LocationId` FOREIGN KEY (`LocationId`) REFERENCES `Locations` (`LocationId`) ON DELETE CASCADE;
