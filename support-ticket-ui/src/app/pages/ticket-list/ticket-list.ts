import { Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { TicketService } from '../../services/ticket';
import { Ticket } from '../../models/ticket';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-ticket-list',
  imports: [RouterLink, CommonModule],
  templateUrl: './ticket-list.html',
  styleUrl: './ticket-list.css',
})
export class TicketList implements OnInit {
  tickets: Ticket[] = [];

  constructor(
  private ticketService: TicketService,
  private authService: AuthService,
  private router: Router
  ) {}

  ngOnInit(): void {
    this.ticketService.getTickets().subscribe({
      next: (data) => {
        console.log('API response:', data);

        this.tickets = data.items;
        console.log('Tickets:', this.tickets);
      },
      error: (error) => {
        console.error('Error loading tickets', error);
      }
    });
  }

  logout(): void {
  this.authService.logout();
  this.router.navigate(['/login']);
  }

}