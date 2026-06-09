import { Routes } from '@angular/router';
import { TicketList } from './pages/ticket-list/ticket-list';
import { TicketCreate } from './pages/ticket-create/ticket-create';

export const routes: Routes = [
  { path: '', component: TicketList },
  { path: 'create', component: TicketCreate }
];