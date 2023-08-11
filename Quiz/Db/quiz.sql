-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gazdă: 127.0.0.1
-- Timp de generare: iun. 15, 2023 la 05:30 PM
-- Versiune server: 10.4.28-MariaDB
-- Versiune PHP: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Bază de date: `quiz`
--

-- --------------------------------------------------------

--
-- Structură tabel pentru tabel `asocmaterii`
--

CREATE TABLE `asocmaterii` (
  `id` int(10) UNSIGNED NOT NULL,
  `idProfesor` int(10) UNSIGNED NOT NULL,
  `idMaterie` int(10) UNSIGNED NOT NULL,
  `idSerie` int(10) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Eliminarea datelor din tabel `asocmaterii`
--

INSERT INTO `asocmaterii` (`id`, `idProfesor`, `idMaterie`, `idSerie`) VALUES
(1, 3, 1, 3),
(2, 7, 4, 3),
(3, 5, 5, 3),
(4, 4, 3, 3),
(5, 6, 2, 3),
(6, 6, 3, 3),
(7, 6, 2, 6),
(10, 18, 5, 5),
(11, 18, 2, 4),
(13, 18, 4, 5);

-- --------------------------------------------------------

--
-- Structură tabel pentru tabel `examen`
--

CREATE TABLE `examen` (
  `idExamen` int(10) UNSIGNED NOT NULL,
  `TS_Start` datetime NOT NULL DEFAULT current_timestamp(),
  `TS_Stop` datetime NOT NULL DEFAULT '2023-12-10 00:00:00',
  `denumireExamen` varchar(45) NOT NULL,
  `punctaj` int(11) NOT NULL,
  `codMaterie` int(10) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Eliminarea datelor din tabel `examen`
--

INSERT INTO `examen` (`idExamen`, `TS_Start`, `TS_Stop`, `denumireExamen`, `punctaj`, `codMaterie`) VALUES
(1, '2023-05-10 09:30:49', '2023-12-10 00:00:00', 'Partial', 30, 1),
(2, '2023-05-10 09:31:01', '2023-12-10 00:00:00', 'Partial', 30, 2),
(3, '2023-05-10 09:31:09', '2023-12-10 00:00:00', 'Partial', 30, 3),
(4, '2023-05-10 09:31:15', '2023-12-10 00:00:00', 'Final', 50, 4),
(5, '2023-05-10 09:31:21', '2023-12-10 00:00:00', 'Final', 50, 5),
(6, '2023-05-10 09:31:28', '2023-12-10 00:00:00', 'Final', 50, 1);

-- --------------------------------------------------------

--
-- Structură tabel pentru tabel `examenintrebari`
--

CREATE TABLE `examenintrebari` (
  `idEI` int(10) UNSIGNED NOT NULL,
  `codExamen` int(10) UNSIGNED NOT NULL,
  `codIntrebare` int(10) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Eliminarea datelor din tabel `examenintrebari`
--

INSERT INTO `examenintrebari` (`idEI`, `codExamen`, `codIntrebare`) VALUES
(1, 1, 1),
(2, 1, 2),
(3, 1, 3),
(4, 1, 4),
(5, 1, 5),
(6, 2, 9),
(7, 2, 10),
(8, 2, 11),
(9, 5, 15),
(10, 5, 16),
(11, 5, 17),
(12, 3, 6),
(13, 3, 7),
(14, 3, 8),
(15, 6, 3),
(16, 6, 1),
(17, 6, 5),
(18, 4, 12),
(19, 4, 13),
(20, 4, 14);

-- --------------------------------------------------------

--
-- Structură tabel pentru tabel `examenstudent`
--

CREATE TABLE `examenstudent` (
  `idES` int(10) UNSIGNED NOT NULL,
  `TS_Start` datetime NOT NULL DEFAULT current_timestamp(),
  `TS_Stop` datetime NOT NULL DEFAULT '2023-12-10 00:00:00',
  `codStudent` int(10) UNSIGNED NOT NULL,
  `codExamen` int(10) UNSIGNED NOT NULL,
  `punctaj` int(10) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Eliminarea datelor din tabel `examenstudent`
--

INSERT INTO `examenstudent` (`idES`, `TS_Start`, `TS_Stop`, `codStudent`, `codExamen`, `punctaj`) VALUES
(1, '2023-05-10 10:09:27', '2023-12-10 00:00:00', 1, 2, 25),
(2, '2023-05-10 10:09:27', '2023-12-10 00:00:00', 6, 2, 25),
(3, '2023-05-10 10:09:27', '2023-12-10 00:00:00', 4, 6, 30),
(4, '2023-05-10 10:09:27', '2023-12-10 00:00:00', 3, 1, 20),
(5, '2023-05-10 10:09:57', '2023-12-10 00:00:00', 1, 5, 30),
(6, '2023-05-10 10:09:57', '2023-12-10 00:00:00', 5, 5, 30);

-- --------------------------------------------------------

--
-- Structură tabel pentru tabel `intrebari`
--

CREATE TABLE `intrebari` (
  `idIntrebare` int(10) UNSIGNED NOT NULL,
  `codMaterie` int(10) UNSIGNED NOT NULL,
  `textIntrebare` varchar(2000) NOT NULL,
  `raspG1` varchar(2000) DEFAULT NULL,
  `raspG2` varchar(2000) DEFAULT NULL,
  `raspG3` varchar(2000) DEFAULT NULL,
  `raspG4` varchar(2000) DEFAULT NULL,
  `raspSA` varchar(2000) DEFAULT NULL,
  `raspCorect` int(10) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Eliminarea datelor din tabel `intrebari`
--

INSERT INTO `intrebari` (`idIntrebare`, `codMaterie`, `textIntrebare`, `raspG1`, `raspG2`, `raspG3`, `raspG4`, `raspSA`, `raspCorect`) VALUES
(1, 1, 'Intrebarea 1 CD', 'Corect', 'Fals', 'Fals', 'Fals', NULL, 1),
(2, 1, 'Intrebarea 2 CD', 'Fals', 'Corect', 'Fals', 'Fals', NULL, 2),
(3, 1, 'Intrebarea 3 CD', 'Fals', 'Fals', 'Fals', 'Corect', NULL, 4),
(4, 1, 'Intrebarea 4 CD', 'Fals', 'Fals', 'Corect', 'Fals', NULL, 3),
(5, 1, 'Intrebarea 5 CD', NULL, NULL, NULL, NULL, '10', 5),
(6, 3, 'Intrebarea 1 P1', 'Fals', 'Fals', 'Corect', 'Fals', NULL, 3),
(7, 3, 'Intrebarea 2 P1', 'Corect', 'Fals', 'Fals', 'Fals', NULL, 1),
(8, 3, 'Intrebarea 3 P1', NULL, NULL, NULL, NULL, '15', 5),
(9, 2, 'Intrebarea 1 P2', 'Fals', 'Corect', 'Fals', 'Fals', NULL, 2),
(10, 2, 'Intrebarea 2 P2', 'Corect', 'Fals', 'Fals', 'Fals', NULL, 1),
(11, 2, 'Intrebarea 3 P2', 'Fals', 'Fals', 'Fals', 'Corect', NULL, 4),
(12, 4, 'Intrebarea 1 SS', 'Fals', 'Fals', 'Corect', 'Fals', NULL, 3),
(13, 4, 'Intrebarea 2 SS', 'Corect', 'Fals', 'Fals', 'Fals', NULL, 1),
(14, 4, 'Intrebarea 3 SS', '', NULL, NULL, NULL, '45', 5),
(15, 5, 'Intrebarea 1 SECR', NULL, NULL, NULL, NULL, '10', 5),
(16, 5, 'Intrebarea 2 SECR', NULL, NULL, NULL, NULL, '100', 5),
(17, 5, 'Intrebarea 3 SECR', NULL, NULL, NULL, NULL, '2023', 5),
(18, 1, 'jdhas jdsahd jashd jas dhsajd hasjdh sajd hasjdh asjdhsajd hasjdhsajdhsajdh sadjhasjdhasdjh', 'sjh djjashd jasd hsa sa sad sa dsa das das fsa fgsa fsa', 'gd d adsf asf sa fsad asd sa dsa', 's dsa d as das d as das d as d asd as  ga sgasfa f sa ', 's dsa d as das d as das d as d asd as  ga sgasfa f sa ', NULL, 3);

-- --------------------------------------------------------

--
-- Structură tabel pentru tabel `materie`
--

CREATE TABLE `materie` (
  `idMaterie` int(10) UNSIGNED NOT NULL,
  `numeMaterie` varchar(45) NOT NULL,
  `codProfesor` int(10) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Eliminarea datelor din tabel `materie`
--

INSERT INTO `materie` (`idMaterie`, `numeMaterie`, `codProfesor`) VALUES
(1, 'Comunicații de date', 3),
(2, 'Proiect 2', 6),
(3, 'Proiect 1', 4),
(4, 'Semnale si sisteme', 7),
(5, 'Sisteme şi echipamente de comunicaţii radio', 5);

-- --------------------------------------------------------

--
-- Structură tabel pentru tabel `materiestudenti`
--

CREATE TABLE `materiestudenti` (
  `idMS` int(10) UNSIGNED NOT NULL,
  `codStudent` int(10) UNSIGNED NOT NULL,
  `codMaterie` int(10) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Eliminarea datelor din tabel `materiestudenti`
--

INSERT INTO `materiestudenti` (`idMS`, `codStudent`, `codMaterie`) VALUES
(1, 5, 3),
(2, 5, 4),
(3, 1, 5),
(4, 4, 2),
(5, 6, 1),
(6, 3, 3),
(7, 3, 1),
(8, 1, 2),
(9, 4, 4),
(10, 6, 5);

-- --------------------------------------------------------

--
-- Structură tabel pentru tabel `materii`
--

CREATE TABLE `materii` (
  `idMaterie` int(10) UNSIGNED NOT NULL,
  `numeMaterie` varchar(256) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Eliminarea datelor din tabel `materii`
--

INSERT INTO `materii` (`idMaterie`, `numeMaterie`) VALUES
(1, 'Comunicatii de date'),
(2, 'Proiect 2'),
(3, 'Proiect 1'),
(4, 'Semnale si sisteme'),
(5, 'Sisteme si echipamente de comunicatii radio');

-- --------------------------------------------------------

--
-- Structură tabel pentru tabel `profesori`
--

CREATE TABLE `profesori` (
  `idProfesor` int(10) UNSIGNED NOT NULL,
  `numeProfesor` varchar(45) NOT NULL,
  `email` varchar(45) NOT NULL,
  `parola` varchar(256) NOT NULL,
  `statut` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Eliminarea datelor din tabel `profesori`
--

INSERT INTO `profesori` (`idProfesor`, `numeProfesor`, `email`, `parola`, `statut`) VALUES
(3, 'Florea Carmen', 'floreacarmen@gmail.com', '410ebea413f55e93b4121071ed083bf064869f8fae933024ed57f3ab6fcff1c8', ''),
(4, 'Mircea Voda', 'mirceavoda@yahoo.com', '9f02b390e5300206d18d563d90659ad28063ada8236871ac6aad6c2bdf6c8fc9', ''),
(5, 'Martian Alexandru', 'martianalexandru@yahoo.com', '7a333ffe9267115bbb1e78341374b9d9f60ec6fbb9c870865d396476cfc121e3', ''),
(6, 'Paun Adrian', 'paunadrian@yahoo.com', '4702c0dba958410b99fd0481513ea1e60f0b837ebb1a05c19f9d58aec7bac667', ''),
(7, 'Halunga Simona', 'halungasimona@yahoo.com', 'b51d2a614152c5bae531e0902bd30a2d146facd7764cb9495f7345378940b1f2', ''),
(8, 'admin', 'admin@admin.admin', '713bfda78870bf9d1b261f565286f85e97ee614efe5f0faf7c34e7ca4f65baca', 'admin'),
(18, 'test', 'test', '9f86d081884c7d659a2feaa0c55ad015a3bf4f1b2b0b822cd15d6c15b0f00a08', NULL);

-- --------------------------------------------------------

--
-- Structură tabel pentru tabel `raspunsstudent`
--

CREATE TABLE `raspunsstudent` (
  `idRS` int(10) UNSIGNED NOT NULL,
  `codExamenStudent` int(10) UNSIGNED NOT NULL,
  `codIntrebare` int(10) UNSIGNED NOT NULL,
  `raspuns` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Structură tabel pentru tabel `serii`
--

CREATE TABLE `serii` (
  `idSerie` int(10) UNSIGNED NOT NULL,
  `serie` varchar(256) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Eliminarea datelor din tabel `serii`
--

INSERT INTO `serii` (`idSerie`, `serie`) VALUES
(1, 'A'),
(2, 'B'),
(3, 'C'),
(4, 'D'),
(5, 'E'),
(6, 'F'),
(7, 'G');

-- --------------------------------------------------------

--
-- Structură tabel pentru tabel `studenti`
--

CREATE TABLE `studenti` (
  `idStudent` int(10) UNSIGNED NOT NULL,
  `numeStudent` varchar(45) NOT NULL,
  `grupa` varchar(10) NOT NULL,
  `serie` varchar(10) NOT NULL,
  `email` varchar(45) NOT NULL,
  `parola` varchar(256) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Eliminarea datelor din tabel `studenti`
--

INSERT INTO `studenti` (`idStudent`, `numeStudent`, `grupa`, `serie`, `email`, `parola`) VALUES
(1, 'Jianu Teodora', '442', 'C', 'teodorajianu@outlook.com', '2ed011bb5ac54b758e4d33cc8bd1b48303ced8f2785dae60d77b3929029fcc26'),
(3, 'Raileanu Alexandru', '442', 'C', 'raileanualexandru@outlook.com', '68a8083130c0d84e3d7db75415eb04ee39b9ea736987a0c123e2982bded8d4a5'),
(4, 'Petcu Gabriela', '443', 'D', 'petcugabriela@outlook.com', '9841fe3d4de7cda2c7f70e6da53f8ac7f0d081ede20ef0a9d6d323f9673e2b3b'),
(5, 'Androne Ionut', '321', 'E', 'androneionut@gmail.com', '4283461ad55ff4d9e5901f4084d69f9a7f0cbcae2b92efcce0dfc0f1f5c1e061'),
(6, 'Damian Dorina', '442', 'C', 'damiandorina@yahoo.com', 'dc06545d711bb49ed762c5f7b6e544737b127a8d1be725c004c36f407d25fdc0');

--
-- Indexuri pentru tabele eliminate
--

--
-- Indexuri pentru tabele `asocmaterii`
--
ALTER TABLE `asocmaterii`
  ADD PRIMARY KEY (`id`),
  ADD KEY `FK1` (`idProfesor`),
  ADD KEY `FK2` (`idMaterie`),
  ADD KEY `FK3` (`idSerie`);

--
-- Indexuri pentru tabele `examen`
--
ALTER TABLE `examen`
  ADD PRIMARY KEY (`idExamen`),
  ADD KEY `exMat_fk` (`codMaterie`);

--
-- Indexuri pentru tabele `examenintrebari`
--
ALTER TABLE `examenintrebari`
  ADD PRIMARY KEY (`idEI`),
  ADD KEY `EIexam_fk` (`codExamen`),
  ADD KEY `EIintreb_fk` (`codIntrebare`);

--
-- Indexuri pentru tabele `examenstudent`
--
ALTER TABLE `examenstudent`
  ADD PRIMARY KEY (`idES`),
  ADD KEY `ESexam_fk` (`codExamen`),
  ADD KEY `ESstudent_fk` (`codStudent`);

--
-- Indexuri pentru tabele `intrebari`
--
ALTER TABLE `intrebari`
  ADD PRIMARY KEY (`idIntrebare`),
  ADD KEY `intrebMat_fk` (`codMaterie`);

--
-- Indexuri pentru tabele `materie`
--
ALTER TABLE `materie`
  ADD PRIMARY KEY (`idMaterie`),
  ADD KEY `matProf_fk` (`codProfesor`);

--
-- Indexuri pentru tabele `materiestudenti`
--
ALTER TABLE `materiestudenti`
  ADD PRIMARY KEY (`idMS`),
  ADD KEY `MSstud_fk` (`codStudent`),
  ADD KEY `MSmaterie_fk` (`codMaterie`);

--
-- Indexuri pentru tabele `materii`
--
ALTER TABLE `materii`
  ADD PRIMARY KEY (`idMaterie`);

--
-- Indexuri pentru tabele `profesori`
--
ALTER TABLE `profesori`
  ADD PRIMARY KEY (`idProfesor`);

--
-- Indexuri pentru tabele `raspunsstudent`
--
ALTER TABLE `raspunsstudent`
  ADD PRIMARY KEY (`idRS`),
  ADD KEY `RSes_fk` (`codExamenStudent`),
  ADD KEY `RSintreb_fk` (`codIntrebare`);

--
-- Indexuri pentru tabele `serii`
--
ALTER TABLE `serii`
  ADD PRIMARY KEY (`idSerie`);

--
-- Indexuri pentru tabele `studenti`
--
ALTER TABLE `studenti`
  ADD PRIMARY KEY (`idStudent`);

--
-- AUTO_INCREMENT pentru tabele eliminate
--

--
-- AUTO_INCREMENT pentru tabele `asocmaterii`
--
ALTER TABLE `asocmaterii`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT pentru tabele `examen`
--
ALTER TABLE `examen`
  MODIFY `idExamen` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT pentru tabele `examenintrebari`
--
ALTER TABLE `examenintrebari`
  MODIFY `idEI` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=36;

--
-- AUTO_INCREMENT pentru tabele `examenstudent`
--
ALTER TABLE `examenstudent`
  MODIFY `idES` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT pentru tabele `intrebari`
--
ALTER TABLE `intrebari`
  MODIFY `idIntrebare` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=24;

--
-- AUTO_INCREMENT pentru tabele `materie`
--
ALTER TABLE `materie`
  MODIFY `idMaterie` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT pentru tabele `materiestudenti`
--
ALTER TABLE `materiestudenti`
  MODIFY `idMS` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT pentru tabele `materii`
--
ALTER TABLE `materii`
  MODIFY `idMaterie` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT pentru tabele `profesori`
--
ALTER TABLE `profesori`
  MODIFY `idProfesor` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT pentru tabele `raspunsstudent`
--
ALTER TABLE `raspunsstudent`
  MODIFY `idRS` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pentru tabele `serii`
--
ALTER TABLE `serii`
  MODIFY `idSerie` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT pentru tabele `studenti`
--
ALTER TABLE `studenti`
  MODIFY `idStudent` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- Constrângeri pentru tabele eliminate
--

--
-- Constrângeri pentru tabele `asocmaterii`
--
ALTER TABLE `asocmaterii`
  ADD CONSTRAINT `FK1` FOREIGN KEY (`idProfesor`) REFERENCES `profesori` (`idProfesor`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `FK2` FOREIGN KEY (`idMaterie`) REFERENCES `materii` (`idMaterie`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `FK3` FOREIGN KEY (`idSerie`) REFERENCES `serii` (`idSerie`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constrângeri pentru tabele `examen`
--
ALTER TABLE `examen`
  ADD CONSTRAINT `exMat_fk` FOREIGN KEY (`codMaterie`) REFERENCES `materie` (`idMaterie`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constrângeri pentru tabele `examenintrebari`
--
ALTER TABLE `examenintrebari`
  ADD CONSTRAINT `EIexam_fk` FOREIGN KEY (`codExamen`) REFERENCES `examen` (`idExamen`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `EIintreb_fk` FOREIGN KEY (`codIntrebare`) REFERENCES `intrebari` (`idIntrebare`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constrângeri pentru tabele `examenstudent`
--
ALTER TABLE `examenstudent`
  ADD CONSTRAINT `ESexam_fk` FOREIGN KEY (`codExamen`) REFERENCES `examen` (`idExamen`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `ESstudent_fk` FOREIGN KEY (`codStudent`) REFERENCES `studenti` (`idStudent`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constrângeri pentru tabele `intrebari`
--
ALTER TABLE `intrebari`
  ADD CONSTRAINT `intrebMat_fk` FOREIGN KEY (`codMaterie`) REFERENCES `materie` (`idMaterie`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constrângeri pentru tabele `materie`
--
ALTER TABLE `materie`
  ADD CONSTRAINT `matProf_fk` FOREIGN KEY (`codProfesor`) REFERENCES `profesori` (`idProfesor`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constrângeri pentru tabele `materiestudenti`
--
ALTER TABLE `materiestudenti`
  ADD CONSTRAINT `MSmaterie_fk` FOREIGN KEY (`codMaterie`) REFERENCES `materie` (`idMaterie`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `MSstud_fk` FOREIGN KEY (`codStudent`) REFERENCES `studenti` (`idStudent`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constrângeri pentru tabele `raspunsstudent`
--
ALTER TABLE `raspunsstudent`
  ADD CONSTRAINT `RSes_fk` FOREIGN KEY (`codExamenStudent`) REFERENCES `examenstudent` (`idES`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `RSintreb_fk` FOREIGN KEY (`codIntrebare`) REFERENCES `intrebari` (`idIntrebare`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
