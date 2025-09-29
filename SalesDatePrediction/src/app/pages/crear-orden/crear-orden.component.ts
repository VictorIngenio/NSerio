import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatFormFieldModule } from "@angular/material/form-field";
import { EmployeesService } from '../../services/employees.service';
import { EmployeeDto } from '../../models/employees.model';
import { ShipperDto } from '../../models/shippers.model';
import { ShippersService } from '../../services/shippers.service';
import { MatOptionModule } from "@angular/material/core";
import { MatDatepickerModule } from '@angular/material/datepicker';
import { ProductsService } from '../../services/products.service';
import { ProductDto } from '../../models/products.model';
import { InsertarOrdenDto } from '../../models/insertarOrden.model';
import { provideNativeDateAdapter } from '@angular/material/core';
import { CommonModule } from '@angular/common';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from "@angular/material/select";
import { OrdersService } from '../../services/orders.service';

@Component({
  selector: 'app-crear-orden',
  standalone: true,
  providers: [
    provideNativeDateAdapter()
  ],
  imports: [
    MatFormFieldModule, ReactiveFormsModule, MatOptionModule, MatDatepickerModule, CommonModule,
    MatInputModule, MatSelectModule
],
  templateUrl: './crear-orden.component.html',
  styleUrl: './crear-orden.component.css'
})
export class CrearOrdenComponent implements OnInit{
  formulario!: FormGroup;
  empleados: EmployeeDto[] = [];
  transportistas: ShipperDto[] = [];
  productos: ProductDto[] = [];
  orden: InsertarOrdenDto = new InsertarOrdenDto();

  @Input() customerId!: number;
  @Input() customerName!: string;

  constructor(private fb: FormBuilder,
              private employeesService: EmployeesService,
              private shippersService: ShippersService,
              private produtsService: ProductsService,
              private ordersService: OrdersService) {
    this.crearFormulario();
  }

  ngOnInit(): void {
    this.traerEmpleados();
    this.traerTransportistas();
    this.traerProductos();
  }

  crearFormulario(): void {
    this.formulario = this.fb.group({
      EmpId: ['', Validators.required],
      OrderDate: ['', Validators.required],
      RequiredDate: ['', Validators.required],
      ShippedDate: ['', Validators.required],
      ShipperId: ['', Validators.required],
      Freight: ['', Validators.required],
      ShipName: ['', Validators.required],
      ShipAddress: ['', Validators.required],
      ShipCity: ['', Validators.required],
      ShipCountry: ['', Validators.required],
      ProductId: ['', Validators.required],
      UnitPrice: ['', Validators.required],
      Qty: ['', Validators.required],
      Discount: ['', Validators.required]
    });
  }

  traerEmpleados(): void {
    this.employeesService.traerEmpleados()
    .subscribe(resp => {
      this.empleados = resp;
    });
  }

  traerTransportistas(): void {
    this.shippersService.traerTransportistas()
    .subscribe(resp => {
      this.transportistas = resp;
    });
  }

  traerProductos(): void {
    this.produtsService.traerProductos()
    .subscribe(resp => {
      this.productos = resp;
    });
  }

  guardar(): void {
    this.orden.custid = this.customerId;
    this.orden.empid = this.formulario.controls['EmpId'].value;
    this.orden.orderdate = this.formulario.controls['OrderDate'].value;
    this.orden.requireddate = this.formulario.controls['RequiredDate'].value;
    this.orden.shippeddate = this.formulario.controls['ShippedDate'].value;
    this.orden.shipperid = this.formulario.controls['ShipperId'].value;
    this.orden.freight = this.formulario.controls['Freight'].value;
    this.orden.shipname = this.formulario.controls['ShipName'].value;
    this.orden.shipaddress = this.formulario.controls['ShipAddress'].value;
    this.orden.shipcity = this.formulario.controls['ShipCity'].value;
    this.orden.shipcountry = this.formulario.controls['ShipCountry'].value;
    this.orden.productid = this.formulario.controls['ProductId'].value;
    this.orden.unitprice = this.formulario.controls['UnitPrice'].value;
    this.orden.qty = this.formulario.controls['Qty'].value;
    this.orden.discount = this.formulario.controls['Discount'].value;

    this.ordersService.insertarOrden(this.orden)
    .subscribe(resp => {
      alert("Orden creada con exito");
      this.formulario.reset();
    });
  }
}
