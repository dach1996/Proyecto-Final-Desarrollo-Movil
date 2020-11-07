CREATE DATABASE  ticketsXamarin;
 
USE ticketsXamarin;
 
  --  SQLINES DEMO *** ---------------------------------------------------------------------
DROP TABLE IF EXISTS locales;
CREATE TABLE locales (
  cod_local int NOT NULL AUTO_INCREMENT,
  nomb_local varchar(25) DEFAULT NULL,
  PRIMARY KEY (cod_local)
)  ;
--  SQLINES DEMO *** ---------------------------------------------------------------------
DROP TABLE IF EXISTS categorias;
CREATE TABLE categorias (
  cod_categoria int NOT NULL AUTO_INCREMENT,
  nomb_categoria varchar(25) DEFAULT NULL,
  PRIMARY KEY (cod_categoria)
)  ;
--  SQLINES DEMO *** ---------------------------------------------------------------------
DROP TABLE IF EXISTS clientes;
CREATE TABLE clientes (
  cod_cliente int NOT NULL AUTO_INCREMENT,
  nomb_cliente varchar(30) NOT NULL,
  image_cliente varchar(200) not null,
  usu_cliente varchar(30) NOT NULL,
  pass_cliente varchar(30) NOT NULL,
  PRIMARY KEY (cod_cliente)
) ;
--  SQLINES DEMO *** ---------------------------------------------------------------------
DROP TABLE IF EXISTS usuarios;
CREATE TABLE usuarios (
  cod_usuario int NOT NULL AUTO_INCREMENT,
  ced_usuario varchar(10) NOT NULL,
  nombre_usuario varchar(20) DEFAULT NULL,
  apellido_usuario varchar(20) DEFAULT NULL,
  password_usuario varchar(20) DEFAULT NULL,
  fecha_nacimiento_usuario date DEFAULT NULL,
  foto_usuario varchar(200),
  usuario_usuario varchar(20) DEFAULT NULL,
  correo_usuario varchar(100) DEFAULT NULL,
  PRIMARY KEY (cod_usuario)
)  ;
--  SQLINES DEMO *** ---------------------------------------------------------------------
DROP TABLE IF EXISTS tickets;
CREATE TABLE tickets(
  cod_ticket int NOT NULL AUTO_INCREMENT,
  cod_local int NOT NULL,
  titulo_ticket varchar(200) DEFAULT NULL,
  fecha_inicio_ticket TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  fecha_fin_ticket TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  estado_ticket varchar(30) DEFAULT NULL,
  prioridad_ticket varchar(40) Default null,  
  completador_ticket varchar(45) DEFAULT null,
  cod_usuario int NOT NULL,
  cod_cliente int NOT NULL,
  cod_categoria int NOT NULL,
  PRIMARY KEY (cod_ticket),
  CONSTRAINT ticket_locales FOREIGN KEY (cod_local) REFERENCES locales (cod_local) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT ticket_usuario FOREIGN KEY (cod_usuario) REFERENCES usuarios (cod_usuario) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT ticket_cliente FOREIGN KEY (cod_cliente) REFERENCES clientes (cod_cliente) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT ticket_categoria FOREIGN KEY (cod_categoria) REFERENCES categorias (cod_categoria) ON DELETE CASCADE ON UPDATE CASCADE
  );
--  SQLINES DEMO *** ---------------------------------------------------------------------
DROP TABLE IF EXISTS detalles_ticket;
CREATE TABLE detalles_ticket(
  cod_detalle int NOT NULL AUTO_INCREMENT,
  texto_detalle varchar(200) DEFAULT NULL,
  fecha_detalle TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  cod_ticket int NOT NULL,
  cod_usuario int NOT NULL,
  PRIMARY KEY (cod_detalle),
  CONSTRAINT detalle_usuario FOREIGN KEY (cod_usuario) REFERENCES usuarios (cod_usuario) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT detalle_ticket FOREIGN KEY (cod_ticket) REFERENCES tickets (cod_ticket) ON DELETE CASCADE ON UPDATE CASCADE
  );

