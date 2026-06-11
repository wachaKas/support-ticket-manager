import { Routes } from '@angular/router';
import { TicketList } from './pages/ticket-list/ticket-list';
import { TicketCreate } from './pages/ticket-create/ticket-create';
import { Login } from './pages/login/login';
import { TicketEdit } from './pages/ticket-edit/ticket-edit';

export const routes: Routes = [
  { path: 'login', component: Login },
  { path: '', component: TicketList },
  { path: 'create', component: TicketCreate },
  { path: 'edit/:id', component: TicketEdit } 
];