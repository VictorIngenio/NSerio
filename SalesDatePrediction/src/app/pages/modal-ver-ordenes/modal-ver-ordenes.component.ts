import { Component, Inject } from '@angular/core';
import { MatDialogContent, MatDialogActions, MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { OrdersComponent } from "../orders/orders.component";

@Component({
  selector: 'app-modal-ver-ordenes',
  standalone: true,
  imports: [MatDialogContent, MatDialogActions, OrdersComponent],
  templateUrl: './modal-ver-ordenes.component.html',
  styleUrl: './modal-ver-ordenes.component.css'
})
export class ModalVerOrdenesComponent {
  constructor(@Inject(MAT_DIALOG_DATA) public data: {id: number, nombre: string},
              public dialogRef: MatDialogRef<ModalVerOrdenesComponent>) {
    
  }

  cerrar(): void {
    this.dialogRef.close();
  }
}
