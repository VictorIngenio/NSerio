import { AfterViewInit, Component, Input, OnInit, ViewChild } from '@angular/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { OrdenesDto } from '../../models/ordenes.model';
import { OrdersService } from '../../services/orders.service';
import { MatSort, MatSortModule } from '@angular/material/sort';

@Component({
  selector: 'app-orders',
  standalone: true,
  imports: [
    MatTableModule, MatFormFieldModule, MatPaginatorModule, MatSortModule
  ],
  templateUrl: './orders.component.html',
  styleUrl: './orders.component.css'
})
export class OrdersComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = [
    'Order ID', 
    'Required Date', 
    'Shipped Date',
    'Ship Name',
    'Ship Address',
    'Ship City'
  ];

  dataSource!: MatTableDataSource<OrdenesDto>;

  @Input() customerId!: number;
  @Input() customerName!: string;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private ordersService: OrdersService) {
    
  }
  
  ngAfterViewInit(): void {
    this.dataSource.sort = this.sort;
  }

  ngOnInit(): void {
    this.traerOrdenes(this.customerId);
  }

  traerOrdenes(id: number): void {
    this.dataSource = new MatTableDataSource<OrdenesDto>();
    this.ordersService.traerOrdenesPorIdCliente(id)
    .subscribe(resp => {
      this.dataSource = new MatTableDataSource<OrdenesDto>(resp);
      this.dataSource.paginator = this.paginator;
    });
  }
}
