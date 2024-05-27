import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-inspection',
  templateUrl: './inspection.component.html',
  styleUrl: './inspection.component.scss'
})
export class InspectionComponent implements OnInit {
  ngOnInit(): void {
    console.log('inspection',this.vehicleId)

  }
  @Input() vehicleId!: string;
}
