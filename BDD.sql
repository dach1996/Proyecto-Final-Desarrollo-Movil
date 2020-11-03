CREATE DATABASE  tickets;
go
USE tickets;
go
-----------------------------------------------------------------------------------------
DROP TABLE IF EXISTS categorias;
CREATE TABLE categorias (
  cod_categoria int NOT NULL IDENTITY,
  nomb_categoria varchar(25) DEFAULT NULL,
  PRIMARY KEY (cod_categoria)
)  ;
-----------------------------------------------------------------------------------------
DROP TABLE IF EXISTS clientes;
CREATE TABLE clientes (
  cod_cliente int NOT NULL IDENTITY,
  nomb_cliente varchar(30) NOT NULL,
  image_cliente varchar(200) not null,
  usu_cliente varchar(30) NOT NULL,
  pass_cliente varchar(30) NOT NULL,
  PRIMARY KEY (cod_cliente)
) ;
-----------------------------------------------------------------------------------------
DROP TABLE IF EXISTS usuarios;
CREATE TABLE usuarios (
  cod_usuario int NOT NULL IDENTITY,
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
-----------------------------------------------------------------------------------------
DROP TABLE IF EXISTS tickets;
CREATE TABLE tickets(
  cod_ticket int NOT NULL IDENTITY,
  local_ticket varchar(100) DEFAULT NULL,
  titulo_ticket varchar(200) DEFAULT NULL,
  prioridad_ticket varchar(40) Default null,
  fecha_inicio_ticket date  DEFAULT GETDATE() NULL,
  fecha_fin_ticket date DEFAULT NULL,
  estado_ticket varchar(30) DEFAULT NULL,
  completador_ticket varchar(45) DEFAULT null,
  cod_usuario int NOT NULL,
  cod_cliente int NOT NULL,
  cod_categoria int NOT NULL,
  PRIMARY KEY (cod_ticket),
  CONSTRAINT ticket_usuario FOREIGN KEY (cod_usuario) REFERENCES usuarios (cod_usuario) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT ticket_cliente FOREIGN KEY (cod_cliente) REFERENCES clientes (cod_cliente) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT ticket_categoria FOREIGN KEY (cod_categoria) REFERENCES categorias (cod_categoria) ON DELETE CASCADE ON UPDATE CASCADE,
  );
-----------------------------------------------------------------------------------------
DROP TABLE IF EXISTS detalles_ticket;
CREATE TABLE detalles_ticket(
  cod_detalle int NOT NULL IDENTITY,
  texto_detalle varchar(200) DEFAULT NULL,
  fecha_detalle datetime DEFAULT  getDate(),
  cod_ticket int NOT NULL,
  cod_usuario int NOT NULL,
  PRIMARY KEY (cod_detalle),
  CONSTRAINT detalle_usuario FOREIGN KEY (cod_usuario) REFERENCES usuarios (cod_usuario) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT detalle_ticket FOREIGN KEY (cod_ticket) REFERENCES tickets (cod_ticket),
  );


/*DROP TABLE IF EXISTS responsables;
CREATE TABLE responsables (
  cod_ticket int NOT NULL,
  ced_usuario varchar(10) NOT NULL,
 
  CONSTRAINT fk_responsables_tickets FOREIGN KEY (cod_ticket) REFERENCES ticket (cod_ticket) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT fk_responsables_usuarios FOREIGN KEY (ced_usuario) REFERENCES usuario (ced_usuario) ON DELETE CASCADE ON UPDATE CASCADE
)  ;

CREATE INDEX ced_usuario ON responsables (ced_usuario,cod_ticket);
CREATE INDEX cod_ticket ON responsables (cod_ticket);

DROP TABLE IF EXISTS ticket;*/

/*DROP TABLE IF EXISTS registros;
CREATE TABLE registros (
  id_Registros int NOT NULL IDENTITY,
  fecha_Registros date DEFAULT NULL,
  hora_Registros time(0) DEFAULT NULL,
  cliente_Registros varchar(100) DEFAULT NULL,
  local_Registros varchar(100) DEFAULT NULL,
  sensor_Registros varchar(100) DEFAULT NULL,
  traf_anterior_Registros int DEFAULT NULL,
  traf_despues_Registros int DEFAULT NULL,
  usuario_Registros varchar(100) DEFAULT NULL,
  fecha_cambio_Registros datetime2(0) DEFAULT NULL,
  PRIMARY KEY (id_Registros)
)  ;*/

