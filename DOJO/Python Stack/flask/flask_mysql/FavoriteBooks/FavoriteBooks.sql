-- MySQL Script generated by MySQL Workbench
-- Sat Jun 22 16:39:32 2019
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema FavoriteBooks
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema FavoriteBooks
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `FavoriteBooks` DEFAULT CHARACTER SET utf8 ;
USE `FavoriteBooks` ;

-- -----------------------------------------------------
-- Table `FavoriteBooks`.`users`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `FavoriteBooks`.`users` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `first_name` VARCHAR(255) NULL,
  `last_name` VARCHAR(255) NULL,
  `email` VARCHAR(255) NULL,
  `hashed_password` VARCHAR(255) NULL,
  `created_at` DATETIME NULL,
  `updated_at` DATETIME NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `FavoriteBooks`.`books`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `FavoriteBooks`.`books` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `title` VARCHAR(255) NOT NULL,
  `desc` TEXT NOT NULL,
  `created_at` DATETIME NOT NULL DEFAULT NOW(),
  `updated_at` DATETIME NOT NULL DEFAULT NOW() on update NOW(),
  `uploaded_by_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_books_uesrs1_idx` (`uploaded_by_id` ASC) VISIBLE,
  CONSTRAINT `fk_books_uesrs1`
    FOREIGN KEY (`uploaded_by_id`)
    REFERENCES `FavoriteBooks`.`users` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `FavoriteBooks`.`favorites`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `FavoriteBooks`.`favorites` (
  `book_id` INT NOT NULL,
  `user_id` INT NOT NULL,
  PRIMARY KEY (`book_id`, `user_id`),
  INDEX `fk_table2_uesrs1_idx` (`user_id` ASC) VISIBLE,
  CONSTRAINT `fk_table2_books`
    FOREIGN KEY (`book_id`)
    REFERENCES `FavoriteBooks`.`books` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_table2_uesrs1`
    FOREIGN KEY (`user_id`)
    REFERENCES `FavoriteBooks`.`users` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
