import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';

import { TicketService } from '../../services/ticket';
import { Ticket } from '../../models/ticket';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-ticket-edit',
  imports: [FormsModule, CommonModule, RouterLink],
  templateUrl: './ticket-edit.html',
  styleUrl: './ticket-edit.css',
})
export class TicketEdit implements OnInit {
  ticket: Ticket = {
    id: 0,
    customerEmail: '',
    subject: '',
    message: '',
    status: 'New',
    priority: 1,
    createdAt: ''
  };

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private ticketService: TicketService,
    private cdr: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));

    console.log('Edit ticket id:', id);

    this.ticketService.getTicketById(id).subscribe({
      next: (data) => {
        console.log('Loaded ticket:', data);
        this.ticket = {
          id: data.id,
          customerEmail: data.customerEmail,
          subject: data.subject,
          message: data.message,
          status: data.status,
          priority: data.priority,
          createdAt: data.createdAt
        };
          this.cdr.detectChanges();
      },
      error: (error) => {
        console.error('Error loading ticket', error);
      }
    });
  }

  updateTicket(): void {
    const updateRequest = {
      ...this.ticket,
      status: this.mapStatusToNumber(this.ticket.status),
      priority: this.mapPriorityToNumber(this.ticket.priority)
    };

    this.ticketService.updateTicket(this.ticket.id, updateRequest).subscribe({
      next: () => {
        this.router.navigate(['/']);
      },
      error: (error) => {
        console.error('Error updating ticket', error);
      }
    });
  }
  cancel(): void {
  this.router.navigate(['/']);
  }
  
  private mapStatusToNumber(status: string | number): number {
    if (typeof status === 'number') {
      return status;
    }

    switch (status) {
      case 'New':
        return 0;
      case 'InProgress':
        return 1;
      case 'Resolved':
        return 2;
      case 'Closed':
        return 3;
      default:
        return 0;
    }
  }

  private mapPriorityToNumber(priority: string | number): number {
    if (typeof priority === 'number') {
      return priority;
    }

    switch (priority) {
      case 'Low':
        return 0;
      case 'Medium':
        return 1;
      case 'High':
        return 2;
      case 'Critical':
        return 3;
      default:
        return 1;
    }
  }
}