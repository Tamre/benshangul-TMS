import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from "../../../../shared/shared.module";
import {  VehicleDetailDto } from 'src/app/model/vehicle';

@Component({
    selector: 'app-vehicle-detail',
    templateUrl: './vehicle-detail.component.html',
    styleUrl: './vehicle-detail.component.scss',
})


export class VehicleDetailComponent implements OnInit{
    @Input() vehicleDetail!: VehicleDetailDto ;
    constructor(){

    }
    
    ngOnInit(): void {
     
    }

}
