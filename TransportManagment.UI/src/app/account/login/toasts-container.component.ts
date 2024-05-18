import { Component, TemplateRef } from '@angular/core';

import { ToastService } from './toast-service';


@Component({
  selector: 'app-toasts',
  styleUrls: ["./login.component.scss"],  
  template: `
   @for(toast of toastService.toasts;track $index){
    <ngb-toast
  [class]="toast.classname"
  [autohide]="true"
  [delay]="toast.delay || 3000"
  (hidden)="toastService.remove(toast)"
  class="custom-toast"
>
  <div class="toast-content">
    <div class="toast-icon">
      <i *ngIf="toast.classname === 'success'" class="icon success"></i>
      <i *ngIf="toast.classname === 'error'" class="icon error"></i>
      <i *ngIf="toast.classname === 'warning'" class="icon warning"></i>
      <i *ngIf="toast.classname === 'info'" class="icon info"></i>
    </div>
    <div class="toast-message">
      <ng-template [ngIf]="isTemplate(toast)" [ngIfElse]="text">
        <ng-template [ngTemplateOutlet]="toast.textOrTpl"></ng-template>
      </ng-template>
      <ng-template #text>{{ toast.textOrTpl }}</ng-template>
    </div>
    <button type="button" class="close-button" aria-label="Close" (click)="toastService.remove(toast)">
      &times;
    </button>
  </div>
</ngb-toast>



   }
  `,
  host: { 'class': 'toast-container position-fixed top-0 end-0 p-3', 'style': 'z-index: 1200' }
})
export class ToastsContainer {
  constructor(public toastService: ToastService) { }

  isTemplate(toast: { textOrTpl: any; }) { return toast.textOrTpl instanceof TemplateRef; }
}
