import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

import { TicketService } from '../../services/ticket';
import { Ticket } from '../../models/ticket';

@Component({
  selector: 'app-ticket-create',
  imports: [FormsModule],
  templateUrl: './ticket-create.html',
  styleUrl: './ticket-create.css',
})
export class TicketCreate {

  ticket: Ticket = {
    id: 0,
    customerEmail: '',
    subject: '',
    message: '',
    status: 'New',
    priority: 1,
    createdAt: new Date().toISOString()
  };

  constructor(
    private ticketService: TicketService,
    private router: Router
  ) {}

  createTicket(): void {
    this.ticketService.createTicket(this.ticket).subscribe({
      next: () => {
        this.router.navigate(['/']);
      },
      error: (error) => {
        console.error('Error creating ticket', error);
      }
    });
  }
}