CREATE TABLE `miniproject`.`smarthome_sensor` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `Home_Id` VARCHAR(20) NOT NULL,
  `Room_Name` VARCHAR(20) NOT NULL,
  `Sensing_DateTime` DATETIME NOT NULL,
  `Temp` FLOAT NOT NULL,
  `Humid` FLOAT NOT NULL,
  PRIMARY KEY (`id`));