INSERT INTO `ticketsxamarin`.`categorias` (`nomb_categoria`) VALUES ('Revisar');
INSERT INTO `ticketsxamarin`.`categorias` (`nomb_categoria`) VALUES ('Instalar');
INSERT INTO `ticketsxamarin`.`categorias` (`nomb_categoria`) VALUES ('Buscar');
INSERT INTO `ticketsxamarin`.`categorias` (`nomb_categoria`) VALUES ('Seguimiento');
INSERT INTO `ticketsxamarin`.`categorias` (`nomb_categoria`) VALUES ('Desinstalacion');

INSERT INTO `ticketsxamarin`.`clientes` (`nomb_cliente`, `image_cliente`, `usu_cliente`, `pass_cliente`) VALUES ('Taty', 'null', 'taty', '12345');
INSERT INTO `ticketsxamarin`.`clientes` (`nomb_cliente`, `image_cliente`, `usu_cliente`, `pass_cliente`) VALUES ('Crocs', 'null', 'crocs', '12345');
INSERT INTO `ticketsxamarin`.`clientes` (`nomb_cliente`, `image_cliente`, `usu_cliente`, `pass_cliente`) VALUES ('Supermaxi', 'null', 'supermaxi', '12345');
INSERT INTO `ticketsxamarin`.`clientes` (`nomb_cliente`, `image_cliente`, `usu_cliente`, `pass_cliente`) VALUES ('Banda', 'null', 'banda', '12345');
INSERT INTO `ticketsxamarin`.`clientes` (`nomb_cliente`, `image_cliente`, `usu_cliente`, `pass_cliente`) VALUES ('Fybeca', 'null', 'fybeca', '12345');

INSERT INTO `ticketsxamarin`.`locales` (`nomb_local`) VALUES ('Bosque');
INSERT INTO `ticketsxamarin`.`locales` (`nomb_local`) VALUES ('CCI');
INSERT INTO `ticketsxamarin`.`locales` (`nomb_local`) VALUES ('San Marino');
INSERT INTO `ticketsxamarin`.`locales` (`nomb_local`) VALUES ('Portoviejo');
INSERT INTO `ticketsxamarin`.`locales` (`nomb_local`) VALUES ('Quicentro');

INSERT INTO `ticketsxamarin`.`usuarios` (`ced_usuario`, `nombre_usuario`, `apellido_usuario`, `password_usuario`, `usuario_usuario`) VALUES ('1716361444', 'Danny', 'Cárdenas', '12345', 'danny');
INSERT INTO `ticketsxamarin`.`usuarios` (`ced_usuario`, `nombre_usuario`, `apellido_usuario`, `password_usuario`, `usuario_usuario`) VALUES ('1716361477', 'Adrian', 'Guadalupe', '12345', 'adrian');
INSERT INTO `ticketsxamarin`.`usuarios` (`ced_usuario`, `nombre_usuario`, `apellido_usuario`, `password_usuario`, `usuario_usuario`) VALUES ('1716361477', 'Bryan', 'Vergara', '12345', 'bryan');
INSERT INTO `ticketsxamarin`.`usuarios` (`ced_usuario`, `nombre_usuario`, `apellido_usuario`, `password_usuario`, `usuario_usuario`) VALUES ('1716361488', 'Pablo', 'Salazar', '12345', 'pablo');

INSERT INTO `ticketsxamarin`.`tickets` (`cod_local`, `titulo_ticket`, `estado_ticket`, `prioridad_ticket`, `cod_usuario`, `cod_cliente`, `cod_categoria`) VALUES ('1', 'Revisar Sensor', 'Ingresado', 'Alta', '1', '1', '1');
INSERT INTO `ticketsxamarin`.`tickets` (`cod_local`, `titulo_ticket`, `estado_ticket`, `prioridad_ticket`, `cod_usuario`, `cod_cliente`, `cod_categoria`) VALUES ('2', 'Corregir Mancha', 'Ingresado', 'Baja', '2', '2', '2');
INSERT INTO `ticketsxamarin`.`tickets` (`cod_local`, `titulo_ticket`, `estado_ticket`, `prioridad_ticket`, `cod_usuario`, `cod_cliente`, `cod_categoria`) VALUES ('3', 'Ver datos', 'Ingresado', 'Media', '3', '3', '3');
INSERT INTO `ticketsxamarin`.`tickets` (`cod_local`, `titulo_ticket`, `estado_ticket`, `prioridad_ticket`, `cod_usuario`, `cod_cliente`, `cod_categoria`) VALUES ('4', 'Desinstalar Local', 'Ingresado', 'Alta', '4', '4', '4');


