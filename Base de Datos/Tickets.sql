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