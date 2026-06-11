import { Component } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { CommonModule, DatePipe } from '@angular/common';
import { Observable } from 'rxjs';

import { TicketService, PagedResult } from '../../services/ticket';
import { Ticket } from '../../models/ticket';
import { AuthService } from '../../services/auth';

@Component({
  selector: 'app-ticket-list',
  imports: [RouterLink, CommonModule, DatePipe],
  templateUrl: './ticket-list.html',
  styleUrl: './ticket-list.css',
})
export class TicketList {
  ticketsResponse$: Observable<PagedResult<Ticket>>;

  constructor(
    private ticketService: TicketService,
    private authService: AuthService,
    private router: Router
  ) {
    this.ticketsResponse$ = this.ticketService.getTickets();
  }

  logout(): void {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}