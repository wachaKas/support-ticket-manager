import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';

import { AuthService, LoginRequest } from '../../services/auth';

@Component({
  selector: 'app-login',
 imports: [FormsModule, CommonModule],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {
  loginRequest: LoginRequest = {
    email: '',
    password: ''
  };

  errorMessage = '';

  constructor(
    private authService: AuthService,
    private router: Router
  ) {}

  login(): void {
    console.log('Sending login request:', this.loginRequest);

    this.authService.login(this.loginRequest).subscribe({
      next: (response) => {
        console.log('Login success:', response);

        this.authService.saveToken(response.token);
        this.router.navigate(['/']);
      },
      error: (err) => {
        console.error('Login error:', err);
        this.errorMessage = 'Invalid email or password';
      }
    });
  }
}