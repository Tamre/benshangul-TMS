import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from "../../../../shared/shared.module";
import { VehicleData } from 'src/app/model/vehicle';

@Component({
    selector: 'app-vehicle-detail',
    standalone: true,
    templateUrl: './vehicle-detail.component.html',
    styleUrl: './vehicle-detail.component.scss',
    imports: [CommonModule, SharedModule]
})


export class VehicleDetailComponent implements OnInit{
    @Input() vehicleDetail!: VehicleData ;
    constructor(){

    }
    
    ngOnInit(): void {
        throw new Error('Method not implemented.');
    }

}
