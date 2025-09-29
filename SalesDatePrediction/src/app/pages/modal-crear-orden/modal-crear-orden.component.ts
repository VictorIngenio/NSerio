import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef, MatDialogContent, MatDialogActions } from '@angular/material/dialog';
import { CrearOrdenComponent } from "../crear-orden/crear-orden.component";

@Component({
  selector: 'app-modal-crear-orden',
  standalone: true,
  imports: [MatDialogContent, MatDialogActions, CrearOrdenComponent],
  templateUrl: './modal-crear-orden.component.html',
  styleUrl: './modal-crear-orden.component.css'
})
export class ModalCrearOrdenComponent {
  constructor(@Inject(MAT_DIALOG_DATA) public data: {id: number, nombre: string},
              public dialogRef: MatDialogRef<ModalCrearOrdenComponent>) {
    
  }

  cerrar(): void {
    this.dialogRef.close();
  }
}
