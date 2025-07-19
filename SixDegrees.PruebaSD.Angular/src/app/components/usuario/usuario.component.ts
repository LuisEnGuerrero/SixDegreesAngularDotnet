import { Component, OnInit } from '@angular/core';
import { UsuarioService, Usuario } from '../../services/usuario.service';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-usuario',
  imports: [CommonModule, FormsModule, HttpClientModule],
  templateUrl: './usuario.component.html',
  styleUrl: './usuario.component.css'
})

export class UsuarioComponent implements OnInit {
  usuarios: Usuario[] = [];
  searchId: number = 0;

  constructor(private usuarioService: UsuarioService) {}

  ngOnInit(): void {
    this.usuarioService.getAllUsuarios().subscribe(data => {
      this.usuarios = data;
    });
  }

  buscarPorId(): void {
    if (this.searchId <= 0) return;

    this.usuarioService.getUsuarioById(this.searchId).subscribe(usuario => {
      this.usuarios = usuario ? [usuario] : [];
    });
  }

  mostrarTodos(): void {
    this.usuarioService.getAllUsuarios().subscribe(data => {
      this.usuarios = data;
      this.searchId = 0;
    });
  }
}