import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { UsuarioComponent } from './components/usuario/usuario.component';

@Component({
  selector: 'app-root',
  imports: [UsuarioComponent, RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'SixDegrees.PruebaSD.Angular';
}

