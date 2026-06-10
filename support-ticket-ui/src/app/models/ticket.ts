export interface Ticket {
  id: number;
  customerEmail: string;
  subject: string;
  message: string;
  status: string;
  priority: number;
  createdAt: string;
}