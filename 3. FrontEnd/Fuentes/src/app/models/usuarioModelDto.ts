export interface UsuarioModelDto {
  idUsuario: string
  usuario: string
  nombreUsuario: string
  rol: number,
  estado: boolean,
  token: string
  fechaCreacion: string
}

export interface ResponseLoginDto {
  codigo: string
  usuario: UsuarioModelDto
}