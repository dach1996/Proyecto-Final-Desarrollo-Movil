using Newtonsoft.Json;
using ProyectoFinalDM.INotifyProperty;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinalDM.Models
{
    public class UsuarioModel:Notificaciones
    {
        private int codUsuario;

        [JsonProperty(PropertyName= "cod_usuario")]
        public int CodUsuario
        {
            get { return codUsuario; }
            set { codUsuario = value;  this.OnPropertyChanged(); }
        }

        private string numeroCedula;

        [JsonProperty(PropertyName = "ced_usuario")]
        public string NumeroCedula
        {
            get { return numeroCedula; }
            set { numeroCedula = value; this.OnPropertyChanged(); }
        }
        private string nombreUsuario;

        [JsonProperty(PropertyName = "nombre_usuario")]
        public string NombreUsuario
        {
            get { return nombreUsuario; }
            set { nombreUsuario = value; this.OnPropertyChanged(); }
        }
        private string apellidoUsuario;

        [JsonProperty(PropertyName = "apellido_usuario")]
        public string ApellidoUsuario
        {
            get { return apellidoUsuario; }
            set { apellidoUsuario = value; this.OnPropertyChanged(); }
        }

        private string passwordUsuario;

        [JsonProperty(PropertyName = "password_usuario")]
        public string PasswordUsuario
        {
            get { return passwordUsuario; }
            set { passwordUsuario = value; this.OnPropertyChanged(); }
        }

        public string NombreCompleto
        {
            get
            {
                return $"{NombreUsuario} {ApellidoUsuario}";
            }
        }

        private DateTime? fechaNacimientoUsuario;

        [JsonProperty(PropertyName = "fecha_nacimiento_usuario")]
        public DateTime? FechaNacimientoUsuario
        {
            get { return fechaNacimientoUsuario; }
            set { fechaNacimientoUsuario = value; this.OnPropertyChanged(); }
        }

        private string fotoUsuario;

        [JsonProperty(PropertyName = "foto_usuario")]
        public string FotoUsuario
        {
            get { return fotoUsuario; }
            set { fotoUsuario = value; this.OnPropertyChanged(); }
        }

        private string usernameUsuario;

        [JsonProperty(PropertyName = "usuario_usuario")]
        public string UsernameUsuario
        {
            get { return usernameUsuario; }
            set { usernameUsuario = value; this.OnPropertyChanged(); }
        }

        private string correoUsuario;

        [JsonProperty(PropertyName = "correo_usuario")]
        public string CorreoUsuario
        {
            get { return correoUsuario; }
            set { correoUsuario = value; this.OnPropertyChanged(); }
        }

        public override bool Equals(object obj)
        {
            return obj is UsuarioModel model &&
                   codUsuario == model.codUsuario &&
                   CodUsuario == model.CodUsuario &&
                   numeroCedula == model.numeroCedula &&
                   NumeroCedula == model.NumeroCedula &&
                   nombreUsuario == model.nombreUsuario &&
                   NombreUsuario == model.NombreUsuario &&
                   apellidoUsuario == model.apellidoUsuario &&
                   ApellidoUsuario == model.ApellidoUsuario &&
                   passwordUsuario == model.passwordUsuario &&
                   PasswordUsuario == model.PasswordUsuario &&
                   fechaNacimientoUsuario == model.fechaNacimientoUsuario &&
                   FechaNacimientoUsuario == model.FechaNacimientoUsuario &&
                   fotoUsuario == model.fotoUsuario &&
                   FotoUsuario == model.FotoUsuario &&
                   usernameUsuario == model.usernameUsuario &&
                   UsernameUsuario == model.UsernameUsuario &&
                   correoUsuario == model.correoUsuario &&
                   CorreoUsuario == model.CorreoUsuario;
        }

        public override int GetHashCode()
        {
            int hashCode = -782014242;
            hashCode = hashCode * -1521134295 + codUsuario.GetHashCode();
            hashCode = hashCode * -1521134295 + CodUsuario.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(numeroCedula);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(NumeroCedula);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nombreUsuario);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(NombreUsuario);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(apellidoUsuario);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ApellidoUsuario);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(passwordUsuario);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(PasswordUsuario);
            hashCode = hashCode * -1521134295 + fechaNacimientoUsuario.GetHashCode();
            hashCode = hashCode * -1521134295 + FechaNacimientoUsuario.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(fotoUsuario);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FotoUsuario);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(usernameUsuario);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UsernameUsuario);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(correoUsuario);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CorreoUsuario);
            return hashCode;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
