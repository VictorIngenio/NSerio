import { AfterViewInit, Component, inject, OnInit, ViewChild } from '@angular/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { OrdersService } from '../../services/orders.service';
import { DatePredictionDto } from '../../models/datePrediction.model';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatInputModule } from '@angular/material/input';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ModalVerOrdenesComponent } from '../modal-ver-ordenes/modal-ver-ordenes.component';
import { ModalCrearOrdenComponent } from '../modal-crear-orden/modal-crear-orden.component';

@Component({
  selector: 'app-date-prediction',
  standalone: true,
  imports: [
    MatFormFieldModule, MatIconModule, MatTableModule, MatPaginatorModule, MatSortModule,
    MatInputModule, ReactiveFormsModule
  ],
  templateUrl: './date-prediction.component.html',
  styleUrl: './date-prediction.component.css'
})
export class DatePredictionComponent implements AfterViewInit, OnInit {
  displayedColumns: string[] = [
    'Customer Name', 
    'Last Order Date', 
    'Next Predicted Order',
    'View Orders',
    'New Order'
  ];
  dataSource!: MatTableDataSource<DatePredictionDto>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  busqueda = new FormControl('');
  readonly dialog = inject(MatDialog);

  constructor(private ordersService: OrdersService) {
    
  }
  
  ngOnInit(): void {
    this.listarPredicciones();
  }

  ngAfterViewInit(): void {
    // this.dataSource.sort = this.sort;
  }

  listarPredicciones(): void {
    this.ordersService.traerPredicciones()
    .subscribe(resp => {
      this.dataSource = new MatTableDataSource<DatePredictionDto>(resp);
      this.dataSource.sort = this.sort;
      this.dataSource.paginator = this.paginator;
    });
  }

  buscarCliente(): void {
    if (this.busqueda.value != null && this.busqueda.value != '') {
      this.dataSource = new MatTableDataSource<DatePredictionDto>();
      this.ordersService.traerPrediccionesPorNombreCliente(this.busqueda.value)
      .subscribe(resp => {
        this.dataSource = new MatTableDataSource<DatePredictionDto>(resp);
        this.dataSource.paginator = this.paginator;
      });
    }

    if (this.busqueda.value == '') {
      this.dataSource = new MatTableDataSource<DatePredictionDto>();
      this.listarPredicciones();
    }
  }

  verOrdenes(id: number, cliente: string): void {
    this.dialog.open(ModalVerOrdenesComponent, {
      data: { id: id, nombre: cliente },
      height: '600px',
      width: '900px',
    });
  }

  crearOrden(id: number, cliente: string): void {
    this.dialog.open(ModalCrearOrdenComponent, {
      data: { id: id, nombre: cliente },
      height: '600px',
      width: '900px',
    });
  }
}
