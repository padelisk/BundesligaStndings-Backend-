CREATE DATABASE IF NOT EXISTS bundesliga;
USE bundesliga;

CREATE TABLE IF NOT EXISTS users (
    id            INT AUTO_INCREMENT PRIMARY KEY,
    first_name    VARCHAR(45)  NOT NULL,
    last_name     VARCHAR(45)  NOT NULL,
    email         VARCHAR(45)  NOT NULL UNIQUE,
    password_hash VARCHAR(255) NOT NULL,
    fav_team_id   INT          NOT NULL
);